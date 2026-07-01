using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmEmployee : Form
    {
        private List<EmployeeDTO> employeeList;

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            this.Text = "Quản Lý Nhân Viên - Di Động Việt";
            LoadEmployees();
            SetupDataGridView();
        }

        private void LoadEmployees()
        {
            try
            {
                employeeList = EmployeeBLL.GetAllEmployees();
                BindDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid()
        {
            dgvEmployee.DataSource = employeeList;
            dgvEmployee.Columns["MaNV"].HeaderText = "Mã NV";
            dgvEmployee.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvEmployee.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgvEmployee.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgvEmployee.Columns["DienThoai"].HeaderText = "Điện Thoại";
            dgvEmployee.Columns["Email"].HeaderText = "Email";
            dgvEmployee.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvEmployee.Columns["ChucVu"].HeaderText = "Chức Vụ";
            dgvEmployee.Columns["NgayVaoLam"].HeaderText = "Ngày Vào Làm";
            dgvEmployee.Columns["TrangThai"].Visible = false;
        }

        private void SetupDataGridView()
        {
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvEmployee.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployee.MultiSelect = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm nhân viên", "Thông báo");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Chức năng sửa nhân viên", "Thông báo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng này không được phép xóa nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim().ToLower();
                if (string.IsNullOrEmpty(keyword))
                {
                    BindDataToGrid();
                }
                else
                {
                    var filteredList = new List<EmployeeDTO>();
                    foreach (var emp in employeeList)
                    {
                        if (emp.HoTen.ToLower().Contains(keyword) || emp.DienThoai.Contains(keyword))
                            filteredList.Add(emp);
                    }
                    dgvEmployee.DataSource = filteredList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
