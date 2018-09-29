using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using HRIS;
using HRIS.Teaching;
using HRIS.Adapter;
using System.Collections.ObjectModel;

namespace HRIS.Controller
{
    public enum Campus { Hobart, Launceston }
    public enum Category { All, Academic, Admin, Casual, Technical }
    //public enum WeekDay { Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday }
    public enum ClassType { Lecture, Tutorial, Practical, Workshop }

    public class StaffController
    {
        //to create a private property and a getter for StaffList
        private List<Staff> allStaffList;
        public List<Staff> AllStaffList { get { return allStaffList; } }

        //to create a private property and a getter for StaffViewList
        private ObservableCollection<Staff> staffViewList;
        public ObservableCollection<Staff> StaffViewList { get { return staffViewList; } }

        //To create a *constructor* for Staff controller
        public StaffController()
        {
            allStaffList = SchoolDBAdpter.LoadAllStaff();
            
            //add consultation time list for every staff
            foreach (Staff s in allStaffList)
            {
                s.StaffConsultationList = SchoolDBAdpter.LoadConsultationList(s.StaffId);
            }

            //to allow list for changing later
            staffViewList = new ObservableCollection<Staff>(allStaffList);
        }

        //a method to pull out the Observable staff list
        //**try to set above ObservableCollection StaffViewList STATIC later
        public ObservableCollection<Staff> GetStaffViewList()
        {
            return StaffViewList;
        }
    }
}
