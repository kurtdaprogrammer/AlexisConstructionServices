namespace BOGSYDVDRENT.Views
{
    partial class CustomerViews
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
            btdeletecustomer = new Button();
            bteditcustomer = new Button();
            btaddcustomer = new Button();
            tbcustomeraddress = new TextBox();
            tbcustomercontactnumber = new TextBox();
            tbcustomerfname = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            ((System.ComponentModel.ISupportInitialize)Customersdg).BeginInit();
            SuspendLayout();
            // 
            // Customersdg
            // 
            Customersdg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Customersdg.Location = new Point(302, 27);
            Customersdg.Name = "Customersdg";
            Customersdg.Size = new Size(486, 382);
            Customersdg.TabIndex = 14;
            // 
            // btdeletecustomer
            // 
            btdeletecustomer.Location = new Point(27, 415);
            btdeletecustomer.Name = "btdeletecustomer";
            btdeletecustomer.Size = new Size(114, 23);
            btdeletecustomer.TabIndex = 13;
            btdeletecustomer.Text = "Delete Customer";
            btdeletecustomer.UseVisualStyleBackColor = true;
            btdeletecustomer.Click += btdeletecustomer_Click;
            // 
            // bteditcustomer
            // 
            bteditcustomer.Location = new Point(584, 415);
            bteditcustomer.Name = "bteditcustomer";
            bteditcustomer.Size = new Size(99, 23);
            bteditcustomer.TabIndex = 12;
            bteditcustomer.Text = "Edit Customer";
            bteditcustomer.UseVisualStyleBackColor = true;
            bteditcustomer.Click += bteditcustomer_Click;
            // 
            // btaddcustomer
            // 
            btaddcustomer.Location = new Point(689, 415);
            btaddcustomer.Name = "btaddcustomer";
            btaddcustomer.Size = new Size(99, 23);
            btaddcustomer.TabIndex = 11;
            btaddcustomer.Text = "Add Customer";
            btaddcustomer.UseVisualStyleBackColor = true;
            btaddcustomer.Click += btaddcustomer_Click;
            // 
            // tbcustomeraddress
            // 
            tbcustomeraddress.Location = new Point(113, 85);
            tbcustomeraddress.Name = "tbcustomeraddress";
            tbcustomeraddress.Size = new Size(173, 23);
            tbcustomeraddress.TabIndex = 10;
            // 
            // tbcustomercontactnumber
            // 
            tbcustomercontactnumber.Location = new Point(113, 56);
            tbcustomercontactnumber.Name = "tbcustomercontactnumber";
            tbcustomercontactnumber.Size = new Size(173, 23);
            tbcustomercontactnumber.TabIndex = 9;
            // 
            // tbcustomerfname
            // 
            tbcustomerfname.Location = new Point(113, 27);
            tbcustomerfname.Name = "tbcustomerfname";
            tbcustomerfname.Size = new Size(173, 23);
            tbcustomerfname.TabIndex = 8;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 30);
            label1.Name = "label1";
            label1.Size = new Size(45, 15);
            label1.TabIndex = 15;
            label1.Text = "Name :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 59);
            label2.Name = "label2";
            label2.Size = new Size(102, 15);
            label2.TabIndex = 16;
            label2.Text = "Contact Number :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 88);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 17;
            label3.Text = "Address :";
            // 
            // CustomerViews
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Customersdg);
            Controls.Add(btdeletecustomer);
            Controls.Add(bteditcustomer);
            Controls.Add(btaddcustomer);
            Controls.Add(tbcustomeraddress);
            Controls.Add(tbcustomercontactnumber);
            Controls.Add(tbcustomerfname);
            Name = "CustomerViews";
            Text = "CustomerViews";
            ((System.ComponentModel.ISupportInitialize)Customersdg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView Customersdg;
        private Button btdeletecustomer;
        private Button bteditcustomer;
        private Button btaddcustomer;
        private TextBox tbcustomeraddress;
        private TextBox tbcustomercontactnumber;
        private TextBox tbcustomerfname;
        private Label label1;
        private Label label2;
        private Label label3;
    }
}