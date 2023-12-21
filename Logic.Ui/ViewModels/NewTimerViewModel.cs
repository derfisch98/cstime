using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.cstime079.Logic.Ui.ViewModels
{
    public class NewTimerViewModel
    {
        public string name {  get; set; }
        public int seconds { get; set; }
        public int minutes { get; set; }
        public int hours { get; set; }
        public ICommand addTimer { get; }
        private TimerGroupViewModel timerGroupViewModel;
        
        public NewTimerViewModel(TimerGroupViewModel viewModelGroup) 
        {
            addTimer = new RelayCommand(addTimerMethod);
            timerGroupViewModel = viewModelGroup;
        }

        private void addTimerMethod()
        {
            TimerViewModel timerViewModel = new TimerViewModel();
            timerViewModel.name = name;
            timerViewModel.secondsAbsolute = seconds + (minutes * 60) + (hours * 3600);
            timerGroupViewModel.Add(timerViewModel);
        }
    }
}
