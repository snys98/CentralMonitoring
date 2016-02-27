using CMS.Business.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.DTO;
using CMS.Database.Provider.Logger;
using CMS.Models.DB;

namespace CMS.Business.Implemention
{
    public class Logger : ILogger
    {
        public void Save(SystemLog log)
        {
            var obj = ObjConvert.Convert<SystemLog, SystemLogEntity>(log);
            obj.Created = DateTime.Now;
            new SystemLogProvider().Add(obj);
        }
    }
}
