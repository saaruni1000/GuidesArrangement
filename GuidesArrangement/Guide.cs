using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    class Guide
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public List<Country> Countries { get; set; }
        public Guide(string name, List<Country> countries, int? id = null)
        {
            ID = id;
            Name = name;
            Countries = countries;
        }

        public Guide(DataTable dt)
        {
            Name = (string)dt.Rows[0]["Guide_Name"];
            ID = (int)dt.Rows[0]["Guide_ID"];
            Countries = new List<Country>();
            foreach(DataRow row in dt.Rows)
            {
                if (row["Country_Name"] is not DBNull && row["Country_ID"] is not DBNull)
                {
                    Countries.Add(new Country((string)row["Country_Name"], (int)row["Country_ID"]));
                }
            }
        }
    }
}
