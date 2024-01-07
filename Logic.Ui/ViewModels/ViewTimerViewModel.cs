using De.HsFlensburg.cstime079.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using De.HsFlensburg.cstime079.Services.MessageBusWithParameter;

namespace De.HsFlensburg.cstime079.Logic.Ui.ViewModels
{
    public class ViewTimerViewModel
    {
        public string Name { get; set; }
        public int SecondsAbsolute { get; set; }
        public int Initial;
        public TimerGroupViewModel TimerGroupViewModel { get; }
        public ViewTimerViewModel(TimerGroupViewModel timerGroupViewModel)
        {
            TimerGroupViewModel = timerGroupViewModel;
            Messenger.Instance.Register<TimerSelectedMessage>(this, OnTimerSelected);
            Initial = SecondsAbsolute;
        }

        private void OnTimerSelected(TimerSelectedMessage msg)
        {
            Name = msg.Name;
            SecondsAbsolute = msg.SecondsAbsolute;
        }

    }
}
