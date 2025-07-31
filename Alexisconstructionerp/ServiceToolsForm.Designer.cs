namespace Alexisconstructionerp
{
    partial class ServiceToolsForm
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
            cbService = new ComboBox();
            cbTools = new ComboBox();
            btnaddmapping = new Button();
            deleteservicesbt = new Button();
            Servicestoolsgrid = new DataGridView();
            numQty = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)Servicestoolsgrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQty).BeginInit();
            SuspendLayout();
            // 
            // cbService
            // 
            cbService.FormattingEnabled = true;
            cbService.Location = new Point(107, 63);
            cbService.Name = "cbService";
            cbService.Size = new Size(121, 23);
            cbService.TabIndex = 0;
            cbService.SelectedIndexChanged += cbService_SelectedIndexChanged;
            // 
            // cbTools
            // 
            cbTools.FormattingEnabled = true;
            cbTools.Location = new Point(107, 102);
            cbTools.Name = "cbTools";
            cbTools.Size = new Size(121, 23);
            cbTools.TabIndex = 1;
            // 
            // btnaddmapping
            // 
            btnaddmapping.Location = new Point(298, 62);
            btnaddmapping.Name = "btnaddmapping";
            btnaddmapping.Size = new Size(75, 23);
            btnaddmapping.TabIndex = 3;
            btnaddmapping.Text = "button1";
            btnaddmapping.UseVisualStyleBackColor = true;
            btnaddmapping.Click += btnaddmapping_Click;
            // 
            // deleteservicesbt
            // 
            deleteservicesbt.Location = new Point(379, 62);
            deleteservicesbt.Name = "deleteservicesbt";
            deleteservicesbt.Size = new Size(75, 23);
            deleteservicesbt.TabIndex = 5;
            deleteservicesbt.Text = "button3";
            deleteservicesbt.UseVisualStyleBackColor = true;
            deleteservicesbt.Click += deleteservicesbt_Click;
            // 
            // Servicestoolsgrid
            // 
            Servicestoolsgrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Servicestoolsgrid.Location = new Point(286, 124);
            Servicestoolsgrid.MultiSelect = false;
            Servicestoolsgrid.Name = "Servicestoolsgrid";
            Servicestoolsgrid.ReadOnly = true;
            Servicestoolsgrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            Servicestoolsgrid.Size = new Size(482, 150);
            Servicestoolsgrid.TabIndex = 6;
            // 
            // numQty
            // 
            numQty.Location = new Point(108, 144);
            numQty.Name = "numQty";
            numQty.Size = new Size(120, 23);
            numQty.TabIndex = 7;
            // 
            // ServiceToolsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numQty);
            Controls.Add(Servicestoolsgrid);
            Controls.Add(deleteservicesbt);
            Controls.Add(btnaddmapping);
            Controls.Add(cbTools);
            Controls.Add(cbService);
            Name = "ServiceToolsForm";
            Text = "ServiceToolsForm";
            ((System.ComponentModel.ISupportInitialize)Servicestoolsgrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQty).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ComboBox cbService;
        private ComboBox cbTools;
        private Button btnaddmapping;
        private Button deleteservicesbt;
        private DataGridView Servicestoolsgrid;
        private NumericUpDown numQty;
    }
}