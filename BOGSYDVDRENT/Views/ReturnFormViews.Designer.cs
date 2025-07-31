namespace BOGSYDVDRENT.Views
{
    partial class ReturnFormViews
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
            tbCustomer = new TextBox();
            dgvCurrentRentals = new DataGridView();
            btnSelectCustomer = new Button();
            btnReturnSelected = new Button();
            lblPenalty = new Label();
            dtpReturnDate = new DateTimePicker();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCurrentRentals).BeginInit();
            SuspendLayout();
            // 
            // tbCustomer
            // 
            tbCustomer.Location = new Point(102, 30);
            tbCustomer.Name = "tbCustomer";
            tbCustomer.Size = new Size(214, 23);
            tbCustomer.TabIndex = 0;
            // 
            // dgvCurrentRentals
            // 
            dgvCurrentRentals.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCurrentRentals.Location = new Point(365, 21);
            dgvCurrentRentals.Name = "dgvCurrentRentals";
            dgvCurrentRentals.Size = new Size(423, 417);
            dgvCurrentRentals.TabIndex = 1;
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.Location = new Point(200, 59);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(116, 23);
            btnSelectCustomer.TabIndex = 2;
            btnSelectCustomer.Text = "Select Customer";
            btnSelectCustomer.UseVisualStyleBackColor = true;
            btnSelectCustomer.Click += btnSelectCustomer_Click;
            // 
            // btnReturnSelected
            // 
            btnReturnSelected.Location = new Point(223, 200);
            btnReturnSelected.Name = "btnReturnSelected";
            btnReturnSelected.Size = new Size(93, 23);
            btnReturnSelected.TabIndex = 3;
            btnReturnSelected.Text = "Return";
            btnReturnSelected.UseVisualStyleBackColor = true;
            btnReturnSelected.Click += btnReturnSelected_Click;
            // 
            // lblPenalty
            // 
            lblPenalty.AutoSize = true;
            lblPenalty.Font = new Font("Segoe UI", 20F);
            lblPenalty.ForeColor = Color.Red;
            lblPenalty.Location = new Point(76, 87);
            lblPenalty.Name = "lblPenalty";
            lblPenalty.Size = new Size(91, 37);
            lblPenalty.TabIndex = 4;
            lblPenalty.Text = "₱ 0.00";
            // 
            // dtpReturnDate
            // 
            dtpReturnDate.Location = new Point(21, 153);
            dtpReturnDate.Name = "dtpReturnDate";
            dtpReturnDate.Size = new Size(191, 23);
            dtpReturnDate.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 30);
            label1.Name = "label1";
            label1.Size = new Size(62, 15);
            label1.TabIndex = 6;
            label1.Text = "Customer:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 105);
            label2.Name = "label2";
            label2.Size = new Size(49, 15);
            label2.TabIndex = 7;
            label2.Text = "Penalty:";
            label2.Click += label2_Click;
            // 
            // ReturnFormViews
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dtpReturnDate);
            Controls.Add(lblPenalty);
            Controls.Add(btnReturnSelected);
            Controls.Add(btnSelectCustomer);
            Controls.Add(dgvCurrentRentals);
            Controls.Add(tbCustomer);
            Name = "ReturnFormViews";
            Text = "ReturnFormViews";
            ((System.ComponentModel.ISupportInitialize)dgvCurrentRentals).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbCustomer;
        private DataGridView dgvCurrentRentals;
        private Button btnSelectCustomer;
        private Button btnReturnSelected;
        private Label lblPenalty;
        private DateTimePicker dtpReturnDate;
        private Label label1;
        private Label label2;
    }
}