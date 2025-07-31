namespace create_edit_client
{
    partial class Form1
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
            this.dgvc = new System.Windows.Forms.DataGridView();
            this.aLEXISCONSTRUCTIONENHANCEDDataSet = new create_edit_client.ALEXISCONSTRUCTIONENHANCEDDataSet();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new create_edit_client.ALEXISCONSTRUCTIONENHANCEDDataSetTableAdapters.ClientsTableAdapter();
            this.lname = new System.Windows.Forms.TextBox();
            this.phone = new System.Windows.Forms.TextBox();
            this.address = new System.Windows.Forms.TextBox();
            this.fname = new System.Windows.Forms.TextBox();
            this.email = new System.Windows.Forms.TextBox();
            this.add = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLEXISCONSTRUCTIONENHANCEDDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvc
            // 
            this.dgvc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvc.Location = new System.Drawing.Point(12, 162);
            this.dgvc.Name = "dgvc";
            this.dgvc.Size = new System.Drawing.Size(776, 276);
            this.dgvc.TabIndex = 0;
            // 
            // aLEXISCONSTRUCTIONENHANCEDDataSet
            // 
            this.aLEXISCONSTRUCTIONENHANCEDDataSet.DataSetName = "ALEXISCONSTRUCTIONENHANCEDDataSet";
            this.aLEXISCONSTRUCTIONENHANCEDDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.aLEXISCONSTRUCTIONENHANCEDDataSet;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // lname
            // 
            this.lname.Location = new System.Drawing.Point(71, 38);
            this.lname.Name = "lname";
            this.lname.Size = new System.Drawing.Size(100, 20);
            this.lname.TabIndex = 1;
            // 
            // phone
            // 
            this.phone.Location = new System.Drawing.Point(71, 90);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(100, 20);
            this.phone.TabIndex = 2;
            // 
            // address
            // 
            this.address.Location = new System.Drawing.Point(71, 64);
            this.address.Name = "address";
            this.address.Size = new System.Drawing.Size(100, 20);
            this.address.TabIndex = 3;
            // 
            // fname
            // 
            this.fname.Location = new System.Drawing.Point(71, 12);
            this.fname.Name = "fname";
            this.fname.Size = new System.Drawing.Size(100, 20);
            this.fname.TabIndex = 4;
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(71, 116);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(100, 20);
            this.email.TabIndex = 5;
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(258, 64);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(75, 23);
            this.add.TabIndex = 6;
            this.add.Text = "button1";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.add_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.add);
            this.Controls.Add(this.email);
            this.Controls.Add(this.fname);
            this.Controls.Add(this.address);
            this.Controls.Add(this.phone);
            this.Controls.Add(this.lname);
            this.Controls.Add(this.dgvc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.aLEXISCONSTRUCTIONENHANCEDDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvc;
        private ALEXISCONSTRUCTIONENHANCEDDataSet aLEXISCONSTRUCTIONENHANCEDDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private ALEXISCONSTRUCTIONENHANCEDDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private System.Windows.Forms.TextBox lname;
        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox address;
        private System.Windows.Forms.TextBox fname;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Button add;
    }
}

