using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CultureControlApplication
{
    class CultureController
    {
        public class CulctureController
        {
            private static CulctureController _myInstance;
            private static object _padLock = new object();

            private List<ILanguageChangedListener> _subscribedLanguageChangedListenersList;


            private CulctureController()
            {
                _subscribedLanguageChangedListenersList = new List<ILanguageChangedListener>();
            }


            public static CulctureController GetInstance()
            {
                if (_myInstance == null)
                {
                    lock (_padLock)
                    {
                        if (_myInstance == null)
                        {
                            _myInstance = new CulctureController();
                        }
                    }
                }
                return _myInstance;
            }

            public void ChangeCultureLanguage(Langauge langauge)
            {
                switch (langauge)
                {
                    case Langauge.English:
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
                        break;

                    case Langauge.Sinhala:
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("si-LK");
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("si-LK");
                        break;

                    case Langauge.Tamil:
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ta-IN");
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ta-IN");
                        break;

                    case Langauge.Arabic:
                        System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("ar-AE");
                        System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-AE");
                        break;
                }

                this.NotifySubscribers();
            }




            public void RegisterUserInterface(ILanguageChangedListener iLanguageChangedListener)
            {

                //If the passsed object is same type, remove the old one
                foreach (var item in this._subscribedLanguageChangedListenersList)
                {
                    if (item.GetType() == iLanguageChangedListener.GetType())
                    {
                        this.RemoveRegisteredUserInterface(iLanguageChangedListener);
                        break;
                    }
                }

                _subscribedLanguageChangedListenersList.Add(iLanguageChangedListener);

            }

            public void RemoveRegisteredUserInterface(ILanguageChangedListener iLanguageChangedListener)
            {
                int i = 0;
                foreach (var item in this._subscribedLanguageChangedListenersList)
                {
                    if (item.GetType() == iLanguageChangedListener.GetType())
                    {
                        _subscribedLanguageChangedListenersList.RemoveAt(i);
                        break;
                    }
                    i++;
                }

                //if (_subscribedLanguageChangedListenersList.Contains(iLanguageChangedListener))
                //{
                //    _subscribedLanguageChangedListenersList.Remove(iLanguageChangedListener);
                //}
            }

            private void NotifySubscribers()
            {
                foreach (var item in this._subscribedLanguageChangedListenersList)
                {
                    item.OnLanguageChanged();
                }
            }


        }

        public enum Langauge
        {
            English,
            Sinhala,
            Tamil,
            Arabic
        }

        public interface ILanguageChangedListener
        {
            void OnLanguageChanged();
        }
    }
}
