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
    public class MonitorService : IMonitorService
    {
        private int i = 0;
        public void AddMonitor(string bedno)
        {
            i++;
            Console.WriteLine(i);
            Console.WriteLine("AddMonitor" + OperationContext.Current.SessionId);
        }

        public void RemoveMonitor(string bedno)
        {
            throw new NotImplementedException();
        }
    }
}
