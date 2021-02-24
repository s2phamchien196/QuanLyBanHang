namespace QuanLyCheDaNang
{
    partial class Thanhtoan
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
            this.btnIn = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtKhachtra = new System.Windows.Forms.TextBox();
            this.lbNgaylap = new System.Windows.Forms.Label();
            this.lbTongtien = new System.Windows.Forms.Label();
            this.lbSohoadon = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbTralai = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSoban = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnIn
            // 
            this.btnIn.Enabled = false;
            this.btnIn.Location = new System.Drawing.Point(191, 491);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(75, 47);
            this.btnIn.TabIndex = 0;
            this.btnIn.Text = "In hóa đơn";
            this.btnIn.UseVisualStyleBackColor = true;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(289, 491);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 47);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Số hóa đơn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ngày lập:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Số bàn: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tổng tiền:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtKhachtra);
            this.panel1.Controls.Add(this.lbNgaylap);
            this.panel1.Controls.Add(this.lbTongtien);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbSohoadon);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.lbTralai);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.lbSoban);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(16, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(428, 189);
            this.panel1.TabIndex = 5;
            // 
            // txtKhachtra
            // 
            this.txtKhachtra.Location = new System.Drawing.Point(117, 95);
            this.txtKhachtra.Name = "txtKhachtra";
            this.txtKhachtra.Size = new System.Drawing.Size(288, 20);
            this.txtKhachtra.TabIndex = 0;
            this.txtKhachtra.TextChanged += new System.EventHandler(this.txtKhachtra_TextChanged);
            this.txtKhachtra.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtKhachtra_KeyPress);
            // 
            // lbNgaylap
            // 
            this.lbNgaylap.AutoSize = true;
            this.lbNgaylap.Location = new System.Drawing.Point(114, 37);
            this.lbNgaylap.Name = "lbNgaylap";
            this.lbNgaylap.Size = new System.Drawing.Size(0, 13);
            this.lbNgaylap.TabIndex = 3;
            // 
            // lbTongtien
            // 
            this.lbTongtien.AutoSize = true;
            this.lbTongtien.Location = new System.Drawing.Point(114, 79);
            this.lbTongtien.Name = "lbTongtien";
            this.lbTongtien.Size = new System.Drawing.Size(0, 13);
            this.lbTongtien.TabIndex = 4;
            // 
            // lbSohoadon
            // 
            this.lbSohoadon.AutoSize = true;
            this.lbSohoadon.Location = new System.Drawing.Point(114, 16);
            this.lbSohoadon.Name = "lbSohoadon";
            this.lbSohoadon.Size = new System.Drawing.Size(0, 13);
            this.lbSohoadon.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Khách trả:";
            // 
            // lbTralai
            // 
            this.lbTralai.AutoSize = true;
            this.lbTralai.Location = new System.Drawing.Point(114, 129);
            this.lbTralai.Name = "lbTralai";
            this.lbTralai.Size = new System.Drawing.Size(0, 13);
            this.lbTralai.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Trả lại:";
            // 
            // lbSoban
            // 
            this.lbSoban.AutoSize = true;
            this.lbSoban.Location = new System.Drawing.Point(114, 58);
            this.lbSoban.Name = "lbSoban";
            this.lbSoban.Size = new System.Drawing.Size(0, 13);
            this.lbSoban.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listView1);
            this.panel2.Location = new System.Drawing.Point(16, 64);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(437, 226);
            this.panel2.TabIndex = 6;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(3, 4);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(425, 219);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Location = new System.Drawing.Point(91, 491);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(75, 47);
            this.btnXacNhan.TabIndex = 7;
            this.btnXacNhan.Text = "Xác nhận";
            this.btnXacNhan.UseVisualStyleBackColor = true;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // panel3
            // 
            this.panel3.BackgroundImage = global::QuanLyCheDaNang.Properties.Resources.anh1;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(481, 40);
            this.panel3.TabIndex = 8;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            this.panel3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel3_MouseMove);
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Location = new System.Drawing.Point(0, 8);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(480, 555);
            this.panel4.TabIndex = 5;
            // 
            // Thanhtoan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 567);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.panel4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Thanhtoan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thanhtoan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Thanhtoan_FormClosed);
            this.Load += new System.EventHandler(this.Thanhtoan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnIn;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label lbNgaylap;
        private System.Windows.Forms.Label lbTongtien;
        private System.Windows.Forms.Label lbSohoadon;
        private System.Windows.Forms.Label lbSoban;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbTralai;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.TextBox txtKhachtra;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
    }
}