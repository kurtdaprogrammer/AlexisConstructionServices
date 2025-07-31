namespace Alexisconstructionerp
{
    partial class Inventoryform
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
            Inventorynametb = new TextBox();
            Inventoryqtytb = new TextBox();
            Addinventorybt = new Button();
            InventoryDataGrid = new DataGridView();
            Deleteinventorybt = new Button();
            Editinventorybt = new Button();
            ((System.ComponentModel.ISupportInitialize)InventoryDataGrid).BeginInit();
            SuspendLayout();
            // 
            // Inventorynametb
            // 
            Inventorynametb.Location = new Point(223, 138);
            Inventorynametb.Name = "Inventorynametb";
            Inventorynametb.Size = new Size(100, 23);
            Inventorynametb.TabIndex = 2;
            // 
            // Inventoryqtytb
            // 
            Inventoryqtytb.Location = new Point(223, 167);
            Inventoryqtytb.Name = "Inventoryqtytb";
            Inventoryqtytb.Size = new Size(100, 23);
            Inventoryqtytb.TabIndex = 3;
            Inventoryqtytb.KeyPress += Inventoryqtytb_KeyPress;
            // 
            // Addinventorybt
            // 
            Addinventorybt.Location = new Point(266, 219);
            Addinventorybt.Name = "Addinventorybt";
            Addinventorybt.Size = new Size(75, 23);
            Addinventorybt.TabIndex = 5;
            Addinventorybt.Text = "button1";
            Addinventorybt.UseVisualStyleBackColor = true;
            Addinventorybt.Click += Addinventorybt_Click;
            // 
            // InventoryDataGrid
            // 
            InventoryDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            InventoryDataGrid.Location = new Point(12, 288);
            InventoryDataGrid.Name = "InventoryDataGrid";
            InventoryDataGrid.ReadOnly = true;
            InventoryDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            InventoryDataGrid.Size = new Size(776, 150);
            InventoryDataGrid.TabIndex = 7;
            InventoryDataGrid.SelectionChanged += InventoryDataGrid_SelectionChanged_1;
            // 
            // Deleteinventorybt
            // 
            Deleteinventorybt.Location = new Point(363, 214);
            Deleteinventorybt.Name = "Deleteinventorybt";
            Deleteinventorybt.Size = new Size(75, 23);
            Deleteinventorybt.TabIndex = 8;
            Deleteinventorybt.Text = "button1";
            Deleteinventorybt.UseVisualStyleBackColor = true;
            Deleteinventorybt.Click += Deleteinventorybt_Click;
            // 
            // Editinventorybt
            // 
            Editinventorybt.Location = new Point(493, 214);
            Editinventorybt.Name = "Editinventorybt";
            Editinventorybt.Size = new Size(75, 23);
            Editinventorybt.TabIndex = 9;
            Editinventorybt.Text = "button1";
            Editinventorybt.UseVisualStyleBackColor = true;
            Editinventorybt.Click += Editinventorybt_Click;
            // 
            // Inventoryform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Editinventorybt);
            Controls.Add(Deleteinventorybt);
            Controls.Add(InventoryDataGrid);
            Controls.Add(Addinventorybt);
            Controls.Add(Inventoryqtytb);
            Controls.Add(Inventorynametb);
            Name = "Inventoryform";
            Text = "Inventory";
            ((System.ComponentModel.ISupportInitialize)InventoryDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Inventorynametb;
        private TextBox Inventoryqtytb;
        private Button Addinventorybt;
        private DataGridView InventoryDataGrid;
        private Button Deleteinventorybt;
        private Button Editinventorybt;
    }
}