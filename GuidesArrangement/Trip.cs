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

        public Trip(Country country, DateTime startDate, DateTime endDate, int? id=null, Guide? guide=null)
        {
            ID = id;
            Guide = guide;
            Country = country;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Trip(DataRow row)
        {
            ID = (int)row["ID"];
            Country = DBLogic.GetCountry((int)row["Country_ID"]);
            StartDate = (DateTime)row["Start_Date"];
            EndDate = (DateTime)row["End_Date"];
            Guide = DBLogic.GetGuide((int)row["Guide_ID"]);
        }
    }
}
