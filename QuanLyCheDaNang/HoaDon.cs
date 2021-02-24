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
    public partial class HoaDon : Form
    {
        public HoaDon()
        {
            InitializeComponent();
        }
        Label[][] lb = new Label[2][];
        Panel[][] pn = new Panel[2][];
        /// <summary>
        /// ////////////////////////////////
        void mangpanel(int imax, int jmax)
        {

            int dem = 1;
            int Top = 30;
            for (int i = 0; i < imax; i++)
            {
                pn[i] = new Panel[5];
                int left = 40;
                for (int j = 0; j < jmax; j++)
                {
                    
                        pn[i][j] = new Panel();
                        pn[i][j].Name = string.Format("pn{0}{1}", i, j);
                        pn[i][j].Text = string.Format("asdasdasdasdasd\nasdas");
                        // lb[i][j].Click += new EventHandler(bt_Click);
                        pn[i][j].Size = new Size(350, 400);
                        pn[i][j].Font = new Font("Segoe Print", 16, FontStyle.Bold);
                        pn[i][j].Top = Top;
                        pn[i][j].Left = left;
                        pn[i][j].BackColor = Color.Transparent;
                        // lb[i][j].FlatStyle = FlatStyle.Flat;
                        // lb[i][j].BackgroundImageLayout = ImageLayout.Zoom;
                     //   pn[i][j].BackgroundImage = Properties.Resources.od2;
                        
                       
                        //  arr[i][j].Image = Properties.Resources.an;

                        pmain.Controls.Add(pn[i][j]);
                        left += 370;
                  
                    dem++;
                }
                Top += 450;

            }
        }
        /// </summary>
        /// <param name="imax"></param>
        /// <param name="jmax"></param>

        void manglabel(int imax, int jmax)
        {

            int dem = 1;
            int Top = 0;
            for (int i = 0; i < imax; i++)
            {
                lb[i] = new Label[5];
                int left = 12;
                for (int j = 0; j < jmax; j++)
                {
                    
                        lb[i][j] = new Label();
                        lb[i][j].Name = string.Format("lb{0}{1}", i, j);
                        //   lb[i][j].Text = string.Format("asdasdasdasdasd");
                        // lb[i][j].Click += new EventHandler(bt_Click);
                        lb[i][j].Size = new Size(350, 400);
                        lb[i][j].Font = new Font("Segoe Print", 14, FontStyle.Bold);
                        lb[i][j].Top = Top;
                        lb[i][j].Left = left;
                        // lb[i][j].FlatStyle = FlatStyle.Flat;
                        // lb[i][j].BackgroundImageLayout = ImageLayout.Zoom;
                        lb[i][j].ForeColor = Color.Navy;
                        lb[i][j].BackColor = Color.Transparent;
                        // lb[i][j].TextAlign = ContentAlignment.BottomLeft;

                        //  arr[i][j].Image = Properties.Resources.an;

                        pn[i][j].Controls.Add(lb[i][j]);
                        // left += 350;
                    
                    dem++;
                }
                //  Top += 400;

            }
        }
        /// <summary>
        /// ////////////////
        /// 
        void addshdlb(string s,string s1)
        {
            int imax = 2, jmax = 5;
           
            for (int i = 0 ; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    if (lb[i][j].Text == "")
                    {
                        lb[i][j].Tag = s;
                        lb[i][j].Text = "Bàn số : "+ s1;
                        pn[i][j].BackgroundImage = Properties.Resources.od2;
                        pn[i][j].BorderStyle = BorderStyle.FixedSingle;
                        goto exit;
                    }
                }
            }
        exit: { }
        }
        void loadshd()
        {
            ketnoi.truyvan("select soban,sohoadon from hoadon where tinhtranght = 0");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    addshdlb(dt.Rows[i][1].ToString(), dt.Rows[i][0].ToString());

                }
            }
            else { reset(); }

           
        }
        //
        int demO()
        {
            ketnoi.connect();
            ketnoi.truyvan("select soban,sohoadon from hoadon where tinhtranght = 0");
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ketnoi.disconnect();
            return dt.Rows.Count;
        }
        //
        void loadhoadon()
        {
            int imax = 2, jmax = 5;

            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    if (Convert.ToString(lb[i][j].Tag) != "")
                    {
                        ketnoi.connect();
                        ketnoi.truyvan("select tenhang,chitietphieuOder.soluong , dongia, TT from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon = '" + Convert.ToString(lb[i][j].Tag) + "' and (TT = N'Chờ' or TT =N'Mua về');");
                        SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        ketnoi.disconnect();
                        if (dt.Rows.Count > 0  )
                        {
                            lb[i][j].Text += "\nTên món      SL  Đơn giá   TT";
                            for (int a = 0; a < dt.Rows.Count; a++)
                            {
                                if(Int16.Parse( dt.Rows[a][1].ToString())>0)
                                {
                                    lb[i][j].Text += "\n" + dt.Rows[a][0].ToString() + " " + dt.Rows[a][1].ToString() + "  " + dt.Rows[a][2].ToString() + "  " + dt.Rows[a][3].ToString();
                                }
                            }
                        }
                    }
                }
            }
           
        }
        //
        void hoanthanh()
        {
            ketnoi.connect();
            ketnoi.truyvan("UPDATE chitietphieuOder SET TT = N'Xong' WHERE sohoadon = '" + Convert.ToString(lb[0][0].Tag) + "'");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.truyvan("UPDATE hoadon SET tinhtranght = 1 WHERE sohoadon = '" + Convert.ToString(lb[0][0].Tag) + "'");
            ketnoi.Cmdsql.ExecuteNonQuery();
            ketnoi.disconnect();
            reset();
            loadshd();
            loadhoadon();
        }
        //
        void reset()
        {
   
            int imax = 2, jmax = 5;

            for (int i = 0; i < imax; i++)
            {
                for (int j = 0; j < jmax; j++)
                {
                    lb[i][j].Text = "";
                    lb[i][j].Tag = "";
                    pn[i][j].BackgroundImage = null;
                    pn[i][j].BorderStyle = BorderStyle.None;
                }
            }
        }
        //

        private void button2_Click(object sender, EventArgs e)
        {
            hoanthanh();
        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
            mangpanel(2, 5);
            manglabel(2, 5);
            loadshd();
            loadhoadon();
        }

        private void load_Click(object sender, EventArgs e)
        {
            reset();
            loadshd();
            loadhoadon();
        }
    }
}
