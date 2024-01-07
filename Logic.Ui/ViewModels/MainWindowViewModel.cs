using De.HsFlensburg.cstime079.Business.Model.BusinessObjects;
using De.HsFlensburg.cstime079.Logic.Ui.MessageBusMessages;
using De.HsFlensburg.cstime079.Logic.Ui.Wrapper;
using De.HsFlensburg.cstime079.Services.MessageBus;
using De.HsFlensburg.cstime079.Services.MessageBusWithParameter;
using De.HsFlensburg.cstime079.Services.SerializationService;
using System;
using System.IO;
using System.Windows.Input;

namespace De.HsFlensburg.cstime079.Logic.Ui.ViewModels
{
    public class MainWindowViewModel
    {
        private ModelFileHandler modelFileHandler;
        private string serializationPath;
        public ICommand SaveCommand { get; }
        public ICommand LoadCommand { get; }
        public ICommand RefreshCommand { get; }
        public ICommand OpenNewTimerWindowCommand { get; }
        public ICommand OpenDataGridCommand { get; }
        public ICommand OpenViewTimerCommand { get; }
        public ICommand DeleteEntryCommand { get; }
        public TimerGroupViewModel timerGroup { get; set; }
        public TimerViewModel selectedTimer { get; set; }
        public int SelectedIndex { get; set; }

        public TimerViewModel SelectedTimer
        {
            get => selectedTimer;
            set
            {
                selectedTimer = value;
                TimerSelectedMessage messageObj = new TimerSelectedMessage
                {
                    Name = value.name,
                    SecondsAbsolute = value.secondsAbsolute
                };
                Messenger.Instance.Send<TimerSelectedMessage>(messageObj);
            }
        }

        public MainWindowViewModel(TimerGroupViewModel viewModelGroup)
        {
            timerGroup = viewModelGroup;
            SaveCommand = new RelayCommand(SaveModel);
            LoadCommand = new RelayCommand(LoadModel);
            RefreshCommand = new RelayCommand(RefreshModel);
            OpenNewTimerWindowCommand = new RelayCommand(OpenNewTimerWindow);
            OpenDataGridCommand = new RelayCommand(OpenDataGrid);
            OpenViewTimerCommand = new RelayCommand(OpenViewTimerWindow);
            DeleteEntryCommand = new RelayCommand(DeleteEntry);
            modelFileHandler = new ModelFileHandler();
            serializationPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
                + "\\cstime\\Timers.tgp";
            LoadModel();
        }

        private void SaveModel()
        {
            // very illegal serialization fix
            /*
            var tg = timerGroup;
            for (int i = 0; i < tg.Count; i++)
            {
                timerGroup.Model[i].Name = tg[i].name;
                timerGroup.Model[i].SecondsAbsolute = tg[i].secondsAbsolute;
            }
            */
            modelFileHandler.WriteModelToFile(serializationPath, timerGroup.Model);
        }

        private void LoadModel()
        {
            string folderPath = Path.GetDirectoryName(serializationPath);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }
            if (!File.Exists(serializationPath))
            {
                TimerGroup newGroup = new TimerGroup();
                modelFileHandler.WriteModelToFile(serializationPath, newGroup);
            }
            timerGroup.Model = modelFileHandler.ReadModelFromFile(serializationPath);
            // see comment above
            /*
            for (int i = 0;i < timerGroup.Model.Count; i++)
            {
                timerGroup[i].name = timerGroup.Model[i].Name;
                timerGroup[i].secondsAbsolute = timerGroup.Model[i].SecondsAbsolute;
            }
            */
        }

        private void RefreshModel()
        {
            SaveModel();
            LoadModel();
        }

        private void OpenNewTimerWindow()
        {
            ServiceBus.Instance.Send(new OpenNewTimerWindowMessage());
        }
        private void OpenDataGrid()
        {
            ServiceBus.Instance.Send(new OpenDataGridMessage());
        }
        private void OpenViewTimerWindow()
        {
            // Command="{Binding Source={StaticResource viewModelLocator},
            // Path=mainWindowViewModel.OpenViewTimerCommand}"

            //ServiceBus.Instance.Send(new OpenViewTimerWindowMessage());
            OpenViewTimerWindowMessage messageObject = new OpenViewTimerWindowMessage();
            messageObject.msgName = selectedTimer.name;
            messageObject.msgSecondsAbsolute = selectedTimer.secondsAbsolute;
            Messenger.Instance.Send<OpenViewTimerWindowMessage>(messageObject);
        }

        private void DeleteEntry()
        {
            try
            {
                timerGroup.RemoveAt(SelectedIndex);
            }
            catch
            {
                // No Timer Selected
            }
        }
    }
}
