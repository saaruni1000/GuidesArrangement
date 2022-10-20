using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuidesArrangement
{
    internal class Guide
    {
        public string Name { get; set; }
        public string[] Countries { get; set; }
        public Guide(string name, string[] countries)
        {
            Name = name;
            Countries = countries;
        }

        public Guide(DataRow row)
        {
            Name = (string)row[1];
            Countries = ((string)row[2]).Split(',');
        }
    }
}
