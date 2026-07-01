using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class InvoiceDAL
    {
        private DatabaseConnection dbConnection = new DatabaseConnection();

        public List<InvoiceDTO> GetAllInvoices()
        {
            List<InvoiceDTO> invoices = new List<InvoiceDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon ORDER BY InvoiceID DESC", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InvoiceDTO invoice = new InvoiceDTO
                        {
                            InvoiceID = (int)reader["InvoiceID"],
                            CustomerID = (int)reader["CustomerID"],
                            InvoiceDate = reader["InvoiceDate"] != DBNull.Value ? (DateTime?)reader["InvoiceDate"] : null,
                            TotalAmount = (decimal)reader["TotalAmount"],
                            Discount = reader["Discount"] != DBNull.Value ? (decimal)reader["Discount"] : 0
                        };
                        invoices.Add(invoice);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách hóa đơn: " + ex.Message);
            }
            return invoices;
        }

        public InvoiceDTO GetInvoiceByID(int invoiceID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon WHERE InvoiceID = @InvoiceID", conn);
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        InvoiceDTO invoice = new InvoiceDTO
                        {
                            InvoiceID = (int)reader["InvoiceID"],
                            CustomerID = (int)reader["CustomerID"],
                            InvoiceDate = reader["InvoiceDate"] != DBNull.Value ? (DateTime?)reader["InvoiceDate"] : null,
                            TotalAmount = (decimal)reader["TotalAmount"],
                            Discount = reader["Discount"] != DBNull.Value ? (decimal)reader["Discount"] : 0
                        };
                        reader.Close();
                        return invoice;
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy hóa đơn: " + ex.Message);
            }
            return null;
        }

        public bool AddInvoice(InvoiceDTO invoice)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO HoaDon (CustomerID, InvoiceDate, TotalAmount, Discount) VALUES (@CustomerID, @InvoiceDate, @TotalAmount, @Discount)", conn);
                    cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    cmd.Parameters.AddWithValue("@Discount", invoice.Discount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
            }
        }

        public bool UpdateInvoice(InvoiceDTO invoice)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE HoaDon SET CustomerID = @CustomerID, InvoiceDate = @InvoiceDate, TotalAmount = @TotalAmount, Discount = @Discount WHERE InvoiceID = @InvoiceID", conn);
                    cmd.Parameters.AddWithValue("@InvoiceID", invoice.InvoiceID);
                    cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    cmd.Parameters.AddWithValue("@Discount", invoice.Discount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật hóa đơn: " + ex.Message);
            }
        }

        public bool DeleteInvoice(int invoiceID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    // Xóa chi tiết hóa đơn trước
                    SqlCommand deleteDetails = new SqlCommand("DELETE FROM ChiTietHoaDon WHERE InvoiceID = @InvoiceID", conn);
                    deleteDetails.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    deleteDetails.ExecuteNonQuery();

                    // Xóa hóa đơn
                    SqlCommand cmd = new SqlCommand("DELETE FROM HoaDon WHERE InvoiceID = @InvoiceID", conn);
                    cmd.Parameters.AddWithValue("@InvoiceID", invoiceID);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa hóa đơn: " + ex.Message);
            }
        }

        public List<InvoiceDTO> GetInvoicesByCustomer(int customerID)
        {
            List<InvoiceDTO> invoices = new List<InvoiceDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon WHERE CustomerID = @CustomerID ORDER BY InvoiceID DESC", conn);
                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InvoiceDTO invoice = new InvoiceDTO
                        {
                            InvoiceID = (int)reader["InvoiceID"],
                            CustomerID = (int)reader["CustomerID"],
                            InvoiceDate = reader["InvoiceDate"] != DBNull.Value ? (DateTime?)reader["InvoiceDate"] : null,
                            TotalAmount = (decimal)reader["TotalAmount"],
                            Discount = reader["Discount"] != DBNull.Value ? (decimal)reader["Discount"] : 0
                        };
                        invoices.Add(invoice);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy hóa đơn theo khách hàng: " + ex.Message);
            }
            return invoices;
        }
    }
}
