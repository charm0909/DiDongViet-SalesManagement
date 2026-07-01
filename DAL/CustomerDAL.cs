using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class CustomerDAL
    {
        /// <summary>
        /// Lấy danh sách tất cả khách hàng
        /// </summary>
        public static List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> customers = new List<CustomerDTO>();
            try
            {
                DataTable dt = DatabaseConnection.ExecuteStoredProcedure("sp_GetAllCustomers");
                foreach (DataRow row in dt.Rows)
                {
                    CustomerDTO customer = new CustomerDTO
                    {
                        MaKH = Convert.ToInt32(row["MaKH"]),
                        HoTen = row["HoTen"].ToString(),
                        DienThoai = row["DienThoai"].ToString(),
                        Email = row["Email"].ToString(),
                        DiaChi = row["DiaChi"].ToString(),
                        TongChiTieu = Convert.ToDecimal(row["TongChiTieu"]),
                        TrangThai = Convert.ToBoolean(row["TrangThai"])
                    };
                    customers.Add(customer);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách khách hàng: " + ex.Message);
            }
            return customers;
        }

        /// <summary>
        /// Thêm khách hàng mới
        /// </summary>
        public static void InsertCustomer(CustomerDTO customer)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@HoTen", customer.HoTen),
                    new SqlParameter("@DienThoai", customer.DienThoai),
                    new SqlParameter("@Email", customer.Email),
                    new SqlParameter("@DiaChi", customer.DiaChi)
                };
                DatabaseConnection.ExecuteStoredProcedureNonQuery("sp_InsertCustomer", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm khách hàng: " + ex.Message);
            }
        }
    }
}
