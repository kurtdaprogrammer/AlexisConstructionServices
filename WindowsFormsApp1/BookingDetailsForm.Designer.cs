namespace WindowsFormsApp1
{
    partial class BookingDetailsForm
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label clientIDLabel;
            System.Windows.Forms.Label bookingDateLabel;
            System.Windows.Forms.Label totalAmountLabel;
            System.Windows.Forms.Label serviceIDLabel;
            System.Windows.Forms.Label serviceNameLabel;
            System.Windows.Forms.Label label6;
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.alexisconstructionDBDataSet = new WindowsFormsApp1.AlexisconstructionDBDataSet();
            this.bookingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookingsTableAdapter = new WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.BookingsTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.TableAdapterManager();
            this.servicesTableAdapter = new WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.ServicesTableAdapter();
            this.label3 = new System.Windows.Forms.Label();
            this.servicesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numberofhoursnum = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.servicesdatagrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.totalamounttb = new System.Windows.Forms.TextBox();
            this.bookingsave = new System.Windows.Forms.Button();
            this.Bookingdetailscancel = new System.Windows.Forms.Button();
            this.servicecmb = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.clienttb = new System.Windows.Forms.TextBox();
            this.bookingtb = new System.Windows.Forms.DateTimePicker();
            this.HourlyRatetb = new System.Windows.Forms.TextBox();
            clientIDLabel = new System.Windows.Forms.Label();
            bookingDateLabel = new System.Windows.Forms.Label();
            totalAmountLabel = new System.Windows.Forms.Label();
            serviceIDLabel = new System.Windows.Forms.Label();
            serviceNameLabel = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.alexisconstructionDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofhoursnum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesdatagrid)).BeginInit();
            this.SuspendLayout();
            // 
            // clientIDLabel
            // 
            clientIDLabel.AutoSize = true;
            clientIDLabel.Location = new System.Drawing.Point(14, 80);
            clientIDLabel.Name = "clientIDLabel";
            clientIDLabel.Size = new System.Drawing.Size(67, 13);
            clientIDLabel.TabIndex = 6;
            clientIDLabel.Text = "Client Name:";
            // 
            // bookingDateLabel
            // 
            bookingDateLabel.AutoSize = true;
            bookingDateLabel.Location = new System.Drawing.Point(14, 107);
            bookingDateLabel.Name = "bookingDateLabel";
            bookingDateLabel.Size = new System.Drawing.Size(75, 13);
            bookingDateLabel.TabIndex = 8;
            bookingDateLabel.Text = "Booking Date:";
            // 
            // totalAmountLabel
            // 
            totalAmountLabel.AutoSize = true;
            totalAmountLabel.Location = new System.Drawing.Point(14, 509);
            totalAmountLabel.Name = "totalAmountLabel";
            totalAmountLabel.Size = new System.Drawing.Size(73, 13);
            totalAmountLabel.TabIndex = 10;
            totalAmountLabel.Text = "Total Amount:";
            // 
            // serviceIDLabel
            // 
            serviceIDLabel.AutoSize = true;
            serviceIDLabel.Location = new System.Drawing.Point(17, 173);
            serviceIDLabel.Name = "serviceIDLabel";
            serviceIDLabel.Size = new System.Drawing.Size(46, 13);
            serviceIDLabel.TabIndex = 12;
            serviceIDLabel.Text = "Service:";
            // 
            // serviceNameLabel
            // 
            serviceNameLabel.AutoSize = true;
            serviceNameLabel.Location = new System.Drawing.Point(17, 199);
            serviceNameLabel.Name = "serviceNameLabel";
            serviceNameLabel.Size = new System.Drawing.Size(90, 13);
            serviceNameLabel.TabIndex = 14;
            serviceNameLabel.Text = "Number of Hours:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(17, 227);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(66, 13);
            label6.TabIndex = 31;
            label6.Text = "Hourly Rate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(137, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Booking Details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 25);
            this.label1.TabIndex = 3;
            this.label1.Text = "Booking Information";
            // 
            // alexisconstructionDBDataSet
            // 
            this.alexisconstructionDBDataSet.DataSetName = "AlexisconstructionDBDataSet";
            this.alexisconstructionDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bookingsBindingSource
            // 
            this.bookingsBindingSource.DataMember = "Bookings";
            this.bookingsBindingSource.DataSource = this.alexisconstructionDBDataSet;
            // 
            // bookingsTableAdapter
            // 
            this.bookingsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BookingsTableAdapter = this.bookingsTableAdapter;
            this.tableAdapterManager.ClientsTableAdapter = null;
            this.tableAdapterManager.ServicesTableAdapter = this.servicesTableAdapter;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // servicesTableAdapter
            // 
            this.servicesTableAdapter.ClearBeforeFill = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(139, 25);
            this.label3.TabIndex = 12;
            this.label3.Text = "Add Services";
            // 
            // servicesBindingSource
            // 
            this.servicesBindingSource.DataMember = "Services";
            this.servicesBindingSource.DataSource = this.alexisconstructionDBDataSet;
            // 
            // numberofhoursnum
            // 
            this.numberofhoursnum.Location = new System.Drawing.Point(131, 199);
            this.numberofhoursnum.Name = "numberofhoursnum";
            this.numberofhoursnum.Size = new System.Drawing.Size(168, 20);
            this.numberofhoursnum.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 255);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(172, 25);
            this.label4.TabIndex = 20;
            this.label4.Text = "Services Availed";
            // 
            // servicesdatagrid
            // 
            this.servicesdatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.servicesdatagrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.servicesdatagrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.servicesdatagrid.Enabled = false;
            this.servicesdatagrid.Location = new System.Drawing.Point(17, 284);
            this.servicesdatagrid.Name = "servicesdatagrid";
            this.servicesdatagrid.ReadOnly = true;
            this.servicesdatagrid.Size = new System.Drawing.Size(372, 185);
            this.servicesdatagrid.TabIndex = 21;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "Summary";
            // 
            // totalamounttb
            // 
            this.totalamounttb.Location = new System.Drawing.Point(240, 506);
            this.totalamounttb.Name = "totalamounttb";
            this.totalamounttb.ReadOnly = true;
            this.totalamounttb.Size = new System.Drawing.Size(137, 20);
            this.totalamounttb.TabIndex = 23;
            // 
            // bookingsave
            // 
            this.bookingsave.Location = new System.Drawing.Point(189, 541);
            this.bookingsave.Name = "bookingsave";
            this.bookingsave.Size = new System.Drawing.Size(110, 23);
            this.bookingsave.TabIndex = 24;
            this.bookingsave.Text = "Save Booking";
            this.bookingsave.UseVisualStyleBackColor = true;
            this.bookingsave.Click += new System.EventHandler(this.bookingsave_Click);
            // 
            // Bookingdetailscancel
            // 
            this.Bookingdetailscancel.Location = new System.Drawing.Point(319, 541);
            this.Bookingdetailscancel.Name = "Bookingdetailscancel";
            this.Bookingdetailscancel.Size = new System.Drawing.Size(70, 23);
            this.Bookingdetailscancel.TabIndex = 25;
            this.Bookingdetailscancel.Text = "Cancel";
            this.Bookingdetailscancel.UseVisualStyleBackColor = true;
            this.Bookingdetailscancel.Click += new System.EventHandler(this.Bookingdetailscancel_Click);
            // 
            // servicecmb
            // 
            this.servicecmb.FormattingEnabled = true;
            this.servicecmb.Location = new System.Drawing.Point(131, 173);
            this.servicecmb.Name = "servicecmb";
            this.servicecmb.Size = new System.Drawing.Size(168, 21);
            this.servicecmb.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(300, 227);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 23);
            this.button1.TabIndex = 27;
            this.button1.Text = "Add Service";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // clienttb
            // 
            this.clienttb.Location = new System.Drawing.Point(114, 80);
            this.clienttb.Name = "clienttb";
            this.clienttb.ReadOnly = true;
            this.clienttb.Size = new System.Drawing.Size(185, 20);
            this.clienttb.TabIndex = 17;
            // 
            // bookingtb
            // 
            this.bookingtb.Enabled = false;
            this.bookingtb.Location = new System.Drawing.Point(114, 107);
            this.bookingtb.Name = "bookingtb";
            this.bookingtb.Size = new System.Drawing.Size(185, 20);
            this.bookingtb.TabIndex = 29;
            // 
            // HourlyRatetb
            // 
            this.HourlyRatetb.Location = new System.Drawing.Point(131, 224);
            this.HourlyRatetb.Name = "HourlyRatetb";
            this.HourlyRatetb.ReadOnly = true;
            this.HourlyRatetb.Size = new System.Drawing.Size(77, 20);
            this.HourlyRatetb.TabIndex = 30;
            // 
            // BookingDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(404, 573);
            this.Controls.Add(label6);
            this.Controls.Add(this.HourlyRatetb);
            this.Controls.Add(this.bookingtb);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.servicecmb);
            this.Controls.Add(this.Bookingdetailscancel);
            this.Controls.Add(this.bookingsave);
            this.Controls.Add(this.totalamounttb);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.servicesdatagrid);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.clienttb);
            this.Controls.Add(this.numberofhoursnum);
            this.Controls.Add(serviceIDLabel);
            this.Controls.Add(serviceNameLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(clientIDLabel);
            this.Controls.Add(bookingDateLabel);
            this.Controls.Add(totalAmountLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Name = "BookingDetailsForm";
            this.Text = "BookingDetailsForm";
            this.Load += new System.EventHandler(this.BookingDetailsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alexisconstructionDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofhoursnum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.servicesdatagrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private AlexisconstructionDBDataSet alexisconstructionDBDataSet;
        private System.Windows.Forms.BindingSource bookingsBindingSource;
        private AlexisconstructionDBDataSetTableAdapters.BookingsTableAdapter bookingsTableAdapter;
        private AlexisconstructionDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private AlexisconstructionDBDataSetTableAdapters.ServicesTableAdapter servicesTableAdapter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingSource servicesBindingSource;
        private System.Windows.Forms.NumericUpDown numberofhoursnum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView servicesdatagrid;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox totalamounttb;
        private System.Windows.Forms.Button bookingsave;
        private System.Windows.Forms.Button Bookingdetailscancel;
        private System.Windows.Forms.ComboBox servicecmb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox clienttb;
        private System.Windows.Forms.DateTimePicker bookingtb;
        private System.Windows.Forms.TextBox HourlyRatetb;
    }
}