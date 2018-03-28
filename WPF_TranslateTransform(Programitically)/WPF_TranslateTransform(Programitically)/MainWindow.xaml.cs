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

namespace WPF_TranslateTransform_Programitically_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)this.Resources["SB"];

            TranslateTransform translateTransform = new TranslateTransform();
            translateTransform.X = -50;
            translateTransform.Y = 0;
            GridA.RenderTransform = translateTransform;

            Storyboard.SetTarget(sb.Children.ElementAt(0) as DoubleAnimation, GridA);
           // Storyboard.SetTarget(myStoryboard.Children.ElementAt(1) as DoubleAnimation, MyGrid);

            sb.Begin();       
        }
    }
}
