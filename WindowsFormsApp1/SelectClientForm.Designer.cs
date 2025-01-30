namespace WindowsFormsApp1
{
    partial class SelectClientForm
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
            this.clientview = new System.Windows.Forms.DataGridView();
            this.ClientSel = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Searchbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clientview)).BeginInit();
            this.SuspendLayout();
            // 
            // clientview
            // 
            this.clientview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.clientview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientview.Location = new System.Drawing.Point(12, 52);
            this.clientview.Name = "clientview";
            this.clientview.ReadOnly = true;
            this.clientview.Size = new System.Drawing.Size(640, 342);
            this.clientview.TabIndex = 0;
            this.clientview.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.clientview_CellClick);
            // 
            // ClientSel
            // 
            this.ClientSel.Location = new System.Drawing.Point(12, 415);
            this.ClientSel.Name = "ClientSel";
            this.ClientSel.Size = new System.Drawing.Size(96, 30);
            this.ClientSel.TabIndex = 1;
            this.ClientSel.Text = "Select Client";
            this.ClientSel.UseVisualStyleBackColor = true;
            this.ClientSel.Click += new System.EventHandler(this.ClientSel_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 415);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 30);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Client";
            // 
            // Searchbox
            // 
            this.Searchbox.Location = new System.Drawing.Point(481, 26);
            this.Searchbox.Name = "Searchbox";
            this.Searchbox.Size = new System.Drawing.Size(170, 20);
            this.Searchbox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(423, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 11);
            this.label2.TabIndex = 5;
            this.label2.Text = "Search:";
            // 
            // SelectClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(663, 467);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Searchbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ClientSel);
            this.Controls.Add(this.clientview);
            this.Name = "SelectClientForm";
            this.Text = "SelectClientForm";
            ((System.ComponentModel.ISupportInitialize)(this.clientview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clientview;
        private System.Windows.Forms.Button ClientSel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Searchbox;
        private System.Windows.Forms.Label label2;
    }
}