﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Client.ViewModels;
using GalaSoft.MvvmLight.Ioc;

namespace CMS.Client.DataServices
{
    public class MainDataService:IDataService
    {
        public dynamic GenTestData()
        {
            ObservableCollection<MonitorContainerViewModel> collection = new ObservableCollection<MonitorContainerViewModel>();
            for (int i = 0; i < 3; i++)
            {
                collection.Add(new MonitorContainerViewModel(SimpleIoc.Default.GetInstance<MonitorContainerDataService>()));
            }
            return collection;
        }
    }
}
