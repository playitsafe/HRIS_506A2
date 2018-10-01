using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Controller;
using HRIS.Adapter;
using HRIS.View;
using HRIS.Teaching;
using System.Data;

namespace HRIS.Teaching
{
    
    public class Staff
    {
        public int StaffId { get; set; }
        public string GivenName { get; set; }
        public string FamilyName { get; set; }
        public string StaffTitle { get; set; }
        public Campus Campus { get; set; }
        public string Phone { get; set; }
        public string Room { get; set; }
        public string Email { get; set; }
        public string PhotoUrl { get; set; }
        public Category Category { get; set; }

        public List<Consultation> StaffConsultationList { get; set; }
        public List<UnitClass> UnitTeachingList { get; set; }
        //daclare a list for every hour activity across Mon-Fri
        public List<WeeklyAvailability> WeeklyAvailabilityList { get; set; }
        

        //public DataTable ActivityTable { get; set; }



        /*
        public Staff()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Time", typeof(string));
            dt.Columns.Add("Monday", typeof(string));
            dt.Columns.Add("Tuesday", typeof(string));
            dt.Columns.Add("Wednesday", typeof(string));
            dt.Columns.Add("Thursday", typeof(string));
            dt.Columns.Add("Friday", typeof(string));
            dt.Rows.Add(new string[] { "9:00-10:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "10:00-11:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "11:00-12:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "12:00-13:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "13:00-14:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "14:00-15:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "15:00-16:00", "1", "2", "3", "4", "5" });
            dt.Rows.Add(new string[] { "16:00-17:00", "1", "2", "3", "4", "5" });

            ActivityTable = dt;
        }
        */

        /*
        public override string ToString()
        {
            return $"{GivenName} {FamilyName} ({StaffTitle})";
        }
        */
    }

}
