using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Entity
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

        public override string ToString()
        {
            return $"{FamilyName}, {GivenName} ({StaffTitle})";
        }
    }

}
