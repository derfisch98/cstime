using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using System.Windows.Input;

namespace De.HsFlensburg.cstime079.Logic.Ui.ViewModels
{
    public class NewTimerViewModel
    {
        public string name { get; set; }
        public int seconds { get; set; }
        public int minutes { get; set; }
        public int hours { get; set; }
        public ICommand AddTimer { get; }
        private TimerGroupViewModel TimerGroup;

        public NewTimerViewModel(TimerGroupViewModel viewModelGroup)
        {
            AddTimer = new RelayCommand(AddTimerMethod);
            TimerGroup = viewModelGroup;
        }

        private void AddTimerMethod()
        {
            TimerViewModel timerViewModel = new TimerViewModel();
            timerViewModel.name = name;
            timerViewModel.secondsAbsolute = seconds + (minutes * 60) + (hours * 3600);
            TimerGroup.Add(timerViewModel);
        }
    }
}
