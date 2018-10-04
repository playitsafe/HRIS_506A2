using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using HRIS.View;
using HRIS.Teaching;
using HRIS.Adapter;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace HRIS.Controller
{
    public enum Campus { Hobart, Launceston }
    public enum Category { All, Academic, Admin, Casual, Technical }
    public enum ClassType { Lecture, Tutorial, Practical, Workshop }
    public enum Availability { Free, Consultation, Teaching }

    public class StaffController
    {
        //to create a private property and a getter for StaffList
        private List<Staff> allStaffList;
        public List<Staff> AllStaffList { get { return allStaffList; } }

        //to create a private property and a getter for StaffViewList
        private ObservableCollection<Staff> staffViewList;
        public ObservableCollection<Staff> StaffViewList { get { return staffViewList; } }

        //to declare a current staff list under selected category
        public List<Staff> CurrentCategoryList;

        //To create a *constructor* for Staff controller
        public StaffController()
        {
            allStaffList = SchoolDBAdpter.LoadAllStaff();
            
            foreach (Staff s in allStaffList)
            {
                //add consultation time list for every staff
                s.StaffConsultationList = SchoolDBAdpter.LoadConsultationList(s.StaffId);

                //add teaching list for every staff
                s.UnitTeachingList = SchoolDBAdpter.LoadUnitTeachingList(s.StaffId);

                //add teaching time for every staff
                s.WeeklyAvailabilityList = SchoolDBAdpter.LoadWeeklyTeachingTime(s.StaffId);
            }

            //to allow list for changing later
            staffViewList = new ObservableCollection<Staff>(allStaffList);

            //to assign current staff list of the same as StaffViewList
            CurrentCategoryList = StaffViewList.ToList();
        }

        //a method to pull out the Observable staff list
        //**try to set above ObservableCollection StaffViewList STATIC later
        public ObservableCollection<Staff> GetStaffViewList()
        {
            return StaffViewList;
        }

        //to implement the category dropdown list filter
        public void CategoryFilter(Category category)
        {
            var filteredList = from Staff s in allStaffList
                               where category == Category.All || s.Category == category
                               select s;
            //to sort the order by family name, then given name
            filteredList.OrderBy(s => s.FamilyName).ThenBy(s => s.GivenName);
            staffViewList.Clear();
            filteredList.ToList().ForEach( staffViewList.Add );

            //to assign current staff list with category changed
            CurrentCategoryList = StaffViewList.ToList();
        }

        public void NameFilter(string txt)
        {
            //to filter key word through current shown list
            var filteredList = from Staff s in CurrentCategoryList
                               where s.FamilyName.ToLower().Contains(txt.ToLower())
                               || s.GivenName.ToLower().Contains(txt.ToLower())
                               select s;
            //to sort the order by family name, then given name
            filteredList.OrderBy(s => s.FamilyName).ThenBy(s => s.GivenName);
            staffViewList.Clear();
            filteredList.ToList().ForEach(staffViewList.Add);
        }
        

        public List<Staff> GetClickedStaff(string coordinator_id)
        {
            var filteredList = from Staff s in allStaffList
                               where s.StaffId == Int32.Parse(coordinator_id)
                               select s;

            return filteredList.ToList();
        }

    }
}
