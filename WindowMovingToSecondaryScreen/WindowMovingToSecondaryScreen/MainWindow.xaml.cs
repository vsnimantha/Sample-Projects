using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace WindowMovingToSecondaryScreen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //SecondWindow.getInstance().Show();

            Task.Run(() =>
            {
                Thread.Sleep(1000);

                Application.Current.Dispatcher.Invoke(new Action(() =>
                {
                    SecondWindow.getInstance().Show();
                }));

            });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            SecondWindow.getInstance().Show();
           // SecondWindow.getInstance().Focus();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            SecondWindow.getInstance().Close();
            Environment.Exit(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SecondWindow.getInstance().Hide();
        }

        private void TextBoxMessage_TextChanged(object sender, TextChangedEventArgs e)
        {
            SecondWindow.getInstance().ChangeText(TextBoxMessage.Text);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            SecondWindow.getInstance().MoveToSecondryScreen();
        }
    }
}
