using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SupplierDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        // Lấy tất cả nhà cung cấp
        public List<dynamic> GetAllSuppliers()
        {
            List<dynamic> suppliers = new List<dynamic>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NhaCungCap", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dynamic supplier = new
                        {
                            SupplierID = (int)reader["SupplierID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                            Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : ""
                        };
                        suppliers.Add(supplier);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách nhà cung cấp: " + ex.Message);
            }
            return suppliers;
        }

        // Thêm nhà cung cấp
        public bool AddSupplier(string supplierName, string phone, string email, string address)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO NhaCungCap (SupplierName, Phone, Email, Address) VALUES (@SupplierName, @Phone, @Email, @Address)", conn);
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm nhà cung cấp: " + ex.Message);
            }
        }

        // Cập nhật nhà cung cấp
        public bool UpdateSupplier(int supplierID, string supplierName, string phone, string email, string address)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE NhaCungCap SET SupplierName = @SupplierName, Phone = @Phone, Email = @Email, Address = @Address WHERE SupplierID = @SupplierID", conn);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);
                    cmd.Parameters.AddWithValue("@SupplierName", supplierName);
                    cmd.Parameters.AddWithValue("@Phone", phone);
                    cmd.Parameters.AddWithValue("@Email", email ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@Address", address ?? (object)DBNull.Value);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật nhà cung cấp: " + ex.Message);
            }
        }

        // Xóa nhà cung cấp
        public bool DeleteSupplier(int supplierID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM NhaCungCap WHERE SupplierID = @SupplierID", conn);
                    cmd.Parameters.AddWithValue("@SupplierID", supplierID);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa nhà cung cấp: " + ex.Message);
            }
        }

        // Tìm kiếm nhà cung cấp
        public List<dynamic> SearchSuppliers(string keyword)
        {
            List<dynamic> suppliers = new List<dynamic>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM NhaCungCap WHERE SupplierName LIKE @Keyword OR Phone LIKE @Keyword OR Email LIKE @Keyword", conn);
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        dynamic supplier = new
                        {
                            SupplierID = (int)reader["SupplierID"],
                            SupplierName = reader["SupplierName"].ToString(),
                            Phone = reader["Phone"].ToString(),
                            Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : "",
                            Address = reader["Address"] != DBNull.Value ? reader["Address"].ToString() : ""
                        };
                        suppliers.Add(supplier);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tìm kiếm nhà cung cấp: " + ex.Message);
            }
            return suppliers;
        }
    }
}
