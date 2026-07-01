using System;

namespace DiDongViet_SalesManagement.DTO
{
    public class EmployeeDTO
    {
        public int MaNV { get; set; }
        public string HoTen { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string SoDienThoai { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public DateTime NgayTao { get; set; }
        public string TrangThai { get; set; }
    }
}
