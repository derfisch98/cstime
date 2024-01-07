using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;

namespace De.HsFlensburg.cstime079.Logic.Ui.ViewModels
{
    public class DataGridViewModel
    {
        public TimerGroupViewModel timerGroup { get; set; }
        public DataGridViewModel(TimerGroupViewModel viewModelGroup)
        {
            timerGroup = viewModelGroup;
        }
    }
}
