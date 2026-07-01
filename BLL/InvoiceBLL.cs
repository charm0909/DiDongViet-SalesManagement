using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class InvoiceBLL
    {
        private InvoiceDAL invoiceDAL = new InvoiceDAL();

        // Lấy tất cả hóa đơn
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

        // Lấy hóa đơn theo ID
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

        // Tạo hóa đơn mới
        public bool CreateInvoice(InvoiceDTO invoice)
        {
            try
            {
                // Validate dữ liệu
                if (invoice == null)
                    throw new Exception("Hóa đơn không được để trống!");

                if (invoice.CustomerID <= 0)
                    throw new Exception("ID khách hàng không hợp lệ!");

                if (invoice.Details == null || invoice.Details.Count == 0)
                    throw new Exception("Hóa đơn phải có ít nhất 1 chi tiết!");

                if (invoice.InvoiceDate == null)
                    invoice.InvoiceDate = DateTime.Now;

                // Tính tổng tiền
                decimal total = 0;
                foreach (var detail in invoice.Details)
                {
                    if (detail.Quantity <= 0)
                        throw new Exception("Số lượng sản phẩm phải lớn hơn 0!");

                    if (detail.Price < 0)
                        throw new Exception("Giá bán không được âm!");

                    total += detail.Total;
                }

                invoice.TotalAmount = total - (total * invoice.Discount / 100);

                return invoiceDAL.CreateInvoice(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo hóa đơn: " + ex.Message);
            }
        }

        // Cập nhật hóa đơn
        public bool UpdateInvoice(InvoiceDTO invoice)
        {
            try
            {
                if (invoice == null || invoice.InvoiceID <= 0)
                    throw new Exception("ID hóa đơn không hợp lệ!");

                return invoiceDAL.UpdateInvoice(invoice);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
            }
        }

        // Xóa hóa đơn
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

        // Tìm kiếm hóa đơn theo ngày
        public List<InvoiceDTO> SearchInvoicesByDate(DateTime startDate, DateTime endDate)
        {
            try
            {
                return invoiceDAL.SearchInvoicesByDate(startDate, endDate);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm hóa đơn: " + ex.Message);
            }
        }
    }
}
