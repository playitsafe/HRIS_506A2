using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HRIS.Adapter;
using HRIS.Teaching;
using HRIS.Controller;


namespace HRIS.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //to declare a STAFF resource key and intiate an object for using staff
        private const string STAFF_LIST_KEY = "staffListKey";
        public StaffController staffController;

        //to declare a UNIT resource key and intiate an object for using unit
        private const string UNIT_LIST_KEY = "unitListKey";
        public UnitController unitController;

        public MainWindow()
        {
            InitializeComponent();
            // intiate an object for using
            staffController = (StaffController)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            unitController = (UnitController)(Application.Current.FindResource(UNIT_LIST_KEY) as ObjectDataProvider).ObjectInstance;

        }

        private void StaffListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Tab.SelectedIndex = 0;
            if (e.AddedItems.Count > 0)
            {
                StaffDetailPanel.DataContext = e.AddedItems[0];
                PhotoGrid.DataContext = e.AddedItems[0];
                //ActivityGrid.DataContext = e.AddedItems[0];
                //MessageBox.Show(e.AddedItems[0].ToString());
                //ActivityGrid.Columns.Clear();
                ActivityGrid.Items.Clear();
                ActivityGrid.Items.Refresh();
                Staff staff = e.AddedItems[0] as Staff;
                //SchoolDBAdpter.LoadWeeklyTeachingTime(staff.StaffId);
                if (staff != null)
                {
                    //MessageBox.Show(staff.StaffId.ToString());
                    for (int i = 0; i < 8; i++)
                    {
                        //WeeklyAvailability weeklyAvailability = staff.WeeklyAvailabilityList[i];
                        ActivityGrid.Items.Add(staff.WeeklyAvailabilityList[i]);
                    }
                }
            }
        }

        private void Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                //MessageBox.Show("Dropdown list used to select: " + e.AddedItems[0]);
                Category category = SchoolDBAdpter.ParseEnum<Category>(e.AddedItems[0].ToString());
                //use the fiter method in StaffController
                staffController.CategoryFilter(category);
            }
        }

        private void StaffNameFilter_KeyUp(object sender, KeyEventArgs e)
        {
            //MessageBox.Show(StaffNameFilter.Text);
            staffController.NameFilter(StaffNameFilter.Text);
        }

        //===========================================================
        //Start to code Unit Part
        private void UnitListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //to reset campus to hobart when change unit
            CampusComboBox.SelectedIndex = 0;
            UnitTimeTable.Items.Clear();
            UnitTimeTable.Items.Refresh();

            if (e.AddedItems.Count > 0)
            {
                UnitDetailPanel.DataContext = e.AddedItems[0];//data context = Object Unit!

                //--To test if it can get value of select unit code and campus-Yes!
                //MessageBox.Show(SelectedCampus);
                //MessageBox.Show(e.AddedItems[0].ToString());
                string SelectedCampus = CampusComboBox.SelectedValue.ToString();
                string unitCode = e.AddedItems[0].ToString();

                //UnitTimeGrid.DataContext = UnitController.GetUnitWithSelectedCampus(SelectedCampus, unitCode);

                //UnitTimeGrid.DataContext = UnitController.GetUnitWithSelectedCampus(SelectedCampus, e.AddedItems[0].ToString())[0];
                Unit unit = UnitController.GetUnitWithSelectedCampus(SelectedCampus, unitCode) as Unit;

                if (unit != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        UnitTimeTable.Items.Add(unit.WeeklyUnitClassList[i]);
                    }
                }
            }
        }

        private void UnitFilter_KeyUp(object sender, KeyEventArgs e)
        {
            unitController.UnitNameFilter(UnitFilter.Text);
        }

        //Campus_SelectionChanged

        private void Campus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                UnitTimeTable.Items.Clear();
                UnitTimeTable.Items.Refresh();
                //MessageBox.Show(CampusComboBox.SelectedValue.ToString());
                string SelectedCampus = CampusComboBox.SelectedValue.ToString();
                string unitCode = CodeLable.Text;

                Unit unit = UnitController.GetUnitWithSelectedCampus(SelectedCampus, unitCode);

                if (unit != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        UnitTimeTable.Items.Add(unit.WeeklyUnitClassList[i]);
                    }
                }
            }
        }

        //an event to navigate back to staff panel
        private void TeacherButton_Click(object sender, EventArgs e)
        {

            //MessageBox.Show(NameTag.ToolTip.ToString());
            Tab.SelectedIndex = 0;

            Staff SelectedStaff = staffController.GetClickedStaff(TeacherButton.ToolTip.ToString())[0];
            StaffDetailPanel.DataContext = SelectedStaff;
            PhotoGrid.DataContext = SelectedStaff;

            ActivityGrid.Items.Clear();
            ActivityGrid.Items.Refresh();

            for (int i = 0; i < 8; i++)
            {
                ActivityGrid.Items.Add(SelectedStaff.WeeklyAvailabilityList[i]);
            }

        }
        
        private void StaffUnitBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (e.AddedItems.Count > 0)
            {
                //some housekeep work for unit detail panel
                Tab.SelectedIndex = 1;
                CampusComboBox.SelectedIndex = 0;
                UnitTimeTable.Items.Clear();
                UnitTimeTable.Items.Refresh();

                string unit_code = e.AddedItems[0].ToString().Substring(0, 6);
                Unit SelectedUnit = unitController.GetClickedUnit(unit_code)[0];
                UnitDetailPanel.DataContext = SelectedUnit;

                string SelectedCampus = CampusComboBox.SelectedValue.ToString();
                
                Unit unit = UnitController.GetUnitWithSelectedCampus(SelectedCampus, unit_code) as Unit;

                if (unit != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        UnitTimeTable.Items.Add(unit.WeeklyUnitClassList[i]);
                    }
                }
            }
        }
        

        
    }
}
