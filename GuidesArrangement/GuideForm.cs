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
    partial class GuideForm : Form
    {
        
        public GuideForm(FormType type, Guide? guide=null)
        {
            InitializeComponent();
            DataTable dt = DBLogic.GetAllCountries();
            checkedListBox1.DataSource = dt;
            checkedListBox1.DisplayMember = "Country_Name";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Country> countries = new List<Country>();
            foreach(DataRowView item in checkedListBox1.CheckedItems)
            {
                countries.Add(new Country(item.Row));
            }
            Guide guide = new Guide(textBox1.Text, countries);
            DBLogic.AddGuide(guide);
            Close();
        }
    }
}
