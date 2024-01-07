using System;
using System.Collections.ObjectModel;

namespace De.HsFlensburg.cstime079.Business.Model.BusinessObjects
{
    [Serializable]
    public class TimerGroup : ObservableCollection<Timer>
    {
        public TimerGroup()
        {
        }
    }
}
