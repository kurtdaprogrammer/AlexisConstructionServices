namespace BOGSYDVDRENT.Views
{
    partial class ReportsFormViews
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            label1 = new Label();
            dtpStartDate = new DateTimePicker();
            dtpEndDate = new DateTimePicker();
            chkFilterDate = new CheckBox();
            label2 = new Label();
            label3 = new Label();
            btnViewRentals = new Button();
            btnViewReturns = new Button();
            dataGridView1 = new DataGridView();
            tbCustomer = new TextBox();
            btnSelectCustomer = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 23);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 0;
            label1.Text = "Customer:";
            // 
            // dtpStartDate
            // 
            dtpStartDate.Location = new Point(110, 60);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(200, 23);
            dtpStartDate.TabIndex = 2;
            // 
            // dtpEndDate
            // 
            dtpEndDate.Location = new Point(420, 60);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(200, 23);
            dtpEndDate.TabIndex = 3;
            // 
            // chkFilterDate
            // 
            chkFilterDate.AutoSize = true;
            chkFilterDate.Location = new Point(330, 22);
            chkFilterDate.Name = "chkFilterDate";
            chkFilterDate.Size = new Size(79, 19);
            chkFilterDate.TabIndex = 1;
            chkFilterDate.Text = "Filter Date";
            chkFilterDate.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 65);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "Start Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(330, 65);
            label3.Name = "label3";
            label3.Size = new Size(57, 15);
            label3.TabIndex = 5;
            label3.Text = "End Date:";
            // 
            // btnViewRentals
            // 
            btnViewRentals.Location = new Point(640, 20);
            btnViewRentals.Name = "btnViewRentals";
            btnViewRentals.Size = new Size(120, 30);
            btnViewRentals.TabIndex = 6;
            btnViewRentals.Text = "View Rentals";
            btnViewRentals.UseVisualStyleBackColor = true;
            btnViewRentals.Click += btnViewRentals_Click;
            // 
            // btnViewReturns
            // 
            btnViewReturns.Location = new Point(640, 60);
            btnViewReturns.Name = "btnViewReturns";
            btnViewReturns.Size = new Size(120, 30);
            btnViewReturns.TabIndex = 7;
            btnViewReturns.Text = "View Returns";
            btnViewReturns.UseVisualStyleBackColor = true;
            btnViewReturns.Click += btnViewReturns_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 110);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 24;
            dataGridView1.Size = new Size(740, 320);
            dataGridView1.TabIndex = 8;
            // 
            // tbCustomer
            // 
            tbCustomer.Location = new Point(110, 20);
            tbCustomer.Name = "tbCustomer";
            tbCustomer.Size = new Size(200, 23);
            tbCustomer.TabIndex = 9;
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.Location = new Point(432, 15);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(120, 30);
            btnSelectCustomer.TabIndex = 10;
            btnSelectCustomer.Text = "Select Customer";
            btnSelectCustomer.UseVisualStyleBackColor = true;
            btnSelectCustomer.Click += btnSelectCustomer_Click;
            // 
            // ReportsFormViews
            // 
            ClientSize = new Size(784, 461);
            Controls.Add(btnSelectCustomer);
            Controls.Add(tbCustomer);
            Controls.Add(label1);
            Controls.Add(chkFilterDate);
            Controls.Add(dtpStartDate);
            Controls.Add(dtpEndDate);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(btnViewRentals);
            Controls.Add(btnViewReturns);
            Controls.Add(dataGridView1);
            Name = "ReportsFormViews";
            Text = "Rental and Return Reports";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // private System.Windows.Forms.ComboBox cbCustomers;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.CheckBox chkFilterDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewRentals;
        private System.Windows.Forms.Button btnViewReturns;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TextBox tbCustomer;
        private Button btnSelectCustomer;
    }
}
