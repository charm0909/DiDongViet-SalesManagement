using System;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.BLL
{
    public class EmployeeBLL
    {
        private DAL.EmployeeDAL employeeDAL = new DAL.EmployeeDAL();

        // Lấy danh sách tất cả nhân viên
        public List<EmployeeDTO> GetAllEmployees()
        {
            return employeeDAL.GetAllEmployees();
        }

        // Lấy nhân viên theo ID
        public EmployeeDTO GetEmployeeByID(int employeeID)
        {
            return employeeDAL.GetEmployeeByID(employeeID);
        }

        // Thêm nhân viên mới
        public bool AddEmployee(EmployeeDTO employee)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(employee.HoTen))
                throw new Exception("Tên nhân viên không được rỗng");

            if (employee.NgaySinh > DateTime.Now)
                throw new Exception("Ngày sinh không hợp lệ");

            if (!string.IsNullOrEmpty(employee.SoDienThoai) && !IsValidPhone(employee.SoDienThoai))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(employee.Email) && !IsValidEmail(employee.Email))
                throw new Exception("Email không hợp lệ");

            return employeeDAL.AddEmployee(employee);
        }

        // Cập nhật nhân viên
        public bool UpdateEmployee(EmployeeDTO employee)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(employee.HoTen))
                throw new Exception("Tên nhân viên không được rỗng");

            if (employee.NgaySinh > DateTime.Now)
                throw new Exception("Ngày sinh không hợp lệ");

            if (!string.IsNullOrEmpty(employee.SoDienThoai) && !IsValidPhone(employee.SoDienThoai))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(employee.Email) && !IsValidEmail(employee.Email))
                throw new Exception("Email không hợp lệ");

            return employeeDAL.UpdateEmployee(employee);
        }

        // Xóa nhân viên
        public bool DeleteEmployee(int employeeID)
        {
            return employeeDAL.DeleteEmployee(employeeID);
        }

        // Tìm kiếm nhân viên
        public List<EmployeeDTO> SearchEmployees(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return GetAllEmployees();

            return employeeDAL.SearchEmployees(keyword);
        }

        // Hàm validate email
        private bool IsValidEmail(string email)
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

        // Hàm validate số điện thoại
        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[0-9]{10,11}$");
        }
    }
}
