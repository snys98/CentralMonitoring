using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTO
{
    [DataContract]
    public class SystemLog
    {
        /// <summary>
        /// 日志级别
        /// </summary>
        [DataMember]
        public LogLevel Level { get; set; }
        /// <summary>
        /// 日志内容
        /// </summary>
        [DataMember]
        public string Content { get; set; }
    }
}
