using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Controller;
using HRIS.Adapter;
using HRIS;

namespace HRIS.Teaching
{
    public class Consultation
    {
        public int StaffId { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
    }
}
