using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmProduct : Form
    {
        private ProductBLL productBLL = new ProductBLL();

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            StyleUI();
        }

        private void LoadProducts()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void StyleUI()
        {
            dgvProducts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProducts.BackgroundColor = System.Drawing.Color.White;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                var product = new ProductDTO
                {
                    MaSanPham = txtProductCode.Text.Trim(),
                    TenSP = txtProductName.Text.Trim(),
                    GiaNhap = decimal.Parse(txtBuyPrice.Text),
                    GiaBan = decimal.Parse(txtSellPrice.Text),
                    MauSac = txtColor.Text.Trim(),
                    TrangThai = "Hoạt động"
                };

                if (productBLL.AddProduct(product))
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    ClearInputs();
                    LoadProducts();
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
                if (dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!");
                    return;
                }

                var product = new ProductDTO
                {
                    MaSP = (int)dgvProducts.SelectedRows[0].Cells["MaSP"].Value,
                    MaSanPham = txtProductCode.Text.Trim(),
                    TenSP = txtProductName.Text.Trim(),
                    GiaNhap = decimal.Parse(txtBuyPrice.Text),
                    GiaBan = decimal.Parse(txtSellPrice.Text),
                    MauSac = txtColor.Text.Trim(),
                    TrangThai = "Hoạt động"
                };

                if (productBLL.UpdateProduct(product))
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    ClearInputs();
                    LoadProducts();
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
                if (dgvProducts.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm!");
                    return;
                }

                int productID = (int)dgvProducts.SelectedRows[0].Cells["MaSP"].Value;
                if (MessageBox.Show("Bạn có chắc muốn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (productBLL.DeleteProduct(productID))
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        LoadProducts();
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
                var products = productBLL.SearchProducts(keyword);
                dgvProducts.DataSource = products;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtProductCode.Text = dgvProducts.Rows[e.RowIndex].Cells["MaSanPham"].Value?.ToString() ?? "";
                txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells["TenSP"].Value?.ToString() ?? "";
                txtBuyPrice.Text = dgvProducts.Rows[e.RowIndex].Cells["GiaNhap"].Value?.ToString() ?? "";
                txtSellPrice.Text = dgvProducts.Rows[e.RowIndex].Cells["GiaBan"].Value?.ToString() ?? "";
                txtColor.Text = dgvProducts.Rows[e.RowIndex].Cells["MauSac"].Value?.ToString() ?? "";
            }
        }

        private void ClearInputs()
        {
            txtProductCode.Clear();
            txtProductName.Clear();
            txtBuyPrice.Clear();
            txtSellPrice.Clear();
            txtColor.Clear();
        }
    }
}
