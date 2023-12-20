using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;

namespace De.HsFlensburg.cstime079.Logic.Ui.Base
{
    public interface IViewModel<TypeOfModel> : INotifyPropertyChanged
    {
        TypeOfModel Model { get; set; }

        void NewModelAssigned();
    }
}
