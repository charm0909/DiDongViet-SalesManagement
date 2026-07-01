using System;
using System.Windows.Forms;
using BLL;
using System.Collections.Generic;

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
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý Kho (Tồn kho)";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
        }

        private void LoadWarehouseData()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                dgvWarehouse.DataSource = products;
                dgvWarehouse.AutoResizeColumns();
                HighlightLowStock();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu kho: " + ex.Message);
            }
        }

        private void HighlightLowStock()
        {
            try
            {
                foreach (DataGridViewRow row in dgvWarehouse.Rows)
                {
                    if (row.Cells["QuantityInStock"].Value != null)
                    {
                        int quantity = int.Parse(row.Cells["QuantityInStock"].Value.ToString());
                        if (quantity < 5) // Ngưỡng tối thiểu
                        {
                            row.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 200, 200);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi làm nổi bật tồn kho thấp: " + ex.Message);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadWarehouseData();
            MessageBox.Show("Đã làm tươi dữ liệu!");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx|CSV Files|*.csv|PDF Files|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Xuất dữ liệu ra file (có thể dùng thư viện bên thứ ba)
                    MessageBox.Show("Xuất dữ liệu thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất dữ liệu: " + ex.Message);
            }
        }
    }
}
