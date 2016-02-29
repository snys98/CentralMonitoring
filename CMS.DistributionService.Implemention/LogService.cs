using CMS.DistributionService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.DTO;
using CMS.Business.Interface;
using System.ServiceModel;

namespace CMS.DistributionService.Implemention
{

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class LogService : ILogService
    {
        public void SaveLog(SystemLog log)
        {
            var logger = ObjFactory.Create<ILogger>();
            logger.Save(log);
        }
    }
}
