using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Interface
{
    [ServiceContract(CallbackContract = typeof(INotifyCallback), SessionMode = SessionMode.Required)]
    public interface INotifyService
    {
        /// <summary>
        /// 连接
        /// </summary>
        [OperationContract]
        void Connect();
        /// <summary>
        /// 关闭
        /// </summary>
        void Close();
    }
}
