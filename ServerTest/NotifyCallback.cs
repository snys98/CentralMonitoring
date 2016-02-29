using CMS.DistributionService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerTest
{
    public class NotifyCallback : INotifyCallback
    {
        public void Notify(string message)
        {
            //Console.WriteLine("服务端通知：" + message);
        }
    }
}
