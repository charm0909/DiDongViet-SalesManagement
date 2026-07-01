namespace DiDongViet_SalesManagement.GUI
{
    partial class frmWarehouse
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
            this.dgvWarehouse = new System.Windows.Forms.DataGridView();
            this.lblTotalProducts = new System.Windows.Forms.Label();
            this.lblLowStock = new System.Windows.Forms.Label();
            this.lblTotalQuantity = new System.Windows.Forms.Label();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();

            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlStats.Controls.Add(this.lblTotalProducts);
            this.pnlStats.Controls.Add(this.lblLowStock);
            this.pnlStats.Controls.Add(this.lblTotalQuantity);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 0);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(784, 80);
            this.pnlStats.TabIndex = 0;

            this.lblTotalProducts.AutoSize = true;
            this.lblTotalProducts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.Location = new System.Drawing.Point(20, 20);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(150, 21);
            this.lblTotalProducts.TabIndex = 0;
            this.lblTotalProducts.Text = "Tổng sản phẩm: 0";

            this.lblLowStock.AutoSize = true;
            this.lblLowStock.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.ForeColor = System.Drawing.Color.Red;
            this.lblLowStock.Location = new System.Drawing.Point(300, 20);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(150, 21);
            this.lblLowStock.TabIndex = 1;
            this.lblLowStock.Text = "Sắp hết hàng: 0";

            this.lblTotalQuantity.AutoSize = true;
            this.lblTotalQuantity.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTotalQuantity.Location = new System.Drawing.Point(580, 20);
            this.lblTotalQuantity.Name = "lblTotalQuantity";
            this.lblTotalQuantity.Size = new System.Drawing.Size(150, 21);
            this.lblTotalQuantity.TabIndex = 2;
            this.lblTotalQuantity.Text = "Tổng số lượng: 0";

            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(139)))), ((int)(((byte)(34)))));
            this.btnRefresh.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Location = new System.Drawing.Point(20, 50);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 25);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            this.pnlStats.Controls.Add(this.btnRefresh);

            this.dgvWarehouse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvWarehouse.Location = new System.Drawing.Point(0, 85);
            this.dgvWarehouse.Name = "dgvWarehouse";
            this.dgvWarehouse.Size = new System.Drawing.Size(784, 376);
            this.dgvWarehouse.TabIndex = 1;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.dgvWarehouse);
            this.Controls.Add(this.pnlStats);
            this.Name = "frmWarehouse";
            this.Text = "Quản lý Kho";
            this.Load += new System.EventHandler(this.frmWarehouse_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvWarehouse)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.DataGridView dgvWarehouse;
        private System.Windows.Forms.Label lblTotalProducts;
        private System.Windows.Forms.Label lblLowStock;
        private System.Windows.Forms.Label lblTotalQuantity;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Panel pnlStats;
    }
}
