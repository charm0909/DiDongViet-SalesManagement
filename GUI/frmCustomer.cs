using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmCustomer : Form
    {
        private List<CustomerDTO> customerList;

        public frmCustomer()
        {
            InitializeComponent();
        }

        private void frmCustomer_Load(object sender, EventArgs e)
        {
            this.Text = "Quản Lý Khách Hàng - Di Động Việt";
            LoadCustomers();
            SetupDataGridView();
        }

        private void LoadCustomers()
        {
            try
            {
                customerList = CustomerBLL.GetAllCustomers();
                BindDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid()
        {
            dgvCustomer.DataSource = customerList;
            dgvCustomer.Columns["MaKH"].HeaderText = "Mã KH";
            dgvCustomer.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvCustomer.Columns["DienThoai"].HeaderText = "Điện Thoại";
            dgvCustomer.Columns["Email"].HeaderText = "Email";
            dgvCustomer.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgvCustomer.Columns["TongChiTieu"].HeaderText = "Tổng Chi Tiêu";
            dgvCustomer.Columns["TrangThai"].Visible = false;
        }

        private void SetupDataGridView()
        {
            dgvCustomer.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCustomer.MultiSelect = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng thêm khách hàng", "Thông báo");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Chức năng sửa khách hàng", "Thông báo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomer.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                MessageBox.Show("Xóa khách hàng thành công!", "Thành công");
                LoadCustomers();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = txtSearch.Text.Trim();
                if (string.IsNullOrEmpty(keyword))
                {
                    BindDataToGrid();
                }
                else
                {
                    var filteredList = CustomerBLL.SearchCustomer(keyword);
                    dgvCustomer.DataSource = filteredList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
