using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Interface
{
    /// <summary>
    /// 数据监视分发服务
    /// </summary>
    /// 
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IMonitorService
    {
        /// <summary>
        /// 关注某张床位
        /// </summary>
        /// <param name="bedno"></param>
        [OperationContract]
        void AddMonitor(string bedno);
        /// <summary>
        /// 取消关注某张床位
        /// </summary>
        /// <param name="bedno"></param>
        [OperationContract]
        void RemoveMonitor(string bedno);

    }
}
