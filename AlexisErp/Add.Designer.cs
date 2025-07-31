namespace AlexisERP
{
    partial class Add
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
            tbName = new TextBox();
            tbAddress = new TextBox();
            btnSave = new Button();
            clientviewer = new DataGridView();
            delete = new Button();
            ((System.ComponentModel.ISupportInitialize)clientviewer).BeginInit();
            SuspendLayout();
            // 
            // tbName
            // 
            tbName.Location = new Point(65, 77);
            tbName.Name = "tbName";
            tbName.Size = new Size(435, 23);
            tbName.TabIndex = 0;
            // 
            // tbAddress
            // 
            tbAddress.Location = new Point(65, 106);
            tbAddress.Name = "tbAddress";
            tbAddress.Size = new Size(435, 23);
            tbAddress.TabIndex = 1;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(291, 160);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 2;
            btnSave.Text = "button1";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // clientviewer
            // 
            clientviewer.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            clientviewer.Location = new Point(12, 206);
            clientviewer.Name = "clientviewer";
            clientviewer.Size = new Size(776, 232);
            clientviewer.TabIndex = 3;
            // 
            // delete
            // 
            delete.Location = new Point(456, 160);
            delete.Name = "delete";
            delete.Size = new Size(75, 23);
            delete.TabIndex = 4;
            delete.Text = "button1";
            delete.UseVisualStyleBackColor = true;
            delete.Click += delete_Click;
            // 
            // Add
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(delete);
            Controls.Add(clientviewer);
            Controls.Add(btnSave);
            Controls.Add(tbAddress);
            Controls.Add(tbName);
            Name = "Add";
            Text = "Add";
            ((System.ComponentModel.ISupportInitialize)clientviewer).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbName;
        private TextBox tbAddress;
        private Button btnSave;
        private DataGridView clientviewer;
        private Button delete;
    }
}