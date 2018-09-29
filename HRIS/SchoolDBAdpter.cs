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

        //To create a method to parse Enum from DB
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

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

        //query staff properties from DB
        public static List<Staff> LoadAllStaff()
        {
            List<Staff> AllStaffList = new List<Staff>();

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("select family_name, given_name, title, campus, phone, room, email, photo, category from staff", conn);
                rdr = sqlCmd.ExecuteReader();

                //pull all staff in DBtable to AllStaffList Object
                while (rdr.Read())
                {
                    //Change the rer.GetString to get data by column name
                    //AllStaffList.Add(new Staff { FamilyName = rdr.GetString(0), GivenName = rdr.GetString(1), StaffTitle = rdr.GetString(2) });
                    AllStaffList.Add(new Staff
                    {
                        FamilyName = rdr["family_name"].ToString(),
                        GivenName = rdr["given_name"].ToString(),
                        StaffTitle = rdr["title"].ToString(),
                        Campus = ParseEnum<Campus>(rdr["campus"].ToString()),
                        Phone = rdr["phone"].ToString(),
                        Room = rdr["room"].ToString(),
                        Email = rdr["email"].ToString(),
                        PhotoUrl = rdr["photo"].ToString(),
                        Category = ParseEnum<Category>(rdr["category"].ToString())
                    });
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
