using CMS.DistributionService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Implemention
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class NotifyService : INotifyService
    {
        private static List<INotifyCallback> list = new List<INotifyCallback>();
        public void Close()
        {
            throw new NotImplementedException();
        }

        public void Connect()
        {
            list.Add(OperationContext.Current.GetCallbackChannel<INotifyCallback>());
            if (list.Count == 1) Send();
            Console.WriteLine(OperationContext.Current.SessionId);
        }

        private void Send()
        {

            Task.Run(() =>
            {
                while (true)
                {
                    list.ForEach(m => { m.Notify(DateTime.Now.ToString()); });
                    System.Threading.Thread.Sleep(10);
                }
            });
        }

    }
}
