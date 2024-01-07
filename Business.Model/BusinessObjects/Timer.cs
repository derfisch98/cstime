using System;
using System.ComponentModel;

namespace De.HsFlensburg.cstime079.Business.Model.BusinessObjects
{
    [Serializable]
    public class Timer : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;
        private int secondsAbsolute;
        public int SecondsAbsolute
        {
            get { return secondsAbsolute; }
            set
            {
                secondsAbsolute = value;
                OnPropertyChanged("secondsAbsolute");
            }
        }
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }

        private string hours;
        public string Hours
        {
            get
            {
                return (secondsAbsolute / 3600 < 10 ? "0" : "")
                    + (secondsAbsolute / 3600).ToString();
            }
            set
            {
                hours = value;
                OnPropertyChanged("hours");
            }
        }
        private string minutes;

        public string Minutes
        {
            get
            {
                return (secondsAbsolute / 60 % 60 < 10 ? "0" : "")
                    + (secondsAbsolute / 60 % 60).ToString();
            }
            set
            {
                minutes = value;
                OnPropertyChanged("minutes");
            }
        }
        private string seconds;

        public string Seconds
        {
            get
            {
                return (secondsAbsolute % 60 < 10 ? "0" : "")
                    + (secondsAbsolute % 60).ToString();
            }
            set
            {
                seconds = value;
                OnPropertyChanged("seconds");
            }
        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
