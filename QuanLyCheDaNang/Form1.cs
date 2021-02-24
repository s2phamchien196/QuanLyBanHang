using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QuanLyCheDaNang
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string chucvu;
        bool kiemtra() 
        {
            ketnoi.connect();
            ketnoi.truyvan("select tendangnhap,matkhau, manv, chucvu from taikhoan where tendangnhap = '"+txtTaikhoan.Text+"' and matkhau = '"+txtMatkhau.Text+"'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt); 
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {
                chucvu = dt.Rows[0][3].ToString();
                return true;
              
            }
            else return false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn thoát không?", "Thoát", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit(); 

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dienMatKhau();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(txtTaikhoan.Text != "" && txtMatkhau.Text != "")
            {
            if (kiemtra() == true)
            {
                if(chucvu == "admin"){
                nhoMatKhau();
                QuanLyheDaNang f = new QuanLyheDaNang(txtTaikhoan.Text);
                this.Hide();
                f.ShowDialog();
                this.Show();
                txtMatkhau.Text = "";
            }
                if(chucvu == "Pha chế"){
                    nhoMatKhau();
                    HoaDon f = new HoaDon();
                    this.Hide();
                    f.ShowDialog();
                    this.Show();
                }
            }
            else { MessageBox.Show("Sai tài khoản hoặc mật khẩu!!"); }
            }
            else { MessageBox.Show("Bạn chưa điền đủ thông tin!!"); }                    
        }



        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panel2.Capture = false;

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        private void nhoMatKhau()
        {
            Properties.Settings.Default.taikhoan = txtTaikhoan.Text;
            Properties.Settings.Default.matkhau = txtMatkhau.Text;
            Properties.Settings.Default.Save();
        }

        private void dienMatKhau()
        {
            txtTaikhoan.Text = Properties.Settings.Default.taikhoan;
            txtMatkhau.Text = Properties.Settings.Default.matkhau;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
