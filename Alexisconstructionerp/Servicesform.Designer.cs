namespace Alexisconstructionerp
{
    partial class Servicesform
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
            ServicesDataGrid = new DataGridView();
            Addservicesbt = new Button();
            Editservicesbt = new Button();
            Removeservicesbt = new Button();
            Servicesnametb = new TextBox();
            Serviceshourlyratetb = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ServicesDataGrid).BeginInit();
            SuspendLayout();
            // 
            // ServicesDataGrid
            // 
            ServicesDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ServicesDataGrid.Location = new Point(171, 201);
            ServicesDataGrid.MultiSelect = false;
            ServicesDataGrid.Name = "ServicesDataGrid";
            ServicesDataGrid.ReadOnly = true;
            ServicesDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ServicesDataGrid.Size = new Size(564, 237);
            ServicesDataGrid.TabIndex = 0;
            // 
            // Addservicesbt
            // 
            Addservicesbt.Location = new Point(195, 85);
            Addservicesbt.Name = "Addservicesbt";
            Addservicesbt.Size = new Size(75, 23);
            Addservicesbt.TabIndex = 1;
            Addservicesbt.Text = "button1";
            Addservicesbt.UseVisualStyleBackColor = true;
            Addservicesbt.Click += Addservicesbt_Click;
            // 
            // Editservicesbt
            // 
            Editservicesbt.Location = new Point(476, 96);
            Editservicesbt.Name = "Editservicesbt";
            Editservicesbt.Size = new Size(75, 23);
            Editservicesbt.TabIndex = 2;
            Editservicesbt.Text = "button2";
            Editservicesbt.UseVisualStyleBackColor = true;
            Editservicesbt.Click += Editservicesbt_Click;
            // 
            // Removeservicesbt
            // 
            Removeservicesbt.Location = new Point(345, 96);
            Removeservicesbt.Name = "Removeservicesbt";
            Removeservicesbt.Size = new Size(75, 23);
            Removeservicesbt.TabIndex = 3;
            Removeservicesbt.Text = "button3";
            Removeservicesbt.UseVisualStyleBackColor = true;
            Removeservicesbt.Click += Removeservicesbt_Click;
            // 
            // Servicesnametb
            // 
            Servicesnametb.Location = new Point(65, 49);
            Servicesnametb.Name = "Servicesnametb";
            Servicesnametb.Size = new Size(100, 23);
            Servicesnametb.TabIndex = 4;
            // 
            // Serviceshourlyratetb
            // 
            Serviceshourlyratetb.Location = new Point(65, 86);
            Serviceshourlyratetb.Name = "Serviceshourlyratetb";
            Serviceshourlyratetb.Size = new Size(100, 23);
            Serviceshourlyratetb.TabIndex = 5;
            // 
            // Servicesform
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Serviceshourlyratetb);
            Controls.Add(Servicesnametb);
            Controls.Add(Removeservicesbt);
            Controls.Add(Editservicesbt);
            Controls.Add(Addservicesbt);
            Controls.Add(ServicesDataGrid);
            Name = "Servicesform";
            Text = "Servicesform";
            ((System.ComponentModel.ISupportInitialize)ServicesDataGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ServicesDataGrid;
        private Button Addservicesbt;
        private Button Editservicesbt;
        private Button Removeservicesbt;
        private TextBox Servicesnametb;
        private TextBox Serviceshourlyratetb;
    }
}