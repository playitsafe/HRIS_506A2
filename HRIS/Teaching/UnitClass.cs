using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.View;
using HRIS.Controller;
using HRIS.Adapter;

namespace HRIS.Teaching
{
    public class UnitClass
    {
        public string UnitCode { get; set; }
        public string UnitName { get; set; }
        public Campus Campus { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }
        public ClassType ClassType { get; set; }
        public string Room { get; set; }
        public int TeachingStaff { get; set; }

        //To override the to string for displaying in listbox
        public override string ToString()
        {
            return $"{UnitCode} {UnitName}";
        }

    }
}
