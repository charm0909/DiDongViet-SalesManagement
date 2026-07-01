namespace DiDongViet_SalesManagement.GUI
{
    partial class frmWarehouse
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.DataGridView dgvWarehouse;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label lblWarning;

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
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblWarning = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.SuspendLayout();

            this.lblWarning.Text = "⚠ Hàng có màu đỏ là tồn kho dưới 5 đơn vị";
            this.lblWarning.Location = new System.Drawing.Point(20, 20);
            this.lblWarning.Size = new System.Drawing.Size(400, 25);
            this.lblWarning.ForeColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 10f, System.Drawing.FontStyle.Bold);

            this.btnRefresh.Text = "Làm tươi";
            this.btnRefresh.Location = new System.Drawing.Point(600, 20);
            this.btnRefresh.Size = new System.Drawing.Size(80, 35);
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Click += btnRefresh_Click;

            this.btnExport.Text = "Xuất dữ liệu";
            this.btnExport.Location = new System.Drawing.Point(700, 20);
            this.btnExport.Size = new System.Drawing.Size(100, 35);
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnExport.ForeColor = System.Drawing.Color.White;
            this.btnExport.Click += btnExport_Click;

            this.dgvWarehouse.Location = new System.Drawing.Point(20, 70);
            this.dgvWarehouse.Size = new System.Drawing.Size(780, 550);
            this.dgvWarehouse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWarehouse.ReadOnly = true;
            this.dgvWarehouse.AllowUserToAddRows = false;
            this.dgvWarehouse.AllowUserToDeleteRows = false;

            this.ClientSize = new System.Drawing.Size(820, 650);
            this.Controls.Add(this.lblWarning);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.dgvWarehouse);

            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
