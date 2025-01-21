namespace WindowsFormsApp1
{
    partial class CreateEditForm
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
            System.Windows.Forms.Label clientIDLabel;
            System.Windows.Forms.Label nameLabel;
            System.Windows.Forms.Label contactLabel;
            System.Windows.Forms.Label addressLabel;
            this.lbTitle = new System.Windows.Forms.Label();
            this.alexisconstructionDBDataSet = new WindowsFormsApp1.AlexisconstructionDBDataSet();
            this.clientsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clientsTableAdapter = new WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.ClientsTableAdapter();
            this.tableAdapterManager = new WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.TableAdapterManager();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lbclient = new System.Windows.Forms.Label();
            this.Nametb = new System.Windows.Forms.TextBox();
            this.Contacttb = new System.Windows.Forms.TextBox();
            this.Addresstb = new System.Windows.Forms.TextBox();
            clientIDLabel = new System.Windows.Forms.Label();
            nameLabel = new System.Windows.Forms.Label();
            contactLabel = new System.Windows.Forms.Label();
            addressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.alexisconstructionDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // clientIDLabel
            // 
            clientIDLabel.AutoSize = true;
            clientIDLabel.Location = new System.Drawing.Point(15, 78);
            clientIDLabel.Name = "clientIDLabel";
            clientIDLabel.Size = new System.Drawing.Size(50, 13);
            clientIDLabel.TabIndex = 2;
            clientIDLabel.Text = "Client ID:";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new System.Drawing.Point(15, 104);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new System.Drawing.Size(38, 13);
            nameLabel.TabIndex = 4;
            nameLabel.Text = "Name:";
            // 
            // contactLabel
            // 
            contactLabel.AutoSize = true;
            contactLabel.Location = new System.Drawing.Point(15, 130);
            contactLabel.Name = "contactLabel";
            contactLabel.Size = new System.Drawing.Size(47, 13);
            contactLabel.TabIndex = 6;
            contactLabel.Text = "Contact:";
            // 
            // addressLabel
            // 
            addressLabel.AutoSize = true;
            addressLabel.Location = new System.Drawing.Point(15, 156);
            addressLabel.Name = "addressLabel";
            addressLabel.Size = new System.Drawing.Size(48, 13);
            addressLabel.TabIndex = 8;
            addressLabel.Text = "Address:";
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTitle.Location = new System.Drawing.Point(88, 20);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(185, 33);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.Text = "Create Client";
            // 
            // alexisconstructionDBDataSet
            // 
            this.alexisconstructionDBDataSet.DataSetName = "AlexisconstructionDBDataSet";
            this.alexisconstructionDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clientsBindingSource
            // 
            this.clientsBindingSource.DataMember = "Clients";
            this.clientsBindingSource.DataSource = this.alexisconstructionDBDataSet;
            // 
            // clientsTableAdapter
            // 
            this.clientsTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.BookingsTableAdapter = null;
            this.tableAdapterManager.ClientsTableAdapter = this.clientsTableAdapter;
            this.tableAdapterManager.ServicesTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = WindowsFormsApp1.AlexisconstructionDBDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(94, 198);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(133, 23);
            this.btnSave.TabIndex = 10;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(233, 198);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lbclient
            // 
            this.lbclient.AutoSize = true;
            this.lbclient.Location = new System.Drawing.Point(91, 78);
            this.lbclient.Name = "lbclient";
            this.lbclient.Size = new System.Drawing.Size(0, 13);
            this.lbclient.TabIndex = 12;
            // 
            // Nametb
            // 
            this.Nametb.Location = new System.Drawing.Point(94, 101);
            this.Nametb.Name = "Nametb";
            this.Nametb.Size = new System.Drawing.Size(224, 20);
            this.Nametb.TabIndex = 13;
            // 
            // Contacttb
            // 
            this.Contacttb.Location = new System.Drawing.Point(94, 127);
            this.Contacttb.Name = "Contacttb";
            this.Contacttb.Size = new System.Drawing.Size(224, 20);
            this.Contacttb.TabIndex = 14;
            // 
            // Addresstb
            // 
            this.Addresstb.Location = new System.Drawing.Point(94, 153);
            this.Addresstb.Name = "Addresstb";
            this.Addresstb.Size = new System.Drawing.Size(224, 20);
            this.Addresstb.TabIndex = 15;
            // 
            // CreateEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 243);
            this.Controls.Add(this.Addresstb);
            this.Controls.Add(this.Contacttb);
            this.Controls.Add(this.Nametb);
            this.Controls.Add(this.lbclient);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(clientIDLabel);
            this.Controls.Add(nameLabel);
            this.Controls.Add(contactLabel);
            this.Controls.Add(addressLabel);
            this.Controls.Add(this.lbTitle);
            this.Name = "CreateEditForm";
            this.Text = "CreateClient";
            this.Load += new System.EventHandler(this.CreateEditForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.alexisconstructionDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clientsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbTitle;
        private AlexisconstructionDBDataSet alexisconstructionDBDataSet;
        private System.Windows.Forms.BindingSource clientsBindingSource;
        private AlexisconstructionDBDataSetTableAdapters.ClientsTableAdapter clientsTableAdapter;
        private AlexisconstructionDBDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbclient;
        private System.Windows.Forms.TextBox Nametb;
        private System.Windows.Forms.TextBox Contacttb;
        private System.Windows.Forms.TextBox Addresstb;
    }
}