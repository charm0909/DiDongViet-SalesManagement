using System;
using System.Configuration;
using System.Data.SqlClient;

namespace DAL
{
    public class DatabaseConnection
    {
        private string connectionString;

        public DatabaseConnection()
        {
            connectionString = ConfigurationManager.AppSettings["ConnectionString"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Không tìm thấy chuỗi kết nối trong App.config!");
            }
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            try
            {
                using (SqlConnection conn = GetConnection())
                {
                    conn.Open();
                    conn.Close();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kết nối database: " + ex.Message);
            }
        }
    }
}
