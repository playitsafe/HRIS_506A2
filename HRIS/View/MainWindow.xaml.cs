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
        private StaffController staffController;

        //to declare a UNIT resource key and intiate an object for using unit
        private const string UNIT_LIST_KEY = "unitListKey";
        private UnitController unitController;

        public MainWindow()
        {
            InitializeComponent();
            // intiate an object for using
            staffController = (StaffController)(Application.Current.FindResource(STAFF_LIST_KEY) as ObjectDataProvider).ObjectInstance;
            unitController = (UnitController)(Application.Current.FindResource(UNIT_LIST_KEY) as ObjectDataProvider).ObjectInstance;
        }

        private void StaffListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
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
            if (e.AddedItems.Count > 0)
            {
                string SelectedCampus = CampusComboBox.SelectedValue.ToString();
                 //MessageBox.Show(aa);

                UnitDetailPanel.DataContext = e.AddedItems[0];
                //MessageBox.Show(e.AddedItems[0].ToString());

                //UnitTimeGrid.DataContext = UnitController.GetUnitWithSelectedCampus(SelectedCampus, e.AddedItems[0].ToString())[0];


                //UnitTimeGrid.DataContext = e.AddedItems[0];//Object of an unit.

                UnitTimeTable.Items.Clear();
                UnitTimeTable.Items.Refresh();
                Unit unit = e.AddedItems[0] as Unit;

                if (unit != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        //WeeklyAvailability weeklyAvailability = staff.WeeklyAvailabilityList[i];
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

                //MessageBox.Show(CampusComboBox.SelectedValue.ToString());
                string selectCampus = CampusComboBox.SelectedValue.ToString();
                string unitCode = CodeLable.Text;

                var unitList_Obj = UnitController.GetUnitWithSelectedCampus(selectCampus, unitCode);

                //if filter result > 0
                if (unitList_Obj.Count > 0)
                {
                    MessageBox.Show(unitList_Obj[0].ToString());
                    //MessageBox.Show(CampusComboBox.SelectedValue.ToString());
                }

                
                /*

                //MessageBox.Show(CodeLable.Text);
                UnitTimeGrid.DataContext = UnitController.GetUnitWithSelectedCampus(CodeLable.Text, e.AddedItems[0].ToString())[0];

                UnitTimeTable.Items.Clear();
                UnitTimeTable.Items.Refresh();
                Unit unit = unitObj as Unit;

                if (unit != null)
                {
                    for (int i = 0; i < 8; i++)
                    {
                        //WeeklyAvailability weeklyAvailability = staff.WeeklyAvailabilityList[i];
                        UnitTimeTable.Items.Add(unit.WeeklyUnitClassList[i]);
                    }
                }
                */
            }
            /*
           if (e.RemovedItems.Count > 0)
           {
               //MessageBox.Show(CampusComboBox.SelectedValue.ToString());
               //UnitTimeTable.Items.Clear();
               //UnitTimeTable.Items.Refresh();

               if (CampusComboBox.SelectedValue.ToString() == "Launceston")
               {
                   UnitTimeTable.Items.Clear();
                   UnitTimeTable.Items.Refresh();

               }
               else
               {
                   UnitTimeTable.Items.Clear();
                   UnitTimeTable.Items.Refresh();
                   Unit unit = e.AddedItems[0] as Unit;

                   if (unit != null)
                   {
                       for (int i = 0; i < 8; i++)
                       {
                           //WeeklyAvailability weeklyAvailability = staff.WeeklyAvailabilityList[i];
                           UnitTimeTable.Items.Add(unit.WeeklyUnitClassList[i]);
                       }
                   }
               }

           }
           */
        }
    }
}
