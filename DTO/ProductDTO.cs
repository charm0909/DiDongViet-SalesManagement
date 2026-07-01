using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDongViet_SalesManagement.DTO
{
    public class ProductDTO
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int MaHang { get; set; }
        public string TenHang { get; set; }
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string MauSac { get; set; }
        public int? BaoHanh { get; set; }
        public string HinhAnh { get; set; }
        public bool TrangThai { get; set; }
    }
}
