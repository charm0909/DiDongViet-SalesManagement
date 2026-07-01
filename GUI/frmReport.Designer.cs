namespace DiDongViet_SalesManagement.GUI
{
    partial class frmReport
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbReportType;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnExportPDF;
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Label lblReportType;
        private System.Windows.Forms.Label lblReportTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cbReportType = new System.Windows.Forms.ComboBox();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExportPDF = new System.Windows.Forms.Button();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.lblReportType = new System.Windows.Forms.Label();
            this.lblReportTitle = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();

            this.lblReportType.Text = "Loại Báo cáo:";
            this.lblReportType.Location = new System.Drawing.Point(20, 20);
            this.lblReportType.Size = new System.Drawing.Size(100, 25);
            this.lblReportType.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);

            this.cbReportType.Location = new System.Drawing.Point(120, 20);
            this.cbReportType.Size = new System.Drawing.Size(250, 25);
            this.cbReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;

            this.btnGenerateReport.Text = "Tạo Báo cáo";
            this.btnGenerateReport.Location = new System.Drawing.Point(400, 20);
            this.btnGenerateReport.Size = new System.Drawing.Size(100, 35);
            this.btnGenerateReport.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnGenerateReport.ForeColor = System.Drawing.Color.White;
            this.btnGenerateReport.Click += btnGenerateReport_Click;

            this.btnExportPDF.Text = "Xuất PDF";
            this.btnExportPDF.Location = new System.Drawing.Point(520, 20);
            this.btnExportPDF.Size = new System.Drawing.Size(80, 35);
            this.btnExportPDF.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnExportPDF.ForeColor = System.Drawing.Color.White;
            this.btnExportPDF.Click += btnExportPDF_Click;

            this.btnExportExcel.Text = "Xuất Excel";
            this.btnExportExcel.Location = new System.Drawing.Point(620, 20);
            this.btnExportExcel.Size = new System.Drawing.Size(80, 35);
            this.btnExportExcel.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExportExcel.ForeColor = System.Drawing.Color.White;
            this.btnExportExcel.Click += btnExportExcel_Click;

            this.lblReportTitle.Text = "Báo cáo";
            this.lblReportTitle.Location = new System.Drawing.Point(20, 70);
            this.lblReportTitle.Size = new System.Drawing.Size(600, 25);
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 12f, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);

            this.dgvReport.Location = new System.Drawing.Point(20, 110);
            this.dgvReport.Size = new System.Drawing.Size(760, 500);
            this.dgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReport.ReadOnly = true;
            this.dgvReport.AllowUserToAddRows = false;
            this.dgvReport.AllowUserToDeleteRows = false;

            this.ClientSize = new System.Drawing.Size(800, 650);
            this.Controls.Add(this.lblReportType);
            this.Controls.Add(this.cbReportType);
            this.Controls.Add(this.btnGenerateReport);
            this.Controls.Add(this.btnExportPDF);
            this.Controls.Add(this.btnExportExcel);
            this.Controls.Add(this.lblReportTitle);
            this.Controls.Add(this.dgvReport);

            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
