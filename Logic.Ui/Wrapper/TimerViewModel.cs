using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using De.HsFlensburg.cstime079.Logic.Ui.Base;

namespace De.HsFlensburg.cstime079.Logic.Ui.Wrapper
{
    public class TimerViewModel : ViewModelBase<Timer>
    {
        private Timer timer = new Timer();
        public TimerViewModel(Timer timer) 
        {
            this.timer = timer;
        }
        public TimerViewModel() { }
        public Int32 secondsAbsolute
        {
            get
            {
                return timer.secondsAbsolute;
            }
            set
            {
                timer.secondsAbsolute = value;
            }
        }

        public string name
        {
            get
            { 
                return timer.name; 
            }
            set
            {
                timer.name = value;
            }
        }

        public string hours
        {
            get
            {
                return timer.getHours();
            }
            set
            {
                //
            }
        }

        public string minutes
        {
            get
            {
                return timer.getMinutes();
            }
            set
            {
                //
            }
        }

        public string seconds
        {
            get
            {
                return timer.getSeconds();
            }
            set
            {
                //
            }
        }

        public override void NewModelAssigned()
        {
            throw new NotImplementedException();
        }
    }
}
