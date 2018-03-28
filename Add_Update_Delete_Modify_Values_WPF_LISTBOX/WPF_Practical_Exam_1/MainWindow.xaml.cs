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

namespace WPF_Practical_Exam_1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer ClockTimer; 
        public MainWindow()
        {
            InitializeComponent();

            ClockTimer = new DispatcherTimer();
            ClockTimer.Interval = TimeSpan.FromSeconds(1);
            ClockTimer.Tick += ClockTimer_Tick;
            LabelClock.Content = String.Format("{0:F}", DateTime.Now);
            ClockTimer.Start();
        }

        void ClockTimer_Tick(object sender, EventArgs e)
        {
            LabelClock.Content = String.Format("{0:F}", DateTime.Now);
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxInput.Text == "")
            {
                MessageBox.Show("No Input","Error",MessageBoxButton.OK,MessageBoxImage.Exclamation);
            }
            else
            {
                ListBoxItems.Items.Add(TextBoxInput.Text.ToString());
                TextBoxInput.Text = String.Empty;
            }
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxItems.SelectedIndex < 0)
            {

            }else
            {

                ListBoxItems.Items.RemoveAt(ListBoxItems.SelectedIndex);
                TextBoxInput.Text = String.Empty;
            }
        }

        private void ButtonUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (ListBoxItems.SelectedIndex < 0)
            {

            }
            else
            {
                int index = ListBoxItems.SelectedIndex;
                if (TextBoxInput.Text == "")
                {
                    MessageBox.Show("No Input", "Error", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    ListBoxItems.Items.RemoveAt(index);
                    ListBoxItems.Items.Insert(index, TextBoxInput.Text.ToString());
                    TextBoxInput.Text = String.Empty;
                    index = -1;
                }
                
                
            }
        }

        private void ListBoxItems_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListBoxItems.SelectedIndex < 0)
            {

            }
            else
            {
                TextBoxInput.Text = ListBoxItems.SelectedItem.ToString();
            }
        }
    }
}
