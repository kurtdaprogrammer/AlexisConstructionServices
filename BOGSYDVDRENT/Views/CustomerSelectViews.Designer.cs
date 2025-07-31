namespace BOGSYDVDRENT.Views
{
    partial class CustomerSelectViews
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
            Customersdg = new DataGridView();
            btnSelectCustomer = new Button();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)Customersdg).BeginInit();
            SuspendLayout();
            // 
            // Customersdg
            // 
            Customersdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Customersdg.Location = new Point(12, 49);
            Customersdg.Name = "Customersdg";
            Customersdg.Size = new Size(776, 355);
            Customersdg.TabIndex = 0;
            // 
            // btnSelectCustomer
            // 
            btnSelectCustomer.Location = new Point(643, 415);
            btnSelectCustomer.Name = "btnSelectCustomer";
            btnSelectCustomer.Size = new Size(132, 23);
            btnSelectCustomer.TabIndex = 1;
            btnSelectCustomer.Text = "Select Customer";
            btnSelectCustomer.UseVisualStyleBackColor = true;
            btnSelectCustomer.Click += btnSelectCustomer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(323, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 37);
            label1.TabIndex = 2;
            label1.Text = "Client List";
            // 
            // CustomerSelectViews
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(btnSelectCustomer);
            Controls.Add(Customersdg);
            Name = "CustomerSelectViews";
            Text = "ClientSelectViews";
            ((System.ComponentModel.ISupportInitialize)Customersdg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Customersdg;
        private Button btnSelectCustomer;
        private Label label1;
    }
}