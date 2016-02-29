using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Threading;
using CMS.Models.DTO;
using CMS.Client.ViewModels;
using GalaSoft.MvvmLight;
using Microsoft.Practices.ServiceLocation;

namespace CMS.Client.DataServices
{
    internal class DataService:IDataService
    {
        public T Retrive<T>() where T : new()
        {
            return new T();
        }

        public dynamic GenTestData(CmsViewModelBase vm)
        {
            switch (vm.GetType().Name)
            {
                case nameof(MainViewModel):
                    for (int i = 0; i < 1; i++)
                    {
                        (vm as MainViewModel).MonitorContainers.Add(new MonitorContainerViewModel(ServiceLocator.Current.GetInstance<IDataService>()));
                    }
                    return null;
                case nameof(MonitorContainerViewModel):
                    for (int i = 0; i < 6; i++)
                    {
                        (vm as MonitorContainerViewModel).Monitors.Add(new MonitorViewModel(ServiceLocator.Current.GetInstance<IDataService>()) { BedNum = "hehe" });
                    }
                    return null;
                case nameof(WaveSimulatorViewModel):
                    for (int i = 0; i < 3; i++)
                    {
                        (vm as WaveSimulatorViewModel).WaveValues = GetValues("Waveform.txt").GetEnumerator();
                    }
                    return null;
                default: throw new InvalidOperationException("不支持给该VM生成测试数据!");
            }
        }

        #region 生成测试数据的方法
        private IEnumerable<WaveValue> GetValues(string filename)
        {
            var values = new List<decimal>();
            var asm = Assembly.GetExecutingAssembly();
            var resourceString = asm.GetManifestResourceNames().Single(x => x.Contains(filename));
            using (var stream = asm.GetManifestResourceStream(resourceString))
            using (var streamReader = new StreamReader(stream))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    values.Add(decimal.Parse(line, NumberFormatInfo.InvariantInfo));
                    line = streamReader.ReadLine();
                }
            }
            while (true)
            {
                for (int i = 0; i < values.Count; i++)
                {

                    yield return new WaveValue()
                    {
                        ReceiveTime = DateTime.Now,
                        Value = values[i]
                    };
                    if (i == values.Count - 1)
                    {
                        i = 0;
                    }
                }
            }
        }
        #endregion
    }
}