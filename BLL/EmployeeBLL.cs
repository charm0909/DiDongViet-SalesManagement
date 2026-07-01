using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDongViet_SalesManagement.DTO;
using DiDongViet_SalesManagement.DAL;

namespace DiDongViet_SalesManagement.BLL
{
    public class EmployeeBLL
    {
        /// <summary>
        /// Lấy danh sách tất cả nhân viên
        /// </summary>
        public static List<EmployeeDTO> GetAllEmployees()
        {
            try
            {
                return EmployeeDAL.GetAllEmployees();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nhân viên: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm nhân viên mới với validate
        /// </summary>
        public static bool InsertEmployee(EmployeeDTO employee)
        {
            try
            {
                // Validate dữ liệu
                if (string.IsNullOrWhiteSpace(employee.HoTen))
                    throw new Exception("Họ tên nhân viên không được để trống!");

                if (employee.NgaySinh > DateTime.Now)
                    throw new Exception("Ngày sinh không hợp lệ!");

                if (string.IsNullOrWhiteSpace(employee.DienThoai))
                    throw new Exception("Điện thoại không được để trống!");

                if (!IsValidPhoneNumber(employee.DienThoai))
                    throw new Exception("Số điện thoại không hợp lệ!");

                if (!string.IsNullOrWhiteSpace(employee.Email) && !IsValidEmail(employee.Email))
                    throw new Exception("Email không hợp lệ!");

                EmployeeDAL.InsertEmployee(employee);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nhân viên: " + ex.Message);
            }
        }

        /// <summary>
        /// Cập nhật nhân viên với validate
        /// </summary>
        public static bool UpdateEmployee(EmployeeDTO employee)
        {
            try
            {
                if (employee.MaNV <= 0)
                    throw new Exception("Mã nhân viên không hợp lệ!");

                if (string.IsNullOrWhiteSpace(employee.HoTen))
                    throw new Exception("Họ tên nhân viên không được để trống!");

                if (employee.NgaySinh > DateTime.Now)
                    throw new Exception("Ngày sinh không hợp lệ!");

                if (!IsValidPhoneNumber(employee.DienThoai))
                    throw new Exception("Số điện thoại không hợp lệ!");

                if (!string.IsNullOrWhiteSpace(employee.Email) && !IsValidEmail(employee.Email))
                    throw new Exception("Email không hợp lệ!");

                EmployeeDAL.UpdateEmployee(employee);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật nhân viên: " + ex.Message);
            }
        }

        /// <summary>
        /// Kiểm tra số điện thoại hợp lệ
        /// </summary>
        private static bool IsValidPhoneNumber(string phone)
        {
            return phone.Length >= 10 && phone.All(char.IsDigit);
        }

        /// <summary>
        /// Kiểm tra email hợp lệ
        /// </summary>
        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
