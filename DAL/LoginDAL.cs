using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class LoginDAL
    {
        /// <summary>
        /// Kiểm tra thông tin đăng nhập
        /// </summary>
        public static LoginDTO CheckLogin(string username, string password)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@TenDangNhap", username),
                    new SqlParameter("@MatKhau", password)
                };

                DataTable dt = DatabaseConnection.ExecuteStoredProcedure("sp_CheckLogin", parameters);
                
                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    return new LoginDTO
                    {
                        MaTK = Convert.ToInt32(row["MaTK"]),
                        TenDangNhap = row["TenDangNhap"].ToString(),
                        LoaiTK = row["LoaiTK"].ToString(),
                        MaNV = Convert.ToInt32(row["MaNV"]),
                        HoTen = row["HoTen"].ToString(),
                        DienThoai = row["DienThoai"].ToString(),
                        ChucVu = row["ChucVu"].ToString()
                    };
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra đăng nhập: " + ex.Message);
            }
        }
    }
}
