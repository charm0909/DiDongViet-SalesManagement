namespace DiDongViet_SalesManagement.GUI
{
    partial class frmInvoice
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ComboBox cbCustomer;
        private System.Windows.Forms.ComboBox cbProduct;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotalAmount;
        private System.Windows.Forms.Button btnAddDetail;
        private System.Windows.Forms.Button btnCreateInvoice;
        private System.Windows.Forms.DataGridView dgvInvoices;
        private System.Windows.Forms.DataGridView dgvInvoiceDetails;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblProduct;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lblDiscount;
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
            this.cbCustomer = new System.Windows.Forms.ComboBox();
            this.cbProduct = new System.Windows.Forms.ComboBox();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotalAmount = new System.Windows.Forms.TextBox();
            this.btnAddDetail = new System.Windows.Forms.Button();
            this.btnCreateInvoice = new System.Windows.Forms.Button();
            this.dgvInvoices = new System.Windows.Forms.DataGridView();
            this.dgvInvoiceDetails = new System.Windows.Forms.DataGridView();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProduct = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).BeginInit();
            this.SuspendLayout();

            // Thiết lập các control
            this.lblCustomer.Text = "Khách hàng:";
            this.lblCustomer.Location = new System.Drawing.Point(20, 20);
            this.cbCustomer.Location = new System.Drawing.Point(120, 20);
            this.cbCustomer.Size = new System.Drawing.Size(250, 25);

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

            this.btnAddDetail.Text = "Thêm";
            this.btnAddDetail.Location = new System.Drawing.Point(650, 60);
            this.btnAddDetail.Size = new System.Drawing.Size(80, 35);
            this.btnAddDetail.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnAddDetail.ForeColor = System.Drawing.Color.White;
            this.btnAddDetail.Click += btnAddDetail_Click;

            this.lblDiscount.Text = "Giảm giá (%)";
            this.lblDiscount.Location = new System.Drawing.Point(20, 100);
            this.txtDiscount.Location = new System.Drawing.Point(120, 100);
            this.txtDiscount.Size = new System.Drawing.Size(100, 25);

            this.lblTotal.Text = "Tổng tiền:";
            this.lblTotal.Location = new System.Drawing.Point(420, 100);
            this.txtTotalAmount.Location = new System.Drawing.Point(520, 100);
            this.txtTotalAmount.Size = new System.Drawing.Size(130, 25);
            this.txtTotalAmount.ReadOnly = true;

            this.btnCreateInvoice.Text = "Lập hóa đơn";
            this.btnCreateInvoice.Location = new System.Drawing.Point(650, 100);
            this.btnCreateInvoice.Size = new System.Drawing.Size(100, 35);
            this.btnCreateInvoice.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnCreateInvoice.ForeColor = System.Drawing.Color.White;
            this.btnCreateInvoice.Click += btnCreateInvoice_Click;

            this.dgvInvoiceDetails.Location = new System.Drawing.Point(20, 150);
            this.dgvInvoiceDetails.Size = new System.Drawing.Size(730, 200);
            this.dgvInvoiceDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvInvoices.Location = new System.Drawing.Point(20, 370);
            this.dgvInvoices.Size = new System.Drawing.Size(730, 250);
            this.dgvInvoices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            this.ClientSize = new System.Drawing.Size(770, 650);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.lblProduct);
            this.Controls.Add(this.cbProduct);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.btnAddDetail);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.txtTotalAmount);
            this.Controls.Add(this.btnCreateInvoice);
            this.Controls.Add(this.dgvInvoiceDetails);
            this.Controls.Add(this.dgvInvoices);

            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInvoiceDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
