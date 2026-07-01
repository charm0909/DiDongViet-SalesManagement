using System;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Collections.Generic;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmImport : Form
    {
        private ImportBLL importBLL = new ImportBLL();
        private ProductBLL productBLL = new ProductBLL();
        private List<ImportDetailDTO> importDetails = new List<ImportDetailDTO>();

        public frmImport()
        {
            InitializeComponent();
        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            LoadProducts();
            LoadImportList();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý Nhập hàng (Phiếu nhập)";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
        }

        private void LoadProducts()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                cbProduct.DataSource = products;
                cbProduct.DisplayMember = "ProductName";
                cbProduct.ValueMember = "ProductID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách sản phẩm: " + ex.Message);
            }
        }

        private void LoadImportList()
        {
            try
            {
                var imports = importBLL.GetAllImports();
                dgvImports.DataSource = imports;
                dgvImports.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phiếu nhập: " + ex.Message);
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProduct.SelectedValue == null || string.IsNullOrEmpty(nudQuantity.Text) || string.IsNullOrEmpty(txtPrice.Text))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm, nhập số lượng và đơn giá!");
                    return;
                }

                int productID = (int)cbProduct.SelectedValue;
                int quantity = (int)nudQuantity.Value;
                decimal price = decimal.Parse(txtPrice.Text);
                var product = productBLL.GetProductByID(productID);

                if (product == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại!");
                    return;
                }

                ImportDetailDTO detail = new ImportDetailDTO
                {
                    ProductID = productID,
                    ProductName = product.ProductName,
                    Quantity = quantity,
                    ImportPrice = price,
                    Total = quantity * price
                };

                importDetails.Add(detail);
                RefreshImportDetailView();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chi tiết phiếu nhập: " + ex.Message);
            }
        }

        private void RefreshImportDetailView()
        {
            dgvImportDetails.DataSource = new List<ImportDetailDTO>(importDetails);
            dgvImportDetails.AutoResizeColumns();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (var detail in importDetails)
            {
                total += detail.Total;
            }
            txtTotalAmount.Text = total.ToString("N0");
        }

        private void btnCreateImport_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtSupplier.Text) || importDetails.Count == 0)
                {
                    MessageBox.Show("Vui lòng nhập tên nhà cung cấp và thêm ít nhất 1 sản phẩm!");
                    return;
                }

                ImportDTO import = new ImportDTO
                {
                    SupplierName = txtSupplier.Text,
                    ImportDate = DateTime.Now,
                    Details = importDetails
                };

                bool result = importBLL.CreateImport(import);
                if (result)
                {
                    MessageBox.Show("Lập phiếu nhập thành công!");
                    ClearForm();
                    LoadImportList();
                }
                else
                {
                    MessageBox.Show("Lập phiếu nhập thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lập phiếu nhập: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            txtSupplier.Clear();
            cbProduct.SelectedIndex = -1;
            nudQuantity.Value = 0;
            txtPrice.Clear();
            txtTotalAmount.Clear();
            importDetails.Clear();
            dgvImportDetails.DataSource = null;
        }
    }
}
