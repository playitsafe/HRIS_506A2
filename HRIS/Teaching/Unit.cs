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
    public class Unit
    {
        public string UnitCode { get; set; }
        public string UnitTitle { get; set; }
        public int CoordinatorId { get; set; }
        public string CoordinatorName { get; set; }
        public Campus Campus { get; set; }

        public List<UnitClass> WeeklyUnitClassList { get; set; }
    }
}
