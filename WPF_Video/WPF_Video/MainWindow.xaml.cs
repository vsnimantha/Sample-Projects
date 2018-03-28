using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Threading;

namespace WPF_Video
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        string path = "";
        DispatcherTimer timer;

        Queue<string> queue = new Queue<string>();
        Stack<string> stack = new Stack<string>();
        List<string> list = new List<string>();

        bool isDragging = false;
        bool isVideoPlaying = false;

        public MainWindow()
        {
            InitializeComponent();

            Loaded += MainWindow_Loaded;

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(200);
            timer.Tick += new EventHandler(timer_tick);
            video.Volume = 0.5;
        }

        private void timer_tick(object sender, EventArgs e)
        {
            if (!isDragging)
            {
                seekBar.Value = video.Position.TotalSeconds;
                //duration.Content = TimeSpan.FromHours(seekBar.Value);
            }

            if (video.Source != null)
            {
                if (video.NaturalDuration.HasTimeSpan) {
                    duration.Content = String.Format("{0} / {1} ", video.Position.ToString(@"hh\:mm\:ss"), video.NaturalDuration.TimeSpan.ToString(@"hh\:mm\:ss"));
                }
            }
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            if (stack.Count == 0)
            {

            }
            else
            {
                //this.video.Source = new Uri(queue.Dequeue(), UriKind.RelativeOrAbsolute);
                this.video.Source = new Uri(stack.Pop(), UriKind.RelativeOrAbsolute);
            }
            volumelbl.Content = (volumeControl.Value*100).ToString() +" %";

            /*this.video.Source = new Uri("H:/English Video/NEW/Alan Walker - Faded.mp4", UriKind.RelativeOrAbsolute);
            video_playing = 1;*/
        }

        private void video_MediaEnded(object sender, RoutedEventArgs e)
        {
            /* String songpath = queue.Dequeue();
             this.video.Source = new Uri(songpath, UriKind.RelativeOrAbsolute);
             queue.Enqueue(songpath);*/
            if (path != "" || path != null)
            {
                queue.Enqueue(path);
                list.Add(path);
                path = queue.Dequeue();
                this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);

                FileInfo fileInfo = new FileInfo(path);
                listviewitems.SelectedItems.Clear();
                if (listviewitems.Items.Count > 0)
                {
                    foreach (var item in listviewitems.Items)
                    {
                        if (item.ToString().Equals(fileInfo.Name))
                        {
                            listviewitems.SelectedItems.Add(item);
                        }
                        else
                        {

                        }
                    }
                }
                //queue.Enqueue(path);
            }
            else
            {

            }
            /* if (stack.Count != 0)
             {
                 this.video.Source = new Uri(stack.Pop(), UriKind.RelativeOrAbsolute);
             }*/
        }
        /*
                private void seekBar_DragEnter(object sender, DragEventArgs e)
                {
                    isDragging = true;
                }

                private void seekBar_DragLeave(object sender, DragEventArgs e)
                {
                    isDragging = false;
                    video.Position = TimeSpan.FromSeconds(seekBar.Value);
                }*/

        private void video_MediaOpened(object sender, RoutedEventArgs e)
        {
            if (video.NaturalDuration.HasTimeSpan)
            {
                TimeSpan ts = video.NaturalDuration.TimeSpan;
                seekBar.Maximum = ts.TotalSeconds;
                seekBar.SmallChange = 1;
                seekBar.LargeChange = Math.Min(10, ts.Seconds / 10);
            }
            timer.Start();
        }

        private void seekBar_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            isDragging = true;
        }

        private void seekBar_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            isDragging = false;
            video.Position = TimeSpan.FromSeconds(seekBar.Value);
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            /*  if (e.Data.GetDataPresent(".mp4"))
              {*/
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                listviewitems.Items.Add(fileInfo.Name);
                //stack.Push(file);
                queue.Enqueue(file);
            }
            /* if (stack.Count != 0) 
             * 
             {*/
            if (queue.Any())
            {
                if (isVideoPlaying)
                {

                }
                else
                {
                    //this.video.Source = new Uri(stack.Pop(), UriKind.RelativeOrAbsolute);

                    path = queue.Dequeue();
                    this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);

                    this.video.Play();
                    playBtnlabel.Content = "Pause";
                    isVideoPlaying = true;
                    stopBtnGrid.Opacity=1;

                    FileInfo fileInfo = new FileInfo(path);
                    listviewitems.SelectedItems.Clear();
                    if (listviewitems.Items.Count > 0)
                    {
                        foreach (var item in listviewitems.Items)
                        {
                            if (item.ToString().Equals(fileInfo.Name))
                            {
                                listviewitems.SelectedItems.Add(item);
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
            // }
            /* }
             else
             {

             }*/

            // var file = files[0];

        }

        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            /* if (!e.Data.GetDataPresent(".") ||sender == e.Source)
             {
                 e.Effects = DragDropEffects.None;
             }*/
            e.Effects = DragDropEffects.None;
        }

        private void playBtnGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void playBtnGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (playBtnlabel.Content.Equals("Play"))
            {
                if (video.Source == null)
                {
                    if (queue.Count != 0)
                    {
                        if (!isVideoPlaying)
                        {
                            //  this.video.Source = new Uri(stack.Pop(), UriKind.RelativeOrAbsolute);

                            path = queue.Dequeue();
                            this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);


                            playBtnlabel.Content = "Pause";
                            isVideoPlaying = true;
                            stopBtnGrid.Opacity = 1;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please add a video to the playlist");
                        isVideoPlaying = false;
                    }
                }
                else
                {
                    if (!isVideoPlaying)
                    {
                        this.video.Play();
                        isVideoPlaying = true;
                        stopBtnGrid.Opacity = 1;
                        playBtnlabel.Content = "Pause";
                    }
                }
            }
            else if (playBtnlabel.Content.Equals("Pause"))
            {
                if (isVideoPlaying)
                {
                    this.video.Pause();
                    playBtnlabel.Content = "Play";
                    isVideoPlaying = false;
                }
            }
            else
            {

            }


        }

        private void fileOpenGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void fileOpenGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                listviewitems.Items.Clear();
                queue.Clear();
                foreach (string filename in openFileDialog.FileNames)
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    queue.Enqueue(filename);
                    listviewitems.Items.Add(fileInfo.Name);
                }

                if (queue.Any())
                {
                        path = queue.Dequeue();
                        this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);

                        this.video.Play();
                        stopBtnGrid.Opacity = 1;
                        playBtnlabel.Content = "Pause";
                        isVideoPlaying = true;

                        FileInfo fileInfo = new FileInfo(path);
                        listviewitems.SelectedItems.Clear();
                        if (listviewitems.Items.Count > 0)
                        {
                            foreach (var item in listviewitems.Items)
                            {
                                if (item.ToString().Equals(fileInfo.Name))
                                {
                                    listviewitems.SelectedItems.Add(item);
                                }
                                else
                                {

                                }
                            }
                        }
                }
            }
            //txtEditor.Text = File.ReadAllText(openFileDialog.FileName);
        }

        private void listviewitems_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            /* var item = (sender as ListView).SelectedItem;
             string name = "";
             if (item != null)
             {
                 for (int i = 0; i < queue.Count; i++)
                 {
                     name = queue.Dequeue();
                     FileInfo fileInfo = new FileInfo(name);
                     if (fileInfo.Name.Equals(item))
                     {
                         video.Stop();
                         video_MediaEnded(sender,e);
                         path = name;
                         this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);
                         name = "";
                     }
                     else
                     {
                         queue.Enqueue(name);
                         name = "";
                     }
                 }
             }*/
        }

        private void playlistAddgrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void playlistAddgrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Multiselect = true;
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (string filename in openFileDialog.FileNames)
                {
                    FileInfo fileInfo = new FileInfo(filename);
                    queue.Enqueue(filename);
                    listviewitems.Items.Add(fileInfo.Name);
                }

                if (queue.Any())
                {
                    if (isVideoPlaying)
                    {

                    }
                    else
                    {
                        //this.video.Source = new Uri(stack.Pop(), UriKind.RelativeOrAbsolute);

                        path = queue.Dequeue();
                        this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);

                        this.video.Play();
                        stopBtnGrid.Opacity = 1;
                        playBtnlabel.Content = "Pause";
                        isVideoPlaying = true;
                        try
                        {
                            FileInfo fileInfo = new FileInfo(path);
                            listviewitems.SelectedItems.Clear();
                            if (listviewitems.Items.Count > 0)
                            {
                                foreach (var item in listviewitems.Items)
                                {
                                    if (item.ToString().Equals(fileInfo.Name))
                                    {
                                        listviewitems.SelectedItems.Add(item);
                                    }
                                    else
                                    {

                                    }
                                }
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Exception", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                        }
                    }
                }
            }

        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
        {
                if (this.video.Source != null)
                {
                    this.video.Stop();
                    isVideoPlaying = false;
                    playBtnlabel.Content = "Play";
                    stopBtnGrid.Opacity = 0.5;
                }

        }

        private void repeatbtnGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void repeatbtnGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (repeatbtnGrid.Opacity == 0.5)
            {
                repeatbtnGrid.Opacity = 1;
            }
            else
            {
                repeatbtnGrid.Opacity = 0.5;
            }
           

        }

        private void video_MouseDown(object sender, MouseButtonEventArgs e)
        {
           /* if (e.ClickCount == 2 && fullscreen == false)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                fullscreen = true;
            }
            else if (e.ClickCount == 2 && fullscreen == true)
            {

                this.WindowStyle = WindowStyle.SingleBorderWindow;
                this.WindowState = WindowState.Normal;
                fullscreen = false;
            }*/
            
        }

        private void nextBtnGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void nextBtnGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if(queue.Count>0)
            {
                if (path !="")
                {
                    queue.Enqueue(path);
                    list.Add(path);
                    path = queue.Dequeue();
                    this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);

                    FileInfo fileInfo = new FileInfo(path);
                    listviewitems.SelectedItems.Clear();
                    if (listviewitems.Items.Count > 0)
                    {
                        foreach (var item in listviewitems.Items)
                        {
                            if (item.ToString().Equals(fileInfo.Name))
                            {
                                listviewitems.SelectedItems.Add(item);
                            }
                            else
                            {

                            }
                        }
                    }
                    //queue.Enqueue(path);
                }
                else
                {
                    path = queue.Dequeue();
                    this.video.Source = new Uri(path, UriKind.RelativeOrAbsolute);

                    FileInfo fileInfo = new FileInfo(path);
                    listviewitems.SelectedItems.Clear();
                    if (listviewitems.Items.Count > 0)
                    {
                        foreach (var item in listviewitems.Items)
                        {
                            if (item.ToString().Equals(fileInfo.Name))
                            {
                                listviewitems.SelectedItems.Add(item);
                            }
                            else
                            {

                            }
                        }
                    }
                }
            }
        }

        private void backBtnGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void backBtnGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (list.Count > 0)
            {
                string backPath = list.ElementAt(list.Count-1);
                list.RemoveAt(list.Count - 1);
                queue.Enqueue(path);
                path = "";
                this.video.Source = new Uri(backPath, UriKind.RelativeOrAbsolute);
            }
            else
            {
                MessageBox.Show("No videos in the Queue", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void volumeControl_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            video.Volume = e.NewValue;
            try
            {
                volumelbl.Content =Convert.ToInt32(((e.NewValue)*100)).ToString()+" %";
            }
            catch
            {

            }
        }

    }   
    
}
