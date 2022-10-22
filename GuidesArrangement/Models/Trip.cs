using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    class Trip
    {
        public int? ID { get; set; }
        public Country Country { get; set; }
        public Guide? Guide { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsFinal { get; set; }

        public Trip(Country country, DateTime startDate, DateTime endDate, bool isFinal, int? id = null, Guide? guide = null)
        {
            ID = id;
            Guide = guide;
            Country = country;
            StartDate = startDate;
            EndDate = endDate;
            IsFinal = isFinal;
        }

        public Trip(DataRow row)
        {
            ID = (int)row["ID"];
            Country = DBLogic.GetCountry((int)row["Country_ID"]);
            StartDate = (DateTime)row["Start_Date"];
            EndDate = (DateTime)row["End_Date"];
            Guide = (int)row["Guide_ID"] != -1 ? DBLogic.GetGuide((int)row["Guide_ID"]) : new Guide("",new List<Country>(),"","",-1);
            IsFinal = row["Is_Final"] is DBNull ? true : row["Is_Final"].GetType() == typeof(bool) ? (bool)row["Is_Final"] : ((string)row["Is_Final"]) == "סופי";
        }
    }
}
