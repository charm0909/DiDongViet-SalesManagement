using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class ProductDAL
    {
        /// <summary>
        /// Lấy danh sách tất cả sản phẩm
        /// </summary>
        public static List<ProductDTO> GetAllProducts()
        {
            List<ProductDTO> products = new List<ProductDTO>();
            try
            {
                DataTable dt = DatabaseConnection.ExecuteStoredProcedure("sp_GetAllProducts");
                foreach (DataRow row in dt.Rows)
                {
                    ProductDTO product = new ProductDTO
                    {
                        MaSP = Convert.ToInt32(row["MaSP"]),
                        TenSP = row["TenSP"].ToString(),
                        TenHang = row["TenHang"].ToString(),
                        MaHang = Convert.ToInt32(row["MaHang"]),
                        TenLoai = row["TenLoai"].ToString(),
                        MaLoai = Convert.ToInt32(row["MaLoai"]),
                        GiaNhap = Convert.ToDecimal(row["GiaNhap"]),
                        GiaBan = Convert.ToDecimal(row["GiaBan"]),
                        SoLuongTon = Convert.ToInt32(row["SoLuongTon"]),
                        MauSac = row["MauSac"].ToString(),
                        BaoHanh = row["BaoHanh"] != DBNull.Value ? Convert.ToInt32(row["BaoHanh"]) : (int?)null,
                        HinhAnh = row["HinhAnh"].ToString(),
                        TrangThai = Convert.ToBoolean(row["TrangThai"])
                    };
                    products.Add(product);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách sản phẩm: " + ex.Message);
            }
            return products;
        }

        /// <summary>
        /// Thêm sản phẩm mới
        /// </summary>
        public static void InsertProduct(ProductDTO product)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenSP", product.TenSP),
                    new SqlParameter("@MaHang", product.MaHang),
                    new SqlParameter("@MaLoai", product.MaLoai),
                    new SqlParameter("@GiaNhap", product.GiaNhap),
                    new SqlParameter("@GiaBan", product.GiaBan),
                    new SqlParameter("@MauSac", product.MauSac),
                    new SqlParameter("@BaoHanh", product.BaoHanh ?? (object)DBNull.Value)
                };
                DatabaseConnection.ExecuteStoredProcedureNonQuery("sp_InsertProduct", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        public static void UpdateProduct(ProductDTO product)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSP", product.MaSP),
                    new SqlParameter("@TenSP", product.TenSP),
                    new SqlParameter("@MaHang", product.MaHang),
                    new SqlParameter("@MaLoai", product.MaLoai),
                    new SqlParameter("@GiaNhap", product.GiaNhap),
                    new SqlParameter("@GiaBan", product.GiaBan),
                    new SqlParameter("@MauSac", product.MauSac),
                    new SqlParameter("@BaoHanh", product.BaoHanh ?? (object)DBNull.Value)
                };
                DatabaseConnection.ExecuteStoredProcedureNonQuery("sp_UpdateProduct", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật sản phẩm: " + ex.Message);
            }
        }

        /// <summary>
        /// Xóa sản phẩm (cập nhật trạng thái)
        /// </summary>
        public static void DeleteProduct(int maSP)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaSP", maSP)
                };
                DatabaseConnection.ExecuteStoredProcedureNonQuery("sp_DeleteProduct", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa sản phẩm: " + ex.Message);
            }
        }
    }
}
