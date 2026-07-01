using System;
using System.Windows.Forms;
using BLL;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;

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
                if (dgvReport.DataSource == null || dgvReport.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PDF Files|*.pdf";
                saveFileDialog.DefaultExt = "pdf";
                saveFileDialog.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportDataGridViewToPdf(dgvReport, saveFileDialog.FileName, lblReportTitle.Text);
                    MessageBox.Show("Xuất PDF thành công tại: " + saveFileDialog.FileName);
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
                if (dgvReport.DataSource == null || dgvReport.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!");
                    return;
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Files|*.xlsx";
                saveFileDialog.DefaultExt = "xlsx";
                saveFileDialog.FileName = $"BaoCao_{DateTime.Now:yyyyMMdd_HHmmss}";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ExportDataGridViewToExcel(dgvReport, saveFileDialog.FileName, lblReportTitle.Text);
                    MessageBox.Show("Xuất Excel thành công tại: " + saveFileDialog.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xuất Excel: " + ex.Message);
            }
        }

        // Xuất PDF
        private void ExportDataGridViewToPdf(DataGridView dgv, string filePath, string title)
        {
            try
            {
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(filePath, FileMode.Create));
                doc.Open();

                // Tiêu đề
                Paragraph titleParagraph = new Paragraph(title, FontFactory.GetFont("Arial", 16, Font.BOLD));
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                doc.Add(titleParagraph);

                // Ngày tạo
                Paragraph dateParagraph = new Paragraph($"Ngày tạo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}", FontFactory.GetFont("Arial", 10));
                dateParagraph.Alignment = Element.ALIGN_RIGHT;
                doc.Add(dateParagraph);

                doc.Add(new Paragraph(" ")); // Khoảng trắng

                // Bảng
                PdfPTable table = new PdfPTable(dgv.Columns.Count);
                table.WidthPercentage = 100;

                // Header
                foreach (DataGridViewColumn column in dgv.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, FontFactory.GetFont("Arial", 10, Font.BOLD)));
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(220, 53, 69); // Màu đỏ Di Động Việt
                    cell.Padding = 5;
                    table.AddCell(cell);
                }

                // Dữ liệu
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(cell.Value?.ToString() ?? "", FontFactory.GetFont("Arial", 9)));
                        pdfCell.Padding = 5;
                        table.AddCell(pdfCell);
                    }
                }

                doc.Add(table);
                doc.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xuất PDF: " + ex.Message);
            }
        }

        // Xuất Excel
        private void ExportDataGridViewToExcel(DataGridView dgv, string filePath, string title)
        {
            try
            {
                // Đặt license context cho EPPlus
                EPPlus.ExcelPackage.LicenseContext = EPPlus.LicenseContext.NonCommercial;

                using (var package = new EPPlus.ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Report");

                    // Tiêu đề
                    worksheet.Cells[1, 1].Value = title;
                    worksheet.Cells[1, 1].Style.Font.Bold = true;
                    worksheet.Cells[1, 1].Style.Font.Size = 14;
                    worksheet.Cells[1, 1].Style.Font.Color.SetColor(System.Drawing.Color.FromArgb(220, 53, 69));

                    // Ngày tạo
                    worksheet.Cells[2, 1].Value = $"Ngày tạo: {DateTime.Now:dd/MM/yyyy HH:mm:ss}";
                    worksheet.Cells[2, 1].Style.Font.Size = 10;

                    // Header
                    int colIndex = 1;
                    foreach (DataGridViewColumn column in dgv.Columns)
                    {
                        worksheet.Cells[4, colIndex].Value = column.HeaderText;
                        worksheet.Cells[4, colIndex].Style.Font.Bold = true;
                        worksheet.Cells[4, colIndex].Style.Fill.PatternType = EPPlus.Style.ExcelFillStyle.Solid;
                        worksheet.Cells[4, colIndex].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.FromArgb(220, 53, 69));
                        worksheet.Cells[4, colIndex].Style.Font.Color.SetColor(System.Drawing.Color.White);
                        colIndex++;
                    }

                    // Dữ liệu
                    int rowIndex = 5;
                    foreach (DataGridViewRow row in dgv.Rows)
                    {
                        colIndex = 1;
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            worksheet.Cells[rowIndex, colIndex].Value = cell.Value;
                            colIndex++;
                        }
                        rowIndex++;
                    }

                    // Tự động điều chỉnh độ rộng cột
                    worksheet.Cells.AutoFitColumns();

                    // Lưu file
                    FileInfo file = new FileInfo(filePath);
                    package.SaveAs(file);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xuất Excel: " + ex.Message);
            }
        }
    }
}
