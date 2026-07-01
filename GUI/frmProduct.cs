using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmProduct : Form
    {
        private List<ProductDTO> productList;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            this.Text = "Quản Lý Sản Phẩm - Di Động Việt";
            LoadProducts();
            SetupDataGridView();
        }

        private void LoadProducts()
        {
            try
            {
                productList = ProductBLL.GetAllProducts();
                BindDataToGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BindDataToGrid()
        {
            dgvProduct.DataSource = productList;
            dgvProduct.Columns["MaSP"].HeaderText = "Mã SP";
            dgvProduct.Columns["TenSP"].HeaderText = "Tên SP";
            dgvProduct.Columns["TenHang"].HeaderText = "Hãng";
            dgvProduct.Columns["TenLoai"].HeaderText = "Loại";
            dgvProduct.Columns["GiaNhap"].HeaderText = "Giá Nhập";
            dgvProduct.Columns["GiaBan"].HeaderText = "Giá Bán";
            dgvProduct.Columns["SoLuongTon"].HeaderText = "Số Lượng Tồn";
            dgvProduct.Columns["MauSac"].HeaderText = "Màu Sắc";
            dgvProduct.Columns["BaoHanh"].HeaderText = "Bảo Hành (tháng)";
            dgvProduct.Columns["TrangThai"].Visible = false;
            dgvProduct.Columns["HinhAnh"].Visible = false;
        }

        private void SetupDataGridView()
        {
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.MultiSelect = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Mở form thêm sản phẩm
            MessageBox.Show("Chức năng thêm sản phẩm", "Thông báo");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            MessageBox.Show("Chức năng sửa sản phẩm", "Thông báo");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvProduct.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    int maSP = Convert.ToInt32(dgvProduct.SelectedRows[0].Cells["MaSP"].Value);
                    ProductBLL.DeleteProduct(maSP);
                    MessageBox.Show("Xóa sản phẩm thành công!", "Thành công");
                    LoadProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    var filteredList = ProductBLL.SearchProductByName(keyword);
                    dgvProduct.DataSource = filteredList;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
