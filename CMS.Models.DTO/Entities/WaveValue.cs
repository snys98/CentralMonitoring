using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTO
{
    /// <summary>
    /// 粗略定义
    /// </summary>
    [DataContract]
    public class WaveValue
    {
        [DataMember]
        public decimal Value { get; set; }
        [DataMember]
        public DateTime ReceiveTime { get; set; }
        [DataMember]
        public WaveCategory Category { get; set; }
    }

    public enum WaveCategory
    {
        ECG = 0,
        SPO2 = 1,
        NIBP = 2,
        RESP = 3,
        TEMP = 4,
        CO2 = 5,
        IBP = 6,
        CO = 7,
        HOCUS = 8,
    }
}
