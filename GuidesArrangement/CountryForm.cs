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
    public partial class CountryForm : Form
    {
        public CountryForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            label1.Text = Path.GetDirectoryName(executable);*/
            string countryName = textBox1.Text;
            //DBLogic.AddCountry(countryName);
        }
    }
}
