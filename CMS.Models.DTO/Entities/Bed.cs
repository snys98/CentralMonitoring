using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTO.Entities
{
    [DataContract]
    public class Bed
    {
        [DataMember]
        public string BedNum { get; set; }
        [DataMember]
        public Department Department { get; set; }
    }
}
