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
    public partial class thongtincanhan : Form
    {
        string id;
        public thongtincanhan(string Message)
            : this()
        {
            id = Message;
            
        }
        string mk;
        void loadDulieu()
        {
            if(id != "")
            ketnoi.connect();
            ketnoi.truyvan("select tendangnhap,matkhau,tennv,tenhienthi from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv where tendangnhap = '"+id+"'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            txtTaikhoan.Text = id;
            txttenhienthi.Text = dt.Rows[0][3].ToString();
            txttennhanvien.Text = dt.Rows[0][2].ToString();
            mk = dt.Rows[0][1].ToString();
        
        }     
        void capnhap()
        {
            if (txtMk.Text == mk)
            {
                if (txt_mkmoi.Text == txt_nhaplai.Text)
                {
                    ketnoi.connect();
                    ketnoi.truyvan("update taikhoan set matkhau = '" + txt_mkmoi.Text + "' where tendangnhap = '" + txtTaikhoan.Text + "'");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.truyvan("update taikhoan set tenhienthi = '" + txttenhienthi.Text + "' where tendangnhap = '" + txtTaikhoan.Text + "'");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
                    MessageBox.Show("Cập nhập thành công!!!");
                      txtMk.Text = ""; txt_mkmoi.Text = ""; txt_nhaplai.Text = ""; 
                }
                else { MessageBox.Show("Nhập lại chưa đúng"); txtMk.Text = ""; txt_mkmoi.Text = ""; txt_nhaplai.Text = ""; }
            }
            else { MessageBox.Show("Bạn nhập sai mật khẩu!!!"); txtMk.Text = ""; txt_mkmoi.Text = ""; txt_nhaplai.Text = ""; }
        }
        public thongtincanhan()
        {
            InitializeComponent();
        }

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void thongtincanhan_Load(object sender, EventArgs e)
        {
            loadDulieu();
        }

        private void btn_capnhat_Click(object sender, EventArgs e)
        {
            if (txttenhienthi.Text != "" && txt_mkmoi.Text != "" && txt_nhaplai.Text != "" && txtMk.Text != "")
            {
                capnhap();
                loadDulieu();
            }
            else { MessageBox.Show("Bạn cần điền đủ thông tin!!!"); }
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                panel2.Capture = false;


                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        private void btnOut_Click(object sender, EventArgs e)
        {

            DialogResult h = MessageBox.Show
               ("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                this.Hide(); 
        }
    }
}
