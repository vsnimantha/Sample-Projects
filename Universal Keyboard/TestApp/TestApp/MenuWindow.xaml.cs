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

namespace TestApp
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();

            UniversalKeyboardButton.Click += UniversalKeyboardButton_Click;
            NumberKeyboardButton.Click += NumberKeyboardButton_Click;
            EmailKeyboardButton.Click += EmailKeyboardButton_Click;
        }

        void EmailKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(Keyboards.EMAIL);
            window.Show();
        }

        void NumberKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(Keyboards.NUMBER);
            window.Show();
        }

        void UniversalKeyboardButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow(Keyboards.UNIVERSAL);
            window.Show();
        }
    }
}
