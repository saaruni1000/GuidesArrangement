using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuidesArrangement
{
    partial class CountryForm : Form
    {
        FormType type;
        Country? country;
        public CountryForm(FormType type, Country? country = null)
        {
            InitializeComponent();
            this.type = type;
            this.country = country;
            if (type == FormType.EDIT && country != null)
            {
                button1.Text = "ערוך מדינה";
                textBox1.Text = country.Name;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (country == null)
            {
                country = new Country("");
            }
            country.Name = textBox1.Text;
            if (type == FormType.EDIT)
            {
                DBLogic.UpdateCountry(country);
            }
            else
            {
                DBLogic.AddCountry(country);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
