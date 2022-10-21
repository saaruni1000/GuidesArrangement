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
    partial class TripForm : Form
    {
        public TripForm(FormType type, Trip? trip =null)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBLogic.AddTrip(new Trip(new Country(textBox1.Text), startDate.Value.Date, endDate.Value.Date));
        }
    }
}
