using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    internal class Trip
    {
        public int? ID { get; set; }
        public Country Country { get; set; }
        public Guide? Guide { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Trip(Country country, DateTime startDate, DateTime endDate)
        {
            Country = country;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Trip(Country country, Guide guide, DateTime startDate, DateTime endDate)
        {
            Country = country;
            Guide = guide;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Trip(int id, Country country, DateTime startDate, DateTime endDate)
        {
            ID = id;
            Country = country;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Trip(int id, Country country, Guide guide, DateTime startDate, DateTime endDate)
        {
            ID = id;
            Country = country;
            Guide = guide;
            StartDate = startDate;
            EndDate = endDate;
        }

        public Trip(DataRow row)
        {
            ID = (int)row[0];
            Country = DBLogic.GetCountry((string)row[1]);
            StartDate = (DateTime)row[2];
            EndDate = (DateTime)row[3];
            Guide = DBLogic.GetGuide((string)row[4]);
        }
    }
}
