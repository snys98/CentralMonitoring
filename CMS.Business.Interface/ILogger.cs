﻿using CMS.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Business.Interface
{
    public interface ILogger
    {
        void Save(SystemLog log);
    }
}
