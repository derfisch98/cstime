using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace De.HsFlensburg.cstime079.Business.Model.BusinessObjects
{
    [Serializable]
    public class Timer : INotifyPropertyChanged
    {
        public int secondsAbsolute {  get; set; }
        private int initial;

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public string name {  get; set; }

        public Timer() { }
        public Timer(int seconds, string name)
        {
            this.secondsAbsolute = seconds;
            this.name = name;
            initial = secondsAbsolute;

        }

        public Timer(int hours = 0, int minutes = 0, int seconds = 0)
        {
            secondsAbsolute = (hours * 3600) + (minutes * 60) + seconds;
            initial = secondsAbsolute;
        }

        public string getHours()
        {
            return (secondsAbsolute / 3600 < 10 ? "0" : "") + (secondsAbsolute / 3600).ToString();
        }

        public string getMinutes()
        {
            return (secondsAbsolute / 60 % 60 < 10 ? "0" : "") + (secondsAbsolute / 60 % 60).ToString();
        }

        public string getSeconds()
        {
            return (secondsAbsolute % 60 < 10 ? "0" : "") + (secondsAbsolute % 60).ToString();
        }

        public void setTime(int hours, int seconds, int minutes)
        {
            initial = hours * 3600 + minutes * 60 + seconds;
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
