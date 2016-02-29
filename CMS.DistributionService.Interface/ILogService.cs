using CMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Interface
{
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface ILogService
    {
        /// <summary>
        /// 保存系统日志
        /// </summary>
        /// <param name="log"></param>
        [OperationContract]
        void SaveLog(SystemLog log);
    }
}
