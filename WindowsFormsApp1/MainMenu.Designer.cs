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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ClientPage.Location = new System.Drawing.Point(666, 80);
            this.ClientPage.Name = "ClientPage";
            this.ClientPage.Size = new System.Drawing.Size(107, 20);
            this.ClientPage.TabIndex = 0;
            this.ClientPage.Text = "Add Client";
            this.ClientPage.UseVisualStyleBackColor = true;
            this.ClientPage.Click += new System.EventHandler(this.ClientPage_Click);
            // 
            // Bookings
            // 
            this.Bookings.Location = new System.Drawing.Point(666, 133);
            this.Bookings.Name = "Bookings";
            this.Bookings.Size = new System.Drawing.Size(107, 24);
            this.Bookings.TabIndex = 1;
            this.Bookings.Text = "Bookings";
            this.Bookings.UseVisualStyleBackColor = true;
            this.Bookings.Click += new System.EventHandler(this.Bookings_Click);
            // 
            // Billings
            // 
            this.Billings.Location = new System.Drawing.Point(666, 163);
            this.Billings.Name = "Billings";
            this.Billings.Size = new System.Drawing.Size(107, 22);
            this.Billings.TabIndex = 2;
            this.Billings.Text = "Billings";
            this.Billings.UseVisualStyleBackColor = true;
            this.Billings.Click += new System.EventHandler(this.Billings_Click);
            // 
            // Inventory
            // 
            this.Inventory.Location = new System.Drawing.Point(666, 191);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(107, 22);
            this.Inventory.TabIndex = 3;
            this.Inventory.Text = "Inventory";
            this.Inventory.UseVisualStyleBackColor = true;
            this.Inventory.Click += new System.EventHandler(this.Inventory_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Services
            // 
            this.Services.Location = new System.Drawing.Point(666, 106);
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(107, 21);
            this.Services.TabIndex = 6;
            this.Services.Text = "Services";
            this.Services.UseVisualStyleBackColor = true;
            this.Services.Click += new System.EventHandler(this.Services_Click);
            // 
            // MainmenuDGT
            // 
            this.MainmenuDGT.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainmenuDGT.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainmenuDGT.DefaultCellStyle = dataGridViewCellStyle1;
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(639, 39);
            this.label1.TabIndex = 8;
            this.label1.Text = "Alexis Construction Services Main Menu";
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
            this.Refresh.Location = new System.Drawing.Point(666, 416);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(107, 22);
            this.Refresh.TabIndex = 9;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 450);
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