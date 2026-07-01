using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class CustomerDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        // Lấy danh sách tất cả khách hàng
        public List<CustomerDTO> GetAllCustomers()
        {
            List<CustomerDTO> customers = new List<CustomerDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM KhachHang ORDER BY MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        customers.Add(new CustomerDTO
                        {
                            MaKH = (int)reader["MaKH"],
                            HoTen = reader["HoTen"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TongChiTieu = (decimal)reader["TongChiTieu"],
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách khách hàng: " + ex.Message);
            }
            return customers;
        }

        // Lấy khách hàng theo ID
        public CustomerDTO GetCustomerByID(int customerID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM KhachHang WHERE MaKH = @MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", customerID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new CustomerDTO
                        {
                            MaKH = (int)reader["MaKH"],
                            HoTen = reader["HoTen"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TongChiTieu = (decimal)reader["TongChiTieu"],
                            TrangThai = reader["TrangThai"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy khách hàng: " + ex.Message);
            }
            return null;
        }

        // Thêm khách hàng mới
        public bool AddCustomer(CustomerDTO customer)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"INSERT INTO KhachHang (HoTen, SoDienThoai, Email, DiaChi, TongChiTieu, TrangThai, NgayTao)
                                    VALUES (@HoTen, @SoDienThoai, @Email, @DiaChi, 0, @TrangThai, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", customer.HoTen);
                    cmd.Parameters.AddWithValue("@SoDienThoai", customer.SoDienThoai ?? "");
                    cmd.Parameters.AddWithValue("@Email", customer.Email ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", customer.DiaChi ?? "");
                    cmd.Parameters.AddWithValue("@TrangThai", customer.TrangThai ?? "Hoạt động");

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm khách hàng: " + ex.Message);
                return false;
            }
        }

        // Cập nhật khách hàng
        public bool UpdateCustomer(CustomerDTO customer)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"UPDATE KhachHang SET HoTen=@HoTen, SoDienThoai=@SoDienThoai, 
                                    Email=@Email, DiaChi=@DiaChi, TrangThai=@TrangThai WHERE MaKH=@MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", customer.MaKH);
                    cmd.Parameters.AddWithValue("@HoTen", customer.HoTen);
                    cmd.Parameters.AddWithValue("@SoDienThoai", customer.SoDienThoai ?? "");
                    cmd.Parameters.AddWithValue("@Email", customer.Email ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", customer.DiaChi ?? "");
                    cmd.Parameters.AddWithValue("@TrangThai", customer.TrangThai);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật khách hàng: " + ex.Message);
                return false;
            }
        }

        // Xóa khách hàng
        public bool DeleteCustomer(int customerID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "DELETE FROM KhachHang WHERE MaKH = @MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaKH", customerID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa khách hàng: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm khách hàng
        public List<CustomerDTO> SearchCustomers(string keyword)
        {
            List<CustomerDTO> customers = new List<CustomerDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"SELECT * FROM KhachHang WHERE HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword ORDER BY MaKH";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        customers.Add(new CustomerDTO
                        {
                            MaKH = (int)reader["MaKH"],
                            HoTen = reader["HoTen"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            TongChiTieu = (decimal)reader["TongChiTieu"],
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm khách hàng: " + ex.Message);
            }
            return customers;
        }
    }
}
