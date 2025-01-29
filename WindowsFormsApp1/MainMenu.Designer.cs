namespace WindowsFormsApp1
{
    partial class MainMenu
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ClientPage = new System.Windows.Forms.Button();
            this.Bookings = new System.Windows.Forms.Button();
            this.Billings = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Services = new System.Windows.Forms.Button();
            this.MainmenuDGT = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.alexisconstructionDBDataSet = new WindowsFormsApp1.AlexisconstructionDBDataSet();
            this.bookingsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bookingsTableAdapter = new WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.BookingsTableAdapter();
            this.Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.MainmenuDGT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alexisconstructionDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ClientPage
            // 
            this.ClientPage.BackColor = System.Drawing.Color.White;
            this.ClientPage.FlatAppearance.BorderSize = 0;
            this.ClientPage.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ClientPage.Location = new System.Drawing.Point(19, 38);
            this.ClientPage.Name = "ClientPage";
            this.ClientPage.Size = new System.Drawing.Size(133, 30);
            this.ClientPage.TabIndex = 0;
            this.ClientPage.Text = "Add Client";
            this.ClientPage.UseVisualStyleBackColor = false;
            this.ClientPage.Click += new System.EventHandler(this.ClientPage_Click);
            // 
            // Bookings
            // 
            this.Bookings.BackColor = System.Drawing.Color.White;
            this.Bookings.Location = new System.Drawing.Point(158, 38);
            this.Bookings.Name = "Bookings";
            this.Bookings.Size = new System.Drawing.Size(113, 29);
            this.Bookings.TabIndex = 1;
            this.Bookings.Text = "Bookings";
            this.Bookings.UseVisualStyleBackColor = false;
            this.Bookings.Click += new System.EventHandler(this.Bookings_Click);
            // 
            // Billings
            // 
            this.Billings.BackColor = System.Drawing.Color.White;
            this.Billings.Location = new System.Drawing.Point(277, 37);
            this.Billings.Name = "Billings";
            this.Billings.Size = new System.Drawing.Size(122, 30);
            this.Billings.TabIndex = 2;
            this.Billings.Text = "Billings";
            this.Billings.UseVisualStyleBackColor = false;
            this.Billings.Click += new System.EventHandler(this.Billings_Click);
            // 
            // Inventory
            // 
            this.Inventory.BackColor = System.Drawing.Color.White;
            this.Inventory.Location = new System.Drawing.Point(405, 37);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(122, 30);
            this.Inventory.TabIndex = 3;
            this.Inventory.Text = "Inventory";
            this.Inventory.UseVisualStyleBackColor = false;
            this.Inventory.Click += new System.EventHandler(this.Inventory_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Services
            // 
            this.Services.BackColor = System.Drawing.Color.White;
            this.Services.Location = new System.Drawing.Point(533, 38);
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(122, 30);
            this.Services.TabIndex = 6;
            this.Services.Text = "Services";
            this.Services.UseVisualStyleBackColor = false;
            this.Services.Click += new System.EventHandler(this.Services_Click);
            // 
            // MainmenuDGT
            // 
            this.MainmenuDGT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainmenuDGT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainmenuDGT.DefaultCellStyle = dataGridViewCellStyle4;
            this.MainmenuDGT.Location = new System.Drawing.Point(19, 80);
            this.MainmenuDGT.Name = "MainmenuDGT";
            this.MainmenuDGT.ReadOnly = true;
            this.MainmenuDGT.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.MainmenuDGT.Size = new System.Drawing.Size(632, 358);
            this.MainmenuDGT.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(208, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alexis Construction Services";
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
            // Refresh
            // 
            this.Refresh.BackColor = System.Drawing.Color.White;
            this.Refresh.Location = new System.Drawing.Point(548, 7);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(107, 22);
            this.Refresh.TabIndex = 9;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = false;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(666, 450);
            this.Controls.Add(this.Refresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.MainmenuDGT);
            this.Controls.Add(this.Services);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.Billings);
            this.Controls.Add(this.Bookings);
            this.Controls.Add(this.ClientPage);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainmenuDGT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alexisconstructionDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookingsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClientPage;
        private System.Windows.Forms.Button Bookings;
        private System.Windows.Forms.Button Billings;
        private System.Windows.Forms.Button Inventory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button Services;
        private System.Windows.Forms.DataGridView MainmenuDGT;
        private System.Windows.Forms.Label label1;
        private AlexisconstructionDBDataSet alexisconstructionDBDataSet;
        private System.Windows.Forms.BindingSource bookingsBindingSource;
        private AlexisconstructionDBDataSetTableAdapters.BookingsTableAdapter bookingsTableAdapter;
        private System.Windows.Forms.Button Refresh;
    }
}