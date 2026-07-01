-- ========================================
-- SCRIPT TẠO DATABASE DI ĐỘNG VIỆT
-- ========================================

USE master;
GO

-- Xóa database cũ nếu tồn tại
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'DiDongVietDB')
BEGIN
    ALTER DATABASE DiDongVietDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE DiDongVietDB;
END
GO

-- Tạo database mới
CREATE DATABASE DiDongVietDB
    ON PRIMARY (
        NAME = N'DiDongVietDB_Data',
        FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DiDongVietDB.mdf',
        SIZE = 100MB,
        FILEGROWTH = 10%
    )
    LOG ON (
        NAME = N'DiDongVietDB_Log',
        FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\DiDongVietDB.ldf',
        SIZE = 50MB,
        FILEGROWTH = 10%
    )
GO

USE DiDongVietDB;
GO

-- ========================================
-- BẢNG HỖ TRỢ (LOOKUP TABLES)
-- ========================================

-- Bảng Hãng sản xuất
CREATE TABLE HangSanXuat (
    MaHang INT PRIMARY KEY IDENTITY(1,1),
    TenHang NVARCHAR(100) NOT NULL UNIQUE,
    QuocGia NVARCHAR(50),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);

-- Bảng Loại sản phẩm
CREATE TABLE LoaiSanPham (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(100) NOT NULL UNIQUE,
    MoTa NVARCHAR(500),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);

-- Bảng Nhà cung cấp
CREATE TABLE NhaCungCap (
    MaNCC INT PRIMARY KEY IDENTITY(1,1),
    TenNCC NVARCHAR(150) NOT NULL,
    DienThoai VARCHAR(20) NOT NULL UNIQUE,
    Email VARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(300),
    NguoiDaiDien NVARCHAR(100),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);

-- ========================================
-- BẢNG CHÍNH
-- ========================================

-- Bảng Sản phẩm
CREATE TABLE SanPham (
    MaSP INT PRIMARY KEY IDENTITY(1,1),
    TenSP NVARCHAR(200) NOT NULL,
    MaHang INT NOT NULL,
    MaLoai INT NOT NULL,
    GiaNhap DECIMAL(15,2) NOT NULL CHECK (GiaNhap > 0),
    GiaBan DECIMAL(15,2) NOT NULL CHECK (GiaBan > GiaNhap),
    SoLuongTon INT NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0),
    MauSac NVARCHAR(50),
    BaoHanh INT,
    HinhAnh NVARCHAR(500),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaHang) REFERENCES HangSanXuat(MaHang),
    FOREIGN KEY (MaLoai) REFERENCES LoaiSanPham(MaLoai)
);

-- Bảng Nhân viên
CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    NgaySinh DATE NOT NULL,
    GioiTinh NVARCHAR(10) CHECK (GioiTinh IN (N'Nam', N'Nữ', N'Khác')),
    DienThoai VARCHAR(20) NOT NULL UNIQUE,
    Email VARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(300),
    ChucVu NVARCHAR(50),
    NgayVaoLam DATE NOT NULL DEFAULT CAST(GETDATE() AS DATE),
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);

-- Bảng Khách hàng
CREATE TABLE KhachHang (
    MaKH INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(20) NOT NULL UNIQUE,
    Email VARCHAR(100) UNIQUE,
    DiaChi NVARCHAR(300),
    TongChiTieu DECIMAL(15,2) DEFAULT 0,
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE()
);

