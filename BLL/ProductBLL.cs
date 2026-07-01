using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ProductBLL
    {
        private ProductDAL productDAL = new ProductDAL();

        public List<ProductDTO> GetAllProducts()
        {
            try
            {
                return productDAL.GetAllProducts();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách sản phẩm: " + ex.Message);
            }
        }

        public ProductDTO GetProductByID(int productID)
        {
            try
            {
                if (productID <= 0)
                    throw new Exception("ID sản phẩm không hợp lệ!");

                return productDAL.GetProductByID(productID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy sản phẩm: " + ex.Message);
            }
        }

        public bool AddProduct(ProductDTO product)
        {
            try
            {
                if (string.IsNullOrEmpty(product.ProductName))
                    throw new Exception("Tên sản phẩm không được để trống!");

                if (product.SalePrice <= 0)
                    throw new Exception("Giá bán phải lớn hơn 0!");

                if (product.ImportPrice <= 0)
                    throw new Exception("Giá nhập phải lớn hơn 0!");

                return productDAL.AddProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        public bool UpdateProduct(ProductDTO product)
        {
            try
            {
                if (product.ProductID <= 0)
                    throw new Exception("ID sản phẩm không hợp lệ!");

                if (string.IsNullOrEmpty(product.ProductName))
                    throw new Exception("Tên sản phẩm không được để trống!");

                if (product.SalePrice <= 0)
                    throw new Exception("Giá bán phải lớn hơn 0!");

                return productDAL.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật sản phẩm: " + ex.Message);
            }
        }

        public bool DeleteProduct(int productID)
        {
            try
            {
                if (productID <= 0)
                    throw new Exception("ID sản phẩm không hợp lệ!");

                return productDAL.DeleteProduct(productID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa sản phẩm: " + ex.Message);
            }
        }

        public List<ProductDTO> SearchProducts(string keyword)
        {
            try
            {
                if (string.IsNullOrEmpty(keyword))
                    return GetAllProducts();

                return productDAL.SearchProducts(keyword);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm sản phẩm: " + ex.Message);
            }
        }
    }
}
