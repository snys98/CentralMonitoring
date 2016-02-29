using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Models.DTO;

namespace CMS.Client.DataServices
{
    public class MonitorDataService:IDataService
    {
        public dynamic GenTestData()
        {
            throw new NotImplementedException();
        }

        public ConcurrentQueue<WaveValue> DataBuffer
        {
            get { throw new NotImplementedException(); }
        }
    }
}
