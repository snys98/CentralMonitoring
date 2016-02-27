using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Host
{
    [ConfigurationCollection(typeof(MapSection), AddItemName = "Map")]
    public class MapsCollection : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new MapSection();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((MapSection)element).Face;
        }

        public MapSection this[int index]
        {
            get { return (MapSection)base.BaseGet(index); }
        }

        public new MapSection this[string name]
        {
            get { return (MapSection)base.BaseGet(name); }
        }
    }
}
