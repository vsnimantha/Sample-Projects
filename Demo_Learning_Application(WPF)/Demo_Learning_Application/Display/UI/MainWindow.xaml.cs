using Demo_Learning_Application.Display.Controllers;
using Demo_Learning_Application.Display.Data_Structures;
using Demo_Learning_Application.Display.UI.UserControls;
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

namespace Demo_Learning_Application
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UIController UIController; 
        //private MainUserControl _MainUserControl;

        public ICommonFunctions iCommonFunctions;

        public MainWindow()
        {
            InitializeComponent();

            UIController = new UIController(this);

            ScreenModeController.LoadUserControls();
            //_MainUserControl = new MainUserControl();

            Loaded += MainWindow_Loaded;

            
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            GridMainWindow.Children.Clear();
            GridMainWindow.Children.Add((UserControl)iCommonFunctions);
        }

        public void ChangeWidget(Widgets widget)
        {
            iCommonFunctions.ChangeWidget(widget);
        }
    }
}
