using System;
using System.Collections.Generic;
using DAL;
using DTO;

namespace BLL
{
    public class ImportBLL
    {
        private ImportDAL importDAL = new ImportDAL();

        // Lấy tất cả phiếu nhập
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

        // Lấy phiếu nhập theo ID
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

        // Tạo phiếu nhập mới
        public bool CreateImport(ImportDTO import)
        {
            try
            {
                // Validate dữ liệu
                if (import == null)
                    throw new Exception("Phiếu nhập không được để trống!");

                if (string.IsNullOrEmpty(import.SupplierName))
                    throw new Exception("Tên nhà cung cấp không được để trống!");

                if (import.Details == null || import.Details.Count == 0)
                    throw new Exception("Phiếu nhập phải có ít nhất 1 chi tiết!");

                if (import.ImportDate == null)
                    import.ImportDate = DateTime.Now;

                // Tính tổng tiền
                decimal total = 0;
                foreach (var detail in import.Details)
                {
                    if (detail.Quantity <= 0)
                        throw new Exception("Số lượng sản phẩm phải lớn hơn 0!");

                    if (detail.ImportPrice < 0)
                        throw new Exception("Giá nhập không được âm!");

                    total += detail.Total;
                }

                import.TotalAmount = total;

                return importDAL.CreateImport(import);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo phiếu nhập: " + ex.Message);
            }
        }

        // Cập nhật phiếu nhập
        public bool UpdateImport(ImportDTO import)
        {
            try
            {
                if (import == null || import.ImportID <= 0)
                    throw new Exception("ID phiếu nhập không hợp lệ!");

                return importDAL.UpdateImport(import);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật phiếu nhập: " + ex.Message);
            }
        }

        // Xóa phiếu nhập
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

        // Tìm kiếm phiếu nhập theo nhà cung cấp
        public List<ImportDTO> SearchImportsBySupplier(string supplierName)
        {
            try
            {
                if (string.IsNullOrEmpty(supplierName))
                    throw new Exception("Tên nhà cung cấp không được để trống!");

                return importDAL.SearchImportsBySupplier(supplierName);
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm phiếu nhập: " + ex.Message);
            }
        }
    }
}
