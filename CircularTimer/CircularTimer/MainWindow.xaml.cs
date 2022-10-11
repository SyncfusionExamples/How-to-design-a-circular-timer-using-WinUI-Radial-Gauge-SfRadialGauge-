using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace CircularTimer
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        bool isCircularTimerOn = false;
        DispatcherTimer dispatcherTimer = null;

        public MainWindow()
        {
            this.InitializeComponent();

            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(1);
            dispatcherTimer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, object e)
        {
            if (isCircularTimerOn)
            {
                pointer.Value -= 1;
                if (pointer.Value == -1)
                {
                    isCircularTimerOn = false;
                    pointer.Value = 60;
                    timer.Text = "01:00";
                }
                else
                {
                    timer.Text = pointer.Value.ToString("00:00");
                }
            }
        }

        private void play_pause_Tapped(object sender, TappedRoutedEventArgs e)
        {
            isCircularTimerOn = !isCircularTimerOn;
            if (isCircularTimerOn)
            {
                play.Visibility = Visibility.Collapsed;
                pause.Visibility = Visibility.Visible;
                dispatcherTimer.Start();
            }
            else
            {
                play.Visibility = Visibility.Visible;
                pause.Visibility = Visibility.Collapsed;
                dispatcherTimer.Stop();
            }
        }
    }
}
