using System;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement.BLL
{
    public class AccountBLL
    {
        private DAL.AccountDAL accountDAL = new DAL.AccountDAL();

        public AccountDTO Login(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                throw new Exception("Tên đăng nhập và mật khẩu không được rỗng");

            return accountDAL.Login(username, password);
        }

        public bool Register(AccountDTO account)
        {
            if (string.IsNullOrEmpty(account.TenDangNhap))
                throw new Exception("Tên đăng nhập không được rỗng");

            if (string.IsNullOrEmpty(account.MatKhau) || account.MatKhau.Length < 6)
                throw new Exception("Mật khẩu phải có ít nhất 6 ký tự");

            return accountDAL.Register(account);
        }

        public bool ChangePassword(int accountID, string oldPassword, string newPassword)
        {
            if (string.IsNullOrEmpty(oldPassword) || string.IsNullOrEmpty(newPassword))
                throw new Exception("Mật khẩu không được rỗng");

            if (newPassword.Length < 6)
                throw new Exception("Mật khẩu mới phải có ít nhất 6 ký tự");

            return accountDAL.ChangePassword(accountID, oldPassword, newPassword);
        }
    }
}
