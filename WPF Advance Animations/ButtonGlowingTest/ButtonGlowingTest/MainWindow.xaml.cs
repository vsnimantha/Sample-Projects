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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ButtonGlowingTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        DispatcherTimer dispatcherTimer2 = new DispatcherTimer();
        Storyboard sb = new Storyboard();
        Storyboard sb2 = new Storyboard();

        double TimerTick = .75;
        double TimerTick2 = .5;

        bool isAnimating;
        public MainWindow()
        {
            InitializeComponent();
            OnTouchLeave();

            Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            btnRect.Height = mainButtonGrid.ActualHeight-5;

            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Interval = TimeSpan.FromSeconds(TimerTick);
            dispatcherTimer.Start();

            dispatcherTimer2.Tick += dispatcherTimer2_Tick;
            dispatcherTimer2.Interval = TimeSpan.FromSeconds(TimerTick2);
        }

        void dispatcherTimer2_Tick(object sender, EventArgs e)
        {
           // dancingButton();
           // EnlargeSmallButton();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            doAnimation();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void btnRect_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void doAnimation()
        {
            isAnimating = true;
            #region Glow
            //DoubleAnimation animation = new DoubleAnimation(0.25, TimeSpan.FromSeconds(0.125));
            //animation.AutoReverse = true;
            //recmidIcon.BeginAnimation(Rectangle.OpacityProperty, animation);

            //DoubleAnimation animation2 = new DoubleAnimation(0.25, TimeSpan.FromSeconds(0.125));
            //animation2.AutoReverse = true;
            //lblInput.BeginAnimation(Label.OpacityProperty, animation2);

            #endregion

            #region Dancing buttons Animation

            //Stock one found from the internet
            //{
            //    //var rt = new RotateTransform();
            //    //rt.Angle = 10;
            //    //btnRect.RenderTransform = rt;
            //    //btnRect.RenderTransformOrigin = new Point(0.5, 0.5);

            //}

            //implemented one

            //RotateTransform transform = new RotateTransform();
            //transform.Angle = 0;
            //btnRect.RenderTransform = transform;
            //btnRect.RenderTransformOrigin = new Point(0.5, 0.5);
            //btnRect.RenderTransform = transform;

            ////dancing to the right

            //Duration dur = new Duration(TimeSpan.FromSeconds(0.125));
            //DoubleAnimation shiftAnimation = new DoubleAnimation(0, 5, dur);
            //shiftAnimation.AutoReverse = true;
            //sb.Children.Add(shiftAnimation);
            //Storyboard.SetTarget(shiftAnimation, btnRect);
            //Storyboard.SetTargetProperty(shiftAnimation, new PropertyPath("RenderTransform.Angle"));

            ////dancing to the left

            //DoubleAnimation shiftAnimation2 = new DoubleAnimation(0, -15, dur);
            //shiftAnimation2.AutoReverse = true;
            //sb2.Children.Add(shiftAnimation2);
            //Storyboard.SetTarget(shiftAnimation2, btnRect);
            //Storyboard.SetTargetProperty(shiftAnimation2, new PropertyPath("RenderTransform.Angle"));

            #endregion

            #region Changing the size of the object

            //double height = btnRect.ActualHeight;


            //DoubleAnimation animation = new DoubleAnimation(height, height + 2, TimeSpan.FromSeconds(0.25));
            //animation.AutoReverse = true;
            //btnRect.BeginAnimation(Rectangle.HeightProperty, animation);

            #endregion

            #region TranslateTransform - Moving up and down

            //Moving up and down buttons

            TranslateTransform trans = new TranslateTransform();
            btnRect.RenderTransform = trans;
            recmidIcon.RenderTransform = trans;
            lblInput.RenderTransform = trans;

            //DoubleAnimation anim1 = new DoubleAnimation(0,100, TimeSpan.FromSeconds(10));
            DoubleAnimation anim2 = new DoubleAnimation(0, -10, TimeSpan.FromSeconds(TimerTick/2));
            anim2.AutoReverse = true;
            // trans.BeginAnimation(TranslateTransform.XProperty, anim1);
            trans.BeginAnimation(TranslateTransform.YProperty, anim2);


            #endregion

            #region Shadow Animations

            //adjusting height

            //double height = ellipseShadow.ActualHeight;
            //DoubleAnimation animation = new DoubleAnimation(height, height + 5, TimeSpan.FromSeconds(0.5));
            //animation.AutoReverse = true;
            //ellipseShadow.BeginAnimation(Ellipse.HeightProperty, animation);


            //adjusting width

            //double ellipseWidth = ellipseShadow.ActualWidth;
            double Width = gridShadow.ColumnDefinitions[1].ActualWidth;

            DoubleAnimation animation2 = new DoubleAnimation(Width - 10, Width, TimeSpan.FromSeconds(TimerTick/2));
            animation2.AutoReverse = true;
           

            //adjusting opacity

            DoubleAnimation animation3 = new DoubleAnimation(0.2, 0.15, TimeSpan.FromSeconds(TimerTick/2));
            animation3.AutoReverse = true;

            ellipseShadow.BeginAnimation(Ellipse.WidthProperty, animation2);
            ellipseShadow.BeginAnimation(Ellipse.OpacityProperty, animation3);

            //moving shadow up and down

            //TranslateTransform trans2 = new TranslateTransform();
            //ellipseShadow.RenderTransform = trans2;
            //DoubleAnimation anim3 = new DoubleAnimation(0, 5, TimeSpan.FromSeconds(.5));
            //anim3.AutoReverse = true;
            //trans2.BeginAnimation(TranslateTransform.YProperty, anim3);

            #endregion

            //sb.Begin();
            //sb.Pause();
            //sb.Seek(sb.Duration.TimeSpan);
            //sb.Resume();

        }

        private void dancingButton()
        {
            RotateTransform transform = new RotateTransform();
            transform.Angle = 0;
            btnRect.RenderTransform = transform;
            btnRect.RenderTransformOrigin = new Point(0.5, 0.5);
            btnRect.RenderTransform = transform;

            //dancing to the right

            Duration dur = new Duration(TimeSpan.FromSeconds(TimerTick2/2));
            DoubleAnimation shiftAnimation = new DoubleAnimation(0, 3, dur);
            shiftAnimation.AutoReverse = true;
            sb.Children.Add(shiftAnimation);
            Storyboard.SetTarget(shiftAnimation, btnRect);
            Storyboard.SetTargetProperty(shiftAnimation, new PropertyPath("RenderTransform.Angle"));

            sb.Begin();
        }

        private void EnlargeButton()
        {

            double height = mainButtonGrid.ActualHeight;


            DoubleAnimation animation = new DoubleAnimation(height-5, height , TimeSpan.FromSeconds(TimerTick2 / 2));
            //animation.AutoReverse = true;
            btnRect.BeginAnimation(Rectangle.HeightProperty, animation);


        }

        private void ReduceButton()
        {


            double height = mainButtonGrid.ActualHeight;


            DoubleAnimation animation = new DoubleAnimation(height , height-5, TimeSpan.FromSeconds(TimerTick2 / 2));
            //animation.AutoReverse = true;
            btnRect.BeginAnimation(Rectangle.HeightProperty, animation);

        }
        private void startAnimating()
        {
            isAnimating = true;
            dispatcherTimer.Start();
            sb.Stop();
            dispatcherTimer2.Stop();
            ReduceButton();
        }
        private void stopAnimating()
        {
            isAnimating = false;
            sb.Stop();
            dispatcherTimer.Stop();
            //dancingButton();
            dispatcherTimer2.Start();
            EnlargeButton();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            stopAnimating();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            sb.Begin();
            dispatcherTimer.Start();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (isAnimating)
            {
                stopAnimating();
            }
            OnTouchEnter();
        }   

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!isAnimating)
            {
                startAnimating();
            }
            OnTouchLeave();

        }

        private void OnTouchEnter()
        {
            recmidIcon.Opacity = 1;
        }

        private void OnTouchLeave()
        {
            recmidIcon.Opacity = .5;
        }
        
    }
}
