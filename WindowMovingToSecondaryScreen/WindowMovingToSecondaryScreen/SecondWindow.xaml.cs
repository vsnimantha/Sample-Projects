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
using System.Windows.Shapes;
using WindowsInput;

namespace WindowMovingToSecondaryScreen
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private static SecondWindow myInstance;

        private static object paddleLock = new object();
        private SecondWindow()
        {
            InitializeComponent();

            Loaded += SecondWindow_Loaded;
        }

        public static SecondWindow getInstance()
        {
            if (myInstance == null)
            {
                lock (paddleLock)
                {
                    if (myInstance == null)
                    {
                        myInstance = new SecondWindow();
                    }
                }
            }
            return myInstance;
        }

        void SecondWindow_Loaded(object sender, RoutedEventArgs e)
        {
            MoveToSecondryScreen();
        }

        public void MoveToSecondryScreen()
        {
            this.Focus();
            InputSimulator insim = new InputSimulator();
            insim.Keyboard.ModifiedKeyStroke(new[] { WindowsInput.Native.VirtualKeyCode.LWIN, WindowsInput.Native.VirtualKeyCode.SHIFT }, new[] { WindowsInput.Native.VirtualKeyCode.RIGHT });
        }

        public void ChangeText(string text)
        {
            TextBlockMessage.Text = text;
        }
    }
}
