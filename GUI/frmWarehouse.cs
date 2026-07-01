using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmWarehouse : Form
    {
        private ProductBLL productBLL = new ProductBLL();

        public frmWarehouse()
        {
            InitializeComponent();
        }

        private void frmWarehouse_Load(object sender, EventArgs e)
        {
            LoadWarehouseData();
            StyleUI();
        }

        private void LoadWarehouseData()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                dgvWarehouse.DataSource = products;
                CalculateStatistics();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu kho: " + ex.Message);
            }
        }

        private void StyleUI()
        {
            dgvWarehouse.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvWarehouse.BackgroundColor = System.Drawing.Color.White;
        }

        private void CalculateStatistics()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                int totalProducts = products.Count;
                int lowStockProducts = 0;
                int totalQuantity = 0;

                foreach (var product in products)
                {
                    totalQuantity += product.SoLuongTon;
                    if (product.SoLuongTon < 5) // Cảnh báo dưới 5 cái
                        lowStockProducts++;
                }

                lblTotalProducts.Text = "Tổng sản phẩm: " + totalProducts;
                lblLowStock.Text = "Sắp hết hàng: " + lowStockProducts;
                lblTotalQuantity.Text = "Tổng số lượng: " + totalQuantity;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính toán thống kê: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWarehouseData();
        }
    }
}
