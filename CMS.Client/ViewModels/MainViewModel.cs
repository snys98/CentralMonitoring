﻿using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using CMS.Client.DataServices;
using CMS.Models.DTO;
using GalaSoft.MvvmLight.Command;

namespace CMS.Client.ViewModels
{
    public class MainViewModel:CmsViewModelBase<MainDataService>
    {
        private static MainViewModel _instance = null;
        private static readonly object SyncRoot = new object();
        
        private ObservableCollection<MonitorContainerViewModel> _monitorContainers = new ObservableCollection<MonitorContainerViewModel>();
        private readonly RelayCommand _addMonitorContainer = new RelayCommand(() =>
        {
            throw new NotImplementedException();
        });

        private readonly ICommand _openSettingsCommand;
        private MonitorViewModel _selectedMonitor;

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
                            _instance = new MainViewModel(SimpleIoc.Default.GetInstance<MainDataService>());
                        }
                    }
                    return _instance;
                }
                return _instance;
            }
        }

        public ICommand OpenSettings => _openSettingsCommand;

        public MonitorViewModel SelectedMonitor
        {
            get { return _selectedMonitor; }
            set { Set(ref _selectedMonitor , value); }
        }


        private MainViewModel(MainDataService dataService)
            :base(dataService)
        {

            this.MonitorContainers = DataService.GenTestData();
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
