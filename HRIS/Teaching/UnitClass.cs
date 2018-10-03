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

        public int Start { get; set; }

        public int End { get; set; }
        public ClassType ClassType { get; set; }
        public string Room { get; set; }
        public string TeachingStaff { get; set; }

        //To override the to string for displaying in listbox
        public override string ToString()
        {
            return $"{UnitCode} {UnitName}";
        }

        public string[] MonToFri_Activity = { "", "", "", "", "" };

        public string Mon_Activity { get { return MonToFri_Activity[0]; } }
        public string Tue_Activity { get { return MonToFri_Activity[1]; } }
        public string Wed_Activity { get { return MonToFri_Activity[2]; } }
        public string Thu_Activity { get { return MonToFri_Activity[3]; } }
        public string Fri_Activity { get { return MonToFri_Activity[4]; } }

        public string RowHeader { get { return $"{Start}:00 - {Start + 1}:00"; } }

    }
}
