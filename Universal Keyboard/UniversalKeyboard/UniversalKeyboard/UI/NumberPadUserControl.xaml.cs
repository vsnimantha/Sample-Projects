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
    /// Interaction logic for NumberPadUserControl.xaml
    /// </summary>
    public partial class NumberPadUserControl : UserControl
    {
        IPressedKey IPressedKey;
        System.Timers.Timer LongPressTimer;
        double longPressCounter;

        public NumberPadUserControl(IPressedKey IPressedKey)
        {

            this.IPressedKey = IPressedKey;
            Loaded += UniversalKeyboardUserControl_Loaded;

            InitializeComponent();

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

        private void UniversalKeyboardUserControl_Loaded(object sender, RoutedEventArgs e)
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

            ButtonSymbolPlus.Button.Click += ButtonSymbolPlus_Click;
            ButtonSymbolHash.Button.Click += ButtonSymbolHash_Click;

            ButtonDelete.Button.Click += ButtonDelete_Click;
            ButtonDelete.Button.PreviewMouseLeftButtonDown += ButtonDelete_PreviewMouseLeftButtonDown;
            ButtonDelete.Button.PreviewMouseLeftButtonUp += ButtonDelete_PreviewMouseLeftButtonUp;
            ButtonDelete.Button.PreviewTouchDown += ButtonDelete_PreviewTouchDown;
            ButtonDelete.Button.PreviewTouchUp += ButtonDelete_PreviewTouchUp;

            ButtonDone.Button.Click += ButtonDone_Click;
        }


        #region ClickEvents

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.BackSpace();
        }

        private void ButtonSymbolHash_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("#");
        }

        private void ButtonSymbolPlus_Click(object sender, RoutedEventArgs e)
        {
            IPressedKey.PressedKey("+");
        }
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
                ButtonSymbolHash.SetButtonDetails("#", FontWeights.Bold, fontSize, FontColor);
                ButtonSymbolPlus.SetButtonDetails("+", FontWeights.Bold, fontSize, FontColor);


                ButtonDelete.SetButtonDetails("delete", FontWeights.Bold, fontSize, FontColor);

                ButtonDone.SetButtonDetails("done", FontWeights.Bold, fontSize, FontColor);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
