using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using De.HsFlensburg.cstime079.Logic.Ui.Base;

namespace De.HsFlensburg.cstime079.Logic.Ui.Wrapper
{
    public class TimerViewModel : ViewModelBase<Timer>
    {
        public TimerViewModel() { }
        public int secondsAbsolute
        {
            get
            {
                return Model.SecondsAbsolute;
            }
            set
            {
                Model.SecondsAbsolute = value;
            }
        }

        public string name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                Model.Name = value;
            }
        }

        public string hours
        {
            get
            {
                return Model.Hours;
            }
            set
            {
                Model.Hours = value;
            }
        }

        public string minutes
        {
            get
            {
                return Model.Minutes;
            }
            set
            {
                Model.Minutes = value;
            }
        }

        public string seconds
        {
            get
            {
                return Model.Seconds;
            }
            set
            {
                Model.Seconds = value;
            }
        }
        public void NewModelAssigned()
        {

        }
    }
}
