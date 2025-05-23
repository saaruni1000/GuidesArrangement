﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace GuidesArrangement
{
    partial class GuideForm : Form
    {
        FormType type;
        Guide? guide;
        public GuideForm(FormType type, Guide? guide = null)
        {
            InitializeComponent();
            this.type = type;
            DataTable dt = DBLogic.GetAllCountries();
            checkedListBox1.DataSource = dt;
            checkedListBox1.DisplayMember = "Country_Name";
            this.guide = guide;
            if (type == FormType.EDIT && guide != null)
            {
                textBox1.Text = guide.Name;
                List<int> CountryIDs = guide.Countries.Select(country => (int)country.ID!).ToList();
                for (int i = 0; i < checkedListBox1.Items.Count; i++)
                {
                    DataRowView row = (DataRowView)checkedListBox1.Items[i];
                    if (CountryIDs.Contains((int)row.Row["ID"]))
                    {
                        checkedListBox1.SetItemCheckState(i, CheckState.Checked);
                    }
                    button1.Text = "ערוך מדריך";
                }
                emailTextBox.Text = guide.Email;
                phoneNumberTextBox.Text = guide.PhoneNumber;
                textBox2.Text = guide.Salary == null ? "" : guide.Salary.ToString();
                checkBoxCanRepeat.Checked = guide.CanRepeat;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (guide == null)
            {
                guide = new Guide("", new List<Country>(), "", "");
            }
            List<Country> countries = new List<Country>();
            foreach (DataRowView item in checkedListBox1.CheckedItems)
            {
                countries.Add(new Country(item.Row));
            }
            guide.Name = textBox1.Text;
            guide.Countries = countries;
            guide.PhoneNumber = phoneNumberTextBox.Text;
            guide.Email = emailTextBox.Text;
            guide.Salary = textBox2.Text == "" ? null : int.Parse(textBox2.Text);
            guide.CanRepeat = checkBoxCanRepeat.Checked;
            if (type == FormType.EDIT)
            {
                DBLogic.UpdateGuide(guide);
            }
            else
            {
                DBLogic.AddGuide(guide);
            }
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
