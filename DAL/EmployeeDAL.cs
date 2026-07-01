using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.DAL
{
    public class EmployeeDAL
    {
        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public static List<EmployeeDTO> GetAllEmployees()
        {
            List<EmployeeDTO> employees = new List<EmployeeDTO>();
            try
            {
                DataTable dt = DatabaseConnection.ExecuteStoredProcedure("sp_GetAllEmployees");
                foreach (DataRow row in dt.Rows)
                {
                    EmployeeDTO employee = new EmployeeDTO
                    {
                        MaNV = Convert.ToInt32(row["MaNV"]),
                        HoTen = row["HoTen"].ToString(),
                        NgaySinh = Convert.ToDateTime(row["NgaySinh"]),
                        GioiTinh = row["GioiTinh"].ToString(),
                        DienThoai = row["DienThoai"].ToString(),
                        Email = row["Email"].ToString(),
                        DiaChi = row["DiaChi"].ToString(),
                        ChucVu = row["ChucVu"].ToString(),
                        NgayVaoLam = Convert.ToDateTime(row["NgayVaoLam"]),
                        TrangThai = Convert.ToBoolean(row["TrangThai"])
                    };
                    employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nhân viên: " + ex.Message);
            }
            return employees;
        }

        /// <summary>
        /// Thêm nhân viên mới
        /// </summary>
        public static void InsertEmployee(EmployeeDTO employee)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@HoTen", employee.HoTen),
                    new SqlParameter("@NgaySinh", employee.NgaySinh),
                    new SqlParameter("@GioiTinh", employee.GioiTinh),
                    new SqlParameter("@DienThoai", employee.DienThoai),
                    new SqlParameter("@Email", employee.Email),
                    new SqlParameter("@DiaChi", employee.DiaChi),
                    new SqlParameter("@ChucVu", employee.ChucVu)
                };
                DatabaseConnection.ExecuteStoredProcedureNonQuery("sp_InsertEmployee", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật nhân viên
        /// </summary>
        public static void UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@MaNV", employee.MaNV),
                    new SqlParameter("@HoTen", employee.HoTen),
                    new SqlParameter("@NgaySinh", employee.NgaySinh),
                    new SqlParameter("@GioiTinh", employee.GioiTinh),
                    new SqlParameter("@DienThoai", employee.DienThoai),
                    new SqlParameter("@Email", employee.Email),
                    new SqlParameter("@DiaChi", employee.DiaChi),
                    new SqlParameter("@ChucVu", employee.ChucVu)
                };
                DatabaseConnection.ExecuteStoredProcedureNonQuery("sp_UpdateEmployee", parameters);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật nhân viên: " + ex.Message);
            }
        }
    }
}
