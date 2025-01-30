namespace WindowsFormsApp1
{
    partial class SelectBookingRefForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.Searchbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.BookingSel = new System.Windows.Forms.Button();
            this.bookingview = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.bookingview)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(423, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 11);
            this.label2.TabIndex = 11;
            this.label2.Text = "Search:";
            // 
            // Searchbox
            // 
            this.Searchbox.Location = new System.Drawing.Point(481, 29);
            this.Searchbox.Name = "Searchbox";
            this.Searchbox.Size = new System.Drawing.Size(170, 20);
            this.Searchbox.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(268, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 24);
            this.label1.TabIndex = 9;
            this.label1.Text = "Select Booking";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(555, 418);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 30);
            this.button2.TabIndex = 8;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // BookingSel
            // 
            this.BookingSel.Location = new System.Drawing.Point(12, 418);
            this.BookingSel.Name = "BookingSel";
            this.BookingSel.Size = new System.Drawing.Size(96, 30);
            this.BookingSel.TabIndex = 7;
            this.BookingSel.Text = "Select Booking";
            this.BookingSel.UseVisualStyleBackColor = true;
            this.BookingSel.Click += new System.EventHandler(this.BookingSel_Click);
            // 
            // bookingview
            // 
            this.bookingview.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.bookingview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookingview.Location = new System.Drawing.Point(12, 55);
            this.bookingview.Name = "bookingview";
            this.bookingview.ReadOnly = true;
            this.bookingview.Size = new System.Drawing.Size(640, 342);
            this.bookingview.TabIndex = 6;
            // 
            // SelectBookingRefForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(663, 478);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Searchbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.BookingSel);
            this.Controls.Add(this.bookingview);
            this.Name = "SelectBookingRefForm";
            this.Text = "SelectBookingRefForm";
            ((System.ComponentModel.ISupportInitialize)(this.bookingview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Searchbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button BookingSel;
        private System.Windows.Forms.DataGridView bookingview;
    }
}