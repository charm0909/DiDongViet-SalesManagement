using System;
using System.Collections.Generic;

namespace DTO
{
    public class InvoiceDTO
    {
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Discount { get; set; }
        public List<InvoiceDetailDTO> Details { get; set; } = new List<InvoiceDetailDTO>();
    }

    public class InvoiceDetailDTO
    {
        public int InvoiceDetailID { get; set; }
        public int InvoiceID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal Total { get; set; }
    }
}
