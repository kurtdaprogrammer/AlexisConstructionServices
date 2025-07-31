namespace Alexisconstructionerp
{
    partial class Clientform
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Clientnametb = new TextBox();
            Clientaddresstb = new TextBox();
            Clientphonenotb = new TextBox();
            Clientemailtb = new TextBox();
            Addclientbt = new Button();
            Delete = new Button();
            ClientDataGrid = new DataGridView();
            EditClient = new Button();
            ((System.ComponentModel.ISupportInitialize)ClientDataGrid).BeginInit();
            SuspendLayout();
            // 
            // Clientnametb
            // 
            Clientnametb.Location = new Point(276, 84);
            Clientnametb.Name = "Clientnametb";
            Clientnametb.Size = new Size(100, 23);
            Clientnametb.TabIndex = 0;
            // 
            // Clientaddresstb
            // 
            Clientaddresstb.Location = new Point(276, 113);
            Clientaddresstb.Name = "Clientaddresstb";
            Clientaddresstb.Size = new Size(100, 23);
            Clientaddresstb.TabIndex = 1;
            // 
            // Clientphonenotb
            // 
            Clientphonenotb.Location = new Point(276, 142);
            Clientphonenotb.Name = "Clientphonenotb";
            Clientphonenotb.Size = new Size(100, 23);
            Clientphonenotb.TabIndex = 2;
            // 
            // Clientemailtb
            // 
            Clientemailtb.Location = new Point(276, 171);
            Clientemailtb.Name = "Clientemailtb";
            Clientemailtb.Size = new Size(100, 23);
            Clientemailtb.TabIndex = 3;
            // 
            // Addclientbt
            // 
            Addclientbt.Location = new Point(312, 210);
            Addclientbt.Name = "Addclientbt";
            Addclientbt.Size = new Size(75, 23);
            Addclientbt.TabIndex = 4;
            Addclientbt.Text = "button1";
            Addclientbt.UseVisualStyleBackColor = true;
            Addclientbt.Click += Addclientbt_Click;
            // 
            // Delete
            // 
            Delete.Location = new Point(445, 210);
            Delete.Name = "Delete";
            Delete.Size = new Size(75, 23);
            Delete.TabIndex = 5;
            Delete.Text = "button2";
            Delete.UseVisualStyleBackColor = true;
            Delete.Click += Delete_Click;
            // 
            // ClientDataGrid
            // 
            ClientDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientDataGrid.Location = new Point(12, 279);
            ClientDataGrid.Name = "ClientDataGrid";
            ClientDataGrid.Size = new Size(776, 150);
            ClientDataGrid.TabIndex = 6;
            // 
            // EditClient
            // 
            EditClient.Location = new Point(594, 210);
            EditClient.Name = "EditClient";
            EditClient.Size = new Size(75, 23);
            EditClient.TabIndex = 7;
            EditClient.Text = "button2";
            EditClient.UseVisualStyleBackColor = true;
            EditClient.Click += EditClient_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(EditClient);
            Controls.Add(ClientDataGrid);
            Controls.Add(Delete);
            Controls.Add(Addclientbt);
            Controls.Add(Clientemailtb);
            Controls.Add(Clientphonenotb);
            Controls.Add(Clientaddresstb);
            Controls.Add(Clientnametb);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)ClientDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Clientnametb;
        private TextBox Clientaddresstb;
        private TextBox Clientphonenotb;
        private TextBox Clientemailtb;
        private Button Addclientbt;
        private Button Delete;
        private DataGridView ClientDataGrid;
        private Button EditClient;
    }
}
