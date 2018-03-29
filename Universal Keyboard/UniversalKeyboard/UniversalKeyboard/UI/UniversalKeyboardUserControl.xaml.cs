using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniversalKeyboard.UI
{
    /// <summary>
    /// Interaction logic for UniversalKeyboardUserControl.xaml
    /// </summary>
    public partial class UniversalKeyboardUserControl : UserControl
    {
        IPressedKey IPressedKey;
        System.Timers.Timer LongPressTimer;
        double longPressCounter;
        public UniversalKeyboardUserControl(IPressedKey IPressedKey)
        {
            InitializeComponent();

            this.IPressedKey = IPressedKey;
            Loaded += UniversalKeyboardUserControl_Loaded;

            LongPressTimer = new System.Timers.Timer();
            LongPressTimer.Interval = 200;
            LongPressTimer.Elapsed += LongPressTimer_Elapsed;

            RegisterButtonClickEvent();

        }

        private void LongPressTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (longPressCounter >= 5)
            {
                longPressCounter = 0;
                LongPressTimer.Stop();
                IPressedKey.BackSpaceLongPressed();
            }
            else
            {
                longPressCounter++;
            }
        }

        private void ButtonDelete_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            longPressCounter = 0;
            LongPressTimer.Stop();
        }

        private void ButtonDelete_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongPressTimer.Start();
        }

        private void ButtonDelete_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            longPressCounter = 0;
            LongPressTimer.Stop();
        }

        private void ButtonDelete_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LongPressTimer.Start();
        }



        void UniversalKeyboardUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int screenHeight = (int)SystemParameters.PrimaryScreenWidth;

            int fontSize = (int)(screenHeight * 0.015);


            Brush FontColor = Brushes.White;

            SetButtonDetails(fontSize, FontColor);

        }

        private void RegisterButtonClickEvent()
        {

            ButtonNumber1.Button.Click += ButtonNumber1_Click;
            ButtonNumber2.Button.Click += ButtonNumber2_Click;
            ButtonNumber3.Button.Click += ButtonNumber3_Click;
            ButtonNumber4.Button.Click += ButtonNumber4_Click;
            ButtonNumber5.Button.Click += ButtonNumber5_Click;
            ButtonNumber6.Button.Click += ButtonNumber6_Click;
            ButtonNumber7.Button.Click += ButtonNumber7_Click;
            ButtonNumber8.Button.Click += ButtonNumber8_Click;
            ButtonNumber9.Button.Click += ButtonNumber9_Click;
            ButtonNumber0.Button.Click += ButtonNumber0_Click;

            ButtonLetterA.Button.Click += ButtonLetterA_Click;
            ButtonLetterB.Button.Click += ButtonLetterB_Click;
            ButtonLetterC.Button.Click += ButtonLetterC_Click;
            ButtonLetterD.Button.Click += ButtonLetterD_Click;
            ButtonLetterE.Button.Click += ButtonLetterE_Click;
            ButtonLetterF.Button.Click += ButtonLetterF_Click;
            ButtonLetterG.Button.Click += ButtonLetterG_Click;
            ButtonLetterH.Button.Click += ButtonLetterH_Click;
            ButtonLetterI.Button.Click += ButtonLetterI_Click;
            ButtonLetterJ.Button.Click += ButtonLetterJ_Click;
            ButtonLetterK.Button.Click += ButtonLetterK_Click;
            ButtonLetterL.Button.Click += ButtonLetterL_Click;
            ButtonLetterM.Button.Click += ButtonLetterM_Click;
            ButtonLetterN.Button.Click += ButtonLetterN_Click;
            ButtonLetterO.Button.Click += ButtonLetterO_Click;
            ButtonLetterP.Button.Click += ButtonLetterP_Click;
            ButtonLetterQ.Button.Click += ButtonLetterQ_Click;
            ButtonLetterR.Button.Click += ButtonLetterR_Click;
            ButtonLetterS.Button.Click += ButtonLetterS_Click;
            ButtonLetterT.Button.Click += ButtonLetterT_Click;
            ButtonLetterU.Button.Click += ButtonLetterU_Click;
            ButtonLetterV.Button.Click += ButtonLetterV_Click;
            ButtonLetterW.Button.Click += ButtonLetterW_Click;
            ButtonLetterX.Button.Click += ButtonLetterX_Click;
            ButtonLetterY.Button.Click += ButtonLetterY_Click;
            ButtonLetterZ.Button.Click += ButtonLetterZ_Click;


            ButtonLettera.Button.Click += ButtonLettera_Click;
            ButtonLetterb.Button.Click += ButtonLetterb_Click;
            ButtonLetterc.Button.Click += ButtonLetterc_Click;
            ButtonLetterd.Button.Click += ButtonLetterd_Click;
            ButtonLettere.Button.Click += ButtonLettere_Click;
            ButtonLetterf.Button.Click += ButtonLetterf_Click;
            ButtonLetterg.Button.Click += ButtonLetterg_Click;
            ButtonLetterh.Button.Click += ButtonLetterh_Click;
            ButtonLetteri.Button.Click += ButtonLetteri_Click;
            ButtonLetterj.Button.Click += ButtonLetterj_Click;
            ButtonLetterk.Button.Click += ButtonLetterk_Click;
            ButtonLetterl.Button.Click += ButtonLetterl_Click;
            ButtonLetterm.Button.Click += ButtonLetterm_Click;
            ButtonLettern.Button.Click += ButtonLettern_Click;
            ButtonLettero.Button.Click += ButtonLettero_Click;
            ButtonLetterp.Button.Click += ButtonLetterp_Click;
            ButtonLetterq.Button.Click += ButtonLetterq_Click;
            ButtonLetterr.Button.Click += ButtonLetterr_Click;
            ButtonLetters.Button.Click += ButtonLetters_Click;
            ButtonLettert.Button.Click += ButtonLettert_Click;
            ButtonLetteru.Button.Click += ButtonLetteru_Click;
            ButtonLetterv.Button.Click += ButtonLetterv_Click;
            ButtonLetterw.Button.Click += ButtonLetterw_Click;
            ButtonLetterx.Button.Click += ButtonLetterx_Click;
            ButtonLettery.Button.Click += ButtonLettery_Click;
            ButtonLetterz.Button.Click += ButtonLetterz_Click;

            //ButtonLetterFullStop.Button.Click += ButtonLetterFullStop_Click;
            //ButtonLetterUnderscore.Button.Click += ButtonLetterUnderScore_Click;
            //ButtonLetterDash.Button.Click += ButtonLetterDash_Click;
            //ButtonLetterAt.Button.Click += ButtonLetterAt_Click;
            //ButtonLetterForwardSlash.Button.Click += ButtonLetterForwardSlash_Click;

            ButtonSymboApostrophe.Button.Click+=ButtonApostrophe_Click;
            ButtonSymbolAnd.Button.Click+=ButtonSymbolAnd_Click;
            ButtonSymbolAt.Button.Click += ButtonSymbolAt_Click;
            ButtonSymbolComma.Button.Click+=ButtonSymbolComma_Click;
            ButtonSymbolDash.Button.Click+=ButtonSymbolDash_Click;
            ButtonSymbolDot.Button.Click+=ButtonSymbolDot_Click;
            ButtonSymbolFWSlash.Button.Click+=ButtonSymbolFWSlash_Click;
            ButtonSymbolPlus.Button.Click+=ButtonSymbolPlus_Click;
            ButtonSymbolUnderscope.Button.Click+=ButtonSymbolUnderscope_Click;

            ButtonSpace.Button.Click += ButtonSpace_Click;

            ButtonDelete.Button.Click+=ButtonDelete_Click;
            ButtonDelete.Button.PreviewMouseLeftButtonDown += ButtonDelete_PreviewMouseLeftButtonDown;
            ButtonDelete.Button.PreviewMouseLeftButtonUp += ButtonDelete_PreviewMouseLeftButtonUp;
            ButtonDelete.Button.PreviewTouchDown += ButtonDelete_PreviewTouchDown;
            ButtonDelete.Button.PreviewTouchUp += ButtonDelete_PreviewTouchUp;

            ButtonDone.Button.Click +=ButtonDone_Click;
        }

      

        #region Click Events
        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.Submit();
        }
        private void ButtonNumber0_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("0");
        }

        private void ButtonNumber9_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("9");
        }

        private void ButtonNumber8_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("8");
        }

        private void ButtonNumber7_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("7");
        }

        private void ButtonNumber6_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("6");
        }

        private void ButtonNumber5_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("5");
        }

        private void ButtonNumber4_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("4");
        }
        private void ButtonNumber3_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("3");
        }
        private void ButtonNumber2_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("2");
        }
        private void ButtonNumber1_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("1");
        }

        private void ButtonLetterz_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("z");
        }

        private void ButtonLettery_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("y");
        }

        private void ButtonLetterx_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("x");
        }

        private void ButtonLetterw_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("w");
        }

        private void ButtonLetterv_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("v");
        }

        private void ButtonLetteru_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("u");
        }

        private void ButtonLettert_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("t");
        }

        private void ButtonLetters_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("s");
        }

        private void ButtonLetterr_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("r");
        }

        private void ButtonLetterq_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("q");
        }

        private void ButtonLetterp_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("p");
        }

        private void ButtonLettero_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("o");
        }

        private void ButtonLettern_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("n");
        }

        private void ButtonLetterm_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("m");
        }

        private void ButtonLetterl_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("l");
        }

        private void ButtonLetterk_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("k");
        }

        private void ButtonLetterj_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("j");
        }

        private void ButtonLetteri_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("i");
        }

        private void ButtonLetterh_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("h");
        }

        private void ButtonLetterg_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("g");
        }

        private void ButtonLetterf_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("f");
        }

        private void ButtonLettere_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("e");
        }

        private void ButtonLetterd_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("d");
        }

        private void ButtonLetterc_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("c");
        }

        private void ButtonLetterb_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("b");
        }

        private void ButtonLettera_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("a");
        }

        private void ButtonLetterZ_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("Z");
        }

        private void ButtonLetterY_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("Y");
        }

        private void ButtonLetterX_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("X");
        }

        private void ButtonLetterW_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("W");
        }

        private void ButtonLetterV_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("V");
        }

        private void ButtonLetterU_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("U");
        }

        private void ButtonLetterT_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("T");
        }

        private void ButtonLetterS_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("S");
        }

        private void ButtonLetterR_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("R");
        }

        private void ButtonLetterQ_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("Q");
        }

        private void ButtonLetterP_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("P");
        }

        private void ButtonLetterO_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("O");
        }

        private void ButtonLetterN_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("N");
        }

        private void ButtonLetterM_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("M");
        }

        private void ButtonLetterL_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("L");
        }

        private void ButtonLetterK_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("K");
        }

        private void ButtonLetterJ_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("J");
        }

        private void ButtonLetterI_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("I");
        }

        private void ButtonLetterH_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("H");
        }

        private void ButtonLetterG_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("G");
        }

        private void ButtonLetterF_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("F");
        }

        private void ButtonLetterE_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("E");
        }

        private void ButtonLetterD_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("D");
        }

        private void ButtonLetterC_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("C");
        }

        private void ButtonLetterB_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("B");
        }

        private void ButtonLetterA_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("A");
        }

        private void ButtonSymbolUnderscope_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("_");
        }

        private void ButtonSymbolPlus_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("+");
        }

        private void ButtonSymbolFWSlash_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("/");
        }

        private void ButtonSymbolDot_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(".");
        }

        private void ButtonSymbolDash_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("-");
        }

        private void ButtonSymbolComma_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(",");
        }

        private void ButtonSymbolAt_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("@");
        }

        private void ButtonSymbolAnd_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("&");
        }

        private void ButtonApostrophe_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("'");
        }

        private void ButtonSpace_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(" ");
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.BackSpace();
        }
        #endregion

        private void SetButtonDetails(double fontSize, Brush FontColor)
        {
            try
            {


                
                //Row 1
                ButtonLetterA.SetButtonDetails("A", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterB.SetButtonDetails("B", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterC.SetButtonDetails("C", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterD.SetButtonDetails("D", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterE.SetButtonDetails("E", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterF.SetButtonDetails("F", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterG.SetButtonDetails("G", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterH.SetButtonDetails("H", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterI.SetButtonDetails("I", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterJ.SetButtonDetails("J", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterK.SetButtonDetails("K", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterL.SetButtonDetails("L", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterM.SetButtonDetails("M", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterN.SetButtonDetails("N", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterO.SetButtonDetails("O", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterP.SetButtonDetails("P", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterQ.SetButtonDetails("Q", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterR.SetButtonDetails("R", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterS.SetButtonDetails("S", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterT.SetButtonDetails("T", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterU.SetButtonDetails("U", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterV.SetButtonDetails("V", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterW.SetButtonDetails("W", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterX.SetButtonDetails("X", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterY.SetButtonDetails("Y", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterZ.SetButtonDetails("Z", FontWeights.Bold, fontSize, FontColor);

                //Row2
                ButtonLettera.SetButtonDetails("a", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterb.SetButtonDetails("b", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterc.SetButtonDetails("c", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterd.SetButtonDetails("d", FontWeights.Bold, fontSize, FontColor);
                ButtonLettere.SetButtonDetails("e", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterf.SetButtonDetails("f", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterg.SetButtonDetails("g", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterh.SetButtonDetails("h", FontWeights.Bold, fontSize, FontColor);
                ButtonLetteri.SetButtonDetails("i", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterj.SetButtonDetails("j", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterk.SetButtonDetails("k", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterl.SetButtonDetails("l", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterm.SetButtonDetails("m", FontWeights.Bold, fontSize, FontColor);
                ButtonLettern.SetButtonDetails("n", FontWeights.Bold, fontSize, FontColor);
                ButtonLettero.SetButtonDetails("o", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterp.SetButtonDetails("p", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterq.SetButtonDetails("q", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterr.SetButtonDetails("r", FontWeights.Bold, fontSize, FontColor);
                ButtonLetters.SetButtonDetails("s", FontWeights.Bold, fontSize, FontColor);
                ButtonLettert.SetButtonDetails("t", FontWeights.Bold, fontSize, FontColor);
                ButtonLetteru.SetButtonDetails("u", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterv.SetButtonDetails("v", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterw.SetButtonDetails("w", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterx.SetButtonDetails("x", FontWeights.Bold, fontSize, FontColor);
                ButtonLettery.SetButtonDetails("y", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterz.SetButtonDetails("z", FontWeights.Bold, fontSize, FontColor);

                //Row3
                ButtonNumber1.SetButtonDetails("1", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber2.SetButtonDetails("2", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber3.SetButtonDetails("3", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber4.SetButtonDetails("4", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber5.SetButtonDetails("5", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber6.SetButtonDetails("6", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber7.SetButtonDetails("7", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber8.SetButtonDetails("8", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber9.SetButtonDetails("9", FontWeights.Bold, fontSize, FontColor);
                ButtonNumber0.SetButtonDetails("0", FontWeights.Bold, fontSize, FontColor);
                ButtonSymboApostrophe.SetButtonDetails("'", FontWeights.Bold, fontSize,FontColor);
                ButtonSymbolAnd.SetButtonDetails("&", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolAt.SetButtonDetails("@", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolComma.SetButtonDetails(",", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolDash.SetButtonDetails("-", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolDot.SetButtonDetails(".", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolFWSlash.SetButtonDetails("/", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolUnderscope.SetButtonDetails("_", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolPlus.SetButtonDetails("+", FontWeights.Bold, fontSize, FontColor);

       
                ButtonSpace.SetButtonDetails("SPACE", FontWeights.Bold, fontSize*.88, FontColor);
                ButtonDelete.SetButtonDetails("DELETE", FontWeights.Bold, fontSize*.87, FontColor);

                ButtonDone.SetButtonDetails("DONE", FontWeights.Bold, fontSize*.88, FontColor);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
