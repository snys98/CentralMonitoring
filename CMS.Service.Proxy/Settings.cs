using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Service.Proxy
{
    internal class Settings
    {
        static Settings()
        {
            WcfBaseAddress = ConfigurationManager.AppSettings["WcfBaseAddress"];
        }
        public static string WcfBaseAddress { get; set; }        
    }
}
