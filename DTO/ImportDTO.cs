using System;
using System.Collections.Generic;

namespace DiDongViet_SalesManagement.DTO
{
    public class ImportDTO
    {
        public int ImportID { get; set; }
        public string ImportCode { get; set; }
        public int SupplierID { get; set; }
        public string SupplierName { get; set; }
        public DateTime ImportDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public List<ImportDetailDTO> Details { get; set; }
    }

    public class ImportDetailDTO
    {
        public int DetailID { get; set; }
        public int ImportID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Amount { get; set; }
    }
}
