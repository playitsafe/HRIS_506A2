using HRIS.Teaching;
using HRIS.Controller;
using HRIS.View;
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
                MySqlCommand sqlCmd = new MySqlCommand("select id, family_name, given_name, title, campus, phone, room, email, photo, category from staff order by family_name, given_name", conn);
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

        //query teach time of whole week of each staff
        public static List<WeeklyAvailability> LoadWeeklyTeachingTime(int id)
        {
            //Firstly create list of 8 hours of each day with all free activity as default.
            List<WeeklyAvailability> weeklyAvailabilityList = new List<WeeklyAvailability>();

            for (int i = 9; i < 17; i++)
            {
                weeklyAvailabilityList.Add(new WeeklyAvailability { StartTime = i});
            }

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand queryForTeaching = new MySqlCommand("select day, start, end from class where campus ='Hobart' and staff=?id", conn);
                queryForTeaching.Parameters.AddWithValue("id", id);
                rdr = queryForTeaching.ExecuteReader();

                while (rdr.Read())
                {
                    int start = Int32.Parse(rdr.GetString(1).ToString().Substring(0, 2));
                    int end = Int32.Parse(rdr.GetString(2).ToString().Substring(0, 2));
                    int consecutive = end - start;

                    //to loop if class is several hours consecutive
                    for (int i = 0; i < consecutive; i++)
                    {
                        foreach (var w in weeklyAvailabilityList)
                        {
                            //This code is for matching the start hour in query result with hour column of weeklyAvailabilityList
                            if (w.StartTime == (start + i))
                            {
                                int indexOfWeekDay = (int)ParseEnum<DayOfWeek>(rdr.GetString(0));
                                w.MonToFri_Activity[(indexOfWeekDay - 1)] = "Teaching(H)";
                            }
                        }
                    }
                    
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

            try
            {
                conn.Open();
                MySqlCommand queryForTeaching = new MySqlCommand("select day, start, end from class where campus ='Launceston' and staff=?id", conn);
                queryForTeaching.Parameters.AddWithValue("id", id);
                rdr = queryForTeaching.ExecuteReader();

                while (rdr.Read())
                {
                    int start = Int32.Parse(rdr.GetString(1).ToString().Substring(0, 2));
                    int end = Int32.Parse(rdr.GetString(2).ToString().Substring(0, 2));
                    int consecutive = end - start;

                    //to loop if class is several hours consecutive
                    for (int i = 0; i < consecutive; i++)
                    {
                        foreach (var w in weeklyAvailabilityList)
                        {
                            //This code is for matching the start hour in query result with hour column of weeklyAvailabilityList
                            if (w.StartTime == (start + i))
                            {
                                int indexOfWeekDay = (int)ParseEnum<DayOfWeek>(rdr.GetString(0));
                                w.MonToFri_Activity[(indexOfWeekDay - 1)] = "Teaching(L)";
                            }
                        }
                    }

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

            try
            {
                conn.Open();
                MySqlCommand queryForConsultation = new MySqlCommand("select c.day, c.start, c.end from consultation c join staff s on c.staff_id = s.id where c.staff_id=?id", conn);
                queryForConsultation.Parameters.AddWithValue("id", id);
                rdr = queryForConsultation.ExecuteReader();

                while (rdr.Read())
                {
                    int start = Int32.Parse(rdr.GetString(1).ToString().Substring(0, 2));
                    int end = Int32.Parse(rdr.GetString(2).ToString().Substring(0, 2));
                    int consecutive = end - start;

                    //to loop if class is several hours consecutive
                    for (int i = 0; i < consecutive; i++)
                    {
                        foreach (var w in weeklyAvailabilityList)
                        {
                            //This code is for matching the start hour in query result with hour column of weeklyAvailabilityList
                            if (w.StartTime == (start + i))
                            {
                                int indexOfWeekDay = (int)ParseEnum<DayOfWeek>(rdr.GetString(0));
                                w.MonToFri_Activity[(indexOfWeekDay - 1)] = "Consultation";
                            }
                        }
                    }
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

            return weeklyAvailabilityList;
        }

        //==============================================================
        //Start to do unit part
        public static List<Unit> LoadAllUnit()
        {
            List<Unit> AllUnitList = new List<Unit>();

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                MySqlCommand sqlCmd = new MySqlCommand("select u.code, u.title, u.coordinator, concat(s.title, ' ', s.given_name, ' ', s.family_name) as coordinator_name from unit u join staff s on u.coordinator=s.id order by u.title", conn);
                rdr = sqlCmd.ExecuteReader();

                //pull all staff in DBtable to AllStaffList Object
                while (rdr.Read())
                {
                    //Change the rer.GetString to get data by column name
                    //AllStaffList.Add(new Staff { FamilyName = rdr.GetString(0), GivenName = rdr.GetString(1), StaffTitle = rdr.GetString(2) });
                    AllUnitList.Add(new Unit
                    {
                        CoordinatorId = Int32.Parse(rdr["coordinator"].ToString()),
                        UnitCode = rdr["code"].ToString(),
                        UnitTitle = rdr["title"].ToString(),
                        CoordinatorName = rdr["coordinator_name"].ToString()
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
            return AllUnitList;
        }

        //query time table from DB for every unit
        public static List<UnitClass> LoadWeeklyUnitClassList(Campus campus, string unit_code)
        {
            //Firstly create list of 8 hours of each day with all free activity as default.
            List<UnitClass> weeklyUnitClassList = new List<UnitClass>();

            for (int i = 9; i < 17; i++)
            {
                weeklyUnitClassList.Add(new UnitClass { Start = i });
            }

            MySqlConnection conn = ConnAlacritas();
            MySqlDataReader rdr = null;

            try
            {
                conn.Open();
                
                MySqlCommand queryForClass = new MySqlCommand("select c.day, c.start, c.end, c.type, c.room, concat(s.given_name, ' ', s.family_name) as teacher from class c join staff s on c.staff=s.id where c.campus=?campus and c.unit_code=?unit_code", conn);
                queryForClass.Parameters.AddWithValue("campus", campus);
                queryForClass.Parameters.AddWithValue("unit_code", unit_code);
                rdr = queryForClass.ExecuteReader();

                while (rdr.Read())
                {
                    ClassType classType = ParseEnum<ClassType>(rdr.GetString(3));
                    String room = rdr.GetString(4);
                    string teacher = rdr.GetString(5);

                    int start = Int32.Parse(rdr.GetString(1).ToString().Substring(0, 2));
                    int end = Int32.Parse(rdr.GetString(2).ToString().Substring(0, 2));
                    int consecutive = end - start;

                    //to loop if unitClass is several hours consecutive
                    for (int i = 0; i < consecutive; i++)
                    {
                        foreach (var w in weeklyUnitClassList)
                        {
                            //This code is for matching the start hour in query result with hour column of weeklyUnitClassList
                            if (w.Start == (start + i))
                            {
                                int indexOfWeekDay = (int)ParseEnum<DayOfWeek>(rdr.GetString(0));
                                w.MonToFri_Activity[(indexOfWeekDay - 1)] = $"{classType}"; //$"{classType}\n{room}\n{teacher}";
                            }
                        }
                    }

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

            return weeklyUnitClassList;
        }
    }
}
