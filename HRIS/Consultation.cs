﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Entity
{
    public class Consultation
    {
        public int StaffId { get; set; }
        public WeekDay WeekDay { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}