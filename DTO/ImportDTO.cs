using System;
using System.Collections.Generic;

namespace DTO
{
    public class ImportDTO
    {
        public int ImportID { get; set; }
        public string SupplierName { get; set; }
        public DateTime? ImportDate { get; set; }
        public decimal TotalAmount { get; set; }
        public List<ImportDetailDTO> Details { get; set; } = new List<ImportDetailDTO>();
    }

    public class ImportDetailDTO
    {
        public int ImportDetailID { get; set; }
        public int ImportID { get; set; }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal Total { get; set; }
    }
}
