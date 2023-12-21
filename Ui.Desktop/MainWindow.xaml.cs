using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
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

namespace De.HsFlensburg.cstime079.Ui.Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        { 
            InitializeComponent();
        }

        private void NewTimerDialog(object sender, EventArgs e)
        {
            NewTimerWindow newTimerWindow = new NewTimerWindow();
            newTimerWindow.ShowDialog();
        }

        private void OpenDataGridWindow(object sender, EventArgs e)
        {
            DataGridWindow dataGridWindow = new DataGridWindow();
            dataGridWindow.Show();
        }

        private async void timer_Start_Click(object sender, RoutedEventArgs e)
        {
            int seconds = Int32.Parse(secondsAbsoluteField.Text);
            await waitTimer(seconds);
            MessageBox.Show("Hol deine Pizza aus dem Ofen");
            Console.WriteLine(timerGrid.SelectedItem.ToString());
        }

        async Task waitTimer(int seconds)
        {
            while (seconds > 0)
            {
                Console.WriteLine(seconds);
                await waitMil(1000);
                seconds -= 1;
                secondsField.Text = (seconds % 60 < 10 ? "0" : "") + (seconds % 60).ToString();
                minutesField.Text = (seconds / 60 % 60 < 10 ? "0" : "") + (seconds / 60 % 60).ToString();
                hoursField.Text = (seconds / 3600 < 10 ? "0" : "") + (seconds / 3600).ToString();
            }
        }

        async Task waitMil(int milliseconds)
        {
            await Task.Delay(milliseconds);
        }
    }
}
