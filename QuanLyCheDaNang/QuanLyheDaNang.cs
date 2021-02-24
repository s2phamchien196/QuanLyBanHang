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

    public partial class QuanLyheDaNang : Form
    {
        string id;
        int jmax = 5, imax = 7;
        public QuanLyheDaNang(string Message)
            : this()
        {
            id = Message;

        }
        Button[][] arr = new Button[7][];

        int gia;
        // Khởi tạo bàn
        void createBan()
        {
            int dem = 1;
            int Top = 10;
            for (int i = 0; i < imax; i++)
            {
                arr[i] = new Button[5];
                int left = 10;
                for (int j = 0; j < jmax; j++)
                {
                    arr[i][j] = new Button();
                    arr[i][j].Name = string.Format("btnBan{0}", dem);
                    arr[i][j].Tag = "";
                    arr[i][j].Text = string.Format("{0} ", dem);
                    arr[i][j].Click += new EventHandler(bt_Click);
                    arr[i][j].Size = new Size(130, 100);
                    arr[i][j].Font = new Font("Segoe Print", 16, FontStyle.Bold);
                    arr[i][j].Top = Top;
                    arr[i][j].Left = left;
                    arr[i][j].BackColor = Color.Transparent;
                    arr[i][j].BackgroundImage = QuanLyCheDaNang.Properties.Resources.banan13;
                    arr[i][j].FlatStyle = FlatStyle.Flat;
                    arr[i][j].BackgroundImageLayout = ImageLayout.Zoom;
                    arr[i][j].ForeColor = Color.Navy;
                    arr[i][j].TextAlign = ContentAlignment.BottomLeft;
                    arr[i][j].Cursor = Cursors.Hand;

                    //  arr[i][j].Image = Properties.Resources.an;

                    pBan.Controls.Add(arr[i][j]);
                    left += 180;
                    dem++;
                }
                Top += 140;
            }
        }

        //Tinh tong tien ban
        void tongtien()
        {
            int tong = 0;

            if (lvOrder.Items.Count > 0)
            {
                for (int i = 0; i < lvOrder.Items.Count; i++)
                {
                    tong += Convert.ToInt32(lvOrder.Items[i].SubItems[2].Text);
                }
                lbTongtien.Text = "Tổng tiền: " + String.Format("{0:n0}", tong);
            }
            else { lbTongtien.Text = "Tổng tiền: "; }
        }

        // Sự kiện buttom click
        private void bt_Click(object sender, EventArgs e)
        {
            btnDonve.BackColor = Color.DarkSeaGreen;
            cbMangve.Checked = false;
            txtBan.Text = ((Button)sender).Text.Substring(0, 2).Trim();
            txthoadon.Text = Convert.ToString(((Button)sender).Tag);

            if (((Button)sender).BackColor == Color.Transparent || ((Button)sender).BackColor == Color.Wheat)
            {

                ((Button)sender).BackColor = Color.LightSlateGray;



                for (int i = 0; i < imax; i++)
                {
                    for (int j = 0; j < jmax; j++)
                    {
                        if (arr[i][j].Text != ((Button)sender).Text && ((Button)sender).BackColor != Color.Wheat)
                        {
                            arr[i][j].BackColor = Color.Transparent;
                        }
                    }
                }
                kiemtra();
            }
            if (Convert.ToString(((Button)sender).Tag) != "")
            {
                lvOrder.Items.Clear();
                loadlisv(Convert.ToInt32(((Button)sender).Tag));
            }
            else lvOrder.Items.Clear();
            tongtien();
            txtBanmoi.Text = "";
        }
        // Tạo cột cho listview
        void listv()
        {
            lvOrder.Columns.Add("Tên món");
            lvOrder.Columns.Add("Số lượng");
            lvOrder.Columns.Add("Thành tiền");
            lvOrder.Columns.Add("Trạng thái");
            //lvOrder.Columns.Add("");
            lvOrder.View = View.Details;
            lvOrder.Columns[0].Width = 210;
            lvOrder.Columns[1].Width = 95;
            lvOrder.Columns[2].Width = 120;
            lvOrder.Columns[3].Width = 100;
           // lvOrder.Columns[4].Width = 100;
        }
        //
        void listDSOrder()
        {
            lvDSOrder.Columns.Add("Tên món");
            lvDSOrder.Columns.Add("Đơn vị tính");
            lvDSOrder.Columns.Add("Giá thành");
            lvDSOrder.View = View.Details;
            lvDSOrder.Columns[1].Width = 120;
            lvDSOrder.Columns[0].Width = 210;
            lvDSOrder.Columns[2].Width = 110;


        }
        // load dữ liệu vào listview
        void loadlisv(int a)
        {
            ketnoi.connect();
            ketnoi.truyvan("select tenhang,chitietphieuOder.soluong , dongia, TT from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon = '" + a.ToString() + "';");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (Int16.Parse(dt.Rows[i][1].ToString()) > 0)
                {
                    ListViewItem item = new ListViewItem(dt.Rows[i][0].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    item.SubItems.Add(dt.Rows[i][3].ToString());
                    lvOrder.Items.Add(item);
                }
            }


        }
        void loadDSMonan()
        {
            ketnoi.connect();
            ketnoi.truyvan("select tenhang,dovitinh,giathanh from hanghoa");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem item = new ListViewItem(dt.Rows[i][0].ToString());
                item.SubItems.Add(dt.Rows[i][1].ToString());
                item.SubItems.Add(dt.Rows[i][2].ToString());
                lvDSOrder.Items.Add(item);
            }
            ketnoi.disconnect();
        }
        // load dữ liệu vào combobox
        void loadCbdoan()
        {
            ketnoi.connect();
            ketnoi.truyvan("select mahang,tenhang from hanghoa");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbMonan.DataSource = dt;
            cbMonan.DisplayMember = "tenhang";
            cbMonan.ValueMember = "mahang";
            ketnoi.disconnect();
        }
        // load du lieu textbox
        void loadTxt()
        {
            try
            {
                ketnoi.connect();
                ketnoi.truyvan("select soluong,giathanh from hanghoa where mahang = '" + cbMonan.SelectedValue.ToString() + "'");
                SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txtGia.Text = dt.Rows[0][1].ToString();
                txtSoluong.Text = dt.Rows[0][0].ToString();
                ketnoi.disconnect();
            }
            catch (Exception ex) { }
        }
        //
        void addChitietOrder(int i, string s)
        {
            ketnoi.connect();
            ketnoi.truyvan("insert into chitietphieuOder values ('" + i.ToString() + "','" + cbMonan.SelectedValue.ToString() + "','" + soluong.Value.ToString() + "','" + gia.ToString() + "',N'" + s + "')");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();
        }
        //
        void updateHoadon()
        {
            ketnoi.connect();
            ketnoi.truyvan("UPDATE hoadon SET tinhtranght = 0, tinhtrangchuyen =0 WHERE sohoadon = '" + txthoadon.Text + "'");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();
        }
        //
        //
        void updateSoHD(string s)
        {
            ketnoi.connect();
            ketnoi.truyvan("UPDATE top(1) chitietphieuOder  SET soluong = soluong - 1 WHERE sohoadon ='" + txthoadon.Text + "' AND mahang = '" + getmahang(s) + "' and soluong > 0 and TT =N'Chờ' ;" +
                            "UPDATE top(1) chitietphieuOder  SET dongia = soluong*'" + getdongia(s) + "' WHERE sohoadon ='" + txthoadon.Text + "' AND mahang = '" + getmahang(s) + "' and soluong > 0;");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();
        }
        //
        string getdongia(string s)
        {
            ketnoi.connect();
            ketnoi.truyvan("select giathanh from hanghoa where tenhang= N'" + s + "'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt.Rows[0][0].ToString();
            ketnoi.disconnect();
        }
        //
        string getmahang(string s)
        {
            ketnoi.connect();
            ketnoi.truyvan("select mahang from hanghoa where tenhang= N'" + s + "'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt.Rows[0][0].ToString();
            ketnoi.disconnect();
        }
        //
        void SumSoluong()
        {

            ketnoi.connect();
            ketnoi.truyvan(" UPDATE hanghoa SET soluong -= '" + soluong.Value + "' WHERE mahang = '" + cbMonan.SelectedValue + "'");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();

        }
        //
        void addDonmoi()
        {
            ketnoi.connect();
            ketnoi.truyvan("insert into hoadon values (getdate(),'" + txtBan.Text + "','" + 0 + "','" + 0 + "','" + 0 + "','" + 0 + "')");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.truyvan("select top 1 sohoadon from hoadon where tinhtranght = 0 ORDER BY sohoadon desc");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            laysohoadon(Convert.ToInt32(dt.Rows[0][0].ToString()));
            ketnoi.disconnect();
        }
        //
        void laysohoadon(int a)
        {
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    if (arr[i][j].BackColor == Color.LightSlateGray)
                    {
                        arr[i][j].Tag = a;
                        txthoadon.Text = a.ToString();
                        break;
                    }
                }
            }
            txthoadon.Text = a.ToString();
        }
        //
        void kiemtra()
        {
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    if (Convert.ToString(arr[i][j].Tag) != "" && arr[i][j].BackColor != Color.LightSlateGray)
                    {
                        arr[i][j].BackColor = Color.Wheat;
                    }
                }
            }
        }
        //
        void loadsql()
        {
            // ketnoi.connect();
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    ketnoi.truyvan("select top 1 sohoadon, tinhtrangchuyen from hoadon where soban = '" + arr[i][j].Text.Substring(0, 2).Trim() + "' and tinhtrangthanhtoan = 0 order by sohoadon desc");
                    SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        arr[i][j].Tag = dt.Rows[0][0].ToString(); arr[i][j].BackColor = Color.Wheat;
                        if (dt.Rows[0][1].ToString() == "True")
                        { //arr[i][j].BackgroundImage = Properties.Resources.icondachuyen;
                            arr[i][j].Text += "\nFinish";
                        }
                    }
                    else { arr[i][j].Tag = ""; arr[i][j].BackColor = Color.Transparent; }
                    if (kiemtraHT(arr[i][j].Text.Substring(0, 2).Trim()))
                    {
                        arr[i][j].ForeColor = Color.Red;
                    }
                    else { arr[i][j].ForeColor = Color.Black; }

                }
            }
            //  ketnoi.disconnect();
        }
        //
       // select top 1 sohoadon from hoadon where soban = 36 and tinhtrangthanhtoan = 0 order by sohoadon asc

        //
        void loadsqlMV()
        {
            ketnoi.connect();
            lvOrder.Items.Clear();
            ketnoi.truyvan("select tenhang,chitietphieuOder.soluong , dongia, TT, sohoadon from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon =(select top 1 sohoadon from hoadon where soban = 36 and tinhtrangthanhtoan = 0 order by sohoadon asc)");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtBan.Text = "36";
                    txthoadon.Text = dt.Rows[i][4].ToString();
                    ListViewItem item = new ListViewItem(dt.Rows[i][0].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    item.SubItems.Add(dt.Rows[i][3].ToString());
                    lvOrder.Items.Add(item);
                }
            }
            else
            {
                ketnoi.connect();
                ketnoi.truyvan(" UPDATE hoadon SET tinhtranght = 1 where sohoadon = (select top 1 sohoadon from hoadon where soban = 36 and tinhtrangthanhtoan = 0 and tinhtranght = 0 order by sohoadon desc)");
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
                MessageBox.Show("Không có gì hết ha!!");
            }
            tongtien();
        }
        //
        void hoadonve()
        {
            ketnoi.connect();
            lvOrder.Items.Clear();
            ketnoi.truyvan("select tenhang,chitietphieuOder.soluong , dongia, TT, sohoadon from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon =(select top 1 sohoadon from hoadon where soban = 36 and tinhtrangthanhtoan = 0 and tinhtranght = 1 order by sohoadon desc)");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    txtBan.Text = "36";
                    txthoadon.Text = dt.Rows[i][4].ToString();
                    ListViewItem item = new ListViewItem(dt.Rows[i][0].ToString());
                    item.SubItems.Add(dt.Rows[i][1].ToString());
                    item.SubItems.Add(dt.Rows[i][2].ToString());
                    item.SubItems.Add(dt.Rows[i][3].ToString());
                    lvOrder.Items.Add(item);
                }
            }
            else
            {
                MessageBox.Show("Không có gì hết ha!!");
            }
            tongtien();
        }
        //
        bool kiemtraHT(string s)
        {
            ketnoi.connect();
            ketnoi.truyvan("select TT from chitietphieuOder where (TT = N'Chờ' or TT = N'Mua về') and sohoadon = (select top 1 sohoadon from hoadon where soban = '" + s + "'  and tinhtrangthanhtoan = 0 order by sohoadon desc)");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {
                return true;
            }
            else return false;
        }
        //
        void thanhtoan()
        {
            ketnoi.connect();
            ketnoi.truyvan("UPDATE hoadon SET tinhtrangthanhtoan = 1 WHERE sohoadon = '" + txthoadon.Text + "'");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.truyvan("update hoadon set tongtien = (select SUM(dongia)from chitietphieuOder where sohoadon = '" + txthoadon.Text + "' and soluong>0)where sohoadon = '" + txthoadon.Text + "'");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    if (arr[i][j].BackColor == Color.LightSlateGray)
                    {
                        arr[i][j].BackColor = Color.Transparent;
                        arr[i][j].Text = arr[i][j].Text.Substring(0, 2);
                    }
                }
            }
        }
        //
        void hoanthanh()
        {
            ketnoi.connect();
            ketnoi.truyvan("select * from hoadon WHERE sohoadon = '" + txthoadon.Text + "' and tinhtranght = 1");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.Cmdsql.ExecuteNonQuery();
            if (dt.Rows.Count > 0)
            {

                ketnoi.truyvan("UPDATE hoadon SET tinhtrangchuyen = '1' WHERE sohoadon = '" + txthoadon.Text + "'");
                ketnoi.Cmdsql.ExecuteNonQuery();
                //select tinhtranght from hoadon WHERE sohoadon = '" + txthoadon.Text + "' 
                ketnoi.disconnect();
                for (int i = 0; i < imax; i++)
                {
                    for (int j = 0; j < jmax; j++)
                    {
                        if (arr[i][j].BackColor == Color.LightSlateGray)
                        {
                            arr[i][j].ForeColor = Color.Red;
                            // arr[i][j].Text = "Hoàn Thành";
                            arr[i][j].Text += "Finish";
                        }
                    }

                }
                lvOrder.Items.Clear();
                loadlisv(Convert.ToInt32(txthoadon.Text));
                reColor(Color.Black);
                loadSTTBan();
            }
            else { MessageBox.Show("Đơn chưa hoàn thành!!!"); }

        }
        //
        string loai;
        void loaitk()
        {
            ketnoi.connect();
            ketnoi.truyvan("select chucvu from taikhoan where tendangnhap = '" + id + "'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            loai = dt.Rows[0][0].ToString();
            if (loai == "admin")
            {
                adminToolStripMenuItem.Enabled = true;
                bttThanhtoan.Enabled = true;
                btnMoi.Enabled = true;
                btn_add.Enabled = true;
                btnhoanthanh.Enabled = true;
            }
            if (loai == "Pha chế")
            {

                btnhoanthanh.Enabled = true;
            }
            if (loai == "Thu ngân")
            {

                bttThanhtoan.Enabled = true;

            }
            if (loai == "Phục vụ")
            {
                btnMoi.Enabled = true;
                btn_add.Enabled = true;
            }

        }
        // 
        void reColor(Color c)
        {
            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    if (arr[i][j].BackColor == Color.LightSlateGray)
                    {
                        arr[i][j].ForeColor = c;
                    }
                }
            }
        }
        //
        void loadSTTBan()
        {
            txtSTTOD.Text = "";
            ketnoi.connect();
            ketnoi.truyvan("select soban from hoadon where tinhtranght = 1 and tinhtrangthanhtoan = 0 ");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (i == 0)
                {
                    if (dt.Rows[i][0].ToString() == "36")
                    { txtSTTOD.Text += "MV"; }
                    else
                    {
                        txtSTTOD.Text += dt.Rows[i][0].ToString();
                    }
                }
                else
                {
                    if (dt.Rows[i][0].ToString() == "36")
                    { txtSTTOD.Text += " - MV"; }
                    else
                    {
                        txtSTTOD.Text += " - " + dt.Rows[i][0].ToString();
                    }
                }
            }

        }
        //
        public QuanLyheDaNang()
        {
            InitializeComponent();

        }

        private void nmsomon_ValueChanged(object sender, EventArgs e)
        {
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {

            thongtincanhan f = new thongtincanhan(id);
            f.ShowDialog();

        }

        private void adminToolStripMenuItem_Click_1(object sender, EventArgs e)
        {

            admin f = new admin();
            f.ShowDialog();
            // this.Hide();

        }

        private void btn_chuyenban_Click(object sender, EventArgs e)
        {
            loadsql();
            loadSTTBan();
            //  loadsqlMV();
        }
        //
        void loadbtnBan()
        {
            if (Int16.Parse(txtBan.Text) < 36 && cbMangve.Checked)
            {
                arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].Text = arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].Text.Substring(0, 2);
                    ketnoi.connect();
                    ketnoi.truyvan(" UPDATE hoadon SET tinhtrangchuyen = '"+false+"' WHERE sohoadon = '" + txthoadon.Text + "'");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
            }
        }
        //
        private void btn_add_Click(object sender, EventArgs e)
        {
            if (soluong.Value != 0 && txtBan.Text != "" && txtSoluong.Text != "0" && Convert.ToInt32(txtSoluong.Text) >= soluong.Value)
            {
                if (txthoadon.Text.Equals("") && txtBan.Text != "")
                {
                    addDonmoi();
                    lvOrder.Items.Clear();
                }

                ListViewItem item = new ListViewItem(cbMonan.Text);
                item.SubItems.Add(soluong.Value.ToString());
                gia = Convert.ToInt32(txtGia.Text) * Convert.ToInt32(soluong.Value.ToString());
                item.SubItems.Add(gia.ToString());
                if (cbMangve.Checked)
                {
                    addChitietOrder(Convert.ToInt32(txthoadon.Text), "Mua về");
                    item.SubItems.Add("Mua về");
                }
                else { addChitietOrder(Convert.ToInt32(txthoadon.Text), "Chờ"); item.SubItems.Add("Chờ"); }
                updateHoadon();
                // item.SubItems.Add("Xóa");
                lvOrder.Items.Add(item);
                //lvDSOrder.Items[0].SubItems[4].Font = new Font("Segoe Print", 16, FontStyle.Italic);
                reColor(Color.Red);
                SumSoluong();
                loadbtnBan();
                if (Int16.Parse(txtBan.Text) < 36) { arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].Text = arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].Text.Substring(0, 2); }
                
            }

            if (Convert.ToInt32(txtSoluong.Text) < soluong.Value) { MessageBox.Show("Số lượng không đủ!!!"); }
            if (soluong.Value == 0) { MessageBox.Show("Bạn chưa nhập số lượng!!!"); }
            if (txtBan.Text == "") { MessageBox.Show("Bạn chưa chọn bàn!!!"); }
            tongtien();

        }

        private void QuanLyheDaNang_Load(object sender, EventArgs e)
        {
            loaitk();
            //theme1();
            createBan();
            listv();
            loadCbdoan();
            loadTxt();
            listDSOrder();
            loadDSMonan();
            loadsql();
            loadSTTBan();


        }

        private void cbMonan_MouseClick(object sender, MouseEventArgs e)
        {
            loadTxt();
            loadCbdoan();
        }


        private void btnDonmoi_Click_1(object sender, EventArgs e)
        {
            if (txthoadon.Text != "") { MessageBox.Show("error!!!"); }
            if (txtBan.Text != "" && txthoadon.Text == "")
            {
                addDonmoi();
                lvOrder.Items.Clear();
                //  btnDonve.BackColor = Color.WhiteSmoke;
            }
            if (txtBan.Text == "36")
            {
                DialogResult h = MessageBox.Show("Bạn có muốn tạo đơn mới không?", "Thoát", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {
                    addDonmoi();
                    lvOrder.Items.Clear();
                }
            }
            
        }
        

        private void btn_add_MouseMove(object sender, MouseEventArgs e)
        {
            loadTxt();
        }
        string s2;
        private void bttHoanThanh_Click(object sender, EventArgs e)
        {
            if (txthoadon.Text == "")
            { MessageBox.Show("Kiểm tra lại bàn!!!"); }
            else{
           // MessageBox.Show(arr[Int16.Parse(txtBan.Text) / 5][Int16.Parse(txtBan.Text) % 5 - 1].Text.Count().ToString());
            if ((Int16.Parse(txtBan.Text) <36 && arr[Int16.Parse(txtBan.Text)*9  / 46][(Int16.Parse(txtBan.Text)-1)%5].Text.Count() > 4)||  txtBan.Text == "36")
            {

                thanhtoan();
                Thanhtoan f = new Thanhtoan(txthoadon.Text);
                f.ShowDialog();
                this.Show();
                loadsql();
                lvOrder.Items.Clear();
                txthoadon.Text = "";
                lbTongtien.Text = "";
            }
            else
            {
                if (txtBan.Text != "36" && arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].ForeColor == Color.Red)
                { DialogResult h = MessageBox.Show
                ("Bàn chưa được chuyển đồ\nBạn có chắc muốn thanh toán trước không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
            {
                thanhtoan();
                Thanhtoan f = new Thanhtoan(txthoadon.Text);
                f.ShowDialog();
                this.Show();
                loadsql();
                lvOrder.Items.Clear();
                txthoadon.Text = "";
                lbTongtien.Text = "";
            }
            }
                else MessageBox.Show("Bàn chưa được chuyển đồ!!!");
            }
            }

        }


        private void cbMonan_MouseDown(object sender, MouseEventArgs e)
        {
            loadCbdoan();
        }


        private void lvDSOrder_MouseClick(object sender, MouseEventArgs e)
        {
            cbMonan.Text = lvDSOrder.SelectedItems[0].Text;
            loadTxt();
            soluong.Value = 1;
            soluong.Focus();

        }

        private void btnhoanthanh_Click(object sender, EventArgs e)
        {

            if (txthoadon.Text != "")
            {
                hoanthanh();
              

            }
            else { MessageBox.Show("Không có gì hết!!!"); }
            s2 = "";


        }


        private void btnDonve_Click(object sender, EventArgs e)
        {
            txthoadon.Text = "";
            if (btnDonve.BackColor != Color.DarkSeaGreen)
            {
                cbMangve.Checked = false;
                btnDonve.BackColor = Color.DarkSeaGreen;
                for (int i = 0; i < imax; i++)
                {
                    for (int j = 0; j < jmax; j++)
                    { if (arr[i][j].BackColor == Color.LightSlateGray) { txtBan.Text = arr[i][j].Text.Substring(0, 2).Trim(); } }
                }
            }
            else { btnDonve.BackColor = Color.LightSlateGray; txtBan.Text = "36"; cbMangve.Checked = true; } // }

        }

        private void btnDonMangVe_Click(object sender, EventArgs e)
        {
            loadsqlMV();
            loadSTTBan();
            //string[] arrListStr = txtSTTOD.Text.ToString().Split('-');
            //txtBanmoi.Text = arrListStr[0].Trim();
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
                ("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                this.Hide();
        }

        //
        //void theme1()
        //{
        //    for (int i = 0; i < imax; i++)
        //    {
        //        for (int j = 0; j < jmax; j++)
        //        {
        //            arr[i][j].BackgroundImage = QuanLyCheDaNang.Properties.Resources.banan13;
        //        }
        //    }
        //    pMain.BackgroundImage = QuanLyCheDaNang.Properties.Resources.backaddOD4;
        //    lvOrder.BackgroundImage = QuanLyCheDaNang.Properties.Resources.od1;
        //    lvDSOrder.BackgroundImage = QuanLyCheDaNang.Properties.Resources.od2;
        //    menuStrip1.BackColor = Color.DarkSeaGreen;
        //}
        //
        private void theme1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // theme1();
        }

        //private void theme2ToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    for (int i = 0; i < imax; i++)
        //    {
        //        for (int j = 0; j < jmax; j++)
        //        {
        //            arr[i][j].BackgroundImage = QuanLyCheDaNang.Properties.Resources.banan13;
        //        }
        //    }
        //    pMain.BackgroundImage = QuanLyCheDaNang.Properties.Resources.backaddOD4;
        //    lvOrder.BackgroundImage = QuanLyCheDaNang.Properties.Resources.ODnew;
        //    lvDSOrder.BackgroundImage = QuanLyCheDaNang.Properties.Resources.ODnew24;
        //    menuStrip1.BackColor = Color.DarkSeaGreen;
        //}

        private void btnHoadonve_Click(object sender, EventArgs e)
        {

            hoadonve();

        }

        void updatebanmoi()
        {
            if (txthoadon.Text != "" && txtBanmoi.Text != "")
            {
                ketnoi.connect();
                ketnoi.truyvan("update hoadon set soban ='" + txtBanmoi.Text + "' where sohoadon ='" + txthoadon.Text + "' ");
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
            }
        }
            // if (txthoadon.Text == "") { MessageBox.Show("Bàn chưa có gì !!!"); }
            void Eathere()
        {
            if (txthoadon.Text != "" && txtBanmoi.Text != "")
            {
                ketnoi.connect();
                ketnoi.truyvan("update chitietphieuOder set TT =N'Chờ'");
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
            }
            //
        }
        int kiemtraban()
        {
            if (txtBan.Text =="" && txthoadon.Text =="" )
            {
                return 1;
                
            }
            if (arr[Int16.Parse(txtBanmoi.Text) * 9 / 46][(Int16.Parse(txtBanmoi.Text) - 1) % 5].BackColor == Color.Wheat)
                {
                    return 2;
                }
            
            return 3;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(arr[Int16.Parse(txtBan.Text)*9  / 46][(Int16.Parse(txtBan.Text)-1)%5].Text);
            if (kiemtraban() == 1) { MessageBox.Show("Kiểm tra lại thông tin bàn!!!"); goto a; }
            if (txtBan.Text == "36")
            {
                Eathere();
                updatebanmoi();
                loadsql();
                loadSTTBan();
                txtBanmoi.Text = "";
                txtBan.Text = "";
                MessageBox.Show("Chuyển bàn thành công!!!");
                goto b;
            }
            if (kiemtraban() == 2) { MessageBox.Show("Bàn đã có người đặt!!!"); }
            else
            {
                if (txtBan.Text != "" && txtBanmoi.Text != "")
                {
                    updatebanmoi();
                    MessageBox.Show("Chuyển bàn thành công!!!");
                    loadsql();
                    loadSTTBan();
                    txtBanmoi.Text = "";
                    txtBan.Text = "";
                }
                else { MessageBox.Show("Bạn cần chọn bàn!!!"); }
            }
        a: { };
        b: { };
        }

        private void txtBanmoi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }



        private void theme1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // theme1();
        }

        
        //

        //
        private void lvOrder_MouseClick(object sender, MouseEventArgs e)
        {
            if (lvOrder.SelectedItems[0].SubItems[3].Text != "Xong")
            {
                DialogResult h = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thoát", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {

                    updateSoHD(lvOrder.SelectedItems[0].Text);
                    lvOrder.Items.Clear();
                    loadlisv(Int16.Parse(txthoadon.Text));
                    tongtien();
                }
            }
            else { MessageBox.Show("Đã hoàn thành không thể xóa !!!!"); }
        }

        //
        void delete_HDROng()
        {
            ketnoi.connect();
            ketnoi.truyvan(" DELETE FROM chitietphieuOder where sohoadon = '" + txthoadon.Text + "';DELETE FROM hoadon where sohoadon = '" + txthoadon.Text + "';");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();
            MessageBox.Show("Đã xóa hóa đơn");
            arr[Int16.Parse(txtBan.Text)*9  / 46][(Int16.Parse(txtBan.Text)-1)%5].BackColor = Color.Transparent;
            arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].Tag = "";
            arr[(Int16.Parse(txtBan.Text) + 1) / 5][Int16.Parse(txtBan.Text) % 5 - 1].ForeColor = Color.Black;
            lvOrder.Items.Clear();
        }
        //
        Boolean kiemtraHDrong()
        {
            ketnoi.connect();
            ketnoi.truyvan("select * from chitietphieuOder where sohoadon = '" + txthoadon.Text + "'and TT = N'Xong'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                return true;
            }
            return false;
        }
        //

        //
        private void btnXoaHDrong_Click(object sender, EventArgs e)
        {
            if (kiemtraHDrong())
            {
                DialogResult h = MessageBox.Show("Bạn có chắc muốn xóa không?", "Thoát", MessageBoxButtons.OKCancel);
                if (h == DialogResult.OK)
                {
                    delete_HDROng();
                }

            }
            else {
                MessageBox.Show("Không thể xóa Hóa Đơn đã hoàn thành!!!");
            }

         
        }

        private void QuanLyheDaNang_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Up)
            //    soluong.Value += 1;
            //else if (e.KeyCode == Keys.Down)
            //    soluong.Value -= 1;
        }

        private void lvDSOrder_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
                soluong.Value += 1;
            else if (e.KeyCode == Keys.Down)
            {
                if (soluong.Value > 1)
                    soluong.Value -= 1;
            }
        }
        //
        void maxzoom()
        {

            int Top = 10;
            for (int i = 0; i < imax; i++)
            {
                int left = 17;
                for (int j = 0; j < jmax; j++)
                {
                    arr[i][j].Size = new Size(130, 100);
                    arr[i][j].Top = Top;
                    arr[i][j].Left = left;
                    left += 180;
                }
                Top += 140;
            }

        }
        //
        void minzoom()
        {

            int Top = 12;
            for (int i = 0; i < imax; i++)
            {
                int left = 12;
                for (int j = 0; j < jmax; j++)
                {
                    arr[i][j].Size = new Size(90, 90);

                    arr[i][j].Top = Top;
                    arr[i][j].Left = left;
                    left += 100;
                }
                Top += 100;
            }

        }
        //
        void loadingDS()
        {
            if (this.WindowState.ToString() == "Normal")
            {

                lvOrder.BackgroundImage = Properties.Resources.od1;
                lvDSOrder.BackgroundImage = Properties.Resources.od2;
                minzoom();
                // ld.Close();
                //QuanLyheDaNang QLDN = new QuanLyheDaNang();
                //QLDN.Show();
            }
            else
            {

                lvOrder.BackgroundImage = Properties.Resources.od11;
                lvDSOrder.BackgroundImage = Properties.Resources.od12;
                maxzoom();
            }
        }
        //

        private void QuanLyheDaNang_Layout(object sender, LayoutEventArgs e)
        {
            loadingDS();
        }

        private void thốngKêDoanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe(0);
            tk.ShowDialog();
        }

        private void thốngKêDoanhThuTheoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe(1);
            tk.ShowDialog();
        }

        private void thốngKêDoanhThuTheoHóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe(2);
            tk.ShowDialog();
        }

        private void thốngKêDoanhThuTheoMónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKe tk = new ThongKe(3);
            tk.ShowDialog();
        }

       

    }
}
