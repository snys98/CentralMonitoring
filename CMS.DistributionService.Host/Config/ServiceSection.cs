using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Host
{
    public class ServiceSection : ConfigurationElement
    {
        [ConfigurationProperty("InterfaceDll", IsKey = true, IsRequired = true)]
        public string InterfaceDll { get { return (string)this["InterfaceDll"]; } set { InterfaceDll = value; } }

        [ConfigurationProperty("ImplementionDll", IsRequired = true)]
        public string ImplementionDll { get { return (string)this["ImplementionDll"]; } set { ImplementionDll = value; } }

        [ConfigurationProperty("Maps", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(MapsCollection), AddItemName = "Map")]
        public MapsCollection Maps
        {
            get { return (MapsCollection)this["Maps"]; }
            set { this["Maps"] = value; }
        }
    }
}
