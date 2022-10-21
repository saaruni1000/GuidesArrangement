using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    class Country
    {
        public int? ID { get; set; }
        public string Name { get; set; }

        public Country(string name, int? id = null)
        {
            ID = id;
            Name = name;
        }

        public Country(DataRow row)
        {
            ID = (int)row["ID"];
            Name = (string)row["Country_Name"];
        }
    }
}
