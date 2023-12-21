using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
