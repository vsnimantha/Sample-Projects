using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace TestLanguageInput
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string Language;
        private ICollection<TextChange> _latestChange = null;
        public MainWindow()
        {
            InitializeComponent();
            drpLang.Items.Add("Sinhala");
            drpLang.Items.Add("English");
            drpLang.Items.Add("Arabic");

            drpLang.SelectedItem="Sinhala";
            Language = drpLang.SelectedItem.ToString();

        }

        private void txtInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            _latestChange = e.Changes;
            CheckLanguageInput(txtInput.Text);

        }

        public void CheckLanguageInput(string Input)
        {
            if (Language.Equals("Sinhala"))
            {
                if (Regex.IsMatch(Input, @"^[\p{IsSinhala}0-9|!#$%&/()=?»«@£§€{}.-;'<>_,^*`~=+;:'\- ]+$"))
                {
                }
                else
                {
                    if (_latestChange != null)
                    {
                        var change = _latestChange.FirstOrDefault(); // Just take first change
                        if (change.AddedLength > 0) // If text was removed, ignore
                        {
                            txtInput.Text = txtInput.Text.Remove(change.Offset, change.AddedLength);
                            txtInput.SelectionStart = txtInput.Text.Length; //put the focus back to the end of the text box
                        }
                    }
                    //MessageBox.Show("Please Enter only Sinhala characters", "Language Input error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else if (Language.Equals("English"))
            {
                if (Regex.IsMatch(Input, @"^[a-zA-Z0-9|!#$%&/()=?»«@£§€{}.-;'<>_,^*`~=+;:'\- ]+$"))
                {
                }
                else
                {
                    if (_latestChange != null)
                    {
                        var change = _latestChange.FirstOrDefault(); // Just take first change
                        if (change.AddedLength > 0) // If text was removed, ignore
                        {
                            txtInput.Text = txtInput.Text.Remove(change.Offset, change.AddedLength);
                            txtInput.SelectionStart = txtInput.Text.Length; //put the focus back to the end of the text box
                        }
                    }
                    //MessageBox.Show("Please Enter only English characters", "Language Input error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
            else if (Language.Equals("Arabic"))
            {
                if (Regex.IsMatch(Input, @"^[\p{IsArabic}0-9|!#$%&/()=?»«@£§€{}.-;'<>_,^*`~=+;:'\- ]+$"))
                {
                }
                else
                {
                    if (_latestChange != null)
                    {
                        var change = _latestChange.FirstOrDefault(); // Just take first change
                        if (change.AddedLength > 0) // If text was removed, ignore
                        {
                            txtInput.Text = txtInput.Text.Remove(change.Offset, change.AddedLength);
                            txtInput.SelectionStart = txtInput.Text.Length; //put the focus back to the end of the text box
                        }
                    }
                   // MessageBox.Show("Please Enter only Arabic characters", "Language Input error", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
            }
        }

        private void drpLang_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Language = drpLang.SelectedItem.ToString();
        }
    }
}
