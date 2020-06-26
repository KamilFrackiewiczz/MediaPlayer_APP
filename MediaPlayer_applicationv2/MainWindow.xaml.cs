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
using System.Windows.Threading;

namespace MediaPlayer_applicationv2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += Timer_Tick;


            InitializeComponent();
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSlider.Value = MyMediaVideo.Position.TotalSeconds;   
        }

        private void ButtonPlay(object sender, RoutedEventArgs e)
        {
            MyMediaVideo.Play();
            timer.Start();
            
        }

        private void ButtonPause(object sender, RoutedEventArgs e)
        {
            MyMediaVideo.Pause();
            timer.Stop();
        }

        private void ButtonStop(object sender, RoutedEventArgs e)
        {
            MyMediaVideo.Stop();
            timer.Stop();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            MyMediaVideo.ScrubbingEnabled = true;
            MyMediaVideo.Stop();
        }

        private void MyMediaVideo_MediaOpened(object sender, RoutedEventArgs e)
        {
            TimeSlider.Maximum = MyMediaVideo.NaturalDuration.TimeSpan.TotalSeconds;
            MyMediaVideo.Play();
            MyMediaVideo.Stop();
        }

        private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            
            MyMediaVideo.Position = TimeSpan.FromSeconds(TimeSlider.Value);
            
        }

        private void TimeSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            MyMediaVideo.Pause();
            timer.Stop();
        }

        private void TimeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            MyMediaVideo.Play();
        }
    }
}
