using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalKeyboard.UI
{
    public interface IPressedKey
    {
        string PressedKey(string key);

        void BackSpace();

        void BackSpaceLongPressed();

        void Submit();
    }
}
