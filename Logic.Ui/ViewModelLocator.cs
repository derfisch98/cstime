using De.HsFlensburg.cstime079.Logic.Ui.ViewModels;
using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;

namespace De.HsFlensburg.cstime079.Logic.Ui
{
    public class ViewModelLocator
    {
        public TimerGroupViewModel TimerGroupViewModel { get; set; }
        public MainWindowViewModel MainWindowViewModel { get; set; }
        public NewTimerViewModel NewTimerViewModel { get; set; }
        public DataGridViewModel DataGridViewModel { get; set; }
        public ViewTimerViewModel ViewTimerViewModel { get; set; }

        public ViewModelLocator()
        {
            TimerGroupViewModel = new TimerGroupViewModel();
            MainWindowViewModel = new MainWindowViewModel(TimerGroupViewModel);
            NewTimerViewModel = new NewTimerViewModel(TimerGroupViewModel);
            DataGridViewModel = new DataGridViewModel(TimerGroupViewModel);
            ViewTimerViewModel = new ViewTimerViewModel(TimerGroupViewModel);
        }
    }
}
