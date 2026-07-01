using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDongViet_SalesManagement.DTO;
using DiDongViet_SalesManagement.DAL;

namespace DiDongViet_SalesManagement.BLL
{
    public class LoginBLL
    {
        /// <summary>
        /// Xác thực đăng nhập
        /// </summary>
        public static LoginDTO Authenticate(string username, string password)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    throw new Exception("Tên đăng nhập không được để trống!");

                if (string.IsNullOrWhiteSpace(password))
                    throw new Exception("Mật khẩu không được để trống!");

                LoginDTO user = LoginDAL.CheckLogin(username, password);
                if (user == null)
                    throw new Exception("Tên đăng nhập hoặc mật khẩu không chính xác!");

                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi đăng nhập: " + ex.Message);
            }
        }
    }
}
