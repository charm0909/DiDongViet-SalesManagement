namespace DiDongViet_SalesManagement.GUI
{
    partial class frmImport
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSupplier;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnCreateImport;
        private System.Windows.Forms.DataGridView dgvImports;
        private System.Windows.Forms.DataGridView dgvImportDetails;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblTotal;

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
            this.txtSupplier = new System.Windows.Forms.TextBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnCreateImport = new System.Windows.Forms.Button();
            this.dgvImports = new System.Windows.Forms.DataGridView();
            this.dgvImportDetails = new System.Windows.Forms.DataGridView();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportDetails)).BeginInit();
            this.SuspendLayout();

            // Thiết lập các control
            this.lblSupplier.Text = "Nhà cung cấp:";
            this.lblSupplier.Location = new System.Drawing.Point(20, 20);
            this.txtSupplier.Location = new System.Drawing.Point(120, 20);
            this.txtSupplier.Size = new System.Drawing.Size(250, 25);

            this.lblProduct.Text = "Sản phẩm:";
            this.lblProduct.Location = new System.Drawing.Point(20, 60);
            this.cbProduct.Location = new System.Drawing.Point(120, 60);
            this.cbProduct.Size = new System.Drawing.Size(250, 25);

            this.lblQuantity.Text = "Số lượng:";
            this.lblQuantity.Location = new System.Drawing.Point(420, 60);
            this.nudQuantity.Location = new System.Drawing.Point(520, 60);
            this.nudQuantity.Size = new System.Drawing.Size(100, 25);
            this.nudQuantity.Minimum = 0;
            this.nudQuantity.Maximum = 10000;

            this.lblPrice.Text = "Đơn giá:";
            this.lblPrice.Location = new System.Drawing.Point(420, 20);
            this.txtPrice.Location = new System.Drawing.Point(520, 20);
            this.txtPrice.Size = new System.Drawing.Size(100, 25);

            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.Location = new System.Drawing.Point(650, 60);
            this.btnAddDetail.Size = new System.Drawing.Size(80, 35);
            this.btnAddDetail.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnAddDetail.ForeColor = System.Drawing.Color.White;
            this.btnAddDetail.Click += btnAddDetail_Click;

            this.lblTotal.Text = "Tổng tiền:";
            this.lblTotal.Location = new System.Drawing.Point(20, 100);
            this.txtTotalAmount.Location = new System.Drawing.Point(120, 100);
            this.txtTotalAmount.Size = new System.Drawing.Size(130, 25);
            this.txtTotalAmount.ReadOnly = true;

            this.btnCreateImport.Text = "Lập phiếu nhập";
            this.btnCreateImport.Location = new System.Drawing.Point(650, 100);
            this.btnCreateImport.Size = new System.Drawing.Size(100, 35);
            this.btnCreateImport.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCreateImport.ForeColor = System.Drawing.Color.White;
            this.btnCreateImport.Click += btnCreateImport_Click;

            this.dgvImportDetails.Location = new System.Drawing.Point(20, 150);
            this.dgvImportDetails.Size = new System.Drawing.Size(730, 200);
            this.dgvImportDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvImports.Location = new System.Drawing.Point(20, 370);
            this.dgvImports.Size = new System.Drawing.Size(730, 250);
            this.dgvImports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.ClientSize = new System.Drawing.Size(770, 650);
            this.Controls.Add(this.lblSupplier);
            this.Controls.Add(this.txtSupplier);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.btnAddDetail);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnCreateImport);
            this.Controls.Add(this.dgvImportDetails);
            this.Controls.Add(this.dgvImports);

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvImportDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
