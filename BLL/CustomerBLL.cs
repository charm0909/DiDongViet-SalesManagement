using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDongViet_SalesManagement.DTO;
using DiDongViet_SalesManagement.DAL;

namespace DiDongViet_SalesManagement.BLL
{
    public class CustomerBLL
    {
        /// <summary>
        /// Lấy danh sách tất cả khách hàng
        /// </summary>
        public static List<CustomerDTO> GetAllCustomers()
        {
            try
            {
                return CustomerDAL.GetAllCustomers();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách khách hàng: " + ex.Message);
            }
        }

        /// <summary>
        /// Thêm khách hàng mới với validate
        /// </summary>
        public static bool InsertCustomer(CustomerDTO customer)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(customer.HoTen))
                    throw new Exception("Tên khách hàng không được để trống!");

                if (string.IsNullOrWhiteSpace(customer.DienThoai))
                    throw new Exception("Điện thoại không được để trống!");

                if (!IsValidPhoneNumber(customer.DienThoai))
                    throw new Exception("Số điện thoại không hợp lệ!");

                if (!string.IsNullOrWhiteSpace(customer.Email) && !IsValidEmail(customer.Email))
                    throw new Exception("Email không hợp lệ!");

                CustomerDAL.InsertCustomer(customer);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm khách hàng: " + ex.Message);
            }
        }

        /// <summary>
        /// Tìm kiếm khách hàng theo tên hoặc số điện thoại
        /// </summary>
        public static List<CustomerDTO> SearchCustomer(string keyword)
        {
            try
            {
                var allCustomers = CustomerDAL.GetAllCustomers();
                return allCustomers.Where(c => c.HoTen.ToLower().Contains(keyword.ToLower()) ||
                                              c.DienThoai.Contains(keyword)).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm khách hàng: " + ex.Message);
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
