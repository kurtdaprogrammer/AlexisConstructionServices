namespace BOGSYDVDRENT.Views
{
    partial class VideoFormViews
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
            tbVideoname = new TextBox();
            numMaxDays = new NumericUpDown();
            numQuantity = new NumericUpDown();
            cbCategory = new ComboBox();
            tbRentalRate = new TextBox();
            videoDataGridView = new DataGridView();
            btnDeleteVideo = new Button();
            btnEditVideo = new Button();
            btnAddVideo = new Button();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            label4 = new Label();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numMaxDays).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoDataGridView).BeginInit();
            SuspendLayout();
            // 
            // tbVideoname
            // 
            tbVideoname.Location = new Point(140, 20);
            tbVideoname.Name = "tbVideoname";
            tbVideoname.Size = new Size(100, 23);
            tbVideoname.TabIndex = 0;
            // 
            // numMaxDays
            // 
            numMaxDays.Location = new Point(140, 78);
            numMaxDays.Name = "numMaxDays";
            numMaxDays.Size = new Size(120, 23);
            numMaxDays.TabIndex = 2;
            // 
            // numQuantity
            // 
            numQuantity.Location = new Point(140, 107);
            numQuantity.Name = "numQuantity";
            numQuantity.Size = new Size(120, 23);
            numQuantity.TabIndex = 3;
            // 
            // cbCategory
            // 
            cbCategory.FormattingEnabled = true;
            cbCategory.Location = new Point(139, 49);
            cbCategory.Name = "cbCategory";
            cbCategory.Size = new Size(121, 23);
            cbCategory.TabIndex = 4;
            cbCategory.SelectedIndexChanged += cbCategory_SelectedIndexChanged;
            // 
            // tbRentalRate
            // 
            tbRentalRate.Enabled = false;
            tbRentalRate.Location = new Point(140, 136);
            tbRentalRate.Name = "tbRentalRate";
            tbRentalRate.ReadOnly = true;
            tbRentalRate.Size = new Size(100, 23);
            tbRentalRate.TabIndex = 5;
            // 
            // videoDataGridView
            // 
            videoDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            videoDataGridView.Location = new Point(291, 12);
            videoDataGridView.Name = "videoDataGridView";
            videoDataGridView.Size = new Size(497, 391);
            videoDataGridView.TabIndex = 6;
            // 
            // btnDeleteVideo
            // 
            btnDeleteVideo.Location = new Point(15, 415);
            btnDeleteVideo.Name = "btnDeleteVideo";
            btnDeleteVideo.Size = new Size(75, 23);
            btnDeleteVideo.TabIndex = 16;
            btnDeleteVideo.Text = "Delete Video";
            btnDeleteVideo.UseVisualStyleBackColor = true;
            btnDeleteVideo.Click += btnDeleteVideo_Click;
            // 
            // btnEditVideo
            // 
            btnEditVideo.Location = new Point(713, 415);
            btnEditVideo.Name = "btnEditVideo";
            btnEditVideo.Size = new Size(75, 23);
            btnEditVideo.TabIndex = 15;
            btnEditVideo.Text = "Edit Video";
            btnEditVideo.UseVisualStyleBackColor = true;
            btnEditVideo.Click += btnEditVideo_Click;
            // 
            // btnAddVideo
            // 
            btnAddVideo.Location = new Point(632, 415);
            btnAddVideo.Name = "btnAddVideo";
            btnAddVideo.Size = new Size(75, 23);
            btnAddVideo.TabIndex = 14;
            btnAddVideo.Text = "Add Video";
            btnAddVideo.UseVisualStyleBackColor = true;
            btnAddVideo.Click += btnAddVideo_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 80);
            label3.Name = "label3";
            label3.Size = new Size(116, 15);
            label3.TabIndex = 20;
            label3.Text = "Max Days to Return :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 52);
            label2.Name = "label2";
            label2.Size = new Size(94, 15);
            label2.TabIndex = 19;
            label2.Text = "Video Category :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 23);
            label1.Name = "label1";
            label1.Size = new Size(78, 15);
            label1.TabIndex = 18;
            label1.Text = "Video Name :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 109);
            label4.Name = "label4";
            label4.Size = new Size(59, 15);
            label4.TabIndex = 21;
            label4.Text = "Quantity :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 139);
            label5.Name = "label5";
            label5.Size = new Size(72, 15);
            label5.TabIndex = 22;
            label5.Text = "Rental Rate :";
            // 
            // VideoFormViews
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnDeleteVideo);
            Controls.Add(btnEditVideo);
            Controls.Add(btnAddVideo);
            Controls.Add(videoDataGridView);
            Controls.Add(tbRentalRate);
            Controls.Add(cbCategory);
            Controls.Add(numQuantity);
            Controls.Add(numMaxDays);
            Controls.Add(tbVideoname);
            Name = "VideoFormViews";
            Text = "VideoFormViews";
            Load += VideoFormViews_Load;
            ((System.ComponentModel.ISupportInitialize)numMaxDays).EndInit();
            ((System.ComponentModel.ISupportInitialize)numQuantity).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbVideoname;
        private NumericUpDown numMaxDays;
        private NumericUpDown numQuantity;
        private ComboBox cbCategory;
        private TextBox tbRentalRate;
        private DataGridView videoDataGridView;
        private Button btnDeleteVideo;
        private Button btnEditVideo;
        private Button btnAddVideo;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label4;
        private Label label5;
    }
}