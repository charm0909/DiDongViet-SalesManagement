using System;
using System.Windows.Forms;
using BLL;
using DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmProduct : Form
    {
        private ProductBLL productBLL = new ProductBLL();
        private int selectedProductID = -1;

        public frmProduct()
        {
            InitializeComponent();
        }

        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProducts();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý Sản phẩm";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
            picProduct.SizeMode = PictureBoxSizeMode.Zoom;
            picProduct.BorderStyle = BorderStyle.Fixed3D;
        }

        private void LoadProducts()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                dgvProducts.DataSource = products;
                dgvProducts.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtProductName.Text) || string.IsNullOrEmpty(txtImportPrice.Text) || string.IsNullOrEmpty(txtSalePrice.Text))
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                    return;
                }

                ProductDTO product = new ProductDTO
                {
                    ProductName = txtProductName.Text,
                    BrandID = string.IsNullOrEmpty(txtBrand.Text) ? 0 : int.Parse(txtBrand.Text),
                    CategoryID = string.IsNullOrEmpty(txtCategory.Text) ? 0 : int.Parse(txtCategory.Text),
                    ImportPrice = decimal.Parse(txtImportPrice.Text),
                    SalePrice = decimal.Parse(txtSalePrice.Text),
                    QuantityInStock = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : int.Parse(txtQuantity.Text),
                    Color = txtColor.Text,
                    Warranty = txtWarranty.Text,
                    ImagePath = txtImagePath.Text
                };

                bool result = productBLL.AddProduct(product);
                if (result)
                {
                    MessageBox.Show("Thêm sản phẩm thành công!");
                    ClearForm();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Thêm sản phẩm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedProductID == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để cập nhật!");
                    return;
                }

                ProductDTO product = new ProductDTO
                {
                    ProductID = selectedProductID,
                    ProductName = txtProductName.Text,
                    BrandID = string.IsNullOrEmpty(txtBrand.Text) ? 0 : int.Parse(txtBrand.Text),
                    CategoryID = string.IsNullOrEmpty(txtCategory.Text) ? 0 : int.Parse(txtCategory.Text),
                    ImportPrice = decimal.Parse(txtImportPrice.Text),
                    SalePrice = decimal.Parse(txtSalePrice.Text),
                    QuantityInStock = string.IsNullOrEmpty(txtQuantity.Text) ? 0 : int.Parse(txtQuantity.Text),
                    Color = txtColor.Text,
                    Warranty = txtWarranty.Text,
                    ImagePath = txtImagePath.Text
                };

                bool result = productBLL.UpdateProduct(product);
                if (result)
                {
                    MessageBox.Show("Cập nhật sản phẩm thành công!");
                    ClearForm();
                    LoadProducts();
                }
                else
                {
                    MessageBox.Show("Cập nhật sản phẩm thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật sản phẩm: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (selectedProductID == -1)
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm để xóa!");
                    return;
                }

                if (MessageBox.Show("Bạn chắc chắn muốn xóa sản phẩm này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    bool result = productBLL.DeleteProduct(selectedProductID);
                    if (result)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công!");
                        ClearForm();
                        LoadProducts();
                    }
                    else
                    {
                        MessageBox.Show("Xóa sản phẩm thất bại!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sản phẩm: " + ex.Message);
            }
        }

        private void dgvProducts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    selectedProductID = (int)dgvProducts.Rows[e.RowIndex].Cells["ProductID"].Value;
                    txtProductName.Text = dgvProducts.Rows[e.RowIndex].Cells["ProductName"].Value.ToString();
                    txtBrand.Text = dgvProducts.Rows[e.RowIndex].Cells["BrandID"].Value.ToString();
                    txtCategory.Text = dgvProducts.Rows[e.RowIndex].Cells["CategoryID"].Value.ToString();
                    txtImportPrice.Text = dgvProducts.Rows[e.RowIndex].Cells["ImportPrice"].Value.ToString();
                    txtSalePrice.Text = dgvProducts.Rows[e.RowIndex].Cells["SalePrice"].Value.ToString();
                    txtQuantity.Text = dgvProducts.Rows[e.RowIndex].Cells["QuantityInStock"].Value.ToString();
                    txtColor.Text = dgvProducts.Rows[e.RowIndex].Cells["Color"].Value?.ToString() ?? "";
                    txtWarranty.Text = dgvProducts.Rows[e.RowIndex].Cells["Warranty"].Value?.ToString() ?? "";
                    txtImagePath.Text = dgvProducts.Rows[e.RowIndex].Cells["ImagePath"].Value?.ToString() ?? "";

                    // Hiển thị ảnh sản phẩm
                    try
                    {
                        if (!string.IsNullOrEmpty(txtImagePath.Text))
                        {
                            picProduct.ImageLocation = txtImagePath.Text;
                        }
                    }
                    catch
                    {
                        picProduct.Image = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn sản phẩm: " + ex.Message);
            }
        }

        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImagePath.Text = openFileDialog.FileName;
                    picProduct.ImageLocation = openFileDialog.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi chọn ảnh: " + ex.Message);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    LoadProducts();
                }
                else
                {
                    var products = productBLL.SearchProducts(txtSearch.Text);
                    dgvProducts.DataSource = products;
                    dgvProducts.AutoResizeColumns();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtProductName.Clear();
            txtBrand.Clear();
            txtCategory.Clear();
            txtImportPrice.Clear();
            txtSalePrice.Clear();
            txtQuantity.Clear();
            txtColor.Clear();
            txtWarranty.Clear();
            txtImagePath.Clear();
            txtSearch.Clear();
            picProduct.Image = null;
            selectedProductID = -1;
        }
    }
}
