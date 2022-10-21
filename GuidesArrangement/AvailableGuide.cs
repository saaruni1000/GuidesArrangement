using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    internal class AvailableGuide : Guide
    {
        public List<Tuple<DateTime, DateTime>> TripsDates { get; set; }
        public AvailableGuide(DataTable dt) : base(dt)
        {
            TripsDates = new List<Tuple<DateTime, DateTime>>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Start_Date"] is not DBNull && row["End_Date"] is not DBNull)
                {
                    TripsDates.Add(Tuple.Create((DateTime)row["Start_Date"], (DateTime)row["End_Date"]));
                }
            }
        }

        public bool isAvailable(DateTime startDate, DateTime endDate)
        {
            foreach (Tuple<DateTime, DateTime> pair in TripsDates)
            {
                if ((pair.Item1.Date <= startDate.Date && pair.Item2.Date >= startDate.Date) || (pair.Item1.Date <= endDate.Date && pair.Item2.Date >= endDate.Date))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
