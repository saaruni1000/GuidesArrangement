using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    enum FormType
    {
        NEW,
        EDIT
    }
    class Utils
    {
        public static List<Guide> ParseGuides(DataTable dt)
        {
            List<Guide> guides = new List<Guide>();
            List<DataTable> dtSplitByIDs = dt.AsEnumerable()
           .GroupBy(row => row.Field<int>("Guide_ID"))
           .Select(g => g.CopyToDataTable())
           .ToList();
            foreach (DataTable guideDT in dtSplitByIDs)
            {
                guides.Add(new Guide(guideDT));
            }

            return guides;
        }
        public static List<AvailableGuide> ParseAvailableGuides(DataTable dt)
        {
            List<AvailableGuide> guides = new List<AvailableGuide>();
            dt.Columns["Guides.ID"]!.ColumnName = "Guide_ID";
            dt.Columns.Add("Country_ID", typeof(int));
            dt.Columns.Add("Country_Name", typeof(string));
            List<DataTable> dtSplitByIDs = dt.AsEnumerable()
           .GroupBy(row => row.Field<int>("Guide_ID"))
           .Select(g => g.CopyToDataTable())
           .ToList();
            foreach (DataTable guideDT in dtSplitByIDs)
            {
                guides.Add(new AvailableGuide(guideDT));
            }

            return guides;
        }
        public static DataTable GuidesListToDataTable(List<Guide> guides)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Guide_Name", typeof(string));
            dt.Columns.Add("Countries", typeof(string));
            dt.Columns.Add("Phone_Number", typeof(string));
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Salary", typeof(int));
            foreach (Guide guide in guides)
            {
                object[] row = { guide.ID!, guide.Name, string.Join(", ", guide.Countries.Select(country => country.Name)), guide.PhoneNumber, guide.Email, guide.Salary };
                dt.Rows.Add(row);
            }
            return dt;
        }
        public static DataTable AvilableGuidesListToDataTable(List<AvailableGuide> guides, DateTime startDate, DateTime endDate, int currentGuide = -1)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Guide_Name", typeof(string));
            object[] r = { -1, "" };
            dt.Rows.Add(r);
            foreach (AvailableGuide guide in guides)
            {
                if (currentGuide == guide.ID || guide.isAvailable(startDate, endDate))
                {
                    object[] row = { guide.ID!, guide.Name };
                    dt.Rows.Add(row);
                }
            }
            return dt;
        }
        public static void MessageBoxRTL(string message)
        {
            MessageBox.Show(message, "", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
        }
    }
}
