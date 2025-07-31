namespace Alexisconstructionerp
{
    partial class UpdateClient
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
            Clientemailtb = new TextBox();
            Clientphonenotb = new TextBox();
            Clientaddresstb = new TextBox();
            Clientnametb = new TextBox();
            UpdateClienttb = new Button();
            SuspendLayout();
            // 
            // Clientemailtb
            // 
            Clientemailtb.Location = new Point(261, 176);
            Clientemailtb.Name = "Clientemailtb";
            Clientemailtb.Size = new Size(100, 23);
            Clientemailtb.TabIndex = 7;
            // 
            // Clientphonenotb
            // 
            Clientphonenotb.Location = new Point(261, 147);
            Clientphonenotb.Name = "Clientphonenotb";
            Clientphonenotb.Size = new Size(100, 23);
            Clientphonenotb.TabIndex = 6;
            // 
            // Clientaddresstb
            // 
            Clientaddresstb.Location = new Point(261, 118);
            Clientaddresstb.Name = "Clientaddresstb";
            Clientaddresstb.Size = new Size(100, 23);
            Clientaddresstb.TabIndex = 5;
            // 
            // Clientnametb
            // 
            Clientnametb.Location = new Point(261, 89);
            Clientnametb.Name = "Clientnametb";
            Clientnametb.Size = new Size(100, 23);
            Clientnametb.TabIndex = 4;
            // 
            // UpdateClienttb
            // 
            UpdateClienttb.Location = new Point(286, 218);
            UpdateClienttb.Name = "UpdateClienttb";
            UpdateClienttb.Size = new Size(75, 23);
            UpdateClienttb.TabIndex = 8;
            UpdateClienttb.Text = "button1";
            UpdateClienttb.UseVisualStyleBackColor = true;
            UpdateClienttb.Click += UpdateClienttb_Click;
            // 
            // UpdateClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(UpdateClienttb);
            Controls.Add(Clientemailtb);
            Controls.Add(Clientphonenotb);
            Controls.Add(Clientaddresstb);
            Controls.Add(Clientnametb);
            Name = "UpdateClient";
            Text = "UpdateClient";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox Clientemailtb;
        private TextBox Clientphonenotb;
        private TextBox Clientaddresstb;
        private TextBox Clientnametb;
        private Button UpdateClienttb;
    }
}