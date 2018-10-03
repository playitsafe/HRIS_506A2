using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HRIS.Adapter;
using HRIS.Teaching;
using HRIS.View;

namespace HRIS.Controller
{
    public class UnitController
    {
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        //to create a private property and a getter for UnitList
        private List<Unit> allUnitList;
        public List<Unit> AllUnitList { get { return allUnitList; } }

        //to create a private property and a getter for UnitViewList
        private ObservableCollection<Unit> unitViewList;
        public ObservableCollection<Unit> UnitViewList { get { return unitViewList; } }

        //to declare a current unit list under selected campus
        public List<Unit> CurrentCampusList;

        //To create a *constructor* for Unit controller
        public UnitController()
        {
            allUnitList = SchoolDBAdpter.LoadAllUnit();

            foreach (Unit u in allUnitList)
            {
                //MainWindow win = new MainWindow();
                //Campus campus = ParseEnum<Campus>(win.CampusComboBox.SelectedValue.ToString());
                u.WeeklyUnitClassList = SchoolDBAdpter.LoadWeeklyUnitClassList("Hobart", u.UnitCode);
            }

            //to allow list for changing later
            unitViewList = new ObservableCollection<Unit>(allUnitList);

            //to assign current unit list of the same as UnitViewList
            //CurrentCategoryList = StaffViewList.ToList();
        }

        //a method to pull out the Observable unit list
        public ObservableCollection<Unit> GetUnitViewList()
        {
            return UnitViewList;
        }

        //create a method to filter unit by name
        public void UnitNameFilter(string txt)
        {
            //to filter key word through current shown list
            var filteredList = from Unit u in allUnitList
                               where u.UnitTitle.ToLower().Contains(txt.ToLower())
                               || u.UnitCode.ToLower().Contains(txt.ToLower())
                               select u;
            //to sort the order by family name, then given name
            filteredList.OrderBy(u => u.UnitTitle);
            unitViewList.Clear();
            filteredList.ToList().ForEach(unitViewList.Add);
        }
    }
}
