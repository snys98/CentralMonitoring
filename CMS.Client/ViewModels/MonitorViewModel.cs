﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using CMS.Client.DataServices;
using CMS.Client.Views.Dialogs;
using CMS.Models.DTO;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace CMS.Client.ViewModels
{
    public class MonitorViewModel:CmsViewModelBase
    {
        private RelayCommand<MonitorViewModel> _attachMonitor = new RelayCommand<MonitorViewModel>((vm) =>
        {
            //SimpleIoc.Default.Register<MonitorViewModel>(() => vm,"Attach");
            CreateMonitorDialog dialog = new CreateMonitorDialog(vm);
        });

        private bool _isMonitoring = false;


        public string BedNum { get; set; }

        public bool IsMonitoring
        {
            get { return _isMonitoring; }
            set { Set(ref _isMonitoring, value); }
        }


        public ObservableCollection<WaveSimulatorViewModel> WaveViewModels { get; set; } = new ObservableCollection<WaveSimulatorViewModel>();

        public ICommand AttachMonitor => _attachMonitor;

        public MonitorViewModel(IDataService dataService)
        {
            this.BedNum = "Hehe";
            var wave = new WaveSimulatorViewModel(ServiceLocator.Current.GetInstance<IDataService>());
            //wave.Values.Add(new WaveValue() { ReceiveTime = DateTime.Now, Value = 0.8 });    
            WaveViewModels.Add(wave);
            
        }
    }
}
