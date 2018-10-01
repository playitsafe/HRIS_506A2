using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Controller;
using HRIS.Adapter;
using HRIS.View;

namespace HRIS.Teaching
{
    public class Consultation
    {
        public int StaffId { get; set; }
        public DayOfWeek WeekDay { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        //To override the to string for displaying in listbox
        public override string ToString()
        {
            return $"{WeekDay} {Start} -- {End}";
        }
    }
}
