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
            SimpleIoc.Default.Register<MonitorViewModel>();
            SimpleIoc.Default.Register<WaveSimulatorViewModel>();
            //todo,泛型DataService
            SimpleIoc.Default.Register<IDataService, DataService>();
        }
        public string GetByConverterWithKey => String.Empty;
        public MainViewModel MainViewModel => ServiceLocator.Current.GetInstance<MainViewModel>();
        public MonitorViewModel MonitorViewModel => ServiceLocator.Current.GetInstance<MonitorViewModel>();
        public WaveSimulatorViewModel WaveSimulatorViewModel => ServiceLocator.Current.GetInstance<WaveSimulatorViewModel>();

        //public MonitorViewModel MonitorViewModel => ServiceLocator.Current.GetInstance<MonitorViewModel>();

        public static void Cleanup()
        {
            
        }
    }
}
