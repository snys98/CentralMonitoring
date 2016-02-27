using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DB
{
    /// <summary>
    /// 系统日志
    /// </summary>
    public class SystemLogEntity
    {
        /// <summary>
        /// Id
        /// </summary>		
        public decimal Id { get; set; }
        /// <summary>
        /// Level
        /// </summary>		
        public string Level { get; set; }
        /// <summary>
        /// Content
        /// </summary>		
        public string Content { get; set; }
        /// <summary>
        /// Created
        /// </summary>		
        public DateTime Created { get; set; }
    }
}
