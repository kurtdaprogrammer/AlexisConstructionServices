namespace Alexisconstructionerp
{
    partial class AddClienttoBookingform
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
            ClientsViewdg = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)ClientsViewdg).BeginInit();
            SuspendLayout();
            // 
            // ClientsViewdg
            // 
            ClientsViewdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientsViewdg.Location = new Point(12, 75);
            ClientsViewdg.Name = "ClientsViewdg";
            ClientsViewdg.Size = new Size(776, 255);
            ClientsViewdg.TabIndex = 0;
            // 
            // AddClienttoBookingform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(ClientsViewdg);
            Name = "AddClienttoBookingform";
            Text = "AddClienttoBookingform";
            ((System.ComponentModel.ISupportInitialize)ClientsViewdg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView ClientsViewdg;
        // ❌ NO button1 HERE
    }
}