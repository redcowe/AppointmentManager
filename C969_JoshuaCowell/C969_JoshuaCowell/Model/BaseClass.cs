﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969_JoshuaCowell.Model
{
    public abstract class BaseClass
    {
        public string CreateDate { get; set; }

        public string CreatedBy { get; set; }

        public string LastUpdate { get; set; }

        public string LastUpdatedBy { get; set; }
    }
}
