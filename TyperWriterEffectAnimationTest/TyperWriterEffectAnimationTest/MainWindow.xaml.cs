using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace TyperWriterEffectAnimationTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Storyboard story;

        public MainWindow()
        {
            InitializeComponent();
            story = new Storyboard();

            story.Completed += story_Completed;

            Loaded += MainWindow_Loaded;

            DependencyPropertyDescriptor dp = DependencyPropertyDescriptor.FromProperty(TextBlock.TextProperty, typeof(TextBlock));

            dp.AddValueChanged(txtBlock, (object a, EventArgs b) =>
            {
                TextChanged(a, b);
            });

            DependencyPropertyDescriptor dplbl = DependencyPropertyDescriptor.FromProperty(Label.ContentProperty, typeof(Label));

            dplbl.AddValueChanged(lbl, (object a, EventArgs b) =>
            {
                ContentChangedLabel(a, b);
            });
        }

        int count = 0;
        private void TextChanged(object a, EventArgs b)
        {
            lblcount.Content = " TextBlock TextChanged "+count;
            count++;
        }

        int cnt=0;
        private void ContentChangedLabel(object a, EventArgs b)
        {
            lblcount_Copy.Content = "Label ContentChanged "+cnt;
            cnt++;
        }
        void story_Completed(object sender, EventArgs e)
        {
           // story.Stop();
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            TypewriteTextblock("Each sentence works together as part of a unit to create an overall thought or impression. A paragraph is the smallest unit or cluster of ", txtBlock, new TimeSpan(0, 0, 0, 5, 0));

            //TypewriteTextblock("sentences in which one idea can be developed adequately. Paragraphs can stand alone or function as part of an essay, but each paragraph covers only one main idea.", lbl, new TimeSpan(0, 0, 0, 5, 0));

        }

        private void TypewriteTextblock(string textToAnimate, TextBlock txt, TimeSpan timeSpan)
        {
            //Storyboard story = new Storyboard();
            story.FillBehavior = FillBehavior.HoldEnd;
            //story.RepeatBehavior = RepeatBehavior.Forever;

            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            foreach (char c in textToAnimate)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;
                tmp += c;
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBlock.TextProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);

            story.Begin(txt,true);
        }

        private void TypewriteTextblock(string textToAnimate, Label txt, TimeSpan timeSpan)
        {
            //Storyboard story = new Storyboard();
            story.FillBehavior = FillBehavior.HoldEnd;
            //story.RepeatBehavior = RepeatBehavior.Forever;

            DiscreteStringKeyFrame discreteStringKeyFrame;
            StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
            stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

            string tmp = string.Empty;
            foreach (char c in textToAnimate)
            {
                discreteStringKeyFrame = new DiscreteStringKeyFrame();
                discreteStringKeyFrame.KeyTime = KeyTime.Paced;
                tmp += c;
                discreteStringKeyFrame.Value = tmp;
                stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
            }
            Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
            Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(Label.ContentProperty));
            story.Children.Add(stringAnimationUsingKeyFrames);

            story.Begin(txt);
        }

        private void stop_Click(object sender, RoutedEventArgs e)
        {
            Interrupt();
        }

        private void Interrupt()
        {
            if (story.GetIsPaused(txtBlock))
            {
                story.Resume(txtBlock);
            }
            else
            {
                story.Pause(txtBlock);
            }
        }

        //private void TypewriteTextblock(string textToAnimate, TextBox txt, TimeSpan timeSpan)
        //{
        //    //Storyboard story = new Storyboard();
        //    story.FillBehavior = FillBehavior.HoldEnd;
        //    //story.RepeatBehavior = RepeatBehavior.Forever;

        //    DiscreteStringKeyFrame discreteStringKeyFrame;
        //    StringAnimationUsingKeyFrames stringAnimationUsingKeyFrames = new StringAnimationUsingKeyFrames();
        //    stringAnimationUsingKeyFrames.Duration = new Duration(timeSpan);

        //    string tmp = string.Empty;
        //    foreach (char c in textToAnimate)
        //    {
        //        discreteStringKeyFrame = new DiscreteStringKeyFrame();
        //        discreteStringKeyFrame.KeyTime = KeyTime.Paced;
        //        tmp += c;
        //        discreteStringKeyFrame.Value = tmp;
        //        stringAnimationUsingKeyFrames.KeyFrames.Add(discreteStringKeyFrame);
        //    }

        //    Storyboard.SetTargetName(stringAnimationUsingKeyFrames, txt.Name);
        //    Storyboard.SetTargetProperty(stringAnimationUsingKeyFrames, new PropertyPath(TextBox.TextProperty));
        //    story.Children.Add(stringAnimationUsingKeyFrames);

        //    story.Begin(txt);
        //}
    }
}
