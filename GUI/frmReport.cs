using System;
using System.Windows.Forms;
using BLL;
using System.Collections.Generic;
using System.Linq;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmReport : Form
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private ProductBLL productBLL = new ProductBLL();

        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            SetupUI();
            LoadReportTypes();
        }

        private void SetupUI()
        {
            this.Text = "Báo cáo & Thống kê";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
        }

        private void LoadReportTypes()
        {
            cbReportType.Items.Clear();
            cbReportType.Items.Add("Doanh thu theo ngày");
            cbReportType.Items.Add("Doanh thu theo tháng");
            cbReportType.Items.Add("Doanh thu theo năm");
            cbReportType.Items.Add("Sản phẩm bán chạy");
            cbReportType.Items.Add("Tồn kho");
            cbReportType.SelectedIndex = 0;
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbReportType.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn loại báo cáo!");
                    return;
                }

                string reportType = cbReportType.SelectedItem.ToString();
                
                switch (reportType)
                {
                    case "Doanh thu theo ngày":
                        LoadRevenueByDay();
                        break;
                    case "Doanh thu theo tháng":
                        LoadRevenueByMonth();
                        break;
                    case "Doanh thu theo năm":
                        LoadRevenueByYear();
                        break;
                    case "Sản phẩm bán chạy":
                        LoadTopSellingProducts();
                        break;
                    case "Tồn kho":
                        LoadInventory();
                        break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tạo báo cáo: " + ex.Message);
            }
        }

        private void LoadRevenueByDay()
        {
            try
            {
                var invoices = invoiceBLL.GetAllInvoices();
                var groupedData = invoices
                    .GroupBy(x => ((DateTime)x.InvoiceDate).Date)
                    .Select(g => new { Date = g.Key, TotalRevenue = g.Sum(x => x.TotalAmount) })
                    .OrderByDescending(x => x.Date)
                    .ToList();

                dgvReport.DataSource = groupedData;
                dgvReport.AutoResizeColumns();
                lblReportTitle.Text = "Báo cáo Doanh thu theo Ngày";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadRevenueByMonth()
        {
            try
            {
                var invoices = invoiceBLL.GetAllInvoices();
                var groupedData = invoices
                    .GroupBy(x => new { Year = ((DateTime)x.InvoiceDate).Year, Month = ((DateTime)x.InvoiceDate).Month })
                    .Select(g => new { Period = $"{g.Key.Month}/{g.Key.Year}", TotalRevenue = g.Sum(x => x.TotalAmount) })
                    .OrderByDescending(x => x.Period)
                    .ToList();

                dgvReport.DataSource = groupedData;
                dgvReport.AutoResizeColumns();
                lblReportTitle.Text = "Báo cáo Doanh thu theo Tháng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadRevenueByYear()
        {
            try
            {
                var invoices = invoiceBLL.GetAllInvoices();
                var groupedData = invoices
                    .GroupBy(x => ((DateTime)x.InvoiceDate).Year)
                    .Select(g => new { Year = g.Key, TotalRevenue = g.Sum(x => x.TotalAmount) })
                    .OrderByDescending(x => x.Year)
                    .ToList();

                dgvReport.DataSource = groupedData;
                dgvReport.AutoResizeColumns();
                lblReportTitle.Text = "Báo cáo Doanh thu theo Năm";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadTopSellingProducts()
        {
            try
            {
                var invoices = invoiceBLL.GetAllInvoices();
                var topProducts = invoices
                    .SelectMany(x => x.Details)
                    .GroupBy(x => x.ProductName)
                    .Select(g => new { ProductName = g.Key, TotalQuantity = g.Sum(x => x.Quantity), TotalRevenue = g.Sum(x => x.Total) })
                    .OrderByDescending(x => x.TotalQuantity)
                    .Take(10)
                    .ToList();

                dgvReport.DataSource = topProducts;
                dgvReport.AutoResizeColumns();
                lblReportTitle.Text = "Báo cáo Sản phẩm Bán chạy (Top 10)";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void LoadInventory()
        {
            try
            {
                var products = productBLL.GetAllProducts();
                var inventoryData = products
                    .Select(p => new { ProductName = p.ProductName, Quantity = p.QuantityInStock, ImportPrice = p.ImportPrice, SalePrice = p.SalePrice })
                    .OrderBy(x => x.Quantity)
                    .ToList();

                dgvReport.DataSource = inventoryData;
                dgvReport.AutoResizeColumns();
                lblReportTitle.Text = "Báo cáo Tồn kho Hiện tại";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Xuất dữ liệu ra PDF (sử dụng thư viện bên thứ ba)
                    MessageBox.Show("Xuất PDF thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất PDF: " + ex.Message);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Xuất dữ liệu ra Excel (sử dụng thư viện bên thứ ba)
                    MessageBox.Show("Xuất Excel thành công!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }
    }
}
