using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class SupplierDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        // Lấy danh sách tất cả nhà cung cấp
        public List<SupplierDTO> GetAllSuppliers()
        {
            List<SupplierDTO> suppliers = new List<SupplierDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM NhaCungCap ORDER BY MaNCC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        suppliers.Add(new SupplierDTO
                        {
                            SupplierID = (int)reader["MaNCC"],
                            SupplierCode = reader["MaNCC"].ToString(),
                            SupplierName = reader["TenNCC"].ToString(),
                            Phone = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["DiaChi"].ToString(),
                            Status = reader["TrangThai"].ToString(),
                            CreatedDate = (DateTime)reader["NgayTao"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách nhà cung cấp: " + ex.Message);
            }
            return suppliers;
        }

        // Lấy nhà cung cấp theo ID
        public SupplierDTO GetSupplierByID(int supplierID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", supplierID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new SupplierDTO
                        {
                            SupplierID = (int)reader["MaNCC"],
                            SupplierCode = reader["MaNCC"].ToString(),
                            SupplierName = reader["TenNCC"].ToString(),
                            Phone = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["DiaChi"].ToString(),
                            Status = reader["TrangThai"].ToString(),
                            CreatedDate = (DateTime)reader["NgayTao"]
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy nhà cung cấp: " + ex.Message);
            }
            return null;
        }

        // Thêm nhà cung cấp mới
        public bool AddSupplier(SupplierDTO supplier)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi, TrangThai, NgayTao)
                                    VALUES (@TenNCC, @SoDienThoai, @Email, @DiaChi, @TrangThai, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@TenNCC", supplier.SupplierName);
                    cmd.Parameters.AddWithValue("@SoDienThoai", supplier.Phone);
                    cmd.Parameters.AddWithValue("@Email", supplier.Email);
                    cmd.Parameters.AddWithValue("@DiaChi", supplier.Address);
                    cmd.Parameters.AddWithValue("@TrangThai", supplier.Status ?? "Hoạt động");

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm nhà cung cấp: " + ex.Message);
                return false;
            }
        }

        // Cập nhật nhà cung cấp
        public bool UpdateSupplier(SupplierDTO supplier)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"UPDATE NhaCungCap SET TenNCC=@TenNCC, SoDienThoai=@SoDienThoai, 
                                    Email=@Email, DiaChi=@DiaChi, TrangThai=@TrangThai WHERE MaNCC=@MaNCC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", supplier.SupplierID);
                    cmd.Parameters.AddWithValue("@TenNCC", supplier.SupplierName);
                    cmd.Parameters.AddWithValue("@SoDienThoai", supplier.Phone);
                    cmd.Parameters.AddWithValue("@Email", supplier.Email);
                    cmd.Parameters.AddWithValue("@DiaChi", supplier.Address);
                    cmd.Parameters.AddWithValue("@TrangThai", supplier.Status);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật nhà cung cấp: " + ex.Message);
                return false;
            }
        }

        // Xóa nhà cung cấp
        public bool DeleteSupplier(int supplierID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "DELETE FROM NhaCungCap WHERE MaNCC = @MaNCC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNCC", supplierID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa nhà cung cấp: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm nhà cung cấp
        public List<SupplierDTO> SearchSuppliers(string keyword)
        {
            List<SupplierDTO> suppliers = new List<SupplierDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"SELECT * FROM NhaCungCap WHERE TenNCC LIKE @Keyword OR SoDienThoai LIKE @Keyword ORDER BY MaNCC";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        suppliers.Add(new SupplierDTO
                        {
                            SupplierID = (int)reader["MaNCC"],
                            SupplierCode = reader["MaNCC"].ToString(),
                            SupplierName = reader["TenNCC"].ToString(),
                            Phone = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            Address = reader["DiaChi"].ToString(),
                            Status = reader["TrangThai"].ToString(),
                            CreatedDate = (DateTime)reader["NgayTao"]
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm nhà cung cấp: " + ex.Message);
            }
            return suppliers;
        }
    }
}
