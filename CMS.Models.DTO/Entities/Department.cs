﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Models.DTO.Entities
{
    [DataContract]
    public class Department
    {
        [DataMember]
        public string Name { get; set; }
    }
}
