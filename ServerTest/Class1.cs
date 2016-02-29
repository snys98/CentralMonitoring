using CMS.DistributionService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest
{
    public class Class1
    {
        public static void Main()
        {
            CMS.Service.Proxy.Service.Use<ILogService>((s) =>
            {
                s.SaveLog(new CMS.Models.DTO.SystemLog()
                { Level = CMS.Models.DTO.LogLevel.Error, Content = "客户端调用" });
            });
            CMS.Service.Proxy.Service.Use<IMonitorService>((s) =>
            {
                s.AddMonitor("01");
            });
            CMS.Service.Proxy.Service.Use<IMonitorService>((s) =>
            {
                s.AddMonitor("02");
            });
            NotifyCallback back = new NotifyCallback();
            CMS.Service.Proxy.Service.RegisterDuplex<INotifyService, NotifyCallback>(back,
                s =>
                {
                    s.Connect();
                });
            Console.ReadLine();
        }
    }
}
