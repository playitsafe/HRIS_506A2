using HRIS.Teaching;
using HRIS.Controller;
using HRIS;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.Types;

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
                MySqlCommand sqlCmd = new MySqlCommand("select id, family_name, given_name, title, campus, phone, room, email, photo, category from staff", conn);
                rdr = sqlCmd.ExecuteReader();

                //pull all staff in DBtable to AllStaffList Object
                while (rdr.Read())
                {
                    //Change the rer.GetString to get data by column name
                    //AllStaffList.Add(new Staff { FamilyName = rdr.GetString(0), GivenName = rdr.GetString(1), StaffTitle = rdr.GetString(2) });
                    AllStaffList.Add(new Staff
                    {
                        StaffId = Int32.Parse(rdr["id"].ToString()),
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

        //query staff property->List<Consultation> from DB
        public static List<Consultation> LoadConsultationList(int id)
        {
            List<Consultation> consultationList = new List<Consultation>();
            //List<UnitClass> unitTeachingList = new List<UnitClass>();

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("select day, start, end from consultation where staff_id=?id", conn);
                sqlCmd.Parameters.AddWithValue("id", id);
                rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    consultationList.Add(new Consultation
                    {
                        WeekDay = ParseEnum<DayOfWeek>(rdr["day"].ToString()),
                        //Start =  rdr.GetTimeSpan(rdr["start"].ToString()),
                        //End = rdr.GetTimeSpan(rdr["end"].ToString())
                        Start = rdr.GetTimeSpan(1),
                        End = rdr.GetTimeSpan(2)
                    });
                }
            }
            catch (Exception e)
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

            return consultationList;
        }

        //query staff property->List<UnitClass> from DB
        public static List<UnitClass> LoadUnitTeachingList(int id)
        {
            List<UnitClass> unitTeachingList = new List<UnitClass>();

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("select distinct c.unit_code, u.title from class c join unit u on c.unit_code=u.code where c.staff=?id", conn);
                sqlCmd.Parameters.AddWithValue("id", id);
                rdr = sqlCmd.ExecuteReader();

                while (rdr.Read())
                {
                    unitTeachingList.Add(new UnitClass
                    {
                        //TeachingStaff = rdr.GetInt32(0),
                        UnitCode = rdr.GetString(0),
                        UnitName = rdr.GetString(1)
                    });
                }
            }
            catch (Exception e)
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

            return unitTeachingList;
        }
    }
}
