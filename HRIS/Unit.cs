﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Entity
{
    public class Unit
    {
        public string UnitCode { get; set; }
        public string UnitTitle { get; set; }
        public int CoordinatorId { get; set; }
    }
}