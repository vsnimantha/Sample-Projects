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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UniversalKeyboard.UI.BubbleControls
{
    /// <summary>
    /// Interaction logic for KeyboardButtonUserControl.xaml
    /// </summary>
    public partial class KeyboardButtonUserControl : UserControl
    {
        public KeyboardButtonUserControl()
        {
            InitializeComponent();

            Loaded += KeyboardButtonUserControl_Loaded;
            Button.Click += Button_Click;
        }

        void KeyboardButtonUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        void Button_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animationButtonClick = new DoubleAnimation(1, .4, TimeSpan.FromSeconds(.125));
            animationButtonClick.AutoReverse = true;
            Button.BeginAnimation(Button.OpacityProperty, animationButtonClick);
        }

        public void SetButtonDetails(string buttonContent, FontWeight fontWeight, double fontSize, Brush fontColor)
        {
            try
            {
                ControlTemplate ButtonTemplate = Button.Template;
                Label ButtonLabel = (Label)ButtonTemplate.FindName("LabelButtonContent", Button);

                ButtonLabel.Content = buttonContent;
                ButtonLabel.FontWeight = fontWeight;
                ButtonLabel.Foreground = fontColor;
                ButtonLabel.FontSize = fontSize;
            }
            catch (Exception ex)
            {

            }

        }

        public void SetButtonTitle(string title)
        {
            try
            {
                ControlTemplate ButtonTemplate = Button.Template;
                Label ButtonLabel = (Label)ButtonTemplate.FindName("LabelButtonContent", Button);

                ButtonLabel.Content = title;
            }
            catch (Exception ex)
            {

            }
        }
    }
}
