using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation.Metadata;

namespace GuidesArrangement
{
    internal class DBLogic
    {
        private static OleDbConnection createConn()
        {
            OleDbConnection conn = new OleDbConnection();
            //string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            //AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetDirectoryName(executable));
            //conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\db\guides_and_countries.accdb";
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saar\Desktop\For Dad\GuidesArrangement\GuidesArrangement\db\guides_and_countries.accdb";
            return conn;
        }

        private static void CreateCopy()
        {
            string path = AppDomain.CurrentDomain.GetData("DataDirectory").ToString() + "\\db\\guides_and_countries.accdb";
            string parentDir = Directory.GetParent(path)!.FullName;
            string newPath = parentDir + "\\" + DateTime.Today.Date.ToString("dd.MM.yyyy") + ".accdb";
            File.Copy(path, newPath);
        }

        public static void CreateBackup()
        {
            OleDbConnection conn = createConn();
            CreateCopy();

            OleDbCommand cmd = new OleDbCommand("DELETE * FROM Trips where End_Date < @Today");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Today", OleDbType.Date).Value = DateTime.Today;

                try
                {
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL("הטיול נוסף בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        #region Countries
        public static void AddCountry(Country country)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("INSERT into Countries (Country_Name) Values(@Country_Name)");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_Name", OleDbType.VarChar).Value = country.Name;

                try
                {
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL(country.Name + " נוסף בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static void UpdateCountry(Country country)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("UPDATE Countries SET Country_Name=@Country_Name where ID=@ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_Name", OleDbType.VarChar).Value = country.Name;
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = country.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL(country.Name + " עודכן בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static void RemoveCountry(Country country)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("DELETE * from Countries where ID=@ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = country.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE * FROM Trips WHERE Country_ID=@ID";
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL(country.Name + " נמחק בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static DataTable GetAllCountries()
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Countries");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }

        public static Country GetCountry(int id)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Countries where ID=@ID");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = id;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return new Country(dt.Rows[0]);
        }
        #endregion

        #region Guides
        public static void AddGuide(Guide guide)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("INSERT into Guides (Guide_Name,Phone_Number,Email) Values(@Guide_Name,@Phone_Number,@Email)");
            cmd.Connection = conn;
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = guide.Name;
                cmd.Parameters.Add("@Phone_Number", OleDbType.VarChar).Value = guide.PhoneNumber;
                cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = guide.Email;

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "SELECT @@Identity";
                    guide.ID = (int)cmd.ExecuteScalar()!;
                    cmd.CommandText = "INSERT into GuideToCountry (Guide_ID,Country_ID) Values(@Guide_ID,@Country_ID)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Guide_ID", OleDbType.Integer).Value = guide.ID;
                    cmd.Parameters.Add("@Country_ID", OleDbType.Integer);
                    foreach (Country country in guide.Countries)
                    {
                        cmd.Parameters["@Country_ID"].Value = country.ID;
                        cmd.ExecuteNonQuery();
                    }
                    //Utils.MessageBoxRTL(guide.Name + " נוסף בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static void RemoveGuide(Guide guide)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("DELETE * from GuideToCountry where Guide_ID=@ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = guide.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "DELETE * from Guides where ID=@ID";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "UPDATE Trips SET Guide_ID=-1 WHERE Guide_ID=@ID";
                    cmd.ExecuteNonQuery();
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static void UpdateGuide(Guide guide)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("UPDATE Guides SET Guide_Name = @Guide_Name, Phone_Number=@Phone_Number,Email=@Email where ID=@ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = guide.Name;
                cmd.Parameters.Add("@Phone_Number", OleDbType.VarChar).Value = guide.PhoneNumber;
                cmd.Parameters.Add("@Email", OleDbType.VarChar).Value = guide.Email;
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = guide.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    cmd.Parameters.Clear();
                    cmd.Parameters.Add("@Guide_ID", OleDbType.Integer).Value = guide.ID;
                    cmd.CommandText = "DELETE * from GuideToCountry where Guide_ID=@Guide_ID";
                    cmd.ExecuteNonQuery();
                    cmd.CommandText = "INSERT into GuideToCountry (Guide_ID,Country_ID) Values(@Guide_ID,@Country_ID)";
                    cmd.Parameters.Add("@Country_ID", OleDbType.Integer);
                    foreach (Country country in guide.Countries)
                    {
                        cmd.Parameters["@Country_ID"].Value = country.ID;
                        cmd.ExecuteNonQuery();
                    }
                    //Utils.MessageBoxRTL(guide.Name + " עודכן בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static DataTable GetAllGuides()
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT Guides.ID AS Guide_ID, Guides.Guide_Name,Guides.Phone_Number,Guides.Email, Countries.ID AS Country_ID, Countries.Country_Name\r\nFROM Guides INNER JOIN (Countries INNER JOIN GuideToCountry ON Countries.[ID] = GuideToCountry.[Country_ID]) ON Guides.[ID] = GuideToCountry.[Guide_ID] UNION SELECT ID,Guide_Name,Phone_Number,Email,Null,Null from Guides");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }

        public static Guide? GetGuide(int? id)
        {
            if (id == null)
            {
                return null;
            }

            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT Guides.ID AS Guide_ID, Guides.Guide_Name,Guides.Phone_Number,Guides.Email, Countries.ID AS Country_ID, Countries.Country_Name\r\nFROM Guides INNER JOIN (Countries INNER JOIN GuideToCountry ON Countries.[ID] = GuideToCountry.[Country_ID]) ON Guides.[ID] = GuideToCountry.[Guide_ID] where Guides.[ID]=@ID UNION SELECT ID,Guide_Name,Phone_Number,Email,Null,Null from Guides where ID=@ID");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = id;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return new Guide(dt);
        }

        public static DataTable GetGuidesForCountry(Country country)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM (Guides INNER JOIN GuideToCountry ON Guides.ID=GuideToCountry.Guide_ID) LEFT JOIN Trips ON Trips.Guide_ID=Guides.ID WHERE GuideToCountry.Country_ID=@Country_ID");
            cmd.Connection = conn;
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_ID", OleDbType.Integer).Value = country.ID;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }
        #endregion

        #region Trips
        public static void AddTrip(Trip trip)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("INSERT into Trips (Country_ID,Start_Date,End_Date,Guide_ID,Is_Final,Type,Status) Values(@Country_ID,@Start_Date,@End_Date,@Guide_ID,@Is_Final,@Type,@Status)");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_ID", OleDbType.Integer).Value = trip.Country.ID;
                cmd.Parameters.Add("@Start_Date", OleDbType.Date).Value = trip.StartDate.Date;
                cmd.Parameters.Add("@End_Date", OleDbType.Date).Value = trip.EndDate.Date;
                cmd.Parameters.Add("@Guide_ID", OleDbType.Integer).Value = trip.Guide == null ? -1 : trip.Guide.ID;
                cmd.Parameters.Add("@Is_Final", OleDbType.Boolean).Value = trip.IsFinal;
                cmd.Parameters.Add("@Type", OleDbType.VarChar).Value = trip.Type;
                cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = trip.Status;

                try
                {
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL("הטיול נוסף בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static bool RemoveTrip(Trip trip)
        {
            if (trip.ID == null)
            {
                return false;
            }

            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("DELETE * from Trips where ID = @ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = trip.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL("הטיול נמחק בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return false;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return false;
            }

            return true;
        }

        public static void UpdateTrip(Trip trip)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("UPDATE Trips SET Country_ID=@Country_ID,Start_Date=@Start_Date,End_Date=@End_Date,Guide_ID=@Guide_ID,Is_Final=@Is_Final,Type=@Type,Status=@Status WHERE ID=@ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_ID", OleDbType.Integer).Value = trip.Country.ID;
                cmd.Parameters.Add("@Start_Date", OleDbType.Date).Value = trip.StartDate.Date;
                cmd.Parameters.Add("@End_Date", OleDbType.Date).Value = trip.EndDate.Date;
                cmd.Parameters.Add("@Guide_ID", OleDbType.Integer).Value = trip.Guide == null ? -1 : trip.Guide.ID;
                cmd.Parameters.Add("@Is_Final", OleDbType.Boolean).Value = trip.IsFinal;
                cmd.Parameters.Add("@Type", OleDbType.VarChar).Value = trip.Type;
                cmd.Parameters.Add("@Status", OleDbType.VarChar).Value = trip.Status;
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = trip.ID!;

                try
                {
                    cmd.ExecuteNonQuery();
                    //Utils.MessageBoxRTL("הטיול עודכן בהצלחה!");
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
            }
        }

        public static DataTable GetAllTrips()
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("Select Trips.*, Guides.Guide_Name, Countries.Country_Name FROM ((Trips LEFT JOIN Guides ON Guides.ID = Trips.Guide_ID) INNER JOIN Countries ON Countries.ID = Trips.Country_ID) ORDER BY Start_Date");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }

        public static DataTable GetAllTripsForSpecificGuide(Guide guide)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("Select Trips.*, Guides.Guide_Name, Countries.Country_Name FROM ((Trips LEFT JOIN Guides ON Guides.ID = Trips.Guide_ID) INNER JOIN Countries ON Countries.ID = Trips.Country_ID) WHERE Guide_ID=@Guide_ID ORDER BY Start_Date");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_ID", OleDbType.Integer).Value = guide.ID!;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }

        public static DataTable GetAllTripsForSpecificCountry(Country country)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("Select Trips.*, Guides.Guide_Name, Countries.Country_Name FROM ((Trips LEFT JOIN Guides ON Guides.ID = Trips.Guide_ID) INNER JOIN Countries ON Countries.ID = Trips.Country_ID) WHERE Country_ID=@Country_ID ORDER BY Start_Date");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_ID", OleDbType.Integer).Value = country.ID!;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }

        public static DataTable GetAllTripsForSpecificMonth(DateTime tripDate)
        {
            int daysInMonth = DateTime.DaysInMonth(tripDate.Year, tripDate.Month);
            DateTime startOfMonth = new DateTime(tripDate.Year, tripDate.Month, 1);
            DateTime endOfMonth = new DateTime(tripDate.Year, tripDate.Month, daysInMonth);

            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("Select Trips.*, Guides.Guide_Name, Countries.Country_Name FROM ((Trips LEFT JOIN Guides ON Guides.ID = Trips.Guide_ID) INNER JOIN Countries ON Countries.ID = Trips.Country_ID) WHERE Start_Date>=@startOfMonth AND Start_Date<=@endOfMonth ORDER BY Start_Date");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@startOfMonth", OleDbType.Date).Value = startOfMonth.Date;
                cmd.Parameters.Add("@endOfMonth", OleDbType.Date).Value = endOfMonth.Date;

                try
                {
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    dt = ds.Tables[0];
                }
                catch (OleDbException ex)
                {
                    MessageBox.Show(ex.Source);
                    return null;
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                Utils.MessageBoxRTL("החיבור למסד הנתונים נכשל");
                return null;
            }

            return dt;
        }
        #endregion

        #region Users

        public static bool Login(User u)
        {
            //TODO: check if user exists

            return false;
        }

        #endregion
    }
}
