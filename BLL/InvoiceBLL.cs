using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class InvoiceBLL
    {
        private InvoiceDAL invoiceDAL = new InvoiceDAL();
        private ProductDAL productDAL = new ProductDAL();

        public List<InvoiceDTO> GetAllInvoices()
        {
            try
            {
                return invoiceDAL.GetAllInvoices();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hóa đơn: " + ex.Message);
            }
        }

        public InvoiceDTO GetInvoiceByID(int invoiceID)
        {
            try
            {
                if (invoiceID <= 0)
                    throw new Exception("ID hóa đơn không hợp lệ!");

                return invoiceDAL.GetInvoiceByID(invoiceID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy hóa đơn: " + ex.Message);
            }
        }

        public bool AddInvoice(InvoiceDTO invoice)
        {
            try
            {
                if (invoice.CustomerID <= 0)
                    throw new Exception("ID khách hàng không hợp lệ!");

                if (invoice.Details == null || invoice.Details.Count == 0)
                    throw new Exception("Hóa đơn phải có ít nhất 1 sản phẩm!");

                if (invoice.TotalAmount <= 0)
                    throw new Exception("Tổng tiền hóa đơn phải lớn hơn 0!");

                // Kiểm tra tồn kho
                foreach (var detail in invoice.Details)
                {
                    ProductDTO product = productDAL.GetProductByID(detail.ProductID);
                    if (product == null)
                        throw new Exception($"Sản phẩm ID {detail.ProductID} không tồn tại!");

                    if (product.QuantityInStock < detail.Quantity)
                        throw new Exception($"Sản phẩm {product.ProductName} không đủ tồn kho! Còn lại: {product.QuantityInStock}");
                }

                return invoiceDAL.AddInvoice(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
            }
        }

        public bool UpdateInvoice(InvoiceDTO invoice)
        {
            try
            {
                if (invoice.InvoiceID <= 0)
                    throw new Exception("ID hóa đơn không hợp lệ!");

                return invoiceDAL.UpdateInvoice(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
            }
        }

        public bool DeleteInvoice(int invoiceID)
        {
            try
            {
                if (invoiceID <= 0)
                    throw new Exception("ID hóa đơn không hợp lệ!");

                return invoiceDAL.DeleteInvoice(invoiceID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa hóa đơn: " + ex.Message);
            }
        }

        public List<InvoiceDTO> GetInvoicesByCustomer(int customerID)
        {
            try
            {
                if (customerID <= 0)
                    throw new Exception("ID khách hàng không hợp lệ!");

                return invoiceDAL.GetInvoicesByCustomer(customerID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy hóa đơn theo khách hàng: " + ex.Message);
            }
        }

        // Tính tổng tiền hóa đơn
        public decimal CalculateTotalAmount(List<InvoiceDetailDTO> details)
        {
            try
            {
                decimal total = 0;
                foreach (var detail in details)
                {
                    total += detail.Total;
                }
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tính toán tổng tiền: " + ex.Message);
            }
        }
    }
}
