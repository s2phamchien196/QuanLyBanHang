using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyCheDaNang
{
    public partial class QuanLyheDaNang : Form
    {
        Button[][] arr = new Button[5][];      
        void createBan()
        {
            int dem = 1;
            int Top = 0;
            for(int i = 0; i<5;i++)
            {
                arr[i] = new Button[5];
                int left = 0;
                for (int j = 0; j < 5; j++)
                {
                    arr[i][j] = new Button();
                    arr[i][j].Name = string.Format("btnBan{0}", j + dem);
                    arr[i][j].Tag = string.Format("[{0},{1}]", i, j);
                    arr[i][j].Text = string.Format("Ban{0}", j + dem);
                    arr[i][j].Click += new EventHandler(bt_Click);
                    arr[i][j].Size = new Size(100, 100);
                    arr[i][j].Top = Top;
                    arr[i][j].Left = left;
                    arr[i][j].BackColor = Color.Yellow;
                    pBan.Controls.Add(arr[i][j]);
                    
                    left += 100;

                }
                dem += 5;
                Top += 100;
            }
        }
        private void bt_Click(object sender, EventArgs e)
        {
            if (((Button)sender).BackColor == Color.Yellow)
            {
                ((Button)sender).BackColor = Color.Green;

                txtBan.Text = ((Button)sender).Text;
                for(int i=0; i < 5; i++)
                {
                    for (int j = 0; j<5; j++)
                    {
                        if (arr[i][j].Text != ((Button)sender).Text)
                        {
                            arr[i][j].BackColor = Color.Yellow;

                        }
                    }
                }
                    
            }
           
        }
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
            thongtincanhan f = new thongtincanhan();
            f.ShowDialog();

        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

            admin f = new admin();
            f.ShowDialog();
        }

        private void btn_chuyenban_Click(object sender, EventArgs e)
        {
            arr[1][1].BackColor = Color.Green;
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            
        }

        private void QuanLyheDaNang_Load(object sender, EventArgs e)
        {
            createBan();
            adminToolStripMenuItem.Enabled = false;
        }

        private void pBan_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
