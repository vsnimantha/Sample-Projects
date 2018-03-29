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

namespace CultureControlApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window,CultureController.ILanguageChangedListener
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;
            ComboBoxCultureList.SelectionChanged += ComboBoxCultureList_SelectionChanged;

           

            ComboBoxCultureList.Items.Clear();
            ComboBoxCultureList.Items.Add("Sinhala");
            ComboBoxCultureList.Items.Add("English");
            ComboBoxCultureList.Items.Add("Tamil");

            CultureController.CulctureController.GetInstance().RegisterUserInterface(this);
        }



        private void ComboBoxCultureList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            switch (ComboBoxCultureList.SelectedItem.ToString())
            {
                case "English":
                    CultureController.CulctureController.GetInstance().ChangeCultureLanguage(CultureController.Langauge.English);
                    break;
                case "Tamil":
                    CultureController.CulctureController.GetInstance().ChangeCultureLanguage(CultureController.Langauge.Tamil);
                    break;
                case "Sinhala":
                    CultureController.CulctureController.GetInstance().ChangeCultureLanguage(CultureController.Langauge.Sinhala);
                    break;
                default:
                    break;
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            LabelDemo.Content = Properties.Resources.LABELTEXT;
        }

        public void OnLanguageChanged()
        {
            LabelDemo.Content = Properties.Resources.LABELTEXT;
        }
    }
}
