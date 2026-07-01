using System;

namespace DiDongViet_SalesManagement.DTO
{
    public class CustomerDTO
    {
        public int MaKH { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public decimal TongChiTieu { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
    }
}
