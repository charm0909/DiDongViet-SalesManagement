namespace DiDongViet_SalesManagement.GUI
{
    partial class frmSupplier
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtSupplierName;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView dgvSuppliers;
        private System.Windows.Forms.Label lblSupplierName;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblSearch;

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
            this.txtSupplierName = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dgvSuppliers = new System.Windows.Forms.DataGridView();
            this.lblSupplierName = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblSearch = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).BeginInit();
            this.SuspendLayout();

            this.lblSearch.Text = "Tìm kiếm:";
            this.lblSearch.Location = new System.Drawing.Point(20, 20);
            this.txtSearch.Location = new System.Drawing.Point(100, 20);
            this.txtSearch.Size = new System.Drawing.Size(300, 25);
            this.btnSearch.Text = "Tìm";
            this.btnSearch.Location = new System.Drawing.Point(420, 20);
            this.btnSearch.Size = new System.Drawing.Size(70, 35);
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnSearch.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Click += btnSearch_Click;

            this.lblSupplierName.Text = "Tên nhà cung cấp:";
            this.lblSupplierName.Location = new System.Drawing.Point(20, 70);
            this.txtSupplierName.Location = new System.Drawing.Point(150, 70);
            this.txtSupplierName.Size = new System.Drawing.Size(250, 25);

            this.lblPhone.Text = "Số điện thoại:";
            this.lblPhone.Location = new System.Drawing.Point(420, 70);
            this.txtPhone.Location = new System.Drawing.Point(550, 70);
            this.txtPhone.Size = new System.Drawing.Size(180, 25);

            this.lblEmail.Text = "Email:";
            this.lblEmail.Location = new System.Drawing.Point(20, 110);
            this.txtEmail.Location = new System.Drawing.Point(150, 110);
            this.txtEmail.Size = new System.Drawing.Size(250, 25);

            this.lblAddress.Text = "Địa chỉ:";
            this.lblAddress.Location = new System.Drawing.Point(420, 110);
            this.txtAddress.Location = new System.Drawing.Point(550, 110);
            this.txtAddress.Size = new System.Drawing.Size(180, 25);

            this.btnAdd.Text = "Thêm";
            this.btnAdd.Location = new System.Drawing.Point(20, 150);
            this.btnAdd.Size = new System.Drawing.Size(80, 35);
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(40, 167, 69);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Click += btnAdd_Click;

            this.btnUpdate.Text = "Cập nhật";
            this.btnUpdate.Location = new System.Drawing.Point(110, 150);
            this.btnUpdate.Size = new System.Drawing.Size(80, 35);
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 123, 255);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Click += btnUpdate_Click;

            this.btnDelete.Text = "Xóa";
            this.btnDelete.Location = new System.Drawing.Point(200, 150);
            this.btnDelete.Size = new System.Drawing.Size(80, 35);
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(220, 53, 69);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Click += btnDelete_Click;

            this.dgvSuppliers.Location = new System.Drawing.Point(20, 200);
            this.dgvSuppliers.Size = new System.Drawing.Size(740, 400);
            this.dgvSuppliers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSuppliers.CellClick += dgvSuppliers_CellClick;

            this.ClientSize = new System.Drawing.Size(780, 650);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblSupplierName);
            this.Controls.Add(this.txtSupplierName);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.dgvSuppliers);

            ((System.ComponentModel.ISupportInitialize)(this.dgvSuppliers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
