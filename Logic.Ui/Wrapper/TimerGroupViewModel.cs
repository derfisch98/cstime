using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using De.HsFlensburg.cstime079.Logic.Ui.Base;
using System.ComponentModel;

namespace De.HsFlensburg.cstime079.Logic.Ui.Wrapper
{
    public class TimerGroupViewModel : ViewModelSyncCollection<TimerViewModel, Timer, TimerGroup>
    {
        public TimerGroupViewModel() { }

        public void NewModelAssigned()
        {
            foreach (var timer in this)
            {
                var modelPropChanged = timer.Model as INotifyPropertyChanged;
                if (modelPropChanged != null)
                {
                    modelPropChanged.PropertyChanged += timer.OnPropertyChangedInModel;
                }
            }
        }
    }
}
