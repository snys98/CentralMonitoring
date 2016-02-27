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
        public static void Use<TChannel>(Action<TChannel> action)
        {
            EndpointAddress address = new EndpointAddress(string.Format("net.tcp://{0}:{1}/", Settings.ServerIP, Settings.ServerPort) + typeof(TChannel).Name);
            NetTcpBinding nb = new NetTcpBinding(SecurityMode.None);
            var chanFactory = new ChannelFactory<TChannel>(nb, address);
            TChannel channel = chanFactory.CreateChannel();
            ((IClientChannel)channel).Open();
            action(channel);
            try
            {
                ((IClientChannel)channel).Close();
            }
            catch
            {
                ((IClientChannel)channel).Abort();
            }
        }
    }
}
