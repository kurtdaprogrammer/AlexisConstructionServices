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
            this.ClientPage = new System.Windows.Forms.Button();
            this.Bookings = new System.Windows.Forms.Button();
            this.Billings = new System.Windows.Forms.Button();
            this.Inventory = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.Services = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ClientPage
            // 
            this.ClientPage.Location = new System.Drawing.Point(57, 120);
            this.ClientPage.Name = "ClientPage";
            this.ClientPage.Size = new System.Drawing.Size(172, 71);
            this.ClientPage.TabIndex = 0;
            this.ClientPage.Text = "Add Client";
            this.ClientPage.UseVisualStyleBackColor = true;
            this.ClientPage.Click += new System.EventHandler(this.ClientPage_Click);
            // 
            // Bookings
            // 
            this.Bookings.Location = new System.Drawing.Point(254, 120);
            this.Bookings.Name = "Bookings";
            this.Bookings.Size = new System.Drawing.Size(172, 71);
            this.Bookings.TabIndex = 1;
            this.Bookings.Text = "Bookings";
            this.Bookings.UseVisualStyleBackColor = true;
            this.Bookings.Click += new System.EventHandler(this.Bookings_Click);
            // 
            // Billings
            // 
            this.Billings.Location = new System.Drawing.Point(445, 120);
            this.Billings.Name = "Billings";
            this.Billings.Size = new System.Drawing.Size(172, 71);
            this.Billings.TabIndex = 2;
            this.Billings.Text = "Billings";
            this.Billings.UseVisualStyleBackColor = true;
            this.Billings.Click += new System.EventHandler(this.Billings_Click);
            // 
            // Inventory
            // 
            this.Inventory.Location = new System.Drawing.Point(159, 211);
            this.Inventory.Name = "Inventory";
            this.Inventory.Size = new System.Drawing.Size(172, 71);
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 20);
            this.toolStripMenuItem1.Text = "toolStripMenuItem1";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem2.Text = "toolStripMenuItem2";
            // 
            // Services
            // 
            this.Services.Location = new System.Drawing.Point(358, 211);
            this.Services.Name = "Services";
            this.Services.Size = new System.Drawing.Size(172, 71);
            this.Services.TabIndex = 6;
            this.Services.Text = "Services";
            this.Services.UseVisualStyleBackColor = true;
            this.Services.Click += new System.EventHandler(this.Services_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Services);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.Inventory);
            this.Controls.Add(this.Billings);
            this.Controls.Add(this.Bookings);
            this.Controls.Add(this.ClientPage);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ClientPage;
        private System.Windows.Forms.Button Bookings;
        private System.Windows.Forms.Button Billings;
        private System.Windows.Forms.Button Inventory;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.Button Services;
    }
}