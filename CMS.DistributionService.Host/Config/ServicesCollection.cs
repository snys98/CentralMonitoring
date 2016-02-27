using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Host
{
    [ConfigurationCollection(typeof(ServiceSection), AddItemName = "Service")]
    public class ServicesCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceSection)element).ImplementionDll;
        }

        public ServiceSection this[int index]
        {
            get { return (ServiceSection)base.BaseGet(index); }
        }

        public new ServiceSection this[string name]
        {
            get { return (ServiceSection)base.BaseGet(name); }
        }
    }
}
