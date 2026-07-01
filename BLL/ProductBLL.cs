using System;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.BLL
{
    public class ProductBLL
    {
        private DAL.ProductDAL productDAL = new DAL.ProductDAL();

        public List<ProductDTO> GetAllProducts()
        {
            return productDAL.GetAllProducts();
        }

        public ProductDTO GetProductByID(int productID)
        {
            return productDAL.GetProductByID(productID);
        }

        public bool AddProduct(ProductDTO product)
        {
            if (string.IsNullOrEmpty(product.MaSanPham))
                throw new Exception("Mã sản phẩm không được rỗng");

            if (string.IsNullOrEmpty(product.TenSP))
                throw new Exception("Tên sản phẩm không được rỗng");

            if (product.GiaNhap <= 0 || product.GiaBan <= 0)
                throw new Exception("Giá nhập và giá bán phải lớn hơn 0");

            if (product.GiaBan < product.GiaNhap)
                throw new Exception("Giá bán không được nhỏ hơn giá nhập");

            return productDAL.AddProduct(product);
        }

        public bool UpdateProduct(ProductDTO product)
        {
            if (string.IsNullOrEmpty(product.MaSanPham))
                throw new Exception("Mã sản phẩm không được rỗng");

            if (string.IsNullOrEmpty(product.TenSP))
                throw new Exception("Tên sản phẩm không được rỗng");

            if (product.GiaNhap <= 0 || product.GiaBan <= 0)
                throw new Exception("Giá nhập và giá bán phải lớn hơn 0");

            if (product.GiaBan < product.GiaNhap)
                throw new Exception("Giá bán không được nhỏ hơn giá nhập");

            return productDAL.UpdateProduct(product);
        }

        public bool DeleteProduct(int productID)
        {
            return productDAL.DeleteProduct(productID);
        }

        public List<ProductDTO> SearchProducts(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return GetAllProducts();

            return productDAL.SearchProducts(keyword);
        }
    }
}
