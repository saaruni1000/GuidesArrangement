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
        List<AvailableGuide> availableGuides;
        public TripForm(FormType type, Trip? trip = null)
        {
            InitializeComponent();
            this.type = type;
            this.trip = trip;
            DataTable countries = DBLogic.GetAllCountries();
            countriesComboBox.DataSource = countries;
            countriesComboBox.DisplayMember = "Country_Name";
            comboBox1.DisplayMember = "Guide_Name";
            if (type == FormType.EDIT && trip != null)
            {
                button1.Text = "ערוך טיול";
                startDate.Value = trip.StartDate;
                endDate.Value = trip.EndDate;
                countriesComboBox.SelectedIndex = countriesComboBox.FindStringExact(trip.Country.Name);
                checkBox1.Checked = !trip.IsFinal;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (trip == null)
            {
                trip = new Trip(new Country(""), DateTime.Now, DateTime.Now, false);
            }
            trip.Country = new Country(((DataRowView)countriesComboBox.SelectedItem).Row);
            trip.StartDate = startDate.Value;
            trip.EndDate = endDate.Value;
            trip.IsFinal = !checkBox1.Checked;
            if (comboBox1.SelectedItem != null)
            {
                DataRow row = ((DataRowView)comboBox1.SelectedItem).Row;
                trip.Guide = new Guide((string)row["Guide_Name"], new List<Country>(), "", "", (int)row["ID"]);
            }
            else
            {
                trip.Guide = null;
            }

            if (trip.EndDate.Date <= trip.StartDate.Date)
            {
                Utils.MessageBoxRTL("תאריך הסיום חייב להיות אחרי תאריך ההתחלה");
                return;
            }

            if (type == FormType.EDIT)
            {
                DBLogic.UpdateTrip(trip);
            }
            else
            {
                DBLogic.AddTrip(trip);
            }
            Close();
        }

        private void countriesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRow row = ((DataRowView)countriesComboBox.Items[countriesComboBox.SelectedIndex]).Row;
            availableGuides = Utils.ParseAvailableGuides(DBLogic.GetGuidesForCountry(new Country(row)));
            updateAvailableGuides();
        }

        private void updateAvailableGuides()
        {
            int currentGuideID = trip != null ? (int)trip.Guide!.ID! : -1;
            comboBox1.DataSource = Utils.AvilableGuidesListToDataTable(availableGuides, startDate.Value, endDate.Value, currentGuideID);
            for (int i = 0; i < comboBox1.Items.Count; i++)
            {
                DataRow row = ((DataRowView)comboBox1.Items[i]).Row;
                if ((int)row["ID"] == currentGuideID)
                {
                    comboBox1.SelectedIndex = i;
                    break;
                }
            }
        }

        private void onDateChanged(object sender, EventArgs e)
        {
            updateAvailableGuides();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
