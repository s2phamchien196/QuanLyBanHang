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
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }
        int ind;
        void thongke()
        {
            ketnoi.connect();
            ketnoi.truyvan("select ROW_NUMBER()over(order by DAY(ngaylap)) AS STT, DAY(ngaylap) as ngaylap , sum(tongtien) as tongtien from hoadon where MONTH(ngaylap) ='"+cbThang.Text+"' and tongtien > 1 group by DAY(ngaylap)");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);           
            ketnoi.disconnect();
            dgvThongke.DataSource = dt;

        }
        void loaddulieuDoan(string a)
        {
            ketnoi.connect();
            ketnoi.truyvan("select mahang,tenhang,soluong,giathanh, xuatxu,dovitinh from hanghoa where mahang = '" +a+ "'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {
                cbMonan.Text = dt.Rows[0][1].ToString();
                txtMonmoi.Text = dt.Rows[0][1].ToString();
                txtGiaThanh.Text = dt.Rows[0][3].ToString();
                txtXuatxu.Text = dt.Rows[0][4].ToString();
                txtDonvit.Text = dt.Rows[0][5].ToString();
                dgv_do_an.DataSource = dt; 
            }
            else { MessageBox.Show("Không tìm thấy!!!"); }
          
        }
        void loadCB()
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
        void addSoluong()
        {
            if (txtSoluong.Text != "")
            {
                ketnoi.connect();
                ketnoi.truyvan(" UPDATE hanghoa SET soluong += '"+txtSoluong.Text+"' WHERE mahang = '"+cbMonan.SelectedValue+"'");
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
                { { MessageBox.Show("Thêm số lượng thành công!!!"); } }
            }
            else { { MessageBox.Show("Chưa nhập số lượng!!!"); } }
        }
        void addMonmoi()
        {
            if (txtMonmoi.Text != "" && txtGiaThanh.Text != "" && txtXuatxu.Text != "" && txtDonvit.Text != "")
            {
                ketnoi.connect();
                ketnoi.truyvan("INSERT INTO hanghoa VALUES (N'" + txtMonmoi.Text + "','0','" + txtGiaThanh.Text + "',N'" + txtXuatxu.Text + "',N'" + txtDonvit.Text + "')");
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
                { { MessageBox.Show("Thêm thành công!!!"); } }
            }
            else { { MessageBox.Show("Bạn cần điền đủ thông tin!!!"); } }
        }
        void updateDoan() 
        {
            if (txt_tkiemdoan.Text != "")
            {
                if (txtMonmoi.Text != "" && txtGiaThanh.Text != "" && txtXuatxu.Text != "" && txtDonvit.Text != "")
                {
                    ketnoi.connect();
                    ketnoi.truyvan("UPDATE hanghoa SET tenhang = N'" + txtMonmoi.Text + "',giathanh = '" + txtGiaThanh.Text + "',xuatxu = N'" + txtXuatxu.Text + "', dovitinh=N'" + txtDonvit.Text + "' where mahang = '" + txt_tkiemdoan.Text + "'");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
                    { { MessageBox.Show("Sửa thành công!!!"); } }
                }
                else { { MessageBox.Show("Bạn cần điền đủ thông tin!!!"); } }
            }
            else { { MessageBox.Show("Bạn cần tìm kiếm trước!!!"); } }
        }
        void xem(string sql, DataGridView dg)
        {
            ketnoi.connect();
            ketnoi.truyvan(sql);
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {     
                dg.DataSource = dt;
            }
        }
        void addTk()
        {
            if (txtTK.Text != "" && txtMK.Text != "" && cbLoai.Text != "" && cbNV.Text != "")
            {

                if (kiemtraDSRong("select * from taikhoan where tendangnhap = '" + txtTK.Text + "'") == false)
                {
                    ketnoi.connect();
                    ketnoi.truyvan("INSERT INTO taikhoan VALUES ('" + txtTK.Text + "','" + txtMK.Text + "',N'" + cbLoai.Text + "','" + cbNV.SelectedValue + "')");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
                    { { MessageBox.Show("Thêm thành công!!!"); } }
                }
                else { MessageBox.Show("Trùng tài khoản!!!"); }                           
            }
            else { MessageBox.Show("Bạn cần điền đủ thông tin!!!"); }
        }
        void resetpass() 
        {
            if (txt_ten_tk.Text != "")
            {
                ketnoi.connect();
                ketnoi.truyvan("select * from taikhoan where tendangnhap = '" + txt_ten_tk.Text + "'");
                SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ketnoi.disconnect();
                if (dt.Rows.Count > 0)
                {
                    ketnoi.connect();
                    ketnoi.truyvan(" UPDATE taikhoan SET matkhau = '1' WHERE tendangnhap = '" + txt_ten_tk.Text + "'");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
                    MessageBox.Show("Reset thành công!!!"); 
                }
                else { MessageBox.Show("Không tìm thấy!!!"); }               
            }
            else { MessageBox.Show("Chưa nhập tài khoản!!!"); }
        }
        void loadCBNV()
        {
            ketnoi.connect();
            ketnoi.truyvan("select manv,tennv from nhanvien");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cbNV.DataSource = dt;
            cbNV.DisplayMember = "tennv";
            cbNV.ValueMember = "manv";
            ketnoi.disconnect();
        }
        void xoaTK(string a, string chuthich) {
            if (a != "")
            {
                ketnoi.connect();
                ketnoi.truyvan(a);
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
                MessageBox.Show("Xóa thành công "+chuthich+ "!!!");
            }
            else { MessageBox.Show("Bạn cần nhập tên đăng nhập !!!"); }
        }
        void timkiemTK(string tukhoa) {
            if(txttktk.Text != "" ){
            ketnoi.connect();
            ketnoi.truyvan("select tendangnhap,tennv,matkhau,chucvu,tenhienthi, nhanvien.manv from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv where tendangnhap ='"+tukhoa+"'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            if (dt.Rows.Count > 0)
            {
                txtTK.Text = dt.Rows[0][0].ToString();
                txtMK.Text = dt.Rows[0][2].ToString();
                cbLoai.Text = dt.Rows[0][3].ToString();
                cbNV.Text = dt.Rows[0][4].ToString();
                cbNV.Tag = dt.Rows[0][5].ToString();
                dgvTK.DataSource = dt;
            }
            else { MessageBox.Show("Không tìm thấy!!!"); }
            }else{MessageBox.Show("Bạn chưa điền tên tài khoản!");}

        }
        void updateTK(string a) {
            
                if (txtTK.Text!= "" && txtMK.Text != "" && cbLoai.Text != "" && cbNV.Text != "")
                {
                    ketnoi.connect();
                    ketnoi.truyvan("UPDATE taikhoan SET matkhau = '" + txtMK.Text + "', chucvu = N'"+cbLoai.Text+"' where tendangnhap = '"+a+"'" );
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
                    { { MessageBox.Show("Sửa thành công!!!"); } }
                }
                else { MessageBox.Show("Bạn cần điền đủ thông tin!!!"); }
        }
        void timkiemNV(string tukhoa)
        {
            if (tukhoa != "")
            {
                ketnoi.connect();
                ketnoi.truyvan("select * from nhanvien where manv ='" + tukhoa + "'");
                SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ketnoi.disconnect();
                if (dt.Rows.Count > 0)
                {
                    txtTenNV.Text = dt.Rows[0][1].ToString();
                    txtSdt.Text = dt.Rows[0][2].ToString();
                    txtDiachi.Text = dt.Rows[0][3].ToString();
                    txtGioitinh.Text = dt.Rows[0][4].ToString();
                    txtnamsinh.Text = dt.Rows[0][5].ToString();
                     dgvNV.DataSource = dt;
                }
                else { MessageBox.Show("Không tìm thấy!!!"); }
            }
            else { MessageBox.Show("Bạn chưa điền Mã nhân viên!"); }

        }
        void addNV()
        {
            if (txtTenNV.Text != "" && txtSdt.Text != "" && txtDiachi.Text != "" && txtGioitinh.Text != "" && txtnamsinh.Text != "")
            {
                ketnoi.connect();
                ketnoi.truyvan("INSERT INTO nhanvien VALUES (N'" + txtTenNV.Text + "','" + txtSdt.Text + "',N'" + txtDiachi.Text + "',N'" + txtGioitinh.Text + "','" + txtnamsinh.Text + "', N'" + txtTenNV.Text + "')");
                ketnoi.Cmdsql.ExecuteNonQuery();
                ketnoi.disconnect();
                { { MessageBox.Show("Thêm thành công!!!"); } }
            }
            else { MessageBox.Show("Bạn cần điền đủ thông tin!!!"); }
        }

        bool kiemtraDSRong(string a)
        {
            ketnoi.connect();
            ketnoi.truyvan(a);
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
        void updateNV()
        {
            if (txtTenNV.Text != "" && txtSdt.Text != "" && txtDiachi.Text != "" && txtGioitinh.Text != "" && txtnamsinh.Text != "")
                {
                    ketnoi.connect();
                    ketnoi.truyvan("UPDATE nhanvien SET tennv = N'" + txtTenNV.Text + "',sdt = '" + txtSdt.Text + "',diachi = N'" + txtDiachi.Text + "',gioitinh = N'" + txtGioitinh.Text + "',namsinh = '" + txtnamsinh.Text + "' where manv = '" + txttkNv.Text + "'");
                    ketnoi.Cmdsql.ExecuteNonQuery();
                    ketnoi.disconnect();
                    { { MessageBox.Show("Sửa thành công!!!"); } }
                }
                else {MessageBox.Show("Bạn cần điền đủ thông tin!!!"); }
 
        }

        // Vẽ đồ thị
      
        void laydulieu()
        {
            cThongke.Series["Thongke"].Points.Clear();
            ketnoi.connect();
            ketnoi.truyvan("select tenhang,chitietphieuOder.mahang, SUM(chitietphieuOder.soluong) as tongtien,  MONTH(ngaylap) as ngay from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang inner join hoadon on chitietphieuOder.sohoadon = hoadon.sohoadon group by chitietphieuOder.mahang,tenhang,MONTH(ngaylap) having MONTH(ngaylap) ='" + cbThang.Text + "'");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                cThongke.Series["Thongke"].Points.Add(Convert.ToInt32(dt.Rows[i][2].ToString()));
                cThongke.Series["Thongke"].Points[i].AxisLabel =dt.Rows[i][0].ToString();
                cThongke.Series["Thongke"].Points[i].Label = dt.Rows[i][2].ToString();
              
            }

        }

        void tkeloinhuan()
        {
            cloinhuyen.Series["TangTruong"].Points.Clear();
            ketnoi.connect();
            ketnoi.truyvan("select DAY(ngaylap) as ngaylap , sum(tongtien) as tongtien from hoadon where MONTH(ngaylap) ='"+cbThang.Text+"' and tongtien > 1 group by DAY(ngaylap)");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                
                cloinhuyen.Series["TangTruong"].Points.Add(Convert.ToInt32(dt.Rows[i][1].ToString()));
                cloinhuyen.Series["TangTruong"].Points[i].AxisLabel = dt.Rows[i][0].ToString();
                cloinhuyen.Series["TangTruong"].Points[i].Label = dt.Rows[i][1].ToString();

            }

        }
       
        private void admin_Load(object sender, EventArgs e)
        {
            loadCBNV();
            loadCB();
            cbNV.Text = "";
        }

        private void btn_xemBill_Click(object sender, EventArgs e)
        {
            thongke();
            laydulieu();
            tkeloinhuan();
            pnTK.Visible = true;
        }

        private void btn_tk_do_an_Click(object sender, EventArgs e)
        {
            timkiemDoan(txt_tkiemdoan.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            addSoluong();
            xem("select mahang,tenhang,soluong,giathanh from hanghoa", dgv_do_an);
        }

        private void btn_add_do_an_Click(object sender, EventArgs e)
        {
                
                addMonmoi();
                loadCB();
                xem("select mahang,tenhang,soluong,giathanh from hanghoa", dgv_do_an);
            
        }

        private void btn_sua_do_an_Click(object sender, EventArgs e)
        {
            updateDoan();
        }

        private void dgv_do_an_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv_do_an.Rows.Count >1 )
            {
                 ind = e.RowIndex;
                 txt_tkiemdoan.Text = dgv_do_an.Rows[ind].Cells[0].Value.ToString();
                 if (txt_tkiemdoan.Text != "")
                 {
                     loaddulieuDoan(txt_tkiemdoan.Text);
                 }
                
            }
        
        }

        private void btn_xem_do_an_Click(object sender, EventArgs e)
        {
            xem("select mahang,tenhang,soluong,giathanh from hanghoa", dgv_do_an);
        }

     

        private void btn_them_tai_khoan_Click(object sender, EventArgs e)
        { 
            addTk();
            txtTK.Text = "";
            txtMK.Text = "";
            cbLoai.Text = "";
            cbNV.Text = "";
            xem("select tendangnhap,tennv,chucvu,tenhienthi from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv", dgvTK);
        }

        private void btn_dat_lai_pass_Click(object sender, EventArgs e)
        {
            resetpass();
        }

        private void btn_xoa_tai_khoan_Click(object sender, EventArgs e)
        {
            if (txttktk.Text != "")
            {
                DialogResult thongbao = MessageBox.Show("Bạn muốn xóa!!! Việc xóa có thể dẫn đến mất các dữ liệu liên quan",
                 "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    xoaTK("DELETE FROM taikhoan WHERE tendangnhap = '" +txttktk.Text + "'","Tài khoản");
                    xem("select tendangnhap,tennv,matkhau,chucvu,tenhienthi from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv", dgvTK);
                    txtTK.Text = "";
                    txtMK.Text = "";
                    cbLoai.Text = "";
                    cbNV.Text = "";                  
               }
             }
            else { MessageBox.Show("Không có gì để xóa !!!");}
        }

        private void btn_xem_tai_khoan_Click(object sender, EventArgs e)
        {
            xem("select tendangnhap,tennv,chucvu,tenhienthi from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv", dgvTK);
        }

        private void dgvThongke_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            timkiemTK(txttktk.Text);
        }

        private void btn_sua_tai_khoan_Click(object sender, EventArgs e)
        {
           if (txttktk.Text != "")
            {
                updateTK(txttktk.Text);
                xem("select tendangnhap,tennv,chucvu,tenhienthi from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv", dgvTK);
            }
           else { { MessageBox.Show("Bạn tìm kiếm trước!!!"); } }
        }

        private void dgvTK_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTK.Rows.Count > 1)
            {
                int a = e.RowIndex;
                string tenDN = dgvTK.Rows[a].Cells[0].Value.ToString();
                txttktk.Text = tenDN;
                txt_ten_tk.Text = tenDN;
                if (tenDN != "")
                {
                    timkiemTK(tenDN);
                }
                
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            xem("select * from nhanvien", dgvNV);
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            timkiemNV(txttkNv.Text);
        }

        private void dgvNV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNV.Rows.Count > 1)
            {
                int a = e.RowIndex;
                string tenDN = dgvNV.Rows[a].Cells[0].Value.ToString();
                txttkNv.Text = tenDN;
                if (tenDN != "")
                {
                    timkiemNV(tenDN);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txttkNv.Text != "")
            {
                DialogResult thongbao = MessageBox.Show("Bạn muốn xóa!!! Việc xóa có thể dẫn đến mất các dữ liệu liên quan",
                 "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                  {
                        if (kiemtraDSRong("select *  from taikhoan where manv = '" + txttkNv.Text + "'") )
                        {
                            xoaTK("DELETE FROM taikhoan WHERE manv = '" + txttkNv.Text + "'","Tài khoản");
                            xoaTK("DELETE FROM nhanvien WHERE manv = '" + txttkNv.Text + "'", "Nhân viên");
                        }
                        else { xoaTK("DELETE FROM nhanvien WHERE manv = '" + txttkNv.Text + "'", "Nhân viên"); }
                        xem("select * from nhanvien", dgvNV);
                    }
                 }
            else { MessageBox.Show("Không có gì để xóa !!!");}

        }

        private void btnThemNV_Click(object sender, EventArgs e)
        {
            addNV();
            xem("select * from nhanvien", dgvNV);
        }

        private void btnSuaNV_Click(object sender, EventArgs e)
        {
            updateNV();
            xem("select * from nhanvien", dgvNV);
        }

        private void txtXoamonan_Click(object sender, EventArgs e)
        {
            if (txt_tkiemdoan.Text != "")
            {
                DialogResult thongbao = MessageBox.Show("Bạn muốn xóa!!! Việc xóa có thể dẫn đến mất các dữ liệu liên quan",
                 "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (thongbao == DialogResult.Yes)
                {
                    if (kiemtraDSRong("select *  from chitietphieuOder where mahang = '" + txt_tkiemdoan.Text + "'"))
                    {
                        xoaTK("DELETE FROM chitietphieuOder WHERE mahang = '" + txt_tkiemdoan.Text + "'", "Chi tiết hóa đơn");
                        xoaTK("DELETE FROM hanghoa WHERE mahang = '" + txt_tkiemdoan.Text + "'", "Mặt hàng");
                    }
                    else xoaTK("DELETE FROM hanghoa WHERE mahang = '" + txt_tkiemdoan.Text + "'", "Mặt hàng");
                    xem("select mahang,tenhang,soluong,giathanh from hanghoa", dgv_do_an);
                }
            }
            else
            {
                MessageBox.Show("Không có gì để xóa !!!");

            }
        }

        private void tabpage_tai_khoan_MouseClick(object sender, MouseEventArgs e)
        {
            loadCBNV();
            loadCB();
            cbNV.Text = "";
            xem("select mahang,tenhang,soluong,giathanh from hanghoa", dgv_do_an);
            xem("select tendangnhap,tennv,chucvu,tenhienthi from taikhoan inner join nhanvien on taikhoan.manv = nhanvien.manv", dgvTK);
            xem("select * from nhanvien", dgvNV);
        }

        

        private void txtSoluong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void txtGiaThanh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void txtSdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void txtnamsinh_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
          
        }

        private void btnout_Click(object sender, EventArgs e)
        {
            DialogResult h = MessageBox.Show
               ("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                this.Hide(); 
        }

        private void panel10_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                panel10.Capture = false;


                const int WM_NCLBUTTONDOWN = 0x00A1;
                const int HTCAPTION = 2;
                Message msg =
                    Message.Create(this.Handle, WM_NCLBUTTONDOWN,
                        new IntPtr(HTCAPTION), IntPtr.Zero);
                this.DefWndProc(ref msg);
            }
        }


        private void btnrsnv_Click(object sender, EventArgs e)
        {
            txtTenNV.Text = "";
            txtSdt.Text = "";
            txtDiachi.Text = "";
            txtnamsinh.Text = "";
            txtGioitinh.Text = "";

        }



        private void btnrsTK_Click(object sender, EventArgs e)
        {
            txtMK.Text = "";
            txtTK.Text = "";
        }

        private void btnrsMA_Click(object sender, EventArgs e)
        {
            txtMonmoi.Text = "";
             txtGiaThanh.Text = "";
             txtXuatxu.Text = "";
             txtDonvit.Text = "";
        }


        private void timkiemDoan(string tendoan)
        {
            if (txt_tkiemdoan.Text.Equals(""))
            {
                xem("select mahang,tenhang,soluong,giathanh from hanghoa", dgv_do_an);
            }
            else
            {
                ketnoi.connect();
                ketnoi.truyvan("select mahang,tenhang,soluong,giathanh, xuatxu,dovitinh from hanghoa where tenhang like N'%" + tendoan + "%'");
                SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ketnoi.disconnect();
                if (dt.Rows.Count > 0)
                {
                    cbMonan.Text = dt.Rows[0][1].ToString();
                    txtMonmoi.Text = dt.Rows[0][1].ToString();
                    txtGiaThanh.Text = dt.Rows[0][3].ToString();
                    txtXuatxu.Text = dt.Rows[0][4].ToString();
                    txtDonvit.Text = dt.Rows[0][5].ToString();
                    dgv_do_an.DataSource = dt;
                }
            }
        }
        private void txt_tkiemdoan_TextChanged(object sender, EventArgs e)
        {
            timkiemDoan(txt_tkiemdoan.Text);
        }


    }
}
