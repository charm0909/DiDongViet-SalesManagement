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

        // Lấy tất cả hóa đơn
        public List<InvoiceDTO> GetAllInvoices()
        {
            List<InvoiceDTO> invoices = new List<InvoiceDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InvoiceDTO invoice = new InvoiceDTO
                        {
                            InvoiceID = (int)reader["InvoiceID"],
                            CustomerID = (int)reader["CustomerID"],
                            InvoiceDate = (DateTime)reader["InvoiceDate"],
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

        // Lấy hóa đơn theo ID
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
                            InvoiceDate = (DateTime)reader["InvoiceDate"],
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

        // Tạo hóa đơn mới
        public bool CreateInvoice(InvoiceDTO invoice)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("spCreateInvoice", conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.AddWithValue("@CustomerID", invoice.CustomerID);
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate ?? DateTime.Now);
                    cmd.Parameters.AddWithValue("@TotalAmount", invoice.TotalAmount);
                    cmd.Parameters.AddWithValue("@Discount", invoice.Discount);

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi tạo hóa đơn: " + ex.Message);
            }
        }

        // Cập nhật hóa đơn
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
                    cmd.Parameters.AddWithValue("@InvoiceDate", invoice.InvoiceDate ?? DateTime.Now);
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

        // Xóa hóa đơn
        public bool DeleteInvoice(int invoiceID)
        {
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
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

        // Tìm kiếm hóa đơn theo ngày
        public List<InvoiceDTO> SearchInvoicesByDate(DateTime startDate, DateTime endDate)
        {
            List<InvoiceDTO> invoices = new List<InvoiceDTO>();
            try
            {
                using (SqlConnection conn = dbConnection.GetConnection())
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM HoaDon WHERE InvoiceDate BETWEEN @StartDate AND @EndDate", conn);
                    cmd.Parameters.AddWithValue("@StartDate", startDate);
                    cmd.Parameters.AddWithValue("@EndDate", endDate);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        InvoiceDTO invoice = new InvoiceDTO
                        {
                            InvoiceID = (int)reader["InvoiceID"],
                            CustomerID = (int)reader["CustomerID"],
                            InvoiceDate = (DateTime)reader["InvoiceDate"],
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
                throw new Exception("Lỗi tìm kiếm hóa đơn: " + ex.Message);
            }
            return invoices;
        }
    }
}
