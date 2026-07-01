using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDongViet_SalesManagement.DAL
{
    public class DatabaseConnection
    {
        // Thay đổi connection string phù hợp với SQL Server của bạn
        private static string connectionString = @"Server=LAPTOP-USER\SQLEXPRESS;Database=DiDongVietDB;Integrated Security=True;";

        /// <summary>
        /// Lấy connection string từ cấu hình
        /// </summary>
        public static string GetConnectionString()
        {
            return connectionString;
        }

        /// <summary>
        /// Đặt connection string
        /// </summary>
        public static void SetConnectionString(string connStr)
        {
            connectionString = connStr;
        }

        /// <summary>
        /// Kiểm tra kết nối đến database
        /// </summary>
        public static bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    return conn.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối đến database: " + ex.Message);
            }
        }

        /// <summary>
        /// Thực thi stored procedure và trả về DataTable
        /// </summary>
        public static DataTable ExecuteStoredProcedure(string procedureName, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi stored procedure " + procedureName + ": " + ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Thực thi stored procedure và không trả về kết quả
        /// </summary>
        public static void ExecuteStoredProcedureNonQuery(string procedureName, SqlParameter[] parameters = null)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(procedureName, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        if (parameters != null)
                            cmd.Parameters.AddRange(parameters);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi stored procedure " + procedureName + ": " + ex.Message);
            }
        }

        /// <summary>
        /// Thực thi query SQL và trả về DataTable
        /// </summary>
        public static DataTable ExecuteQuery(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi query: " + ex.Message);
            }
            return dt;
        }

        /// <summary>
        /// Thực thi query SQL và không trả về kết quả
        /// </summary>
        public static void ExecuteQueryNonQuery(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandType = CommandType.Text;
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thực thi query: " + ex.Message);
            }
        }
    }
}
