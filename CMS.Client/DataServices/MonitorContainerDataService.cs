using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Client.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace CMS.Client.DataServices
{
    public class MonitorContainerDataService:IDataService
    {
        public dynamic GenTestData()
        {
            ObservableCollection<MonitorViewModel> collection = new ObservableCollection<MonitorViewModel>();
            for (int i = 0; i < 3; i++)
            {
                collection.Add(new MonitorViewModel(SimpleIoc.Default.GetInstance<MonitorDataService>()));
            }
            return collection;
        }
    }
}
