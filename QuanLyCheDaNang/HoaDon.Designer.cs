namespace QuanLyCheDaNang
{
    partial class HoaDon
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
            this.pmain = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.load = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // pmain
            // 
            this.pmain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pmain.BackColor = System.Drawing.Color.Transparent;
            this.pmain.Location = new System.Drawing.Point(3, 29);
            this.pmain.Name = "pmain";
            this.pmain.Size = new System.Drawing.Size(1139, 507);
            this.pmain.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button2.Location = new System.Drawing.Point(369, 554);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(218, 41);
            this.button2.TabIndex = 3;
            this.button2.Text = "Hoàn Thành";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // load
            // 
            this.load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.load.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.load.Cursor = System.Windows.Forms.Cursors.Hand;
            this.load.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.load.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.load.Location = new System.Drawing.Point(131, 555);
            this.load.Name = "load";
            this.load.Size = new System.Drawing.Size(210, 41);
            this.load.TabIndex = 4;
            this.load.Text = "Tải lại";
            this.load.UseVisualStyleBackColor = false;
            this.load.Click += new System.EventHandler(this.load_Click);
            // 
            // HoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1145, 619);
            this.Controls.Add(this.load);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pmain);
            this.Name = "HoaDon";
            this.Text = "HoaDon";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.HoaDon_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pmain;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button load;
    }
}