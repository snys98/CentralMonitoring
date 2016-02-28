using System;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using CMS.Client.DataServices;

namespace CMS.Client.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>(() => MainViewModel.Current);
            //todo,泛型DataService
            SimpleIoc.Default.Register<MainDataService, MainDataService>();
            SimpleIoc.Default.Register<MonitorDataService, MonitorDataService>();
            SimpleIoc.Default.Register<MonitorContainerDataService, MonitorContainerDataService>();
            SimpleIoc.Default.Register<WaveSimulatorDataService, WaveSimulatorDataService>();
        }

        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();

        //public MonitorViewModel MonitorViewModel => ServiceLocator.Current.GetInstance<MonitorViewModel>();

        public static void Cleanup()
        {
            
        }
    }
}