-- Bảng Tài khoản đăng nhập
CREATE TABLE TaiKhoan (
    MaTK INT PRIMARY KEY IDENTITY(1,1),
    TenDangNhap VARCHAR(50) NOT NULL UNIQUE,
    MatKhau VARCHAR(255) NOT NULL,
    MaNV INT NOT NULL UNIQUE,
    LoaiTK NVARCHAR(50) CHECK (LoaiTK IN (N'Admin', N'Nhân viên')) DEFAULT N'Nhân viên',
    TrangThai BIT DEFAULT 1,
    NgayTao DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Hóa đơn bán hàng
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    MaKH INT NOT NULL,
    MaNV INT NOT NULL,
    NgayLap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(15,2) NOT NULL CHECK (TongTien >= 0),
    GiamGia DECIMAL(15,2) DEFAULT 0 CHECK (GiamGia >= 0),
    ThanhTien DECIMAL(15,2) NOT NULL CHECK (ThanhTien >= 0),
    GhiChu NVARCHAR(500),
    TrangThai BIT DEFAULT 1,
    FOREIGN KEY (MaKH) REFERENCES KhachHang(MaKH),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi tiết hóa đơn
CREATE TABLE ChiTietHoaDon (
    MaCTHD INT PRIMARY KEY IDENTITY(1,1),
    MaHD INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia DECIMAL(15,2) NOT NULL CHECK (DonGia > 0),
    ThanhTien DECIMAL(15,2) NOT NULL CHECK (ThanhTien > 0),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Bảng Phiếu nhập hàng
CREATE TABLE PhieuNhap (
    MaPN INT PRIMARY KEY IDENTITY(1,1),
    MaNCC INT NOT NULL,
    MaNV INT NOT NULL,
    NgayNhap DATETIME DEFAULT GETDATE(),
    TongTien DECIMAL(15,2) NOT NULL CHECK (TongTien >= 0),
    GhiChu NVARCHAR(500),
    TrangThai BIT DEFAULT 1,
    FOREIGN KEY (MaNCC) REFERENCES NhaCungCap(MaNCC),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng Chi tiết phiếu nhập
CREATE TABLE ChiTietPhieuNhap (
    MaCTPN INT PRIMARY KEY IDENTITY(1,1),
    MaPN INT NOT NULL,
    MaSP INT NOT NULL,
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGiaNhap DECIMAL(15,2) NOT NULL CHECK (DonGiaNhap > 0),
    ThanhTien DECIMAL(15,2) NOT NULL CHECK (ThanhTien > 0),
    FOREIGN KEY (MaPN) REFERENCES PhieuNhap(MaPN) ON DELETE CASCADE,
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

-- Bảng Lịch sử tồn kho
CREATE TABLE LichSuTonKho (
    MaLSTK INT PRIMARY KEY IDENTITY(1,1),
    MaSP INT NOT NULL,
    LoaiGiaoDich NVARCHAR(50) CHECK (LoaiGiaoDich IN (N'Nhập', N'Xuất')),
    SoLuong INT NOT NULL,
    SoLuongSau INT NOT NULL,
    GhiChu NVARCHAR(500),
    NgayGiaoDich DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (MaSP) REFERENCES SanPham(MaSP)
);

GO

-- ========================================
-- TẠO INDEX
-- ========================================

CREATE INDEX IX_SanPham_MaHang ON SanPham(MaHang);
CREATE INDEX IX_SanPham_MaLoai ON SanPham(MaLoai);
CREATE INDEX IX_HoaDon_MaKH ON HoaDon(MaKH);
CREATE INDEX IX_HoaDon_MaNV ON HoaDon(MaNV);
CREATE INDEX IX_HoaDon_NgayLap ON HoaDon(NgayLap);
CREATE INDEX IX_ChiTietHoaDon_MaHD ON ChiTietHoaDon(MaHD);
CREATE INDEX IX_ChiTietHoaDon_MaSP ON ChiTietHoaDon(MaSP);
CREATE INDEX IX_PhieuNhap_MaNCC ON PhieuNhap(MaNCC);
CREATE INDEX IX_PhieuNhap_MaNV ON PhieuNhap(MaNV);
CREATE INDEX IX_ChiTietPhieuNhap_MaPN ON ChiTietPhieuNhap(MaPN);
CREATE INDEX IX_LichSuTonKho_MaSP ON LichSuTonKho(MaSP);

GO

PRINT N'✓ Database DiDongVietDB đã được tạo thành công!';
GO