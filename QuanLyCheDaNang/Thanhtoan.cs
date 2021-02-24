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
    public partial class Thanhtoan : Form
    {
        string _message;
        public Thanhtoan()
        {
            InitializeComponent();
        }
        public Thanhtoan(string Message)
            : this()
        {
            _message = Message;
            
        }
      
        void listv()
        {
            listView1.Columns.Add("Tên món");
            listView1.Columns.Add("Số lượng");
            listView1.Columns.Add("Thành tiền");
            listView1.View = View.Details;
            listView1.Columns[2].Width = 120;
            listView1.Columns[0].Width = 120;
        }
        void loadlisv(int a)
        {
            ketnoi.connect();
            ketnoi.truyvan("select tenhang,chitietphieuOder.soluong , dongia from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon = '" + a.ToString() + "';");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Int16.Parse(dt.Rows[i][1].ToString()) > 0)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i][0].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    listView1.Items.Add(item);
                }
               
            }
            ketnoi.disconnect();
        }
        int tongtien;
        void loadlb() 
        {
            ketnoi.connect();
            ketnoi.truyvan("select ngaylap,soban , tongtien from hoadon where sohoadon = '" +_message+ "'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            lbNgaylap.Text = dt.Rows[0][0].ToString();
            lbSoban.Text = dt.Rows[0][1].ToString();
            //if (dt.Rows[0][2].ToString() != "")
            //{
            //    tongtien = (Convert.ToInt32(dt.Rows[0][2].ToString()) / 1000);
            //}
            //else { tongtien = 0; MessageBox.Show("Không có gì hết ha !!!!"); this.Close(); }
            lbTongtien.Text = string.Format("{0:n0}", int.Parse(dt.Rows[0][2].ToString()));
            ketnoi.disconnect();

        }
        private void Thanhtoan_Load(object sender, EventArgs e)
        {
            lbSohoadon.Text = _message;
            listv();
            loadlb();
            loadlisv( Convert.ToInt32( _message));
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
          //  MessageBox.Show(Int32.Parse(String.Format("{0:G}", Double.Parse(txtKhachtra.Text))).ToString());

            if (txtKhachtra.Text != "" && Int32.Parse(String.Format("{0:G}", Double.Parse(txtKhachtra.Text))) >= Double.Parse(lbTongtien.Text))
            {
                tongtien = int.Parse(String.Format("{0:G}", Double.Parse(lbTongtien.Text)));
                string khachtra = String.Format("{0:G}", Double.Parse(txtKhachtra.Text));
                string tralai = (Int32.Parse(khachtra) - tongtien).ToString();
                lbTralai.Text = string.Format("{0:n0}", int.Parse(tralai));
                btnOK.Enabled = true;
                btnIn.Enabled = true;
            }
            else { MessageBox.Show("Kiểm tra lại số tiền nhập vào"); }

        }

        private void txtKhachtra_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;             
            }
        }

        private void txtKhachtra_TextChanged(object sender, EventArgs e)
        {
            if (txtKhachtra.Text != "")
            {
                string khachtra = String.Format("{0:G}", Double.Parse(txtKhachtra.Text));
                txtKhachtra.Text = string.Format("{0:n0}", int.Parse(khachtra));
                
                txtKhachtra.SelectionStart = txtKhachtra.Text.Length;
                txtKhachtra.SelectionLength = 0;
            }
            
        }

        private void Thanhtoan_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Release the mouse capture started by the mouse down.
                panel3.Capture = false;

                // Create and send a WM_NCLBUTTONDOWN message.
                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }

        
    }
}
