using Demo_Learning_Application.Display.Controllers;
using Demo_Learning_Application.Display.Data_Structures;
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
    /// Interaction logic for DropdownUserControl.xaml
    /// </summary>
    public partial class DropdownUserControl : UserControl
    {
        public DropdownUserControl()
        {
            InitializeComponent();

            PopulateUserControlList();

            Loaded += DropdownUserControl_Loaded;
        }

        void DropdownUserControl_Loaded(object sender, RoutedEventArgs e)
        {
            int screenHeight = (int)SystemParameters.PrimaryScreenHeight;

            int fontSize = (int)(screenHeight * 0.020);

            ComboBoxUserControls.FontSize = fontSize;
            ComboBoxUserControls.FontWeight = FontWeights.SemiBold;
        }

        /// <summary>
        /// Populating the user control list
        /// </summary>
        private void PopulateUserControlList()
        {
            ComboBoxUserControls.Items.Add("Media Player");
            ComboBoxUserControls.Items.Add("Web Browser");
            ComboBoxUserControls.Items.Add("Image Viewer");
        }

        private void ComboBoxUserControls_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ComboBoxUserControls.SelectedItem.ToString())
            {
                case "Media Player":
                    UIController.ChangeWidget(Widgets.VIDEO_PLAYER);
                    break;
                case "Web Browser":
                    UIController.ChangeWidget(Widgets.WEB_BROWSER);
                    break;
                case "Image Viewer":
                    UIController.ChangeWidget(Widgets.IMAGE_VIEWER);
                    break;
                default:
                    UIController.ChangeWidget(Widgets.BLANK);
                    break;
            }
        }
    }
}
