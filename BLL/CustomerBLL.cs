using System;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.BLL
{
    public class CustomerBLL
    {
        private DAL.CustomerDAL customerDAL = new DAL.CustomerDAL();

        // Lấy danh sách tất cả khách hàng
        public List<CustomerDTO> GetAllCustomers()
        {
            return customerDAL.GetAllCustomers();
        }

        // Lấy khách hàng theo ID
        public CustomerDTO GetCustomerByID(int customerID)
        {
            return customerDAL.GetCustomerByID(customerID);
        }

        // Thêm khách hàng mới
        public bool AddCustomer(CustomerDTO customer)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(customer.HoTen))
                throw new Exception("Tên khách hàng không được rỗng");

            if (!string.IsNullOrEmpty(customer.SoDienThoai) && !IsValidPhone(customer.SoDienThoai))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(customer.Email) && !IsValidEmail(customer.Email))
                throw new Exception("Email không hợp lệ");

            return customerDAL.AddCustomer(customer);
        }

        // Cập nhật khách hàng
        public bool UpdateCustomer(CustomerDTO customer)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(customer.HoTen))
                throw new Exception("Tên khách hàng không được rỗng");

            if (!string.IsNullOrEmpty(customer.SoDienThoai) && !IsValidPhone(customer.SoDienThoai))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(customer.Email) && !IsValidEmail(customer.Email))
                throw new Exception("Email không hợp lệ");

            return customerDAL.UpdateCustomer(customer);
        }

        // Xóa khách hàng
        public bool DeleteCustomer(int customerID)
        {
            return customerDAL.DeleteCustomer(customerID);
        }

        // Tìm kiếm khách hàng
        public List<CustomerDTO> SearchCustomers(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return GetAllCustomers();

            return customerDAL.SearchCustomers(keyword);
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
