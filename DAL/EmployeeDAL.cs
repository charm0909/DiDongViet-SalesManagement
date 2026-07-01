using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class EmployeeDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        // Lấy danh sách tất cả nhân viên
        public List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM NhanVien ORDER BY MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employees.Add(new EmployeeDTO
                        {
                            MaNV = (int)reader["MaNV"],
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? (DateTime)reader["NgaySinh"] : DateTime.Now,
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            NgayVaoLam = reader["NgayVaoLam"] != DBNull.Value ? (DateTime)reader["NgayVaoLam"] : DateTime.Now,
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy danh sách nhân viên: " + ex.Message);
            }
            return employees;
        }

        // Lấy nhân viên theo ID
        public EmployeeDTO GetEmployeeByID(int employeeID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "SELECT * FROM NhanVien WHERE MaNV = @MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", employeeID);
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        return new EmployeeDTO
                        {
                            MaNV = (int)reader["MaNV"],
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? (DateTime)reader["NgaySinh"] : DateTime.Now,
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            NgayVaoLam = reader["NgayVaoLam"] != DBNull.Value ? (DateTime)reader["NgayVaoLam"] : DateTime.Now,
                            TrangThai = reader["TrangThai"].ToString()
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi lấy nhân viên: " + ex.Message);
            }
            return null;
        }

        // Thêm nhân viên mới
        public bool AddEmployee(EmployeeDTO employee)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, ChucVu, NgayVaoLam, TrangThai, NgayTao)
                                    VALUES (@HoTen, @NgaySinh, @GioiTinh, @SoDienThoai, @Email, @DiaChi, @ChucVu, @NgayVaoLam, @TrangThai, GETDATE())";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@HoTen", employee.HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", employee.NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh ?? "Nam");
                    cmd.Parameters.AddWithValue("@SoDienThoai", employee.SoDienThoai ?? "");
                    cmd.Parameters.AddWithValue("@Email", employee.Email ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", employee.DiaChi ?? "");
                    cmd.Parameters.AddWithValue("@ChucVu", employee.ChucVu ?? "Nhân viên bán hàng");
                    cmd.Parameters.AddWithValue("@NgayVaoLam", employee.NgayVaoLam);
                    cmd.Parameters.AddWithValue("@TrangThai", employee.TrangThai ?? "Hoạt động");

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi thêm nhân viên: " + ex.Message);
                return false;
            }
        }

        // Cập nhật nhân viên
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"UPDATE NhanVien SET HoTen=@HoTen, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, 
                                    SoDienThoai=@SoDienThoai, Email=@Email, DiaChi=@DiaChi, ChucVu=@ChucVu, 
                                    NgayVaoLam=@NgayVaoLam, TrangThai=@TrangThai WHERE MaNV=@MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", employee.MaNV);
                    cmd.Parameters.AddWithValue("@HoTen", employee.HoTen);
                    cmd.Parameters.AddWithValue("@NgaySinh", employee.NgaySinh);
                    cmd.Parameters.AddWithValue("@GioiTinh", employee.GioiTinh);
                    cmd.Parameters.AddWithValue("@SoDienThoai", employee.SoDienThoai ?? "");
                    cmd.Parameters.AddWithValue("@Email", employee.Email ?? "");
                    cmd.Parameters.AddWithValue("@DiaChi", employee.DiaChi ?? "");
                    cmd.Parameters.AddWithValue("@ChucVu", employee.ChucVu);
                    cmd.Parameters.AddWithValue("@NgayVaoLam", employee.NgayVaoLam);
                    cmd.Parameters.AddWithValue("@TrangThai", employee.TrangThai);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi cập nhật nhân viên: " + ex.Message);
                return false;
            }
        }

        // Xóa nhân viên
        public bool DeleteEmployee(int employeeID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = "DELETE FROM NhanVien WHERE MaNV = @MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@MaNV", employeeID);

                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    return result > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi xóa nhân viên: " + ex.Message);
                return false;
            }
        }

        // Tìm kiếm nhân viên
        public List<EmployeeDTO> SearchEmployees(string keyword)
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    string query = @"SELECT * FROM NhanVien WHERE HoTen LIKE @Keyword OR SoDienThoai LIKE @Keyword ORDER BY MaNV";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        employees.Add(new EmployeeDTO
                        {
                            MaNV = (int)reader["MaNV"],
                            HoTen = reader["HoTen"].ToString(),
                            NgaySinh = reader["NgaySinh"] != DBNull.Value ? (DateTime)reader["NgaySinh"] : DateTime.Now,
                            GioiTinh = reader["GioiTinh"].ToString(),
                            SoDienThoai = reader["SoDienThoai"].ToString(),
                            Email = reader["Email"].ToString(),
                            DiaChi = reader["DiaChi"].ToString(),
                            ChucVu = reader["ChucVu"].ToString(),
                            NgayVaoLam = reader["NgayVaoLam"] != DBNull.Value ? (DateTime)reader["NgayVaoLam"] : DateTime.Now,
                            TrangThai = reader["TrangThai"].ToString()
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm nhân viên: " + ex.Message);
            }
            return employees;
        }
    }
}
