using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace De.HsFlensburg.cstime079.Business.Model.BusinessObjects
{
    internal class TimerGroup: List<Timer>
    {
        private string name {  get; set; }
        public void runAll() 
        {
            for (int i = 0; i < this.Count; i++)
            {
                this[i].run();
            }
        }
    }
}
