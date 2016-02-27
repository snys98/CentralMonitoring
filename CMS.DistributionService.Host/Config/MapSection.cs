using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.DistributionService.Host
{
    public class MapSection : ConfigurationElement
    {
        [ConfigurationProperty("Face", IsKey = true, IsRequired = true)]
        public string Face { get { return (string)this["Face"]; } set { Face = value; } }

        [ConfigurationProperty("Real", IsRequired = true)]
        public string Real { get { return (string)this["Real"]; } set { Real = value; } }
    }
}
