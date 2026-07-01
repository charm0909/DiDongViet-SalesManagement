using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.GUI;
using DiDongViet_SalesManagement.DAL;

namespace DiDongViet_SalesManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                // Kiểm tra kết nối database
                if (!DatabaseConnection.TestConnection())
                {
                    MessageBox.Show("Không thể kết nối đến database!\nVui lòng kiểm tra cấu hình.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new frmLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khởi động ứng dụng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
