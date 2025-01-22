namespace WindowsFormsApp1
{
    partial class BillingPage
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
            System.Windows.Forms.Label bookingid;
            System.Windows.Forms.Label contactLabel;
            System.Windows.Forms.Label addressLabel;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            this.dataGridBilling = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.Update = new System.Windows.Forms.Button();
            this.btnDeleteTool = new System.Windows.Forms.Button();
            this.btnAddBill = new System.Windows.Forms.Button();
            this.amttb = new System.Windows.Forms.TextBox();
            this.amtpaidtb = new System.Windows.Forms.TextBox();
            this.cbBookingID = new System.Windows.Forms.ComboBox();
            this.ClientNametb = new System.Windows.Forms.TextBox();
            this.Searchbox = new System.Windows.Forms.TextBox();
            bookingid = new System.Windows.Forms.Label();
            contactLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBilling)).BeginInit();
            this.SuspendLayout();
            // 
            // bookingid
            // 
            bookingid.AutoSize = true;
            bookingid.Location = new System.Drawing.Point(12, 79);
            bookingid.Name = "bookingid";
            bookingid.Size = new System.Drawing.Size(102, 13);
            bookingid.TabIndex = 17;
            bookingid.Text = "Booking Reference:";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new System.Drawing.Point(12, 132);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new System.Drawing.Size(69, 13);
            contactLabel.TabIndex = 18;
            contactLabel.Text = "Amount Due:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(12, 161);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(70, 13);
            addressLabel.TabIndex = 19;
            addressLabel.Text = "Amount Paid:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 106);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(64, 13);
            label3.TabIndex = 38;
            label3.Text = "Client Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(668, 51);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(44, 13);
            label4.TabIndex = 40;
            label4.Text = "Search:";
            // 
            // dataGridBilling
            // 
            this.dataGridBilling.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridBilling.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBilling.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBilling.Location = new System.Drawing.Point(442, 75);
            this.dataGridBilling.Name = "dataGridBilling";
            this.dataGridBilling.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridBilling.Size = new System.Drawing.Size(481, 390);
            this.dataGridBilling.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(388, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 26;
            this.label2.Text = "Billing Page";
            // 
            // Update
            // 
            this.Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Update.Location = new System.Drawing.Point(90, 222);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(86, 24);
            this.Update.TabIndex = 30;
            this.Update.Text = "Update Biling";
            this.Update.UseVisualStyleBackColor = true;
            this.Update.Click += new System.EventHandler(this.Update_Click);
            // 
            // btnDeleteTool
            // 
            this.btnDeleteTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteTool.Location = new System.Drawing.Point(355, 222);
            this.btnDeleteTool.Name = "btnDeleteTool";
            this.btnDeleteTool.Size = new System.Drawing.Size(69, 24);
            this.btnDeleteTool.TabIndex = 29;
            this.btnDeleteTool.Text = "Delete";
            this.btnDeleteTool.UseVisualStyleBackColor = true;
            this.btnDeleteTool.Click += new System.EventHandler(this.btnDeleteTool_Click_1);
            // 
            // btnAddBill
            // 
            this.btnAddBill.Location = new System.Drawing.Point(15, 222);
            this.btnAddBill.Name = "btnAddBill";
            this.btnAddBill.Size = new System.Drawing.Size(69, 24);
            this.btnAddBill.TabIndex = 28;
            this.btnAddBill.Text = "Add Billing";
            this.btnAddBill.UseVisualStyleBackColor = true;
            this.btnAddBill.Click += new System.EventHandler(this.btnAddBill_Click);
            // 
            // amttb
            // 
            this.amttb.Location = new System.Drawing.Point(120, 129);
            this.amttb.Name = "amttb";
            this.amttb.ReadOnly = true;
            this.amttb.Size = new System.Drawing.Size(304, 20);
            this.amttb.TabIndex = 34;
            // 
            // amtpaidtb
            // 
            this.amtpaidtb.Location = new System.Drawing.Point(120, 158);
            this.amtpaidtb.Name = "amtpaidtb";
            this.amtpaidtb.Size = new System.Drawing.Size(304, 20);
            this.amtpaidtb.TabIndex = 35;
            // 
            // cbBookingID
            // 
            this.cbBookingID.FormattingEnabled = true;
            this.cbBookingID.Location = new System.Drawing.Point(120, 76);
            this.cbBookingID.Name = "cbBookingID";
            this.cbBookingID.Size = new System.Drawing.Size(304, 21);
            this.cbBookingID.TabIndex = 36;
            // 
            // ClientNametb
            // 
            this.ClientNametb.Location = new System.Drawing.Point(120, 103);
            this.ClientNametb.Name = "ClientNametb";
            this.ClientNametb.ReadOnly = true;
            this.ClientNametb.Size = new System.Drawing.Size(304, 20);
            this.ClientNametb.TabIndex = 37;
            // 
            // Searchbox
            // 
            this.Searchbox.Location = new System.Drawing.Point(718, 48);
            this.Searchbox.Name = "Searchbox";
            this.Searchbox.Size = new System.Drawing.Size(205, 20);
            this.Searchbox.TabIndex = 39;
            // 
            // BillingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(951, 494);
            this.Controls.Add(label4);
            this.Controls.Add(this.Searchbox);
            this.Controls.Add(label3);
            this.Controls.Add(this.ClientNametb);
            this.Controls.Add(this.cbBookingID);
            this.Controls.Add(this.amtpaidtb);
            this.Controls.Add(this.amttb);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.btnDeleteTool);
            this.Controls.Add(this.btnAddBill);
            this.Controls.Add(this.label2);
            this.Controls.Add(bookingid);
            this.Controls.Add(contactLabel);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.dataGridBilling);
            this.Name = "BillingPage";
            this.Text = "BillingPage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBilling)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridBilling;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Update;
        private System.Windows.Forms.Button btnDeleteTool;
        private System.Windows.Forms.Button btnAddBill;
        private System.Windows.Forms.TextBox amttb;
        private System.Windows.Forms.TextBox amtpaidtb;
        private System.Windows.Forms.ComboBox cbBookingID;
        private System.Windows.Forms.TextBox ClientNametb;
        private System.Windows.Forms.TextBox Searchbox;
    }
}