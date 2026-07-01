using System;
using System.Windows.Forms;
using DiDongViet_SalesManagement.BLL;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.GUI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.Text = "Đăng Nhập - Di Động Việt";
            lblTitle.Text = "HỆ THỐNG QUẢN LÝ BÁN HÀNG\nDI ĐỘNG VIỆT";
            btnLogin.Text = "ĐĂNG NHẬP";
            btnExit.Text = "THOÁT";
            
            // Thiết lập focus vào TextBox username
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text;

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                LoginDTO user = LoginBLL.Authenticate(username, password);

                if (user != null)
                {
                    // Lưu thông tin người dùng
                    GlobalData.CurrentUser = user;
                    
                    MessageBox.Show($"Đăng nhập thành công!\nXin chào {user.HoTen}", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Mở form chính
                    frmMainDashboard mainForm = new frmMainDashboard();
                    mainForm.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                btnLogin_Click(null, null);
            }
        }
    }
}
