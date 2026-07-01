namespace DiDongViet_SalesManagement.GUI
{
    partial class frmMainDashboard
    {
        private System.ComponentModel.IContainer components = null;

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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lblTodayRevenue = new System.Windows.Forms.Label();
            this.lblTodayInvoices = new System.Windows.Forms.Label();
            this.btnProduct = new System.Windows.Forms.Button();
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnCustomer = new System.Windows.Forms.Button();
            this.btnInvoice = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnWarehouse = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.SuspendLayout();

            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Load += new System.EventHandler(this.frmMainDashboard_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMainDashboard_FormClosing);

            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Arial", 16F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Size = new System.Drawing.Size(300, 25);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "";

            this.lblRole.AutoSize = true;
            this.lblRole.Location = new System.Drawing.Point(20, 50);
            this.lblRole.Size = new System.Drawing.Size(100, 13);
            this.lblRole.TabIndex = 1;
            this.lblRole.Text = "";

            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTotalProducts.Location = new System.Drawing.Point(20, 100);
            this.lblTotalProducts.Size = new System.Drawing.Size(150, 18);
            this.lblTotalProducts.TabIndex = 2;
            this.lblTotalProducts.Text = "Tổng sản phẩm: 0";

            this.lblInventory.AutoSize = true;
            this.lblInventory.Font = new System.Drawing.Font("Arial", 12F);
            this.lblInventory.Location = new System.Drawing.Point(20, 130);
            this.lblInventory.Size = new System.Drawing.Size(150, 18);
            this.lblInventory.TabIndex = 3;
            this.lblInventory.Text = "Tồn kho: 0";

            this.lblTodayRevenue.AutoSize = true;
            this.lblTodayRevenue.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTodayRevenue.Location = new System.Drawing.Point(20, 160);
            this.lblTodayRevenue.Size = new System.Drawing.Size(200, 18);
            this.lblTodayRevenue.TabIndex = 4;
            this.lblTodayRevenue.Text = "Doanh thu hôm nay: 0";

            this.lblTodayInvoices.AutoSize = true;
            this.lblTodayInvoices.Font = new System.Drawing.Font("Arial", 12F);
            this.lblTodayInvoices.Location = new System.Drawing.Point(20, 190);
            this.lblTodayInvoices.Size = new System.Drawing.Size(150, 18);
            this.lblTodayInvoices.TabIndex = 5;
            this.lblTodayInvoices.Text = "Hóa đơn hôm nay: 0";

            this.btnProduct.Location = new System.Drawing.Point(20, 260);
            this.btnProduct.Size = new System.Drawing.Size(150, 40);
            this.btnProduct.TabIndex = 6;
            this.btnProduct.Text = "Sản Phẩm";
            this.btnProduct.UseVisualStyleBackColor = true;
            this.btnProduct.Click += new System.EventHandler(this.btnProduct_Click);

            this.btnEmployee.Location = new System.Drawing.Point(180, 260);
            this.btnEmployee.Size = new System.Drawing.Size(150, 40);
            this.btnEmployee.TabIndex = 7;
            this.btnEmployee.Text = "Nhân Viên";
            this.btnEmployee.UseVisualStyleBackColor = true;
            this.btnEmployee.Click += new System.EventHandler(this.btnEmployee_Click);

            this.btnCustomer.Location = new System.Drawing.Point(340, 260);
            this.btnCustomer.Size = new System.Drawing.Size(150, 40);
            this.btnCustomer.TabIndex = 8;
            this.btnCustomer.Text = "Khách Hàng";
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);

            this.btnInvoice.Location = new System.Drawing.Point(500, 260);
            this.btnInvoice.Size = new System.Drawing.Size(150, 40);
            this.btnInvoice.TabIndex = 9;
            this.btnInvoice.Text = "Bán Hàng";
            this.btnInvoice.UseVisualStyleBackColor = true;
            this.btnInvoice.Click += new System.EventHandler(this.btnInvoice_Click);

            this.btnImport.Location = new System.Drawing.Point(20, 320);
            this.btnImport.Size = new System.Drawing.Size(150, 40);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Nhập Hàng";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);

            this.btnWarehouse.Location = new System.Drawing.Point(180, 320);
            this.btnWarehouse.Size = new System.Drawing.Size(150, 40);
            this.btnWarehouse.TabIndex = 11;
            this.btnWarehouse.Text = "Quản Lý Kho";
            this.btnWarehouse.UseVisualStyleBackColor = true;
            this.btnWarehouse.Click += new System.EventHandler(this.btnWarehouse_Click);

            this.btnReport.Location = new System.Drawing.Point(340, 320);
            this.btnReport.Size = new System.Drawing.Size(150, 40);
            this.btnReport.TabIndex = 12;
            this.btnReport.Text = "Báo Cáo";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);

            this.btnLogout.Location = new System.Drawing.Point(1070, 20);
            this.btnLogout.Size = new System.Drawing.Size(110, 35);
            this.btnLogout.TabIndex = 13;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblTotalProducts);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lblTodayRevenue);
            this.Controls.Add(this.lblTodayInvoices);
            this.Controls.Add(this.btnProduct);
            this.Controls.Add(this.btnEmployee);
            this.Controls.Add(this.btnCustomer);
            this.Controls.Add(this.btnInvoice);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.btnWarehouse);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnLogout);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.Label lblTodayRevenue;
        private System.Windows.Forms.Label lblTodayInvoices;
        private System.Windows.Forms.Button btnProduct;
        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnCustomer;
        private System.Windows.Forms.Button btnInvoice;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnWarehouse;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnLogout;
    }
}
