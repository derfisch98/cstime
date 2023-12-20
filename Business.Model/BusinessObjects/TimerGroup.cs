using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.cstime079.Business.Model.BusinessObjects
{
    public class TimerGroup: ObservableCollection<Timer>
    {
        public TimerGroup() 
        {
        }
        public string name {  get; set; }
        public void runAll() 
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].run();
            }
        }
    }
}
