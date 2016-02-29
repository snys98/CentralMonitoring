using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            ServiceMapsSection serviceMaps = (ServiceMapsSection)System.Configuration.ConfigurationManager.GetSection("ServiceMaps");
            string url = ConfigurationManager.AppSettings["WcfBaseAddress"];
            //Console.WriteLine(ServiceMaps.Services[0].Maps[0].Face);
            //先将程序集全部加载 
            Dictionary<string, string> loaded = new Dictionary<string, string>();
            Parallel.For(0, serviceMaps.Services.Count, (i) =>
             {
                 var face = serviceMaps.Services[i].InterfaceDll;
                 var real = serviceMaps.Services[i].ImplementionDll;
                 if (!loaded.ContainsKey(face))
                 {
                     Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, face) + ".dll");
                     loaded.Add(face, face);
                 }
                 if (!loaded.ContainsKey(real))
                 {
                     Assembly.LoadFrom(Path.Combine(Environment.CurrentDirectory, real) + ".dll");
                     loaded.Add(real, real);
                 }

                 for (int j = 0; j < serviceMaps.Services[i].Maps.Count; j++)
                 {
                     var itype = Type.GetType(serviceMaps.Services[i].Maps[j].Face + "," + face);
                     var type = Type.GetType(serviceMaps.Services[i].Maps[j].Real + "," + real);
                     AddService(type, itype, url);
                 }
             });
            Console.WriteLine("服务已启动");
            Console.ReadLine();
        }

        private static void AddService(Type type, Type iType, string url)
        {
            ServiceHost host = new ServiceHost(type);
            NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            nb.ReliableSession.InactivityTimeout = TimeSpan.FromDays(1);
            nb.MaxBufferPoolSize = int.MaxValue;
            nb.MaxBufferSize = int.MaxValue;
            nb.MaxReceivedMessageSize = int.MaxValue;
            nb.MaxConnections = 1000;      

            host.AddServiceEndpoint(iType, nb, string.Concat(url, iType.Name));
            host.Open();
        }
    }
}
