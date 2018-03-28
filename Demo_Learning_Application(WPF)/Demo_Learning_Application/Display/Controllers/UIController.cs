using Demo_Learning_Application.Display.Data_Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo_Learning_Application.Display.Controllers
{
    class UIController
    {
        public static MainWindow mainWindow;

        public UIController(MainWindow mainWindowParameter)
        {
            if (mainWindow == null)
            {
                mainWindow = mainWindowParameter;
            }
        }

        public static void ChangeWidget(Widgets widget)
        {
            mainWindow.ChangeWidget(widget);
        }
    }
}
