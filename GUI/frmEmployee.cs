using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmEmployee : Form
    {
        private EmployeeBLL employeeBLL = new EmployeeBLL();

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            LoadEmployees();
            StyleUI();
        }

        private void LoadEmployees()
        {
            try
            {
                var employees = employeeBLL.GetAllEmployees();
                dgvEmployees.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void StyleUI()
        {
            dgvEmployees.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployees.BackgroundColor = System.Drawing.Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var employee = new EmployeeDTO
                {
                    HoTen = txtName.Text.Trim(),
                    NgaySinh = dtpBirthDate.Value,
                    GioiTinh = cmbGender.SelectedItem?.ToString() ?? "Nam",
                    SoDienThoai = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtAddress.Text.Trim(),
                    ChucVu = cmbPosition.SelectedItem?.ToString() ?? "Nhân viên bán hàng",
                    NgayVaoLam = dtpStartDate.Value,
                    TrangThai = "Hoạt động"
                };

                if (employeeBLL.AddEmployee(employee))
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    ClearInputs();
                    LoadEmployees();
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
                if (dgvEmployees.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!");
                    return;
                }

                var employee = new EmployeeDTO
                {
                    MaNV = (int)dgvEmployees.SelectedRows[0].Cells["MaNV"].Value,
                    HoTen = txtName.Text.Trim(),
                    NgaySinh = dtpBirthDate.Value,
                    GioiTinh = cmbGender.SelectedItem?.ToString() ?? "Nam",
                    SoDienThoai = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    DiaChi = txtAddress.Text.Trim(),
                    ChucVu = cmbPosition.SelectedItem?.ToString() ?? "Nhân viên bán hàng",
                    NgayVaoLam = dtpStartDate.Value,
                    TrangThai = "Hoạt động"
                };

                if (employeeBLL.UpdateEmployee(employee))
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                    ClearInputs();
                    LoadEmployees();
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
                if (dgvEmployees.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn nhân viên!");
                    return;
                }

                int employeeID = (int)dgvEmployees.SelectedRows[0].Cells["MaNV"].Value;
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (employeeBLL.DeleteEmployee(employeeID))
                    {
                        MessageBox.Show("Xóa nhân viên thành công!");
                        LoadEmployees();
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
                var employees = employeeBLL.SearchEmployees(keyword);
                dgvEmployees.DataSource = employees;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtName.Text = dgvEmployees.Rows[e.RowIndex].Cells["HoTen"].Value?.ToString() ?? "";
                dtpBirthDate.Value = (DateTime)dgvEmployees.Rows[e.RowIndex].Cells["NgaySinh"].Value;
                cmbGender.SelectedItem = dgvEmployees.Rows[e.RowIndex].Cells["GioiTinh"].Value?.ToString();
                txtPhone.Text = dgvEmployees.Rows[e.RowIndex].Cells["SoDienThoai"].Value?.ToString() ?? "";
                txtEmail.Text = dgvEmployees.Rows[e.RowIndex].Cells["Email"].Value?.ToString() ?? "";
                txtAddress.Text = dgvEmployees.Rows[e.RowIndex].Cells["DiaChi"].Value?.ToString() ?? "";
                cmbPosition.SelectedItem = dgvEmployees.Rows[e.RowIndex].Cells["ChucVu"].Value?.ToString();
            }
        }

        private void ClearInputs()
        {
            txtName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            dtpBirthDate.Value = DateTime.Now;
            dtpStartDate.Value = DateTime.Now;
        }
    }
}
