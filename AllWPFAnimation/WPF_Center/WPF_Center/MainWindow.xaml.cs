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

namespace WPF_Center
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Loaded+=MainWindow_Loaded;

            main.WindowState = WindowState.Maximized;

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ImageBrush imageBrush = new ImageBrush();


            BitmapImage image = new BitmapImage(new Uri("pack://siteoforigin:,,,/Resources/cr.jpg", UriKind.Relative));

            ColumnDefinition col1 =grid.ColumnDefinitions[0];
            ColumnDefinition col2 = grid.ColumnDefinitions[1];
            ColumnDefinition col3 = grid.ColumnDefinitions[2];

            double gdwidth=grid.ActualWidth;
            double colwidth = (gdwidth - image.PixelWidth) / 2;

            Console.WriteLine(gdwidth);
            Console.WriteLine(gdwidth - image.Width);
            Console.WriteLine((gdwidth - image.Width)/2);

            col1.Width = new GridLength(colwidth);
            col2.Width = new GridLength(image.PixelWidth);
            col3.Width = new GridLength(colwidth);

            

            imageBrush.ImageSource = image;
            imageBrush.Stretch = Stretch.Uniform;
            image_rect.Fill = imageBrush;

        }


    }
}
