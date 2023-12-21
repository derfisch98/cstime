using De.HsFlensburg.cstime079.Logic.Ui.ViewModels;
using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.cstime079.Logic.Ui
{
    public class ViewModelLocator
    {
        public TimerGroupViewModel timerGroupViewModel { get; set; }
        public MainWindowViewModel mainWindowViewModel { get; set; }
        public NewTimerViewModel newTimerViewModel { get; set; }
        public DataGridViewModel dataGridViewModel { get; set; }

        public ViewModelLocator() 
        {
            timerGroupViewModel = new TimerGroupViewModel();
            mainWindowViewModel = new MainWindowViewModel(timerGroupViewModel);
            newTimerViewModel = new NewTimerViewModel(timerGroupViewModel);
            dataGridViewModel = new DataGridViewModel(timerGroupViewModel);
        }
    }
}
