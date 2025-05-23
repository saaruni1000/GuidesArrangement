﻿using System;
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
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? Salary { get; set; }
        public bool CanRepeat { get; set; }
        public Guide(string name, List<Country> countries, string phoneNumber, string email, int? id = null, int? salary = null, bool canRepeat = false)
        {
            ID = id;
            Name = name;
            Countries = countries;
            PhoneNumber = phoneNumber;
            Email = email;
            Salary = salary;
            CanRepeat = canRepeat;
        }

        public Guide(DataTable dt)
        {
            Name = (string)dt.Rows[0]["Guide_Name"];
            ID = (int)dt.Rows[0]["Guide_ID"];
            Countries = new List<Country>();
            foreach (DataRow row in dt.Rows)
            {
                if (row["Country_Name"] is not DBNull && row["Country_ID"] is not DBNull)
                {
                    Countries.Add(new Country((string)row["Country_Name"], (int)row["Country_ID"]));
                }
            }
            PhoneNumber = (string)dt.Rows[0]["Phone_Number"];
            Email = (string)dt.Rows[0]["Email"];
            Salary = dt.Rows[0]["Salary"] is DBNull ? null : (int)dt.Rows[0]["Salary"];
            CanRepeat = (bool)dt.Rows[0]["CanRepeat"];
        }
    }
}
