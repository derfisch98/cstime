using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using De.HsFlensburg.cstime079.Logic.Ui.Base;

namespace De.HsFlensburg.cstime079.Logic.Ui.Wrapper
{
    public class TimerGroupViewModel : ViewModelSyncCollection<TimerViewModel, Timer, TimerGroup>
    {
        public override void NewModelAssigned()
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
