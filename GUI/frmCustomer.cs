using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmCustomer : Form
    {
        private CustomerBLL customerBLL = new CustomerBLL();

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            StyleUI();
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = customerBLL.GetAllCustomers();
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
        }

        private void StyleUI()
        {
            // Tùy chỉnh DataGridView
            dgvCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCustomers.BackgroundColor = System.Drawing.Color.White;
            dgvCustomers.BorderStyle = BorderStyle.Fixed3D;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var customer = new CustomerDTO
                {
                    HoTen = txtName.Text.Trim(),
                    SoDienThoai = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtAddress.Text.Trim(),
                    TrangThai = "Hoạt động"
                };

                if (customerBLL.AddCustomer(customer))
                {
                    MessageBox.Show("Thêm khách hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInputs();
                    LoadCustomers();
                }
                else
                {
                    MessageBox.Show("Thêm khách hàng thất bại!");
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
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!");
                    return;
                }

                var customer = new CustomerDTO
                {
                    MaKH = (int)dgvCustomers.SelectedRows[0].Cells["MaKH"].Value,
                    HoTen = txtName.Text.Trim(),
                    SoDienThoai = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtAddress.Text.Trim(),
                    TrangThai = "Hoạt động"
                };

                if (customerBLL.UpdateCustomer(customer))
                {
                    MessageBox.Show("Cập nhật khách hàng thành công!");
                    ClearInputs();
                    LoadCustomers();
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
                if (dgvCustomers.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng!");
                    return;
                }

                int customerID = (int)dgvCustomers.SelectedRows[0].Cells["MaKH"].Value;
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (customerBLL.DeleteCustomer(customerID))
                    {
                        MessageBox.Show("Xóa khách hàng thành công!");
                        LoadCustomers();
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
                var customers = customerBLL.SearchCustomers(keyword);
                dgvCustomers.DataSource = customers;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvCustomers.Rows[e.RowIndex].Cells["HoTen"].Value?.ToString() ?? "";
                txtPhone.Text = dgvCustomers.Rows[e.RowIndex].Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtEmail.Text = dgvCustomers.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";
                txtAddress.Text = dgvCustomers.Rows[e.RowIndex].Cells["DiaChi"].Value?.ToString() ?? "";
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
