using CefSharp;
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

namespace GoogleChromeInWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeBrowser();

            InitializeComponent();

            Browser.RegisterJsObject("callbackObj", new CallbackObjectForJs());
        }

        private void InitializeBrowser()
        {


            var CefSettings = new CefSettings();
            CefSettings.CefCommandLineArgs.Add("enable-media-stream", "1"); //Enable WebRTC
            //CefSettings.CefCommandLineArgs.Add("--use-fake-ui-for-media-stream","1");
            //CefSettings.CefCommandLineArgs.Add("--use-fake-device-for-media-stream", "1");
            //CefSettings.CefCommandLineArgs.Add("--use-file-for-fake-audio-capture", "1");
            CefSettings.CefCommandLineArgs.Add("--enable-default-media-session", "1");
            //CefSettings.CefCommandLineArgs.Add("no-proxy-server", "1");
            CefSettings.CefCommandLineArgs.Add("enable-speech-input", "1"); //Enable Speech 
            Cef.Initialize(CefSettings, performDependencyCheck: true, browserProcessHandler: null);
            

        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            //Browser.Load("http://localhost/GoogleVoiceRecognitionDemo/");

            //Browser.Load(txtUrl.Text);

            loadStringContentToBrowser("<html>"+
                                         "<body>"+
                                            "<input type='button' onclick='OnClick()' value='Click Me!'/>"+
                                            "<script type=" + "text/javascript" + ">" +
                                                "function OnClick()"+
                                                "{callbackObj.showMessage('message from js');}"+
                                            "</script >"+
                                        "</body>"+
                                    "</html>");
        }
        
        private void btnfwd_Click(object sender, RoutedEventArgs e)
        {
            Browser.Forward();
        }

        private void btnbck_Click(object sender, RoutedEventArgs e)
        {
            Browser.Back();
        }

        private void txtUrl_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
            {
                Browser.Load(txtUrl.Text);
            }
        }

        public void loadStringContentToBrowser(string fullWebPage)
        {


                //this.webBrowser.NavigateToString(
                // "" +
                // "" +
                // "" +
                // "" +
                // "" +
                // "Hello" +
                // "");

                //webBrowser.NavigateToString(fullWebPage);
            Browser.LoadHtml(fullWebPage, "http://localhost/PulztecVoiceRecognition");


        }


    }
    public class CallbackObjectForJs
    {
        public void showMessage(string msg)
        {//Read Note
            MessageBox.Show(msg,"Message",MessageBoxButton.OK,MessageBoxImage.Information);
        }
    }
        
}
