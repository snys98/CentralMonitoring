using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using CMS.Client.DataServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CMS.Client.ViewModels
{
    public class MonitorContainerViewModel:CmsViewModelBase<MonitorContainerDataService>
    {
        private int _rowCount = 2;
        private int _columeCount = 3;
        private readonly RelayCommand _closeCommand;
        private static MonitorViewModel _selectedMonitor;


        public int RowCount
        {
            get { return _rowCount; }
            set { Set(ref _rowCount, value); }
        }
        public int ColumeCount
        {
            get { return _columeCount; }
            set
            {
                Set(ref _columeCount, value);
            }
        }
        public ICommand Close => _closeCommand;
        public string Name => "哈哈";
        public ObservableCollection<MonitorViewModel> Monitors { get; set; } = new ObservableCollection<MonitorViewModel>();

        public static MonitorViewModel SelectedMonitor
        {
            get { return _selectedMonitor; }
            set
            {
                _selectedMonitor = value;
                MainViewModel.Current.SelectedMonitor = value;
            }
        }

        public MonitorContainerViewModel(MonitorContainerDataService dataService)
            :base(dataService)
        {
            _closeCommand = new RelayCommand(this.Cleanup);
            //this._dataService = dataService;
            this.Monitors = DataService.GenTestData();
            
        }
        
        public override void Cleanup()
        {
            foreach (MonitorViewModel monitor in Monitors)
            {
                monitor.IsMonitoring = false;
                monitor.Cleanup();
            }
            base.Cleanup();
        }
    }
}
