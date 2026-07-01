using System;
using System.Collections.Generic;

namespace DiDongViet_SalesManagement.DTO
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public string InvoiceCode { get; set; }
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public decimal FinalAmount { get; set; }
        public string Status { get; set; }
        public List<InvoiceDetailDTO> Details { get; set; }
    }

    public class InvoiceDetailDTO
    {
        public int DetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
