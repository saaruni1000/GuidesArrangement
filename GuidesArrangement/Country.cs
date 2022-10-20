using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    internal class Country
    {
        public string Name { get; set; }

        public Country(string name)
        {
            this.Name = name;
        }

        public Country(DataRow row)
        {
            Name = (string)row[1];
        }
    }
}
