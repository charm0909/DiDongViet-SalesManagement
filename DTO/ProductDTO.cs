using System;

namespace DiDongViet_SalesManagement.DTO
{
    public class ProductDTO
    {
        public int MaSP { get; set; }
        public string MaSanPham { get; set; }
        public string TenSP { get; set; }
        public int MaHang { get; set; }
        public int MaLoai { get; set; }
        public decimal GiaNhap { get; set; }
        public decimal GiaBan { get; set; }
        public int SoLuongTon { get; set; }
        public string MauSac { get; set; }
        public int ThoiGianBaoHanh { get; set; }
        public string DuongDanAnh { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
    }
}
