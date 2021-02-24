using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.Reporting.WinForms;

namespace QuanLyCheDaNang
{
    public partial class ThongKe : Form
    {
        public ThongKe(int i)
        {
            InitializeComponent();
            tabControl1.SelectedIndex = i;
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            cbThang1.Text = DateTime.Now.Month.ToString();
            cbThang3.Text = DateTime.Now.Month.ToString();
            cbThang4.Text = DateTime.Now.Month.ToString();
            doanhthu(cbThang1.Text);
            doanhthutheothang();
            doanhthutheodon(cbThang3.Text);
            doanhthutheomon(cbThang4.Text);
        }
  
        private void doanhthu(string thang)
        {
            ketnoi.connect();
            ketnoi.Cmdsql =  new SqlCommand("thongkedoanhthu", ketnoi.con);
            ketnoi.Cmdsql.CommandType = CommandType.StoredProcedure;
            ketnoi.Cmdsql.Parameters.AddWithValue("@month", thang);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            da.Fill(ds);
            reportViewer1.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = "thongkedoanhthu.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);
                reportViewer1.RefreshReport();
            }
            ketnoi.disconnect();
        }

        private void doanhthutheothang()
        {
            ketnoi.connect();
            ketnoi.Cmdsql = new SqlCommand("thongkedoanhthutheothang", ketnoi.con);
            ketnoi.Cmdsql.CommandType = CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            da.Fill(ds);
            reportViewer2.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer2.LocalReport.ReportPath = "thongkedoanhthutheothang.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                reportViewer2.LocalReport.DataSources.Clear();
                reportViewer2.LocalReport.DataSources.Add(rds);
                reportViewer2.RefreshReport();
            }
            ketnoi.disconnect();
        }
        private void doanhthutheodon(string thang)
        {
            ketnoi.connect();
            ketnoi.Cmdsql = new SqlCommand("thongkedoanhthutheodon", ketnoi.con);
            ketnoi.Cmdsql.CommandType = CommandType.StoredProcedure;
            ketnoi.Cmdsql.Parameters.AddWithValue("@month", thang);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            da.Fill(ds);
            reportViewer3.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer3.LocalReport.ReportPath = "thongkedoanhthutheodon.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                reportViewer3.LocalReport.DataSources.Clear();
                reportViewer3.LocalReport.DataSources.Add(rds);
                reportViewer3.RefreshReport();
            }
            ketnoi.disconnect();
        }
        private void doanhthutheomon(string thang)
        {
            ketnoi.connect();
            ketnoi.Cmdsql = new SqlCommand("thongkedoanhthutheomon", ketnoi.con);
            ketnoi.Cmdsql.CommandType = CommandType.StoredProcedure;
            ketnoi.Cmdsql.Parameters.AddWithValue("@month", thang);
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(ketnoi.Cmdsql);
            da.Fill(ds);
            reportViewer4.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer4.LocalReport.ReportPath = "thongkedoanhthutheomon.rdlc";
            if (ds.Tables[0].Rows.Count > 0)
            {
                ReportDataSource rds = new ReportDataSource();
                rds.Name = "DataSet1";
                rds.Value = ds.Tables[0];
                reportViewer4.LocalReport.DataSources.Clear();
                reportViewer4.LocalReport.DataSources.Add(rds);
                reportViewer4.RefreshReport();
            }
            ketnoi.disconnect();
        }
        private void btnCreateReport_Click(object sender, EventArgs e)
        {
            doanhthu(cbThang1.Text);
        }

        private void btnCreateReport2_Click(object sender, EventArgs e)
        {
            doanhthutheothang();
        }

        private void btnCreateReport3_Click(object sender, EventArgs e)
        {
            doanhthutheodon(cbThang3.Text);
        }

        private void btnCreateReport4_Click(object sender, EventArgs e)
        {
            doanhthutheomon(cbThang4.Text);
        }





        
    }
}
