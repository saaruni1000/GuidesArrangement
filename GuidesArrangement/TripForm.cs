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
        FormType type;
        Trip? trip;
        public TripForm(FormType type, Trip? trip = null)
        {
            InitializeComponent();
            this.type = type;
            this.trip = trip;
            DataTable countries = DBLogic.GetAllCountries();
            countriesComboBox.DataSource = countries;
            countriesComboBox.DisplayMember = "Country_Name";
            if (type == FormType.EDIT && trip != null)
            {
                button1.Text = "ערוך טיול";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trip == null)
            {
                trip = new Trip(new Country(""), DateTime.Now, DateTime.Now);
            }
            //DBLogic.AddTrip(new Trip(new Country(textBox1.Text), startDate.Value.Date, endDate.Value.Date));
        }

        private void updateGuides()
        {
            DataRow row = ((DataRowView)countriesComboBox.Items[countriesComboBox.SelectedIndex]).Row;
            comboBox1.DataSource = DBLogic.GetGuidesForSpecificCountryAndTime(new Country(row), startDate.Value, endDate.Value);
            comboBox1.DisplayMember = "Guide_Name";
        }
        private void countriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateGuides();
        }

        private void startDate_ValueChanged(object sender, EventArgs e)
        {
            updateGuides();
        }

        private void endDate_ValueChanged(object sender, EventArgs e)
        {
            updateGuides();
        }
    }
}
