using System.ComponentModel;

namespace De.HsFlensburg.cstime079.Logic.Ui.Base
{
    public interface IViewModel<TOfModel> : INotifyPropertyChanged
    {
        TOfModel Model { get; set; }

        void OnPropertyChangedInModel(object sender, PropertyChangedEventArgs e);
    }
}
