using System;
using System.Windows.Forms;
using DAL;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmSupplier : Form
    {
        private SupplierDAL supplierDAL = new SupplierDAL();
        private int selectedSupplierID = -1;

        public frmSupplier()
        {
            InitializeComponent();
        }

        private void frmSupplier_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý Nhà cung cấp";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
        }

        private void LoadSuppliers()
        {
            try
            {
                var suppliers = supplierDAL.GetAllSuppliers();
                dgvSuppliers.DataSource = suppliers;
                dgvSuppliers.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhà cung cấp: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSupplierName.Text) || string.IsNullOrEmpty(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                if (!IsValidPhone(txtPhone.Text))
                {
                    MessageBox.Show("Số điện thoại không hợp lệ!");
                    return;
                }

                bool result = supplierDAL.AddSupplier(txtSupplierName.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text);
                if (result)
                {
                    MessageBox.Show("Thêm nhà cung cấp thành công!");
                    ClearForm();
                    LoadSuppliers();
                }
                else
                {
                    MessageBox.Show("Thêm nhà cung cấp thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm nhà cung cấp: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSupplierID == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp để cập nhật!");
                    return;
                }

                if (string.IsNullOrEmpty(txtSupplierName.Text) || string.IsNullOrEmpty(txtPhone.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                bool result = supplierDAL.UpdateSupplier(selectedSupplierID, txtSupplierName.Text, txtPhone.Text, txtEmail.Text, txtAddress.Text);
                if (result)
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thành công!");
                    ClearForm();
                    LoadSuppliers();
                }
                else
                {
                    MessageBox.Show("Cập nhật nhà cung cấp thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật nhà cung cấp: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedSupplierID == -1)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp để xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn chắc chắn muốn xóa nhà cung cấp này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = supplierDAL.DeleteSupplier(selectedSupplierID);
                    if (result)
                    {
                        MessageBox.Show("Xóa nhà cung cấp thành công!");
                        ClearForm();
                        LoadSuppliers();
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhà cung cấp thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa nhà cung cấp: " + ex.Message);
            }
        }

        private void dgvSuppliers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    selectedSupplierID = (int)dgvSuppliers.Rows[e.RowIndex].Cells["SupplierID"].Value;
                    txtSupplierName.Text = dgvSuppliers.Rows[e.RowIndex].Cells["SupplierName"].Value.ToString();
                    txtPhone.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Phone"].Value.ToString();
                    txtEmail.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";
                    txtAddress.Text = dgvSuppliers.Rows[e.RowIndex].Cells["Address"].Value?.ToString() ?? "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn nhà cung cấp: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtSupplierName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            selectedSupplierID = -1;
            txtSearch.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    LoadSuppliers();
                }
                else
                {
                    var suppliers = supplierDAL.SearchSuppliers(txtSearch.Text);
                    dgvSuppliers.DataSource = suppliers;
                    dgvSuppliers.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private bool IsValidPhone(string phone)
        {
            return phone.Length >= 10 && phone.All(char.IsDigit);
        }
    }
}
