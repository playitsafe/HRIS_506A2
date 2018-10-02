using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Controller;
using HRIS.Teaching;

namespace HRIS.Teaching
{
    public class WeeklyAvailability
    {
        public int StartTime { get; set; }
        public string HourRow = "StartTime - EndTime";

        public string[] MonToFri_Activity = { "Free", "Free", "Free", "Free", "Free" };

        public string Mon_Activity { get { return MonToFri_Activity[0]; } }
        public string Tue_Activity { get { return MonToFri_Activity[1]; } }
        public string Wed_Activity { get { return MonToFri_Activity[2]; } }
        public string Thu_Activity { get { return MonToFri_Activity[3]; } }
        public string Fri_Activity { get { return MonToFri_Activity[4]; } }

        public string RowHeader{ get { return $"{StartTime}:00 - {StartTime + 1}:00"; } }
    }
}
