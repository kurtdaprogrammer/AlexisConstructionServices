namespace WindowsFormsApp1
{
    partial class InventoryPage
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
            System.Windows.Forms.Label toollb;
            System.Windows.Forms.Label Toolamtlb;
            System.Windows.Forms.Label Services;
            this.dataGridInventory = new System.Windows.Forms.DataGridView();
            this.Tooltb = new System.Windows.Forms.TextBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.servicecb = new System.Windows.Forms.ComboBox();
            this.btnEditTool = new System.Windows.Forms.Button();
            this.btnDeleteClient = new System.Windows.Forms.Button();
            this.btnAddTool = new System.Windows.Forms.Button();
            this.Update = new System.Windows.Forms.Button();
            toollb = new System.Windows.Forms.Label();
            Toolamtlb = new System.Windows.Forms.Label();
            Services = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // toollb
            // 
            toollb.AutoSize = true;
            toollb.Location = new System.Drawing.Point(12, 51);
            toollb.Name = "toollb";
            toollb.Size = new System.Drawing.Size(62, 13);
            toollb.TabIndex = 16;
            toollb.Text = "Tool Name:";
            // 
            // Toolamtlb
            // 
            Toolamtlb.AutoSize = true;
            Toolamtlb.Location = new System.Drawing.Point(12, 77);
            Toolamtlb.Name = "Toolamtlb";
            Toolamtlb.Size = new System.Drawing.Size(52, 13);
            Toolamtlb.TabIndex = 17;
            Toolamtlb.Text = "Quantity: ";
            // 
            // Services
            // 
            Services.AutoSize = true;
            Services.Location = new System.Drawing.Point(12, 102);
            Services.Name = "Services";
            Services.Size = new System.Drawing.Size(46, 13);
            Services.TabIndex = 23;
            Services.Text = "Service:";
            // 
            // dataGridInventory
            // 
            this.dataGridInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridInventory.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridInventory.Location = new System.Drawing.Point(12, 160);
            this.dataGridInventory.Name = "dataGridInventory";
            this.dataGridInventory.Size = new System.Drawing.Size(592, 359);
            this.dataGridInventory.TabIndex = 0;
            // 
            // Tooltb
            // 
            this.Tooltb.Location = new System.Drawing.Point(91, 48);
            this.Tooltb.Name = "Tooltb";
            this.Tooltb.Size = new System.Drawing.Size(224, 20);
            this.Tooltb.TabIndex = 19;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(90, 74);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(266, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 25);
            this.label2.TabIndex = 21;
            this.label2.Text = "Inventory ";
            // 
            // servicecb
            // 
            this.servicecb.FormattingEnabled = true;
            this.servicecb.Location = new System.Drawing.Point(90, 99);
            this.servicecb.Name = "servicecb";
            this.servicecb.Size = new System.Drawing.Size(121, 21);
            this.servicecb.TabIndex = 22;
            // 
            // btnEditTool
            // 
            this.btnEditTool.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditTool.Location = new System.Drawing.Point(454, 131);
            this.btnEditTool.Name = "btnEditTool";
            this.btnEditTool.Size = new System.Drawing.Size(71, 23);
            this.btnEditTool.TabIndex = 26;
            this.btnEditTool.Text = "Edit Tool";
            this.btnEditTool.UseVisualStyleBackColor = true;
            // 
            // btnDeleteClient
            // 
            this.btnDeleteClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteClient.Location = new System.Drawing.Point(531, 131);
            this.btnDeleteClient.Name = "btnDeleteClient";
            this.btnDeleteClient.Size = new System.Drawing.Size(71, 23);
            this.btnDeleteClient.TabIndex = 25;
            this.btnDeleteClient.Text = "Delete";
            this.btnDeleteClient.UseVisualStyleBackColor = true;
            // 
            // btnAddTool
            // 
            this.btnAddTool.Location = new System.Drawing.Point(15, 131);
            this.btnAddTool.Name = "btnAddTool";
            this.btnAddTool.Size = new System.Drawing.Size(75, 23);
            this.btnAddTool.TabIndex = 24;
            this.btnAddTool.Text = "Add Tool";
            this.btnAddTool.UseVisualStyleBackColor = true;
            // 
            // Update
            // 
            this.Update.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Update.Location = new System.Drawing.Point(377, 131);
            this.Update.Name = "Update";
            this.Update.Size = new System.Drawing.Size(71, 23);
            this.Update.TabIndex = 27;
            this.Update.Text = "Update";
            this.Update.UseVisualStyleBackColor = true;
            // 
            // InventoryPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(613, 524);
            this.Controls.Add(this.Update);
            this.Controls.Add(this.btnEditTool);
            this.Controls.Add(this.btnDeleteClient);
            this.Controls.Add(this.btnAddTool);
            this.Controls.Add(Services);
            this.Controls.Add(this.servicecb);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Tooltb);
            this.Controls.Add(toollb);
            this.Controls.Add(Toolamtlb);
            this.Controls.Add(this.dataGridInventory);
            this.Name = "InventoryPage";
            this.Text = "InventoryPage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridInventory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridInventory;
        private System.Windows.Forms.TextBox Tooltb;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox servicecb;
        private System.Windows.Forms.Button btnEditTool;
        private System.Windows.Forms.Button btnDeleteClient;
        private System.Windows.Forms.Button btnAddTool;
        private System.Windows.Forms.Button Update;
    }
}