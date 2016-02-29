using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Service.Proxy
{
    public class Service
    {
        private static Dictionary<string, IClientChannel> _channel = null;
        static Service()
        {
            _channel = new Dictionary<string, IClientChannel>();
        }
        public static void Use<TChannel>(Action<TChannel> action)
        {
            EndpointAddress address = new EndpointAddress(string.Concat(Settings.WcfBaseAddress, typeof(TChannel).Name));
            NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            //NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            nb.ReliableSession.InactivityTimeout = TimeSpan.FromDays(1);
            nb.MaxBufferPoolSize = int.MaxValue;
            nb.MaxBufferSize = int.MaxValue;
            nb.MaxReceivedMessageSize = int.MaxValue;
            nb.MaxConnections = 1000;
            var chanFactory = new ChannelFactory<TChannel>(nb, address);
            TChannel channel = chanFactory.CreateChannel();
            System.Diagnostics.Stopwatch owatch = new System.Diagnostics.Stopwatch();
            owatch.Start();
            ((IClientChannel)channel).Open();
            owatch.Stop();
            Console.WriteLine("打开耗时：" + owatch.ElapsedMilliseconds.ToString());
            action(channel);
            try
            {
                System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
                watch.Start();
                ((IClientChannel)channel).Close();
                watch.Stop();
                Console.WriteLine("关闭耗时：" + watch.ElapsedMilliseconds.ToString());
            }
            catch
            {
                ((IClientChannel)channel).Abort();
            }
        }


        public static void RegisterDuplex<TChannel, TCallback>(TCallback callback, Action<TChannel> action) where TCallback : class
        {
            EndpointAddress address = new EndpointAddress(string.Concat(Settings.WcfBaseAddress, typeof(TChannel).Name));
            //NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            nb.ReliableSession.InactivityTimeout = TimeSpan.FromDays(1);
            nb.MaxBufferPoolSize = int.MaxValue;
            nb.MaxBufferSize = int.MaxValue;
            nb.MaxReceivedMessageSize = int.MaxValue;
            nb.MaxConnections = 1000;
            InstanceContext context = new InstanceContext(callback);
            var chanFactory = new DuplexChannelFactory<TChannel>(context, nb, address);
            TChannel channel = chanFactory.CreateChannel();
            ((IClientChannel)channel).Open();
            action(channel);
            _channel.Add(typeof(TChannel).FullName, (IClientChannel)channel);
            //try
            //{
            //    ((IClientChannel)channel).Close();
            //}
            //catch
            //{
            //    ((IClientChannel)channel).Abort();
            //}
        }
    }
}
