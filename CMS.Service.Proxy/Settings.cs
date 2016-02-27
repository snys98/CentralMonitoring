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
            ServerIP = ConfigurationManager.AppSettings["ServerIP"];
            ServerPort = ConfigurationManager.AppSettings["ServerPort"];
        }
        public static string ServerIP { get; set; }
        public static string ServerPort { get; set; }
    }
}
