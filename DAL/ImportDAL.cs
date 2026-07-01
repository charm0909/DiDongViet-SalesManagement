using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class ImportDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        // Lấy tất cả phiếu nhập
        public List<ImportDTO> GetAllImports()
        {
            List<ImportDTO> imports = new List<ImportDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuNhap", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ImportDTO import = new ImportDTO
                        {
                            ImportID = (int)reader["ImportID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            ImportDate = (DateTime)reader["ImportDate"],
                            TotalAmount = (decimal)reader["TotalAmount"]
                        };
                        imports.Add(import);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách phiếu nhập: " + ex.Message);
            }
            return imports;
        }

        // Lấy phiếu nhập theo ID
        public ImportDTO GetImportByID(int importID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuNhap WHERE ImportID = @ImportID", conn);
                    cmd.Parameters.AddWithValue("@ImportID", importID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        ImportDTO import = new ImportDTO
                        {
                            ImportID = (int)reader["ImportID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            ImportDate = (DateTime)reader["ImportDate"],
                            TotalAmount = (decimal)reader["TotalAmount"]
                        };
                        reader.Close();
                        return import;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy phiếu nhập: " + ex.Message);
            }
            return null;
        }

        // Tạo phiếu nhập mới
        public bool CreateImport(ImportDTO import)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spCreateImport", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@SupplierName", import.SupplierName);
                    cmd.Parameters.AddWithValue("@ImportDate", import.ImportDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@TotalAmount", import.TotalAmount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
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
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE PhieuNhap SET SupplierName = @SupplierName, ImportDate = @ImportDate, TotalAmount = @TotalAmount WHERE ImportID = @ImportID", conn);
                    cmd.Parameters.AddWithValue("@ImportID", import.ImportID);
                    cmd.Parameters.AddWithValue("@SupplierName", import.SupplierName);
                    cmd.Parameters.AddWithValue("@ImportDate", import.ImportDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@TotalAmount", import.TotalAmount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
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
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM PhieuNhap WHERE ImportID = @ImportID", conn);
                    cmd.Parameters.AddWithValue("@ImportID", importID);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa phiếu nhập: " + ex.Message);
            }
        }

        // Tìm kiếm phiếu nhập theo nhà cung cấp
        public List<ImportDTO> SearchImportsBySupplier(string supplierName)
        {
            List<ImportDTO> imports = new List<ImportDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuNhap WHERE SupplierName LIKE @SupplierName", conn);
                    cmd.Parameters.AddWithValue("@SupplierName", "%" + supplierName + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ImportDTO import = new ImportDTO
                        {
                            ImportID = (int)reader["ImportID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            ImportDate = (DateTime)reader["ImportDate"],
                            TotalAmount = (decimal)reader["TotalAmount"]
                        };
                        imports.Add(import);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm phiếu nhập: " + ex.Message);
            }
            return imports;
        }
    }
}
