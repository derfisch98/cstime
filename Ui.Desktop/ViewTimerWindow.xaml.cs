using System;
using System.Threading.Tasks;
using System.Windows;

namespace De.HsFlensburg.cstime079.Ui.Desktop
{
    /// <summary>
    /// Interaction logic for ViewTimerWindow.xaml
    /// </summary>
    public partial class ViewTimerWindow : Window
    {
        public string name { get; set; }
        public int secondsAbsolute { get; set; }
        private bool stopClicked = false;
        public ViewTimerWindow()
        {
            InitializeComponent();
        }

        public ViewTimerWindow(string name, int secondsAbsolute)
        {
            this.name = name;
            this.secondsAbsolute = secondsAbsolute;
            InitializeComponent();
            nameField.Content = name;
            secondsField.Text = (secondsAbsolute % 60 < 10 ? "0" : "")
                + (secondsAbsolute % 60).ToString();
            minutesField.Text = (secondsAbsolute / 60 % 60 < 10 ? "0" : "")
                + (secondsAbsolute / 60 % 60).ToString();
            hoursField.Text = (secondsAbsolute / 3600 < 10 ? "0" : "")
                + (secondsAbsolute / 3600).ToString();

        }

        private async void timer_Start_Click(object sender, RoutedEventArgs e)
        {
            //
            int seconds = Int32.Parse(secondsField.Text) +
                Int32.Parse(minutesField.Text) * 60 +
                Int32.Parse(hoursField.Text) * 3600;
            await waitTimer(seconds);
            System.Media.SystemSounds.Exclamation.Play();
            MessageBox.Show("Timer \"" + name + "\" Completed");
            stopClicked = false;
        }

        async Task waitTimer(int seconds)
        {
            while (seconds > 0)
            {
                if (stopClicked)
                {
                    break;
                }
                await waitMil(999);
                seconds -= 1;
                secondsField.Text = (seconds % 60 < 10 ? "0" : "")
                    + (seconds % 60).ToString();
                minutesField.Text = (seconds / 60 % 60 < 10 ? "0" : "")
                    + (seconds / 60 % 60).ToString();
                hoursField.Text = (seconds / 3600 < 10 ? "0" : "")
                    + (seconds / 3600).ToString();
            }
        }

        async Task waitMil(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }

        private void timer_Stop_Click(object sender, RoutedEventArgs e)
        {
            stopClicked = true;
        }

        private void timer_Reset_Click(object sender, RoutedEventArgs e)
        {
            int seconds = secondsAbsolute;
            secondsField.Text = (seconds % 60 < 10 ? "0" : "")
                + (seconds % 60).ToString();
            minutesField.Text = (seconds / 60 % 60 < 10 ? "0" : "")
                + (seconds / 60 % 60).ToString();
            hoursField.Text = (seconds / 3600 < 10 ? "0" : "")
                + (seconds / 3600).ToString();
        }
    }
}
