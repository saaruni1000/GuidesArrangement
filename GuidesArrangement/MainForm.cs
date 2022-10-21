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
        }

        //trips
        private void allTrips_Click(object sender, EventArgs e)
        {
            clearOnClick();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DBLogic.GetAllTrips();
            dataGridView1.Columns["ID"].Visible = false;
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit_Column";
            editButton.Text = "Edit";
            if (dataGridView1.Columns[editButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, editButton);
            }
            dataGridView1.CellClick += TripEditClick;
        }

        private void TripEditClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit_Column"]?.Index)
            {
                DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Trip trip = new Trip(row);
                Application.Run(new TripForm(FormType.EDIT, trip));
            }
        }

        //countries
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

        //guides
        private void allGuides_Click(object sender, EventArgs e)
        {
            clearOnClick();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = DBLogic.GetAllGuides();
            dataGridView1.Columns["ID"].Visible = false;
            DataGridViewButtonColumn editButton = new DataGridViewButtonColumn();
            editButton.Name = "Edit_Column";
            editButton.Text = "Edit";
            if (dataGridView1.Columns[editButton.Name] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, editButton);
            }
            dataGridView1.CellClick += GuideEditClick;
        }

        private void GuideEditClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit_Column"]?.Index)
            {
                /*DataRow row = ((DataRowView)dataGridView1.Rows[e.RowIndex].DataBoundItem).Row;
                Guide guide = new Guide(row);
                Application.Run(new GuideForm(FormType.EDIT, guide));*/
            }
        }

        private void newTrip_Click(object sender, EventArgs e)
        {
            Hide();
            new TripForm(FormType.NEW).ShowDialog();
            allTrips_Click(sender, e);
            Show();
        }

        private void newCountry_Click(object sender, EventArgs e)
        {
            Hide();
            new CountryForm(FormType.NEW).ShowDialog();
            allCountries_Click(sender, e);
            Show();
        }

        private void newGuide_Click(object sender, EventArgs e)
        {
            Hide();
            new GuideForm(FormType.NEW).ShowDialog();
            allGuides_Click(sender, e);
            Show();
        }
    }
}