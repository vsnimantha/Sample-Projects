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
using UniversalKeyboard.UI.BubbleControls;

namespace UniversalKeyboard.UI
{
    /// <summary>
    /// Interaction logic for HorizontalKeyboardUserControl.xaml
    /// </summary>
    public partial class HorizontalEmailKeyboardUserControl : UserControl
    {
        IPressedKey IPressedKey;
        System.Timers.Timer LongPressTimer;
        double longPressCounter;
        public HorizontalEmailKeyboardUserControl(IPressedKey IPressedKey)
        {
            InitializeComponent();

            Loaded += HorizontalKeyboardUserControl_Loaded;

            this.IPressedKey = IPressedKey;
            RegisterButtonClickEvent();

            LongPressTimer = new System.Timers.Timer();
            LongPressTimer.Interval = 200;
            LongPressTimer.Elapsed += LongPressTimer_Elapsed;
        }

        void LongPressTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
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
        void Button_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            longPressCounter = 0;
            LongPressTimer.Stop();
        }

        void Button_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LongPressTimer.Start();
        }

        void Button_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            longPressCounter = 0;
            LongPressTimer.Stop();
        }

        void Button_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            LongPressTimer.Start();
        }


        void HorizontalKeyboardUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int screenHeight = (int)SystemParameters.PrimaryScreenWidth;

            int fontSize = (int)(screenHeight * 0.014);


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

            ButtonLetterFullStop.Button.Click += ButtonLetterFullStop_Click;
            ButtonLetterUnderscore.Button.Click += ButtonLetterUnderScore_Click;
            ButtonLetterDash.Button.Click += ButtonLetterDash_Click;
            ButtonLetterAt.Button.Click += ButtonLetterAt_Click;
            ButtonLetterForwardSlash.Button.Click += ButtonLetterForwardSlash_Click;

            ButtonSpace.Button.Click += ButtonSpace_Click;
            ButtonDotCom.Button.Click += ButtonDotCom_Click;
            ButtonDotNet.Button.Click += ButtonDotNet_Click;
            ButtonDotEdu.Button.Click += ButtonDotEdu_Click;
            ButtonDotLk.Button.Click += ButtonDotLk_Click;
            ButtonBackSpace.Button.Click += ButtonBackSpace_Click;

            ButtonBackSpace.Button.PreviewMouseLeftButtonDown += Button_PreviewMouseLeftButtonDown;
            ButtonBackSpace.Button.PreviewMouseLeftButtonUp += Button_PreviewMouseLeftButtonUp;
            ButtonBackSpace.Button.PreviewTouchDown += Button_PreviewTouchDown;
            ButtonBackSpace.Button.PreviewTouchUp += Button_PreviewTouchUp;

            ButtonSubmit.Button.Click+=ButtonSubmit_Click;
        }

        #region ClickEvents
        private void ButtonSubmit_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.Submit();
        }

        private void ButtonBackSpace_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.BackSpace();
        }

        private void ButtonDotLk_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(".lk");
        }

        private void ButtonDotEdu_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(".edu");
        }

        private void ButtonDotNet_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(".net");
        }

        private void ButtonDotCom_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(".com");
        }

        private void ButtonSpace_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(" ");
        }

        private void ButtonLetterForwardSlash_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("/");
        }

        private void ButtonLetterAt_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("@");
        }

        private void ButtonLetterDash_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("-");
        }

        private void ButtonLetterUnderScore_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("_");
        }

        private void ButtonLetterFullStop_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey(".");
        }

        private void ButtonLetterZ_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("z");
        }

        private void ButtonLetterY_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("y");
        }

        private void ButtonLetterX_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("x");
        }

        private void ButtonLetterW_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("w");
        }

        private void ButtonLetterV_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("v"); ;
        }

        private void ButtonLetterU_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("u");
        }

        private void ButtonLetterT_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("t");
        }

        private void ButtonLetterS_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("s");
        }

        private void ButtonLetterR_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("r");
        }

        private void ButtonLetterQ_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("q");
        }

        private void ButtonLetterP_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("p");
        }

        private void ButtonLetterO_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("o");
        }

        private void ButtonLetterN_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("n");
        }

        private void ButtonLetterM_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("m");
        }

        private void ButtonLetterL_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("l");
        }

        private void ButtonLetterK_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("k");
        }

        private void ButtonLetterJ_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("j");
        }

        private void ButtonLetterI_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("i");
        }

        private void ButtonLetterH_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("h");
        }

        private void ButtonLetterG_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("g");
        }

        private void ButtonLetterF_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("f");
        }

        private void ButtonLetterE_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("e");
        }

        private void ButtonLetterD_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("d");
        }

        private void ButtonLetterC_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("c");
        }

        private void ButtonLetterB_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("b");
        }

        private void ButtonLetterA_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("a");
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

        #endregion

        private void SetButtonDetails(double fontSize, Brush FontColor)
        {
            try
            {
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

                ButtonLetterA.SetButtonDetails("a", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterB.SetButtonDetails("b", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterC.SetButtonDetails("c", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterD.SetButtonDetails("d", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterE.SetButtonDetails("e", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterF.SetButtonDetails("f", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterG.SetButtonDetails("g", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterH.SetButtonDetails("h", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterI.SetButtonDetails("i", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterJ.SetButtonDetails("j", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterK.SetButtonDetails("k", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterL.SetButtonDetails("l", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterM.SetButtonDetails("m", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterN.SetButtonDetails("n", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterO.SetButtonDetails("o", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterP.SetButtonDetails("p", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterQ.SetButtonDetails("q", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterR.SetButtonDetails("r", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterS.SetButtonDetails("s", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterT.SetButtonDetails("t", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterU.SetButtonDetails("u", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterV.SetButtonDetails("v", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterW.SetButtonDetails("w", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterX.SetButtonDetails("x", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterY.SetButtonDetails("y", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterZ.SetButtonDetails("z", FontWeights.Bold, fontSize, FontColor);

                ButtonLetterFullStop.SetButtonDetails(".", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterUnderscore.SetButtonDetails("_", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterDash.SetButtonDetails("-", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterAt.SetButtonDetails("@", FontWeights.Bold, fontSize, FontColor);
                ButtonLetterForwardSlash.SetButtonDetails("/", FontWeights.Bold, fontSize, FontColor);

                ButtonSpace.SetButtonDetails("Space", FontWeights.Bold, fontSize, FontColor);
                ButtonDotCom.SetButtonDetails(".com", FontWeights.Bold, fontSize, FontColor);
                ButtonDotNet.SetButtonDetails(".net", FontWeights.Bold, fontSize, FontColor);
                ButtonDotEdu.SetButtonDetails(".edu", FontWeights.Bold, fontSize, FontColor);
                ButtonDotLk.SetButtonDetails(".lk", FontWeights.Bold, fontSize, FontColor);
                ButtonBackSpace.SetButtonDetails("delete", FontWeights.Bold, fontSize, FontColor);

                ButtonSubmit.SetButtonDetails("Submit", FontWeights.Bold, fontSize, FontColor);
            }
            catch (Exception ex)
            {
 
            }
        }
    }
}
