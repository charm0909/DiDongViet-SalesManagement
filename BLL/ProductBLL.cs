using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDongViet_SalesManagement.DTO;
using DiDongViet_SalesManagement.DAL;

namespace DiDongViet_SalesManagement.BLL
{
    public class ProductBLL
    {
        /// <summary>
        /// Lấy danh sách tất cả sản phẩm
        /// </summary>
        public static List<ProductDTO> GetAllProducts()
        {
            try
            {
                return ProductDAL.GetAllProducts();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm sản phẩm mới với validate
        /// </summary>
        public static bool InsertProduct(ProductDTO product)
        {
            try
            {
                // Validate dữ liệu
                if (string.IsNullOrWhiteSpace(product.TenSP))
                    throw new Exception("Tên sản phẩm không được để trống!");

                if (product.GiaNhap <= 0)
                    throw new Exception("Giá nhập phải lớn hơn 0!");

                if (product.GiaBan <= product.GiaNhap)
                    throw new Exception("Giá bán phải lớn hơn giá nhập!");

                if (product.MaHang <= 0 || product.MaLoai <= 0)
                    throw new Exception("Hãng và loại sản phẩm không được để trống!");

                ProductDAL.InsertProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật sản phẩm với validate
        /// </summary>
        public static bool UpdateProduct(ProductDTO product)
        {
            try
            {
                // Validate dữ liệu
                if (product.MaSP <= 0)
                    throw new Exception("Mã sản phẩm không hợp lệ!");

                if (string.IsNullOrWhiteSpace(product.TenSP))
                    throw new Exception("Tên sản phẩm không được để trống!");

                if (product.GiaNhap <= 0)
                    throw new Exception("Giá nhập phải lớn hơn 0!");

                if (product.GiaBan <= product.GiaNhap)
                    throw new Exception("Giá bán phải lớn hơn giá nhập!");

                ProductDAL.UpdateProduct(product);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        public static bool DeleteProduct(int maSP)
        {
            try
            {
                if (maSP <= 0)
                    throw new Exception("Mã sản phẩm không hợp lệ!");

                ProductDAL.DeleteProduct(maSP);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm kiếm sản phẩm theo tên
        /// </summary>
        public static List<ProductDTO> SearchProductByName(string tenSP)
        {
            try
            {
                var allProducts = ProductDAL.GetAllProducts();
                return allProducts.Where(p => p.TenSP.ToLower().Contains(tenSP.ToLower())).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm sản phẩm: " + ex.Message);
            }
        }
    }
}
