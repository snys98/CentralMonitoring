using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTO
{
    public enum LogLevel
    {
        [Description("消息")]
        Info = 1,
        [Description("警告")]
        Warning = 2,
        [Description("错误")]
        Error = 3
    }
}
