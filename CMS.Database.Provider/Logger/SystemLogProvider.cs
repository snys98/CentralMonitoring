using CMS.Models.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Threading;

namespace CMS.Database.Provider.Logger
{
    public class SystemLogProvider
    {
        public void Add(SystemLogEntity entity)
        {
            ThreadPool.QueueUserWorkItem((e) =>
            {
                var item = e as SystemLogEntity;
                using (DbContent db = DbFactory.Create())
                {
                    DataParameters paramters = new DataParameters();
                    paramters.Add("@Level", item.Level);
                    paramters.Add("@Content", item.Content);
                    paramters.Add("@Created", item.Created);
                    db.ExecuteProc("SystemLog_Save", paramters);
                }
            }, entity);
        }
    }
}
