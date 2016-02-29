using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Interface
{
    public interface INotifyCallback
    {
        /// <summary>
        /// 回调通知
        /// </summary>
        /// <param name="message"></param>
        [OperationContract(IsOneWay = true)]
        void Notify(string message);
    }
}
