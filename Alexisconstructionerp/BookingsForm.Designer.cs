namespace Alexisconstructionerp
{
    partial class BookingsForm
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
            bookingsdatagrid = new DataGridView();
            button1 = new Button();
            Clientselectedtb = new TextBox();
            addservicebtn = new Button();
            submitbookingbtn = new Button();
            dateTimePicker1 = new DateTimePicker();
            textBox1 = new TextBox();
            Statuscb = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)bookingsdatagrid).BeginInit();
            SuspendLayout();
            // 
            // bookingsdatagrid
            // 
            bookingsdatagrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bookingsdatagrid.Location = new Point(434, 12);
            bookingsdatagrid.Name = "bookingsdatagrid";
            bookingsdatagrid.Size = new Size(344, 426);
            bookingsdatagrid.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(313, 37);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Clientselectedtb
            // 
            Clientselectedtb.Enabled = false;
            Clientselectedtb.Location = new Point(62, 37);
            Clientselectedtb.Name = "Clientselectedtb";
            Clientselectedtb.ReadOnly = true;
            Clientselectedtb.Size = new Size(200, 23);
            Clientselectedtb.TabIndex = 2;
            // 
            // addservicebtn
            // 
            addservicebtn.Location = new Point(113, 196);
            addservicebtn.Name = "addservicebtn";
            addservicebtn.Size = new Size(75, 23);
            addservicebtn.TabIndex = 3;
            addservicebtn.Text = "AddServiceBtn";
            addservicebtn.UseVisualStyleBackColor = true;
            addservicebtn.Visible = false;
            addservicebtn.Click += addservicebtn_Click;
            // 
            // submitbookingbtn
            // 
            submitbookingbtn.Location = new Point(194, 196);
            submitbookingbtn.Name = "submitbookingbtn";
            submitbookingbtn.Size = new Size(75, 23);
            submitbookingbtn.TabIndex = 4;
            submitbookingbtn.Text = "button";
            submitbookingbtn.UseVisualStyleBackColor = true;
            submitbookingbtn.Visible = false;
            submitbookingbtn.Click += submitbookingbtn_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(62, 73);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.Value = new DateTime(2025, 7, 28, 23, 11, 18, 0);
            dateTimePicker1.Visible = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(62, 151);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 7;
            textBox1.Visible = false;
            // 
            // Statuscb
            // 
            Statuscb.FormattingEnabled = true;
            Statuscb.Location = new Point(62, 112);
            Statuscb.Name = "Statuscb";
            Statuscb.Size = new Size(200, 23);
            Statuscb.TabIndex = 9;
            Statuscb.Visible = false;
            // 
            // BookingsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Statuscb);
            Controls.Add(textBox1);
            Controls.Add(dateTimePicker1);
            Controls.Add(submitbookingbtn);
            Controls.Add(addservicebtn);
            Controls.Add(Clientselectedtb);
            Controls.Add(button1);
            Controls.Add(bookingsdatagrid);
            Name = "BookingsForm";
            Text = "BookingsForm";
            ((System.ComponentModel.ISupportInitialize)bookingsdatagrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView bookingsdatagrid;
        private Button button1;
        private TextBox Clientselectedtb;
        private Button addservicebtn;
        private Button submitbookingbtn;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox1;
        private ComboBox Statuscb;
    }
}