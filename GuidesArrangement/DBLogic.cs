using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    internal class DBLogic
    {
        private static OleDbConnection createConn()
        {
            OleDbConnection conn = new OleDbConnection();
            /*string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.GetDirectoryName(executable));
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\db\guides_and_countries.accdb";*/
            conn.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\Saar\Desktop\For Dad\GuidesArrangement\GuidesArrangement\db\guides_and_countries.accdb";
            return conn;
        }

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
                    Utils.MessageBoxRTL(country.Name + " נוסף בהצלחה!");
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
            OleDbCommand cmd = new OleDbCommand("DELETE from Countries where Country_Name=@Country_Name");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_Name", OleDbType.VarChar).Value = country.Name;

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL(country.Name + " נמחק בהצלחה!");
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

        public static void AddGuide(Guide guide)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("INSERT into Guides (Guide_Name,Countries) Values(@Guide_Name,@Countries)");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = guide.Name;
                cmd.Parameters.Add("@Countries", OleDbType.VarChar).Value = String.Join(",", guide.Countries);

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL(guide.Name + " נוסף בהצלחה!");
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
            OleDbCommand cmd = new OleDbCommand("DELETE from Guides where Guide_Name = @Guide_Name");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = guide.Name;

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL(guide.Name + " נמחק בהצלחה!");
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
            OleDbCommand cmd = new OleDbCommand("UPDATE Guides SET Countries = @Countries where Guide_Name = @Guide_Name");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Countries", OleDbType.VarChar).Value = String.Join(",", guide.Countries);
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = guide.Name;

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL(guide.Name + " עודכן בהצלחה!");
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

        public static Guide[]? GetAllGuides()
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Guides");
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

            Guide[] guides = new Guide[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                guides[i] = new Guide(dt.Rows[i]);
            }

            return guides;
        }

        public static Country[]? GetAllCountries()
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

            Country[] countries = new Country[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                countries[i] = new Country(dt.Rows[i]);
            }

            return countries;
        }

        public static Trip[]? GetAllTrips()
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Trips");
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

            Trip[] trips = new Trip[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                trips[i] = new Trip(dt.Rows[i]);
            }

            return trips;
        }

        public static Guide? GetGuide(string guideName)
        {
            if (guideName == null)
            {
                return null;
            }

            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Guides where Guide_Name=@Guide_Name");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = guideName;

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

            return new Guide(dt.Rows[0]);
        }

        public static Country GetCountry(string countryName)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("SELECT * from Countries where Country_Name=@Country_Name");
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataTable dt;
            DataSet ds = new DataSet();
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_Name", OleDbType.VarChar).Value = countryName;

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
        public static void AddTrip(Trip trip)
        {
            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("INSERT into Trips (Country_Name,Start_Date,End_Date) Values(@Country_Name,@Start_Date,@End_Date)");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Country_Name", OleDbType.VarChar).Value = trip.Country.Name;
                cmd.Parameters.Add("@Start_Date", OleDbType.DBDate).Value = trip.StartDate;
                cmd.Parameters.Add("@End_Date", OleDbType.DBDate).Value = trip.EndDate;

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL("הטיול נוסף בהצלחה!");
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
            OleDbCommand cmd = new OleDbCommand("DELETE from Trips where ID = @ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = trip.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL("הטיול נמחק בהצלחה!");
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

        public static bool SetGuideForTrip(Trip trip)
        {
            if (trip.ID == null || trip.Guide == null)
            {
                return false;
            }

            OleDbConnection conn = createConn();
            OleDbCommand cmd = new OleDbCommand("UPDATE Trips SET Guide_Name = @Guide_Name where ID = @ID");
            cmd.Connection = conn;

            conn.Open();
            if (conn.State == ConnectionState.Open)
            {
                cmd.Parameters.Add("@Guide_Name", OleDbType.VarChar).Value = trip.Guide.Name;
                cmd.Parameters.Add("@ID", OleDbType.Integer).Value = trip.ID;

                try
                {
                    cmd.ExecuteNonQuery();
                    Utils.MessageBoxRTL(trip.Guide.Name + " נקבע עבור הטיול בהצלחה!");
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
    }
}
