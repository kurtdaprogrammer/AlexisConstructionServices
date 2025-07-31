namespace BOGSYDVDRENT.Views
{
    partial class RentalFormViews
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
            AddClient = new Button();
            tbCustomer = new TextBox();
            dtRentalDate = new DateTimePicker();
            dtDueDate = new DateTimePicker();
            dgvAvailableVideos = new DataGridView();
            btnAddToCart = new Button();
            dgvCart = new DataGridView();
            lblTotalAmount = new Label();
            btnSaveRental = new Button();
            Removetocartbt = new Button();
            numQuantity = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvAvailableVideos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            SuspendLayout();
            // 
            // AddClient
            // 
            AddClient.Location = new Point(205, 84);
            AddClient.Name = "AddClient";
            AddClient.Size = new Size(107, 23);
            AddClient.TabIndex = 0;
            AddClient.Text = "Select Customer";
            AddClient.UseVisualStyleBackColor = true;
            AddClient.Click += AddClient_Click;
            // 
            // tbCustomer
            // 
            tbCustomer.Location = new Point(112, 55);
            tbCustomer.Name = "tbCustomer";
            tbCustomer.Size = new Size(200, 23);
            tbCustomer.TabIndex = 1;
            // 
            // dtRentalDate
            // 
            dtRentalDate.Location = new Point(112, 127);
            dtRentalDate.Name = "dtRentalDate";
            dtRentalDate.Size = new Size(200, 23);
            dtRentalDate.TabIndex = 2;
            // 
            // dtDueDate
            // 
            dtDueDate.Location = new Point(112, 156);
            dtDueDate.Name = "dtDueDate";
            dtDueDate.Size = new Size(200, 23);
            dtDueDate.TabIndex = 3;
            // 
            // dgvAvailableVideos
            // 
            dgvAvailableVideos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAvailableVideos.Location = new Point(341, 41);
            dgvAvailableVideos.Name = "dgvAvailableVideos";
            dgvAvailableVideos.Size = new Size(554, 201);
            dgvAvailableVideos.TabIndex = 4;
            // 
            // btnAddToCart
            // 
            btnAddToCart.Location = new Point(788, 248);
            btnAddToCart.Name = "btnAddToCart";
            btnAddToCart.Size = new Size(107, 23);
            btnAddToCart.TabIndex = 5;
            btnAddToCart.Text = "Add To Cart";
            btnAddToCart.UseVisualStyleBackColor = true;
            btnAddToCart.Click += btnAddToCart_Click;
            // 
            // dgvCart
            // 
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(32, 277);
            dgvCart.Name = "dgvCart";
            dgvCart.Size = new Size(863, 290);
            dgvCart.TabIndex = 6;
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 30F);
            lblTotalAmount.ForeColor = Color.Red;
            lblTotalAmount.Location = new Point(182, 582);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(133, 54);
            lblTotalAmount.TabIndex = 7;
            lblTotalAmount.Text = "₱ 0.00";
            // 
            // btnSaveRental
            // 
            btnSaveRental.Location = new Point(820, 573);
            btnSaveRental.Name = "btnSaveRental";
            btnSaveRental.Size = new Size(75, 23);
            btnSaveRental.TabIndex = 8;
            btnSaveRental.Text = "Save Rental";
            btnSaveRental.UseVisualStyleBackColor = true;
            btnSaveRental.Click += btnSaveRental_Click;
            // 
            // Removetocartbt
            // 
            Removetocartbt.Location = new Point(693, 573);
            Removetocartbt.Name = "Removetocartbt";
            Removetocartbt.Size = new Size(119, 23);
            Removetocartbt.TabIndex = 9;
            Removetocartbt.Text = "Remove To Cart";
            Removetocartbt.UseVisualStyleBackColor = true;
            Removetocartbt.Click += Removetocartbt_Click;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(192, 207);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 55);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 11;
            label1.Text = "Customer :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 133);
            label2.Name = "label2";
            label2.Size = new Size(70, 15);
            label2.TabIndex = 12;
            label2.Text = "Rental Date:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(27, 162);
            label3.Name = "label3";
            label3.Size = new Size(72, 15);
            label3.TabIndex = 13;
            label3.Text = "Return Date:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F);
            label4.Location = new Point(32, 243);
            label4.Name = "label4";
            label4.Size = new Size(57, 28);
            label4.TabIndex = 14;
            label4.Text = "Cart :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(587, 20);
            label5.Name = "label5";
            label5.Size = new Size(58, 15);
            label5.TabIndex = 15;
            label5.Text = "Video List";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(32, 209);
            label6.Name = "label6";
            label6.Size = new Size(59, 15);
            label6.TabIndex = 16;
            label6.Text = "Quantity :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 15F);
            label7.Location = new Point(40, 593);
            label7.Name = "label7";
            label7.Size = new Size(134, 28);
            label7.TabIndex = 17;
            label7.Text = "Total Amount:";
            // 
            // RentalFormViews
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(905, 651);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(numQuantity);
            Controls.Add(Removetocartbt);
            Controls.Add(btnSaveRental);
            Controls.Add(lblTotalAmount);
            Controls.Add(dgvCart);
            Controls.Add(btnAddToCart);
            Controls.Add(dgvAvailableVideos);
            Controls.Add(dtDueDate);
            Controls.Add(dtRentalDate);
            Controls.Add(tbCustomer);
            Controls.Add(AddClient);
            Name = "RentalFormViews";
            Text = "RentalFormViews";
            ((System.ComponentModel.ISupportInitialize)dgvAvailableVideos).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddClient;
        private TextBox tbCustomer;
        private DateTimePicker dtRentalDate;
        private DateTimePicker dtDueDate;
        private DataGridView dgvAvailableVideos;
        private Button btnAddToCart;
        private DataGridView dgvCart;
        private Label lblTotalAmount;
        private Button btnSaveRental;
        private Button Removetocartbt;
        private NumericUpDown numQuantity;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
    }
}