using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using De.HsFlensburg.cstime079.Services.SerializationService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace De.HsFlensburg.cstime079.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        private ModelFileHandler modelFileHandler;
        private string serializationPath;
        public ICommand RenameValueInModelCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public TimerGroupViewModel timerGroup { get; set; }
        
        public MainWindowViewModel(TimerGroupViewModel viewModelGroup) 
        {
            RenameValueInModelCommand = new RelayCommand(RenameValueInModel);
            timerGroup = viewModelGroup;
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);
            modelFileHandler = new ModelFileHandler();
            serializationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\TimerSerialization\\Timers.cc";
        }

        private void RenameValueInModel()
        {
            //var collection = this.timerGroup.ItemsSource as timerGroup;
            var first = timerGroup.FirstOrDefault();
            Console.WriteLine(first.Model.name);
            first.Model.name = "rename in the model";
            Console.WriteLine("rename");
            Console.WriteLine(first.Model.name);
        }

        private void SaveModel()
        {
            modelFileHandler.WriteModelToFile(serializationPath, timerGroup.Model);
        }

        private void LoadModel()
        {
            timerGroup.Model = modelFileHandler.ReadModelFromFile(serializationPath);
        }
    }
}
