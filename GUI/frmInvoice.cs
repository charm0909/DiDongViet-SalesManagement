using System;
using System.Windows.Forms;
using BLL;
using DTO;
using System.Collections.Generic;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmInvoice : Form
    {
        private InvoiceBLL invoiceBLL = new InvoiceBLL();
        private ProductBLL productBLL = new ProductBLL();
        private CustomerBLL customerBLL = new CustomerBLL();
        private List<InvoiceDetailDTO> invoiceDetails = new List<InvoiceDetailDTO>();

        public frmInvoice()
        {
            InitializeComponent();
        }

        private void frmInvoice_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadProducts();
            LoadInvoiceList();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Text = "Quản lý Bán hàng (Hóa đơn)";
            this.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.Font = new System.Drawing.Font("Segoe UI", 10f);
        }

        private void LoadCustomers()
        {
            try
            {
                var customers = customerBLL.GetAllCustomers();
                cbCustomer.DataSource = customers;
                cbCustomer.DisplayMember = "FullName";
                cbCustomer.ValueMember = "CustomerID";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách khách hàng: " + ex.Message);
            }
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

        private void LoadInvoiceList()
        {
            try
            {
                var invoices = invoiceBLL.GetAllInvoices();
                dgvInvoices.DataSource = invoices;
                dgvInvoices.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách hóa đơn: " + ex.Message);
            }
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbProduct.SelectedValue == null || string.IsNullOrEmpty(nudQuantity.Text))
                {
                    MessageBox.Show("Vui lòng chọn sản phẩm và nhập số lượng!");
                    return;
                }

                int productID = (int)cbProduct.SelectedValue;
                int quantity = (int)nudQuantity.Value;
                var product = productBLL.GetProductByID(productID);

                if (product == null)
                {
                    MessageBox.Show("Sản phẩm không tồn tại!");
                    return;
                }

                if (quantity > product.QuantityInStock)
                {
                    MessageBox.Show("Số lượng hàng trong kho không đủ!");
                    return;
                }

                InvoiceDetailDTO detail = new InvoiceDetailDTO
                {
                    ProductID = productID,
                    ProductName = product.ProductName,
                    Quantity = quantity,
                    Price = product.SalePrice,
                    Total = quantity * product.SalePrice
                };

                invoiceDetails.Add(detail);
                RefreshInvoiceDetailView();
                CalculateTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm chi tiết hóa đơn: " + ex.Message);
            }
        }

        private void RefreshInvoiceDetailView()
        {
            dgvInvoiceDetails.DataSource = new List<InvoiceDetailDTO>(invoiceDetails);
            dgvInvoiceDetails.AutoResizeColumns();
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (var detail in invoiceDetails)
            {
                total += detail.Total;
            }
            txtTotalAmount.Text = total.ToString("N0");
        }

        private void btnCreateInvoice_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbCustomer.SelectedValue == null || invoiceDetails.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn khách hàng và thêm ít nhất 1 sản phẩm!");
                    return;
                }

                int customerID = (int)cbCustomer.SelectedValue;
                decimal discount = string.IsNullOrEmpty(txtDiscount.Text) ? 0 : decimal.Parse(txtDiscount.Text);

                InvoiceDTO invoice = new InvoiceDTO
                {
                    CustomerID = customerID,
                    InvoiceDate = DateTime.Now,
                    Details = invoiceDetails,
                    Discount = discount
                };

                bool result = invoiceBLL.CreateInvoice(invoice);
                if (result)
                {
                    MessageBox.Show("Lập hóa đơn thành công!");
                    ClearForm();
                    LoadInvoiceList();
                }
                else
                {
                    MessageBox.Show("Lập hóa đơn thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lập hóa đơn: " + ex.Message);
            }
        }

        private void ClearForm()
        {
            cbCustomer.SelectedIndex = -1;
            cbProduct.SelectedIndex = -1;
            nudQuantity.Value = 0;
            txtDiscount.Clear();
            txtTotalAmount.Clear();
            invoiceDetails.Clear();
            dgvInvoiceDetails.DataSource = null;
        }
    }
}
