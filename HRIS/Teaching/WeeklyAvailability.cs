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
        /*
        public Availability Monday = Availability.Free;
        public Availability Tuesday = Availability.Free;
        public Availability Wednesday = Availability.Free;
        public Availability Thursday = Availability.Free;
        public Availability Friday = Availability.Free;
        */
        public string[] MonToFri_Activity = { "Free", "Free", "Free", "Free", "Free" };


    }
}
