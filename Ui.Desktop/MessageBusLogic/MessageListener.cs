using De.HsFlensburg.cstime079.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.cstime079.Logic.Ui.ViewModels;
using De.HsFlensburg.cstime079.Services.MessageBus;
using De.HsFlensburg.cstime079.Services.MessageBusWithParameter;

namespace De.HsFlensburg.cstime079.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
            InitMessengerWithParameter();
        }

        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenNewTimerWindowMessage>(this, OpenNewTimerWindow);
            ServiceBus.Instance.Register<OpenDataGridMessage>(this, OpenDataGrid);
        }

        private void InitMessengerWithParameter()
        {
            Messenger.Instance.Register<OpenViewTimerWindowMessage>(
                this, delegate (OpenViewTimerWindowMessage message)
            {
                ViewTimerWindow viewTimerWindow = new ViewTimerWindow(
                    message.msgName, message.msgSecondsAbsolute);
                ((ViewTimerViewModel)viewTimerWindow.DataContext).Name = message.msgName;
                ((ViewTimerViewModel)viewTimerWindow.DataContext).SecondsAbsolute
                = message.msgSecondsAbsolute;
                viewTimerWindow.Show();
            });
        }

        private void OpenNewTimerWindow()
        {
            NewTimerWindow newTimerWindow = new NewTimerWindow();
            newTimerWindow.Show();
        }

        private void OpenDataGrid()
        {
            DataGridWindow dataGridWindow = new DataGridWindow();
            dataGridWindow.Show();
        }
        /*
        private void OpenViewTimerWindow()
        {
            ViewTimerWindow viewTimerWindow = new ViewTimerWindow();
            viewTimerWindow.Show();
        }
        */
    }
}
