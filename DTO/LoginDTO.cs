using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDongViet_SalesManagement.DTO
{
    public class LoginDTO
    {
        public int MaTK { get; set; }
        public string TenDangNhap { get; set; }
        public string LoaiTK { get; set; }
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public string DienThoai { get; set; }
        public string ChucVu { get; set; }
    }
}
