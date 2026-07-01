-- =====================================================
-- TẠO CƠ SỞ DỮ LIỆU DI ĐỘNG VIỆT SALES MANAGEMENT
-- =====================================================

-- Xóa database nếu tồn tại
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'DiDongVietSales')
DROP DATABASE DiDongVietSales
GO

-- Tạo database mới
CREATE DATABASE DiDongVietSales
GO

USE DiDongVietSales
GO

-- =====================================================
-- BẢNG LOẠI SẢN PHẨM
-- =====================================================
CREATE TABLE LoaiSanPham
(
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động'
)
GO

-- =====================================================
-- BẢNG HÃNG SẢN XUẤT
-- =====================================================
CREATE TABLE HangSanXuat
(
    MaHang INT PRIMARY KEY IDENTITY(1,1),
    TenHang NVARCHAR(100) NOT NULL UNIQUE,
    QuocGia NVARCHAR(100),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động'
)
GO

-- =====================================================
-- BẢNG SẢN PHẨM
-- =====================================================
CREATE TABLE SanPham
(
    MaSP INT PRIMARY KEY IDENTITY(1,1),
    MaSanPham NVARCHAR(50) NOT NULL UNIQUE,
    TenSP NVARCHAR(200) NOT NULL,
    MaHang INT NOT NULL,
    MaLoai INT NOT NULL,
    GiaNhap DECIMAL(15,2) NOT NULL CHECK (GiaNhap > 0),
    GiaBan DECIMAL(15,2) NOT NULL CHECK (GiaBan >= GiaNhap),
    SoLuongTon INT NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    MauSac NVARCHAR(100),
    ThoiGianBaoHanh INT DEFAULT 12,
    DuongDanAnh NVARCHAR(500),
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động',
    FOREIGN KEY (MaHang) REFERENCES HangSanXuat(MaHang),
    FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
)
GO

-- =====================================================
-- BẢNG NHÀ CUNG CẤP
-- =====================================================
CREATE TABLE NhaCungCap
(
    MaNCC INT PRIMARY KEY IDENTITY(1,1),
    TenNCC NVARCHAR(200) NOT NULL,
    SoDienThoai NVARCHAR(20) NOT NULL UNIQUE,
    Email NVARCHAR(100),
    DiaChi NVARCHAR(500),
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động'
)
GO

-- =====================================================
-- BẢNG NHÂN VIÊN
-- =====================================================
CREATE TABLE NhanVien
(
    MaNV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    SoDienThoai NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(500),
    ChucVu NVARCHAR(100),
    NgayVaoLam DATE,
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động'
)
GO

-- =====================================================
-- BẢNG KHÁCH HÀNG
-- =====================================================
CREATE TABLE KhachHang
(
    MaKH INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    SoDienThoai NVARCHAR(20) UNIQUE,
    Email NVARCHAR(100),
    DiaChi NVARCHAR(500),
    TongChiTieu DECIMAL(15,2) DEFAULT 0,
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động'
)
GO

-- =====================================================
-- BẢNG TÀI KHOẢN ĐĂNG NHẬP
-- =====================================================
CREATE TABLE TaiKhoan
(
    MaTK INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    MaNV INT NOT NULL,
    Quyen NVARCHAR(50) DEFAULT N'Nhân viên',
    NgayTao DATETIME DEFAULT GETDATE(),
    TrangThai NVARCHAR(20) DEFAULT N'Hoạt động',
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)
GO

-- =====================================================
-- BẢNG HÓA ĐƠN BÁN HÀNG
-- =====================================================
CREATE TABLE HoaDon
(
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    SoHoaDon NVARCHAR(50) NOT NULL UNIQUE,
    MaKH INT NOT NULL,
    MaNV INT NOT NULL,
    NgayLapHD DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(15,2) NOT NULL CHECK (TongTien >= 0),
    GiamGia DECIMAL(15,2) DEFAULT 0 CHECK (GiamGia >= 0),
    ThanhTien DECIMAL(15,2) NOT NULL CHECK (ThanhTien >= 0),
    TrangThai NVARCHAR(20) DEFAULT N'Hoàn thành',
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)
GO

-- =====================================================
-- BẢNG CHI TIẾT HÓA ĐƠN
-- =====================================================
CREATE TABLE ChiTietHoaDon
(
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1),
    MaHD INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(15,2) NOT NULL CHECK (DonGia > 0),
    ThanhTien DECIMAL(15,2) NOT NULL CHECK (ThanhTien >= 0),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
GO

-- =====================================================
-- BẢNG PHIẾU NHẬP HÀNG
-- =====================================================
CREATE TABLE PhieuNhap
(
    MaPN INT PRIMARY KEY IDENTITY(1,1),
    SoPhieuNhap NVARCHAR(50) NOT NULL UNIQUE,
    MaNCC INT NOT NULL,
    MaNV INT NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(15,2) NOT NULL CHECK (TongTien >= 0),
    TrangThai NVARCHAR(20) DEFAULT N'Hoàn thành',
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
)
GO

-- =====================================================
-- BẢNG CHI TIẾT PHIẾU NHẬP
-- =====================================================
CREATE TABLE ChiTietPhieuNhap
(
    MaChiTiet INT PRIMARY KEY IDENTITY(1,1),
    MaPN INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(15,2) NOT NULL CHECK (DonGia > 0),
    ThanhTien DECIMAL(15,2) NOT NULL CHECK (ThanhTien >= 0),
    FOREIGN KEY (MaPN) REFERENCES PhieuNhap(MaPN) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
GO

-- =====================================================
-- BẢNG LỊCH SỬ NHẬP/XUẤT KHO
-- =====================================================
CREATE TABLE LichSuKho
(
    MaLS INT PRIMARY KEY IDENTITY(1,1),
    MaSP INT NOT NULL,
    LoaiGiaoDich NVARCHAR(20),
    SoLuong INT NOT NULL,
    TruocGiaoDich INT NOT NULL,
    SauGiaoDich INT NOT NULL,
    NgayGiaoDich DATETIME DEFAULT GETDATE(),
    GhiChu NVARCHAR(500),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
)
GO

-- =====================================================
-- TẠO INDEXES
-- =====================================================
CREATE INDEX idx_SanPham_MaHang ON SanPham(MaHang)
CREATE INDEX idx_SanPham_MaLoai ON SanPham(MaLoai)
CREATE INDEX idx_HoaDon_MaKH ON HoaDon(MaKH)
CREATE INDEX idx_HoaDon_NgayLapHD ON HoaDon(NgayLapHD)
CREATE INDEX idx_PhieuNhap_MaNCC ON PhieuNhap(MaNCC)
CREATE INDEX idx_PhieuNhap_NgayNhap ON PhieuNhap(NgayNhap)
CREATE INDEX idx_LichSuKho_MaSP ON LichSuKho(MaSP)

GO

PRINT 'Tạo cơ sở dữ liệu Di Động Việt Sales Management thành công!'
GO
