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

        public List<ImportDTO> GetAllImports()
        {
            List<ImportDTO> imports = new List<ImportDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuNhap ORDER BY ImportID DESC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ImportDTO import = new ImportDTO
                        {
                            ImportID = (int)reader["ImportID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            ImportDate = reader["ImportDate"] != DBNull.Value ? (DateTime?)reader["ImportDate"] : null,
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
                            ImportDate = reader["ImportDate"] != DBNull.Value ? (DateTime?)reader["ImportDate"] : null,
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

        public bool AddImport(ImportDTO import)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO PhieuNhap (SupplierName, ImportDate, TotalAmount) VALUES (@SupplierName, @ImportDate, @TotalAmount)", conn);
                    cmd.Parameters.AddWithValue("@SupplierName", import.SupplierName);
                    cmd.Parameters.AddWithValue("@ImportDate", import.ImportDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", import.TotalAmount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
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
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE PhieuNhap SET SupplierName = @SupplierName, ImportDate = @ImportDate, TotalAmount = @TotalAmount WHERE ImportID = @ImportID", conn);
                    cmd.Parameters.AddWithValue("@ImportID", import.ImportID);
                    cmd.Parameters.AddWithValue("@SupplierName", import.SupplierName);
                    cmd.Parameters.AddWithValue("@ImportDate", import.ImportDate ?? (object)DBNull.Value);
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

        public bool DeleteImport(int importID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // Xóa chi tiết phiếu nhập trước
                    SqlCommand deleteDetails = new SqlCommand("DELETE FROM ChiTietPhieuNhap WHERE ImportID = @ImportID", conn);
                    deleteDetails.Parameters.AddWithValue("@ImportID", importID);
                    deleteDetails.ExecuteNonQuery();

                    // Xóa phiếu nhập
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

        public List<ImportDTO> GetImportsBySupplier(string supplierName)
        {
            List<ImportDTO> imports = new List<ImportDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM PhieuNhap WHERE SupplierName LIKE @SupplierName ORDER BY ImportID DESC", conn);
                    cmd.Parameters.AddWithValue("@SupplierName", "%" + supplierName + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        ImportDTO import = new ImportDTO
                        {
                            ImportID = (int)reader["ImportID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            ImportDate = reader["ImportDate"] != DBNull.Value ? (DateTime?)reader["ImportDate"] : null,
                            TotalAmount = (decimal)reader["TotalAmount"]
                        };
                        imports.Add(import);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy phiếu nhập theo nhà cung cấp: " + ex.Message);
            }
            return imports;
        }
    }
}
