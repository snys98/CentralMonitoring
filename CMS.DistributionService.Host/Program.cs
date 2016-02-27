using System;
using System.Collections.Generic;
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
                     AddService(type, itype);
                 }
             });
            Console.WriteLine("服务已启动");
            Console.ReadLine();
        }

        private static void AddService(Type type, Type iType)
        {
            ServiceHost host = new ServiceHost(type);
            NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            host.AddServiceEndpoint(iType, nb, string.Concat("net.tcp://", "127.0.0.1", ":", 19527, "/", iType.Name));
            host.Open();
        }
    }
}
