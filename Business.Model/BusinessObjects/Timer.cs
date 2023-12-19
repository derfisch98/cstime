using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.cstime079.Business.Model.BusinessObjects
{
    internal class Timer
    {
        private Int32 secondsAbsolute;
        private Int32 initial;
        private Int32 hours;
        private Int32 minutes;
        private Int32 seconds;
        private string name {  get; set; }
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

        public void run()
        {
            while (secondsAbsolute >= 0)
            {
                Console.Clear();
                Console.WriteLine("Timer " + this.name);
                Console.WriteLine(getHours() + ":" + getMinutes() + ":" + getSeconds());
                System.Threading.Thread.Sleep(1000);
                secondsAbsolute -= 1;
            }
        }

        public void reset()
        {
            secondsAbsolute = initial;
        }
        
        public string getHours()
        {
            return secondsAbsolute / 3600 < 10 ? "0" : "" + (secondsAbsolute / 3600).ToString();
        }

        public string getMinutes()
        {
            return secondsAbsolute / 60 % 60 < 10 ? "0" : "" + (secondsAbsolute / 60 % 60).ToString();
        }

        public string getSeconds()
        {
            return secondsAbsolute % 60 < 10 ? "0" : "" + (secondsAbsolute % 60).ToString();
        }
    }
}
