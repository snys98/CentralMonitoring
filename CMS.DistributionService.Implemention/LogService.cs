using CMS.DistributionService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.DTO;
using CMS.Business.Interface;

namespace CMS.DistributionService.Implemention
{
    public class LogService : ILogService
    {
        public void SaveLog(SystemLog log)
        {
            var logger = ObjFactory.Create<ILogger>();
            logger.Save(log);
        }
    }
}
