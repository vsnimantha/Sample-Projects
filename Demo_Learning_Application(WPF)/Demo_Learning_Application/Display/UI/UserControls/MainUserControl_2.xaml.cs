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
    /// Interaction logic for MainUserControl_2.xaml
    /// </summary>
    public partial class MainUserControl_2 : UserControl,ICommonFunctions
    {
        private ImageViewerUserControl _ImageViewerUserControl;
        private VideoPlayerUserControl _VideoPlayerUserControl;
        private WebBrowserUserControl _WebBrowserUserControl;

        private DropdownUserControl _DropdownUserControl;
        public MainUserControl_2()
        {

            InitializeComponent();



            _ImageViewerUserControl = new ImageViewerUserControl();
            _VideoPlayerUserControl = new VideoPlayerUserControl();
            _WebBrowserUserControl = new WebBrowserUserControl();

            _DropdownUserControl = new DropdownUserControl();

            GridDropdownArea.Children.Add(_DropdownUserControl);

            Loaded += MainUserControl_Loaded;
        }

        private void MainUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            int fontSize = (int)(screenHeight * 0.020);
        }

        public void ChangeWidget(Data_Structures.Widgets widget)
        {
            switch (widget)
            {
                case Widgets.IMAGE_VIEWER:
                    GridUserControlPushArea.Children.Clear();
                    GridUserControlPushArea.Children.Add(_ImageViewerUserControl);
                    break;
                case Widgets.VIDEO_PLAYER:
                    GridUserControlPushArea.Children.Clear();
                    GridUserControlPushArea.Children.Add(_VideoPlayerUserControl);
                    break;
                case Widgets.WEB_BROWSER:
                    GridUserControlPushArea.Children.Clear();
                    GridUserControlPushArea.Children.Add(_WebBrowserUserControl);
                    break;
                case Widgets.BLANK:
                    GridUserControlPushArea.Children.Clear();
                    break;
                default:
                    GridUserControlPushArea.Children.Clear();
                    break;
            }
        }
    }
}
