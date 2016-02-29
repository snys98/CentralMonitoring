using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Interface
{
    /// <summary>
    /// 设备数据采集接口，供设备托盘上报数据使用
    /// </summary>
    /// 
    [ServiceContract(SessionMode = SessionMode.Required)]
    public interface IDeviceService
    {
        /// <summary>
        /// 修改设备状态
        /// </summary>
        [OperationContract]
        void ChangeDeviceState();
        /// <summary>
        /// 上传数据
        /// </summary>
        [OperationContract]
        void UploadData();
    }
}
