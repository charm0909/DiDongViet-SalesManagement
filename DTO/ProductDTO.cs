using System;
using System.Collections.Generic;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int BrandID { get; set; }
        public int CategoryID { get; set; }
        public decimal ImportPrice { get; set; }
        public decimal SalePrice { get; set; }
        public int QuantityInStock { get; set; }
        public string Color { get; set; }
        public string Warranty { get; set; }
        public string ImagePath { get; set; } // Đường dẫn ảnh sản phẩm
    }
}
