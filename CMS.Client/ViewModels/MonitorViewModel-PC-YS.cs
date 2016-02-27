using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;
using CMS.Client.DataServices;
using CMS.Client.Views.Dialogs;
using CMS.Models.DTO;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;

namespace CMS.Client.ViewModels
{
    public class MonitorViewModel:ViewModelBase
    {
        private RelayCommand<object> _createMonitor = new RelayCommand<object>((content) =>
        {
            CreateMonitorDialog dialog = new CreateMonitorDialog();
            dialog.ShowDialog();
        });

        public string BedNum { get; set; }
        

        public ObservableCollection<WaveSimulatorViewModel> WaveViewModels { get; set; } = new ObservableCollection<WaveSimulatorViewModel>();

        public ICommand CreateMonitor
        {
            get { return _createMonitor; }
        }

        public MonitorViewModel(IDataService dataService)
        {
            this.BedNum = "Hehe";
            var wave = new WaveSimulatorViewModel(ServiceLocator.Current.GetInstance<IDataService>());
            //wave.Values.Add(new WaveValue() { ReceiveTime = DateTime.Now, Value = 0.8 });    
            WaveViewModels.Add(wave);
            
        }
    }
}
