namespace GuidesArrangement
{
    partial class GuideForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            label1 = new Label();
            checkedListBox1 = new CheckedListBox();
            button1 = new Button();
            button2 = new Button();
            phoneNumberTextBox = new TextBox();
            emailTextBox = new TextBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            textBox2 = new TextBox();
            checkBoxCanRepeat = new CheckBox();
            label5 = new Label();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.None;
            textBox1.Location = new Point(526, 63);
            textBox1.Name = "textBox1";
            textBox1.RightToLeft = RightToLeft.Yes;
            textBox1.Size = new Size(183, 27);
            textBox1.TabIndex = 0;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Location = new Point(627, 40);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.Yes;
            label1.Size = new Size(82, 20);
            label1.TabIndex = 1;
            label1.Text = "שם המדריך";
            // 
            // checkedListBox1
            // 
            checkedListBox1.Anchor = AnchorStyles.None;
            checkedListBox1.CheckOnClick = true;
            checkedListBox1.FormattingEnabled = true;
            checkedListBox1.Location = new Point(229, 63);
            checkedListBox1.Name = "checkedListBox1";
            checkedListBox1.RightToLeft = RightToLeft.Yes;
            checkedListBox1.Size = new Size(291, 312);
            checkedListBox1.TabIndex = 2;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.None;
            button1.Location = new Point(91, 346);
            button1.Name = "button1";
            button1.RightToLeft = RightToLeft.Yes;
            button1.Size = new Size(94, 29);
            button1.TabIndex = 3;
            button1.Text = "הוסף מדריך";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.None;
            button2.Location = new Point(91, 381);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.Yes;
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "חזור";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // phoneNumberTextBox
            // 
            phoneNumberTextBox.Anchor = AnchorStyles.None;
            phoneNumberTextBox.Location = new Point(526, 127);
            phoneNumberTextBox.Name = "phoneNumberTextBox";
            phoneNumberTextBox.Size = new Size(183, 27);
            phoneNumberTextBox.TabIndex = 5;
            // 
            // emailTextBox
            // 
            emailTextBox.Anchor = AnchorStyles.None;
            emailTextBox.Location = new Point(526, 192);
            emailTextBox.Name = "emailTextBox";
            emailTextBox.Size = new Size(183, 27);
            emailTextBox.TabIndex = 6;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.None;
            label2.AutoSize = true;
            label2.Location = new Point(660, 169);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(49, 20);
            label2.TabIndex = 7;
            label2.Text = "אימייל";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Location = new Point(624, 104);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(85, 20);
            label3.TabIndex = 8;
            label3.Text = "מספר טלפון";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.None;
            label4.AutoSize = true;
            label4.Location = new Point(672, 234);
            label4.Name = "label4";
            label4.RightToLeft = RightToLeft.Yes;
            label4.Size = new Size(37, 20);
            label4.TabIndex = 10;
            label4.Text = "שכר";
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.None;
            textBox2.Location = new Point(526, 257);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(183, 27);
            textBox2.TabIndex = 9;
            // 
            // checkBoxCanRepeat
            // 
            checkBoxCanRepeat.AutoSize = true;
            checkBoxCanRepeat.Location = new Point(608, 307);
            checkBoxCanRepeat.Name = "checkBoxCanRepeat";
            checkBoxCanRepeat.RightToLeft = RightToLeft.Yes;
            checkBoxCanRepeat.Size = new Size(18, 17);
            checkBoxCanRepeat.TabIndex = 11;
            checkBoxCanRepeat.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(632, 304);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(77, 20);
            label5.TabIndex = 12;
            label5.Text = "יכול לחפוף";
            // 
            // GuideForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(checkBoxCanRepeat);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(emailTextBox);
            Controls.Add(phoneNumberTextBox);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(checkedListBox1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "GuideForm";
            Text = "AddGuideForm";
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private TextBox textBox1;
        private Label label1;
        private CheckedListBox checkedListBox1;
        private Button button1;
        private Button button2;
        private TextBox phoneNumberTextBox;
        private TextBox emailTextBox;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox textBox2;
        private CheckBox checkBoxCanRepeat;
        private Label label5;
    }
}