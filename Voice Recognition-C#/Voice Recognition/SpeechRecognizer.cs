using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Speech.Synthesis;

namespace Voice_Recognition
{
    public partial class SpeechRecognizer : Form
    {
        SpeechRecognitionEngine RecEngine = new SpeechRecognitionEngine();
        SpeechSynthesizer Synth = new SpeechSynthesizer();
        bool isRecognitionActive = false;
        bool isSpeakingEnabled = false;
        public SpeechRecognizer()
        {
            InitializeComponent();
            this.richTextBox1.Enabled = true;
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.GotFocus += new System.EventHandler(this.RTBGotFocus);
        
        }
        /// <summary>
        /// change the richtextbox to editable false
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RTBGotFocus(object sender, EventArgs e)
        {
            System.Windows.Forms.SendKeys.Send("{tab}");
        }
        

        private void btnEnable_Click(object sender, EventArgs e)
        {
            if (!isRecognitionActive)
            {
                RecEngine.RecognizeAsync(RecognizeMode.Multiple);
                isRecognitionActive = true;
                btnDisable.Enabled = true;
                lblStatus.Text = "Active";
                lblStatus.ForeColor = Color.Green;
                btnEnable.Enabled = false;
               
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Choices Commands = new Choices();
            Commands.Add(new string[] {"hey","hello","name","hey jarvis",
                                        "hey sampath","ok google","ok",
                                        "okay","google","apple","orange",
                                        "colombo","new york","sri lanka","computer",
                                        "watch","ok sampath","hi sampath","hello sampath"});
            //{ "ok sampath", "hey sampath", "sampath", "hello", "ok" });
            GrammarBuilder GBuilder = new GrammarBuilder();
            GBuilder.Append(Commands);
            Grammar GrammarObj = new Grammar(GBuilder);

            //recEngine.BabbleTimeout = TimeSpan.FromSeconds(10);

            RecEngine.LoadGrammarAsync(GrammarObj);
            RecEngine.SetInputToDefaultAudioDevice();
            RecEngine.SpeechRecognized += recEngine_SpeechRecognized;

            RecEngine.SpeechDetected += recEngine_SpeechDetected;
            RecEngine.RecognizeCompleted += recEngine_RecognizeCompleted;
            RecEngine.SpeechHypothesized += recEngine_SpeechHypothesized;
            RecEngine.SpeechRecognitionRejected += recEngine_SpeechRecognitionRejected;

            foreach(InstalledVoice InstalledVoice in Synth.GetInstalledVoices())
            {
                VoiceInfo Info = InstalledVoice.VoiceInfo;
                cmbVoices.Items.Add(Info.Name);
            }

            VoiceInfo Vinfo = Synth.Voice;
            cmbVoices.SelectedItem = Vinfo.Name;

        }

        void recEngine_SpeechRecognitionRejected(object sender, SpeechRecognitionRejectedEventArgs e)
        {
            richTextBox1.Text += "\n  SpeechRecognitionRejected " + e.Result.Text;
            if (isSpeakingEnabled)
            {
                Synth.SpeakAsync("Rejected Speech is " + e.Result.Text);
            }
        }

        void recEngine_SpeechHypothesized(object sender, SpeechHypothesizedEventArgs e)
        {
            richTextBox1.Text += "\n  Speech Hypothesized "+ e.Result.Text;
            if (isSpeakingEnabled)
            {
                Synth.SpeakAsync("Hypothesized Speech is " + e.Result.Text);
            }
        }

        void recEngine_SpeechDetected(object sender, SpeechDetectedEventArgs e)
        {
            richTextBox1.Text += "\n  " + DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt") +" Speech Detected - ";
        }

        void recEngine_RecognizeCompleted(object sender, RecognizeCompletedEventArgs e)
        {
            richTextBox1.Text += "\n Completed ";
        }

        void recEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //e.Result.Confidence.Equals(1.0);
            if (e.Result.Confidence > 0.1)
            {
                richTextBox1.Text += " Confidence level = " + e.Result.Confidence.ToString();

                switch (e.Result.Text)
                {
                    /* case "hello":
                        // MessageBox.Show("Hello Triggered");
                         richTextBox1.Text += " hello";
                         break;
                     case "name":
                        // MessageBox.Show("name");
                         richTextBox1.Text += " name";
                         break;
                     case "hey jarvis":
                         richTextBox1.Text += " hey jarvis";
                         break;
                     case "hey sampath":
                         richTextBox1.Text += " hey sampath";
                         break;
                     case "ok google":
                         richTextBox1.Text += " ok google";
                         break;
                     case "hey":
                         richTextBox1.Text += " hey";
                         break;*/
                    default:
                        richTextBox1.Text += " ### Detected Speech = " + e.Result.Text;
                        if (isSpeakingEnabled)
                        {
                            Synth.SpeakAsync("Detected Speech is " + e.Result.Text);
                        }
                        break;
                }

                foreach (RecognizedPhrase Phrase in e.Result.Alternates)
                {
                    richTextBox1.Text += " ### Alternates = "+ Phrase.Text;
                }
            }
        }

        private void btnDisable_Click_1(object sender, EventArgs e)
        {
            RecEngine.RecognizeAsyncStop();
            btnDisable.Enabled = false;
            isRecognitionActive = false;
            lblStatus.Text = "Inactive";
            lblStatus.ForeColor = Color.Red;
            btnEnable.Enabled = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            RecEngine.RecognizeAsyncStop();
        }

        private void btnClearLog_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "-Log-";
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isSpeakingEnabled)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox1.Text != "")
                    {
                        Synth.SpeakAsync(textBox1.Text);
                        textBox1.Text = "";
                    }
                    else
                    {
                        Synth.SpeakAsync("Please enter something to talk");
                    }
                }
            }
        }

        private void cmbVoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbVoices.SelectedIndex != -1)
            {
                try
                {
                    Synth.SelectVoice(cmbVoices.SelectedItem.ToString());
                }
                catch
                {

                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                isSpeakingEnabled = true;
            }
            else
            {
                isSpeakingEnabled = false;
            }
        }
    }
}
