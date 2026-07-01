using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiDongViet_SalesManagement.DTO
{
    public class InvoiceDTO
    {
        public int MaHD { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTien { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThanhTien { get; set; }
        public string GhiChu { get; set; }
        public List<InvoiceDetailDTO> ChiTiet { get; set; }
    }

    public class InvoiceDetailDTO
    {
        public int MaCTHD { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
