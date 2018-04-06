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

namespace EmailValidator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ButtonCheck.Click += ButtonCheck_Click;
        }

        private void ButtonCheck_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxInput.Text != null)
            {
                if (EmailValidator.EmailValidatorController.IsEmailValid(TextBoxInput.Text))
                {
                    MessageBox.Show("Valid Email!!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("invalid Email!!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);

                }
            }
            else
            {
                MessageBox.Show("Text Box Cannot be empty!!", "Message", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
