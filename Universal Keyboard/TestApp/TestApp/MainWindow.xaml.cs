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
using System.Windows.Threading;

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,UniversalKeyboard.UI.IPressedKey
    {
        public MainWindow(Keyboards keyboard)
        {
            InitializeComponent();

            switch (keyboard)
            {
                case Keyboards.UNIVERSAL:
                    UniversalKeyboard.UI.UniversalKeyboardUserControl uc1 = new UniversalKeyboard.UI.UniversalKeyboardUserControl(this);
                    gridKeyboard.Children.Add(uc1);
                    this.Width = 1000;
                    this.Height = 300;
                    this.Top= SystemParameters.PrimaryScreenWidth/2.2;
                    this.Left = SystemParameters.PrimaryScreenWidth/25;
                    break;
                case Keyboards.EMAIL:
                    UniversalKeyboard.UI.HorizontalEmailKeyboardUserControl uc2 = new UniversalKeyboard.UI.HorizontalEmailKeyboardUserControl(this);
                    gridKeyboard.Children.Add(uc2);
                    this.Width = 1000;
                    this.Height = 300;
                    this.Top= SystemParameters.PrimaryScreenWidth/2.2;
                    this.Left = SystemParameters.PrimaryScreenWidth/25;
                    break;
                case Keyboards.NUMBER:
                    UniversalKeyboard.UI.NumberPadUserControl uc3 = new UniversalKeyboard.UI.NumberPadUserControl(this);
                    gridKeyboard.Children.Add(uc3);
                    this.Width = 350;
                    this.Height = 350;
                    this.Top= SystemParameters.PrimaryScreenWidth/1.5;
                    this.Left = SystemParameters.PrimaryScreenWidth/3;
                    break;
                default:
                    break;
            }
        }

        public string PressedKey(string key)
        {
           txt.Focus();
           txt.Text += key;
           if (txt.Text.Length > 0)
           {
               txt.CaretIndex = txt.Text.Length;
           }
           return txt.Text;
        }

        public void BackSpace()
        {
            string s = txt.Text;

            if (s.Length > 1)
            {
                s = s.Substring(0, s.Length - 1);
            }
            else
            {
                s = "";
            }

            txt.Text = s;

            txt.Focus();
            if (txt.Text.Length > 0)
            {
                txt.CaretIndex = txt.Text.Length;
            }
        }

        public void Submit()
        {
            
        }


        public void BackSpaceLongPressed()
        {
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                txt.Text = "";
            }));
        }

        private void btnclose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
