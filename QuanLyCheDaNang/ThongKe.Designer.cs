namespace QuanLyCheDaNang
{
    partial class ThongKe
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource5 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource7 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource8 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource6 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.thongkedoanhthuBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLyCheDaNangDataSet = new QuanLyCheDaNang.QuanLyCheDaNangDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCreateReport1 = new System.Windows.Forms.Button();
            this.thongkedoanhthuTableAdapter = new QuanLyCheDaNang.QuanLyCheDaNangDataSetTableAdapters.thongkedoanhthuTableAdapter();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cbThang1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCreateReport2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cbThang3 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCreateReport3 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.cbThang4 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.reportViewer4 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btnCreateReport4 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.thongkedoanhthuBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCheDaNangDataSet)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // thongkedoanhthuBindingSource
            // 
            this.thongkedoanhthuBindingSource.DataMember = "thongkedoanhthu";
            this.thongkedoanhthuBindingSource.DataSource = this.QuanLyCheDaNangDataSet;
            // 
            // QuanLyCheDaNangDataSet
            // 
            this.QuanLyCheDaNangDataSet.DataSetName = "QuanLyCheDaNangDataSet";
            this.QuanLyCheDaNangDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource5.Name = "DataSet1";
            reportDataSource5.Value = this.thongkedoanhthuBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource5);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "QuanLyCheDaNang.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(24, 56);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(824, 368);
            this.reportViewer1.TabIndex = 0;
            // 
            // btnCreateReport1
            // 
            this.btnCreateReport1.Location = new System.Drawing.Point(256, 16);
            this.btnCreateReport1.Name = "btnCreateReport1";
            this.btnCreateReport1.Size = new System.Drawing.Size(104, 23);
            this.btnCreateReport1.TabIndex = 0;
            this.btnCreateReport1.Text = "Tạo báo cáo";
            this.btnCreateReport1.UseVisualStyleBackColor = true;
            this.btnCreateReport1.Click += new System.EventHandler(this.btnCreateReport_Click);
            // 
            // thongkedoanhthuTableAdapter
            // 
            this.thongkedoanhthuTableAdapter.ClearBeforeFill = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(884, 475);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cbThang1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.reportViewer1);
            this.tabPage1.Controls.Add(this.btnCreateReport1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(876, 449);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Doanh thu";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cbThang1
            // 
            this.cbThang1.FormattingEnabled = true;
            this.cbThang1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang1.Location = new System.Drawing.Point(104, 16);
            this.cbThang1.Name = "cbThang1";
            this.cbThang1.Size = new System.Drawing.Size(121, 21);
            this.cbThang1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tháng";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.reportViewer2);
            this.tabPage2.Controls.Add(this.btnCreateReport2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(876, 449);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Doanh thu theo tháng";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource7.Name = "DataSet1";
            reportDataSource7.Value = this.thongkedoanhthuBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource7);
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "QuanLyCheDaNang.Report1.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(26, 56);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(824, 372);
            this.reportViewer2.TabIndex = 3;
            // 
            // btnCreateReport2
            // 
            this.btnCreateReport2.Location = new System.Drawing.Point(32, 16);
            this.btnCreateReport2.Name = "btnCreateReport2";
            this.btnCreateReport2.Size = new System.Drawing.Size(104, 23);
            this.btnCreateReport2.TabIndex = 4;
            this.btnCreateReport2.Text = "Tạo báo cáo";
            this.btnCreateReport2.UseVisualStyleBackColor = true;
            this.btnCreateReport2.Click += new System.EventHandler(this.btnCreateReport2_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cbThang3);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.reportViewer3);
            this.tabPage3.Controls.Add(this.btnCreateReport3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(876, 449);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Doanh thu theo hóa đơn";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cbThang3
            // 
            this.cbThang3.FormattingEnabled = true;
            this.cbThang3.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang3.Location = new System.Drawing.Point(106, 20);
            this.cbThang3.Name = "cbThang3";
            this.cbThang3.Size = new System.Drawing.Size(121, 21);
            this.cbThang3.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(34, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Tháng";
            // 
            // reportViewer3
            // 
            this.reportViewer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource8.Name = "DataSet1";
            reportDataSource8.Value = this.thongkedoanhthuBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource8);
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "QuanLyCheDaNang.Report1.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(26, 60);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(824, 368);
            this.reportViewer3.TabIndex = 3;
            // 
            // btnCreateReport3
            // 
            this.btnCreateReport3.Location = new System.Drawing.Point(258, 20);
            this.btnCreateReport3.Name = "btnCreateReport3";
            this.btnCreateReport3.Size = new System.Drawing.Size(104, 23);
            this.btnCreateReport3.TabIndex = 4;
            this.btnCreateReport3.Text = "Tạo báo cáo";
            this.btnCreateReport3.UseVisualStyleBackColor = true;
            this.btnCreateReport3.Click += new System.EventHandler(this.btnCreateReport3_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.cbThang4);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.reportViewer4);
            this.tabPage4.Controls.Add(this.btnCreateReport4);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(876, 449);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Doanh thu theo món";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // cbThang4
            // 
            this.cbThang4.FormattingEnabled = true;
            this.cbThang4.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12"});
            this.cbThang4.Location = new System.Drawing.Point(106, 20);
            this.cbThang4.Name = "cbThang4";
            this.cbThang4.Size = new System.Drawing.Size(121, 21);
            this.cbThang4.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Tháng";
            // 
            // reportViewer4
            // 
            this.reportViewer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource6.Name = "DataSet1";
            reportDataSource6.Value = this.thongkedoanhthuBindingSource;
            this.reportViewer4.LocalReport.DataSources.Add(reportDataSource6);
            this.reportViewer4.LocalReport.ReportEmbeddedResource = "QuanLyCheDaNang.Report1.rdlc";
            this.reportViewer4.Location = new System.Drawing.Point(26, 60);
            this.reportViewer4.Name = "reportViewer4";
            this.reportViewer4.Size = new System.Drawing.Size(824, 368);
            this.reportViewer4.TabIndex = 7;
            // 
            // btnCreateReport4
            // 
            this.btnCreateReport4.Location = new System.Drawing.Point(258, 20);
            this.btnCreateReport4.Name = "btnCreateReport4";
            this.btnCreateReport4.Size = new System.Drawing.Size(104, 23);
            this.btnCreateReport4.TabIndex = 8;
            this.btnCreateReport4.Text = "Tạo báo cáo";
            this.btnCreateReport4.UseVisualStyleBackColor = true;
            this.btnCreateReport4.Click += new System.EventHandler(this.btnCreateReport4_Click);
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 475);
            this.Controls.Add(this.tabControl1);
            this.Name = "ThongKe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thống kê";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.thongkedoanhthuBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLyCheDaNangDataSet)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btnCreateReport1;
        private System.Windows.Forms.BindingSource thongkedoanhthuBindingSource;
        private QuanLyCheDaNangDataSet QuanLyCheDaNangDataSet;
        private QuanLyCheDaNangDataSetTableAdapters.thongkedoanhthuTableAdapter thongkedoanhthuTableAdapter;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ComboBox cbThang1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer2;
        private System.Windows.Forms.Button btnCreateReport2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.ComboBox cbThang3;
        private System.Windows.Forms.Label label2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer3;
        private System.Windows.Forms.Button btnCreateReport3;
        private System.Windows.Forms.ComboBox cbThang4;
        private System.Windows.Forms.Label label3;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer4;
        private System.Windows.Forms.Button btnCreateReport4;
        
    }
}