using System;
using System.Collections.Generic;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.BLL
{
    public class SupplierBLL
    {
        private DAL.SupplierDAL supplierDAL = new DAL.SupplierDAL();

        public List<SupplierDTO> GetAllSuppliers()
        {
            return supplierDAL.GetAllSuppliers();
        }

        public SupplierDTO GetSupplierByID(int supplierID)
        {
            return supplierDAL.GetSupplierByID(supplierID);
        }

        public bool AddSupplier(SupplierDTO supplier)
        {
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new Exception("Tên nhà cung cấp không được rỗng");

            if (!string.IsNullOrEmpty(supplier.Phone) && !IsValidPhone(supplier.Phone))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(supplier.Email) && !IsValidEmail(supplier.Email))
                throw new Exception("Email không hợp lệ");

            return supplierDAL.AddSupplier(supplier);
        }

        public bool UpdateSupplier(SupplierDTO supplier)
        {
            if (string.IsNullOrEmpty(supplier.SupplierName))
                throw new Exception("Tên nhà cung cấp không được rỗng");

            if (!string.IsNullOrEmpty(supplier.Phone) && !IsValidPhone(supplier.Phone))
                throw new Exception("Số điện thoại không hợp lệ");

            if (!string.IsNullOrEmpty(supplier.Email) && !IsValidEmail(supplier.Email))
                throw new Exception("Email không hợp lệ");

            return supplierDAL.UpdateSupplier(supplier);
        }

        public bool DeleteSupplier(int supplierID)
        {
            return supplierDAL.DeleteSupplier(supplierID);
        }

        public List<SupplierDTO> SearchSuppliers(string keyword)
        {
            if (string.IsNullOrEmpty(keyword))
                return GetAllSuppliers();

            return supplierDAL.SearchSuppliers(keyword);
        }

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

        private bool IsValidPhone(string phone)
        {
            if (string.IsNullOrEmpty(phone)) return false;
            return System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[0-9]{10,11}$");
        }
    }
}
