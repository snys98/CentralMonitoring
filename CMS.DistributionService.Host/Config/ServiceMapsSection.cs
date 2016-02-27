using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Host
{
    public class ServiceMapsSection : ConfigurationSection
    {
        [ConfigurationProperty("Services", IsDefaultCollection = true)]
        [ConfigurationCollection(typeof(ServicesCollection), AddItemName = "Service")]
        public ServicesCollection Services
        {
            get { return (ServicesCollection)this["Services"]; }
            set { this["Services"] = value; }
        }
    }
}
