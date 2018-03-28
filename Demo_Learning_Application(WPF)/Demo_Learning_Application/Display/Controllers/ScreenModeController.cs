using Demo_Learning_Application.Display.Data_Structures;
using Demo_Learning_Application.Display.UI.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Learning_Application.Display.Controllers
{
    class ScreenModeController
    {
        static ICommonFunctions commonFunctions;
        static ScreenModes screenMode;
        public ScreenModeController()
        {
            
        }
        public static void LoadUserControls()
        {
            setScreen(ScreenModes.MODE1);
            UIController.mainWindow.iCommonFunctions = commonFunctions;
        }
        public static void setScreenMode(ScreenModes screen)
        {
            screenMode = screen;
        }

        public static ScreenModes getScreenMode()
        {
            return screenMode;
        }

        public static void setScreen(ScreenModes screen)
        {
            switch (screen)
            {
                case ScreenModes.MODE1:
                    commonFunctions = new MainUserControl();
                    break;
                case ScreenModes.MODE2:
                    commonFunctions = new MainUserControl_2();
                    break;
                default:
                    break;
            }
        }
    }

}
