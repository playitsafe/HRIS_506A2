using HRIS.Entity;
using HRIS.Controller;
using HRIS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRIS.Adapter
{
    class SchoolDBAdpter
    {
        //Boolean for error handling 
        private static bool reportingErrors = false;

        //Specify the DB credentials
        private const string db = "kit206";
        private const string user = "kit206";
        private const string pass = "kit206";
        private const string server = "alacritas.cis.utas.edu.au";

        private static MySqlConnection conn = null;

        //create an instance of MySql connection
        public static MySqlConnection ConnAlacritas()
        {
            if (conn == null)
            {
                string connString = $"Database={db};Data Source={server};User Id={user};Password={pass}";
                conn = new MySqlConnection(connString);
            }
            return conn;
        }

        public static List<Staff> LoadAllStaff()
        {
            List<Staff> AllStaffList = new List<Staff>();

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("select family_name, given_name, title from staff", conn);
                rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    AllStaffList.Add(new Staff { FamilyName = rdr.GetString(0), GivenName = rdr.GetString(1), StaffTitle = rdr.GetString(2) });
                }
            }
            catch (MySqlException e)
            {
                throw;
            }
            finally
            {
                if (rdr != null)
                {
                    rdr.Close();
                }
                if (conn != null)
                {
                    conn.Close();
                }
            }
            return AllStaffList;
        }
    }
}
