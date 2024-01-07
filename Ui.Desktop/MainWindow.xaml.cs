using De.HsFlensburg.cstime079.Logic.Ui.ViewModels;
using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using System;
using System.Windows;
using System.Windows.Controls;

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

        private void Debug_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("debug");
        }

        private void View_Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Button btn = (Button)sender;
                TimerViewModel selected = (TimerViewModel)btn.DataContext;
                /*
                OpenViewTimerWindowMessage messageObject = new OpenViewTimerWindowMessage();
                messageObject.msgName = selected.name;
                messageObject.msgSecondsAbsolute = selected.secondsAbsolute;
                Messenger.Instance.Send<OpenViewTimerWindowMessage>(messageObject);
                */

                ViewTimerWindow window = new ViewTimerWindow(selected.name, selected.secondsAbsolute);
                window.Show();
            }
            catch
            {
                // Dead element clicked
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mvm = (MainWindowViewModel)this.DataContext;
            mvm.SaveCommand.Execute(null);
        }
    }
}
