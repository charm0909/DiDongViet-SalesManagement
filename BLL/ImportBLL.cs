using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ImportBLL
    {
        private ImportDAL importDAL = new ImportDAL();
        private ProductDAL productDAL = new ProductDAL();

        public List<ImportDTO> GetAllImports()
        {
            try
            {
                return importDAL.GetAllImports();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách phiếu nhập: " + ex.Message);
            }
        }

        public ImportDTO GetImportByID(int importID)
        {
            try
            {
                if (importID <= 0)
                    throw new Exception("ID phiếu nhập không hợp lệ!");

                return importDAL.GetImportByID(importID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy phiếu nhập: " + ex.Message);
            }
        }

        public bool AddImport(ImportDTO import)
        {
            try
            {
                if (string.IsNullOrEmpty(import.SupplierName))
                    throw new Exception("Tên nhà cung cấp không được để trống!");

                if (import.Details == null || import.Details.Count == 0)
                    throw new Exception("Phiếu nhập phải có ít nhất 1 sản phẩm!");

                if (import.TotalAmount <= 0)
                    throw new Exception("Tổng tiền nhập phải lớn hơn 0!");

                return importDAL.AddImport(import);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm phiếu nhập: " + ex.Message);
            }
        }

        public bool UpdateImport(ImportDTO import)
        {
            try
            {
                if (import.ImportID <= 0)
                    throw new Exception("ID phiếu nhập không hợp lệ!");

                return importDAL.UpdateImport(import);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật phiếu nhập: " + ex.Message);
            }
        }

        public bool DeleteImport(int importID)
        {
            try
            {
                if (importID <= 0)
                    throw new Exception("ID phiếu nhập không hợp lệ!");

                return importDAL.DeleteImport(importID);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa phiếu nhập: " + ex.Message);
            }
        }

        public List<ImportDTO> GetImportsBySupplier(string supplierName)
        {
            try
            {
                if (string.IsNullOrEmpty(supplierName))
                    return GetAllImports();

                return importDAL.GetImportsBySupplier(supplierName);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy phiếu nhập theo nhà cung cấp: " + ex.Message);
            }
        }

        // Tính tổng tiền nhập
        public decimal CalculateTotalAmount(List<ImportDetailDTO> details)
        {
            try
            {
                decimal total = 0;
                foreach (var detail in details)
                {
                    total += detail.Total;
                }
                return total;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tính toán tổng tiền: " + ex.Message);
            }
        }
    }
}
