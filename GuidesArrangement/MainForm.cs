namespace GuidesArrangement
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            DBLogic.GetAllGuides();
        }
    }
}