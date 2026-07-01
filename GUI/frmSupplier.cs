using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmSupplier : Form
    {
        private SupplierBLL supplierBLL = new SupplierBLL();

        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            StyleUI();
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = supplierBLL.GetAllSuppliers();
                dgvSuppliers.DataSource = suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void StyleUI()
        {
            dgvSuppliers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSuppliers.BackgroundColor = System.Drawing.Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var supplier = new SupplierDTO
                {
                    SupplierName = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = "Hoạt động"
                };

                if (supplierBLL.AddSupplier(supplier))
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    ClearInputs();
                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSuppliers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                    return;
                }

                var supplier = new SupplierDTO
                {
                    SupplierID = (int)dgvSuppliers.SelectedRows[0].Cells["SupplierID"].Value,
                    SupplierName = txtName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Address = txtAddress.Text.Trim(),
                    Status = "Hoạt động"
                };

                if (supplierBLL.UpdateSupplier(supplier))
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                    ClearInputs();
                    LoadSuppliers();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvSuppliers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp!");
                    return;
                }

                int supplierID = (int)dgvSuppliers.SelectedRows[0].Cells["SupplierID"].Value;
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (supplierBLL.DeleteSupplier(supplierID))
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!");
                        LoadSuppliers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                var suppliers = supplierBLL.SearchSuppliers(keyword);
                dgvSuppliers.DataSource = suppliers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvSuppliers.Rows[e.RowIndex].Cells["SupplierName"].Value?.ToString() ?? "";
                txtPhone.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Phone"].Value?.ToString() ?? "";
                txtEmail.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";
                txtAddress.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Address"].Value?.ToString() ?? "";
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
        }
    }
}
