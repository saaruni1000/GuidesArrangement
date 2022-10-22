using System.ComponentModel.DataAnnotations;
using System.Data;

namespace GuidesArrangement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void clearOnClick()
        {
            dataGridView1.CellClick -= CountryEditClick;
            dataGridView1.CellClick -= TripEditClick;
            dataGridView1.CellClick -= GuideEditClick;
            dataGridView1.CellClick -= CountryDeleteClick;
            dataGridView1.CellClick -= TripDeleteClick;
            dataGridView1.CellClick -= GuideDeleteClick;
        }

        #region Trips

        private DataTable changeIDsToNames(DataTable rawDT)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Country_Name", typeof(string));
            foreach (DataColumn column in rawDT.Columns)
            {
                dt.Columns.Add(column.ColumnName, column.DataType);
            }
            dt.Columns.Add("Guide_Name", typeof(string));
            foreach (DataRow row in rawDT.Rows)
            {
                Trip trip = new Trip(row);
                object[] tempRow =
                {
                    trip.Country.Name,
                    trip.ID!,
                    trip.Country.ID!,
                    trip.StartDate,
                    trip.EndDate,
                    trip.Guide==null?-1:trip.Guide.ID!,
                    trip.Guide?.Name
                };
                dt.Rows.Add(tempRow);
            }

            return dt;
        }

        private void allTrips_Click(object sender, EventArgs e)
        {
            clearOnClick();
            dataGridView1.Columns.Clear();
            DataTable tripsRawDT = DBLogic.GetAllTrips();
            dataGridView1.DataSource = changeIDsToNames(tripsRawDT);
            dataGridView1.Columns["ID"].Visible = false;
            dataGridView1.Columns["Guide_ID"].Visible = false;
            dataGridView1.Columns["Country_ID"].Visible = false;
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.UseColumnTextForButtonValue = true;
            editButton.Name = "Edit_Column";
            editButton.Text = "ערוך";
            if (dataGridView1.Columns[editButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, editButton);
            }
            dataGridView1.CellClick += TripEditClick;
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Name = "Delete_Column";
            deleteButton.Text = "הסר";
            if (dataGridView1.Columns[deleteButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, deleteButton);
            }
            dataGridView1.CellClick += TripDeleteClick;
        }

        private void TripDeleteClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Delete_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Trip trip = new Trip(row);
                DBLogic.RemoveTrip(trip);
                allTrips_Click(sender, e);
            }
        }

        private void TripEditClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Trip trip = new Trip(row);
                Hide();
                new TripForm(FormType.EDIT, trip).ShowDialog();
                allTrips_Click(sender, e);
                Show();
            }
        }

        private void newTrip_Click(object sender, EventArgs e)
        {
            Hide();
            new TripForm(FormType.NEW).ShowDialog();
            allTrips_Click(sender, e);
            Show();
        }
        #endregion

        #region Countries
        private void allCountries_Click(object sender, EventArgs e)
        {
            clearOnClick();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DBLogic.GetAllCountries();
            dataGridView1.Columns["ID"].Visible = false;
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.UseColumnTextForButtonValue = true;
            editButton.Name = "Edit_Column";
            editButton.Text = "ערוך";
            if (dataGridView1.Columns[editButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, editButton);
            }
            dataGridView1.CellClick += CountryEditClick;
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Name = "Delete_Column";
            deleteButton.Text = "הסר";
            if (dataGridView1.Columns[deleteButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, deleteButton);
            }
            dataGridView1.CellClick += CountryDeleteClick;
        }

        private void CountryDeleteClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Delete_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Country country = new Country(row);
                DBLogic.RemoveCountry(country);
                allCountries_Click(sender, e);
            }
        }

        private void CountryEditClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Country country = new Country(row);
                Hide();
                new CountryForm(FormType.EDIT, country).ShowDialog();
                allCountries_Click(sender, e);
                Show();
            }
        }

        private void newCountry_Click(object sender, EventArgs e)
        {
            Hide();
            new CountryForm(FormType.NEW).ShowDialog();
            allCountries_Click(sender, e);
            Show();
        }
        #endregion

        #region Guides
        private void allGuides_Click(object sender, EventArgs e)
        {
            clearOnClick();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = Utils.GuidesListToDataTable(Utils.ParseGuides(DBLogic.GetAllGuides()));
            dataGridView1.Columns["ID"].Visible = false;
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.UseColumnTextForButtonValue = true;
            editButton.Name = "Edit_Column";
            editButton.Text = "ערוך";
            if (dataGridView1.Columns[editButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, editButton);
            }
            dataGridView1.CellClick += GuideEditClick;
            DataGridViewButtonColumn deleteButton = new DataGridViewButtonColumn();
            deleteButton.UseColumnTextForButtonValue = true;
            deleteButton.Name = "Delete_Column";
            deleteButton.Text = "הסר";
            if (dataGridView1.Columns[deleteButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, deleteButton);
            }
            dataGridView1.CellClick += GuideDeleteClick;
        }

        private void GuideDeleteClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Delete_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Guide guide = new Guide((string)row["Guide_Name"], new List<Country>(), (int)row["ID"]);
                DBLogic.RemoveGuide(guide);
                allGuides_Click(sender, e);
            }
        }

        private void GuideEditClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Guide guide = DBLogic.GetGuide((int)row["ID"])!;
                Hide();
                new GuideForm(FormType.EDIT, guide).ShowDialog();
                allGuides_Click(sender, e);
                Show();
            }
        }

        private void newGuide_Click(object sender, EventArgs e)
        {
            Hide();
            new GuideForm(FormType.NEW).ShowDialog();
            allGuides_Click(sender, e);
            Show();
        }
        #endregion
    }
}