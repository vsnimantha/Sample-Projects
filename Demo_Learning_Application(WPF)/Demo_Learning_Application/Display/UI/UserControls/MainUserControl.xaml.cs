using Demo_Learning_Application.Display.Data_Structures;
using Demo_Learning_Application.Display.UI.UserControls.SmallWidgets;
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

namespace Demo_Learning_Application.Display.UI.UserControls
{
    /// <summary>
    /// Interaction logic for MainUserControl.xaml
    /// </summary>
    public partial class MainUserControl : UserControl,ICommonFunctions
    {
        private ImageViewerUserControl _ImageViewerUserControl;
        private VideoPlayerUserControl _VideoPlayerUserControl;
        private WebBrowserUserControl _WebBrowserUserControl;

        private DropdownUserControl _DropdownUserControl;
        public MainUserControl()
        {
            InitializeComponent();

            _ImageViewerUserControl = new ImageViewerUserControl();
            _VideoPlayerUserControl = new VideoPlayerUserControl();
            _WebBrowserUserControl = new WebBrowserUserControl();

            _DropdownUserControl = new DropdownUserControl();

            GridDropdownArea.Children.Add(_DropdownUserControl);

            Loaded += MainUserControl_Loaded;
        }

        void MainUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            int fontSize = (int)(screenHeight * 0.020);
        }


        public void ChangeWidget(Widgets widget)
        {
            switch (widget)
            {
                case Widgets.IMAGE_VIEWER:
                    GridUserControlPushArea.Children.Clear();
                    GridUserControlPushArea.Children.Add(_ImageViewerUserControl);
                    LabelStatus.Content = "Image";
                    break;
                case Widgets.VIDEO_PLAYER:
                    GridUserControlPushArea.Children.Clear();
                    GridUserControlPushArea.Children.Add(_VideoPlayerUserControl);
                    LabelStatus.Content = "Video";
                    break;
                case Widgets.WEB_BROWSER:
                    GridUserControlPushArea.Children.Clear();
                    GridUserControlPushArea.Children.Add(_WebBrowserUserControl);
                    LabelStatus.Content = "Web";
                    break;
                case Widgets.BLANK:
                    GridUserControlPushArea.Children.Clear();
                    LabelStatus.Content = "Blank";
                    break;
                default:
                    GridUserControlPushArea.Children.Clear();
                    break;
            }
        }
    }
}
