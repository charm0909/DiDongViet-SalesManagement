using System;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.BLL
{
    public class SupplierBLL
    {
        private DAL.SupplierDAL supplierDAL = new DAL.SupplierDAL();

        // Lấy danh sách tất cả nhà cung cấp
        public List<SupplierDTO> GetAllSuppliers()
        {
            return supplierDAL.GetAllSuppliers();
        }

        // Lấy nhà cung cấp theo ID
        public SupplierDTO GetSupplierByID(int supplierID)
        {
            return supplierDAL.GetSupplierByID(supplierID);
        }

        // Thêm nhà cung cấp mới
        public bool AddSupplier(SupplierDTO supplier)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new Exception("Tên nhà cung cấp không được rỗng");

            if (string.IsNullOrEmpty(supplier.Phone))
                throw new Exception("Số điện thoại không được rỗng");

            if (!IsValidPhone(supplier.Phone))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(supplier.Email) && !IsValidEmail(supplier.Email))
                throw new Exception("Email không hợp lệ");

            return supplierDAL.AddSupplier(supplier);
        }

        // Cập nhật nhà cung cấp
        public bool UpdateSupplier(SupplierDTO supplier)
        {
            // Validate dữ liệu
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new Exception("Tên nhà cung cấp không được rỗng");

            if (string.IsNullOrEmpty(supplier.Phone))
                throw new Exception("Số điện thoại không được rỗng");

            if (!IsValidPhone(supplier.Phone))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(supplier.Email) && !IsValidEmail(supplier.Email))
                throw new Exception("Email không hợp lệ");

            return supplierDAL.UpdateSupplier(supplier);
        }

        // Xóa nhà cung cấp
        public bool DeleteSupplier(int supplierID)
        {
            return supplierDAL.DeleteSupplier(supplierID);
        }

        // Tìm kiếm nhà cung cấp
        public List<SupplierDTO> SearchSuppliers(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return GetAllSuppliers();

            return supplierDAL.SearchSuppliers(keyword);
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
