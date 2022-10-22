namespace GuidesArrangement
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.addTripButton = new System.Windows.Forms.Button();
            this.addCountryButton = new System.Windows.Forms.Button();
            this.addGuideButton = new System.Windows.Forms.Button();
            this.viewByGuideButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ColumnHeadersVisible = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 29;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(776, 339);
            this.dataGridView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(453, 22);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 1;
            this.button1.Text = "טיולים";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.allTrips_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(353, 22);
            this.button2.Name = "button2";
            this.button2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "יעדים";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.allCountries_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(253, 22);
            this.button3.Name = "button3";
            this.button3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button3.Size = new System.Drawing.Size(94, 29);
            this.button3.TabIndex = 3;
            this.button3.Text = "מדריכים";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.allGuides_Click);
            // 
            // addTripButton
            // 
            this.addTripButton.Location = new System.Drawing.Point(453, 402);
            this.addTripButton.Name = "addTripButton";
            this.addTripButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addTripButton.Size = new System.Drawing.Size(94, 29);
            this.addTripButton.TabIndex = 4;
            this.addTripButton.Text = "הוסף טיול";
            this.addTripButton.UseVisualStyleBackColor = true;
            this.addTripButton.Click += new System.EventHandler(this.newTrip_Click);
            // 
            // addCountryButton
            // 
            this.addCountryButton.Location = new System.Drawing.Point(353, 402);
            this.addCountryButton.Name = "addCountryButton";
            this.addCountryButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addCountryButton.Size = new System.Drawing.Size(94, 29);
            this.addCountryButton.TabIndex = 5;
            this.addCountryButton.Text = "הוסף יעד";
            this.addCountryButton.UseVisualStyleBackColor = true;
            this.addCountryButton.Click += new System.EventHandler(this.newCountry_Click);
            // 
            // addGuideButton
            // 
            this.addGuideButton.Location = new System.Drawing.Point(253, 402);
            this.addGuideButton.Name = "addGuideButton";
            this.addGuideButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addGuideButton.Size = new System.Drawing.Size(94, 29);
            this.addGuideButton.TabIndex = 6;
            this.addGuideButton.Text = "הוסף מדריך";
            this.addGuideButton.UseVisualStyleBackColor = true;
            this.addGuideButton.Click += new System.EventHandler(this.newGuide_Click);
            // 
            // viewByGuideButton
            // 
            this.viewByGuideButton.Location = new System.Drawing.Point(110, 402);
            this.viewByGuideButton.Name = "viewByGuideButton";
            this.viewByGuideButton.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.viewByGuideButton.Size = new System.Drawing.Size(137, 29);
            this.viewByGuideButton.TabIndex = 7;
            this.viewByGuideButton.Text = "צפייה לפי מדריך";
            this.viewByGuideButton.UseVisualStyleBackColor = true;
            this.viewByGuideButton.Click += new System.EventHandler(this.viewByGuideButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.viewByGuideButton);
            this.Controls.Add(this.addGuideButton);
            this.Controls.Add(this.addCountryButton);
            this.Controls.Add(this.addTripButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridView1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button addTripButton;
        private Button addCountryButton;
        private Button addGuideButton;
        private Button viewByGuideButton;
    }
}