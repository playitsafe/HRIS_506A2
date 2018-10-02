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
using HRIS.Controller;
using HRIS.Teaching;
using HRIS.View;

namespace HRIS.View
{
    /// <summary>
    /// Interaction logic for SmallPartsUserControl.xaml
    /// </summary>
    public partial class SmallPartsUserControl : UserControl
    {
        public SmallPartsUserControl()
        {
            InitializeComponent();
        }
        /*
        private void Campus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.RemovedItems.Count > 0)
            {
                //MessageBox.Show(CampusComboBox.SelectedValue.ToString());
            }

        }
        */
    }
}
