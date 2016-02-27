using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CMS.Client.DataServices;
using CMS.Models.DTO;
using GalaSoft.MvvmLight.Command;

namespace CMS.Client.ViewModels
{
    public class MainViewModel:CmsViewModelBase
    {
        private static MainViewModel _instance = null;
        private static readonly object SyncRoot = new object();
        
        private ObservableCollection<MonitorContainerViewModel> _monitorContainers = new ObservableCollection<MonitorContainerViewModel>();
        private readonly RelayCommand _addMonitorContainer = new RelayCommand(() =>
        {
            throw new NotImplementedException();
        });

        private readonly ICommand _openSettingsCommand;

        public ObservableCollection<MonitorContainerViewModel> MonitorContainers
        {
            get { return _monitorContainers; }
            set { Set(ref _monitorContainers, value); }
        }

        public ICommand AddMonitorContainer => _addMonitorContainer;

        public static MainViewModel Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (SyncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = new MainViewModel(SimpleIoc.Default.GetInstance<IDataService>());
                        }
                    }
                    return _instance;
                }
                return _instance;
            }
        }

        public ICommand OpenSettings => _openSettingsCommand;

        private MainViewModel(IDataService dataService)
        {

            dataService.GenTestData(this);
            //= dataService.Retrive<MonitorViewModel>() as ObservableCollection<MonitorViewModel>;
            _openSettingsCommand = new RelayCommand(()=>{});
        }

        public override void Cleanup()
        {
            foreach (MonitorContainerViewModel monitorContainer in MonitorContainers)
            {
                monitorContainer.Cleanup();
            }
            base.Cleanup();
        }
    }
}
