using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Demo_Learning_Application.Display.UI.UserControls.SmallWidgets
{
    /// <summary>
    /// Interaction logic for ImageViewerUserControl.xaml
    /// </summary>
    public partial class ImageViewerUserControl : UserControl
    {
        public ImageViewerUserControl()
        {
            InitializeComponent();

        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animationButtonClick = new DoubleAnimation(1, .4, TimeSpan.FromSeconds(.125));
            animationButtonClick.AutoReverse = true;
            ButtonOpen.BeginAnimation(Button.OpacityProperty, animationButtonClick);  

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ImageBrushFill.ImageSource = new BitmapImage(new Uri(openFileDialog.FileName));
            }
            
        }
    }
}
