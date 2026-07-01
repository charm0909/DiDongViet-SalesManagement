-- ========================================
-- SCRIPT TẠO STORED PROCEDURE
-- ========================================

USE DiDongVietDB;
GO

-- ========================================
-- STORED PROCEDURE - SẢN PHẨM
-- ========================================

-- SP: Lấy danh sách sản phẩm
CREATE PROCEDURE sp_GetAllProducts
AS
BEGIN
    SELECT 
        p.MaSP,
        p.TenSP,
        h.TenHang,
        l.TenLoai,
        p.GiaNhap,
        p.GiaBan,
        p.SoLuongTon,
        p.MauSac,
        p.BaoHanh,
        p.HinhAnh,
        p.TrangThai
    FROM SanPham p
    INNER JOIN HangSanXuat h ON p.MaHang = h.MaHang
    INNER JOIN LoaiSanPham l ON p.MaLoai = l.MaLoai
    ORDER BY p.MaSP DESC;
END
GO

-- SP: Thêm sản phẩm
CREATE PROCEDURE sp_InsertProduct
    @TenSP NVARCHAR(200),
    @MaHang INT,
    @MaLoai INT,
    @GiaNhap DECIMAL(15,2),
    @GiaBan DECIMAL(15,2),
    @MauSac NVARCHAR(50),
    @BaoHanh INT
AS
BEGIN
    IF @GiaBan <= @GiaNhap
    BEGIN
        RAISERROR(N'Giá bán phải lớn hơn giá nhập!', 16, 1);
        RETURN;
    END
    
    INSERT INTO SanPham (TenSP, MaHang, MaLoai, GiaNhap, GiaBan, SoLuongTon, MauSac, BaoHanh, TrangThai)
    VALUES (@TenSP, @MaHang, @MaLoai, @GiaNhap, @GiaBan, 0, @MauSac, @BaoHanh, 1);
END
GO

-- SP: Cập nhật sản phẩm
CREATE PROCEDURE sp_UpdateProduct
    @MaSP INT,
    @TenSP NVARCHAR(200),
    @MaHang INT,
    @MaLoai INT,
    @GiaNhap DECIMAL(15,2),
    @GiaBan DECIMAL(15,2),
    @MauSac NVARCHAR(50),
    @BaoHanh INT
AS
BEGIN
    IF @GiaBan <= @GiaNhap
    BEGIN
        RAISERROR(N'Giá bán phải lớn hơn giá nhập!', 16, 1);
        RETURN;
    END
    
    UPDATE SanPham
    SET TenSP = @TenSP,
        MaHang = @MaHang,
        MaLoai = @MaLoai,
        GiaNhap = @GiaNhap,
        GiaBan = @GiaBan,
        MauSac = @MauSac,
        BaoHanh = @BaoHanh
    WHERE MaSP = @MaSP;
END
GO

-- SP: Xóa sản phẩm
CREATE PROCEDURE sp_DeleteProduct
    @MaSP INT
AS
BEGIN
    UPDATE SanPham
    SET TrangThai = 0
    WHERE MaSP = @MaSP;
END
GO

-- ========================================
-- STORED PROCEDURE - NHÂN VIÊN
-- ========================================

-- SP: Lấy danh sách nhân viên
CREATE PROCEDURE sp_GetAllEmployees
AS
BEGIN
    SELECT 
        MaNV,
        HoTen,
        NgaySinh,
        GioiTinh,
        DienThoai,
        Email,
        DiaChi,
        ChucVu,
        NgayVaoLam,
        TrangThai
    FROM NhanVien
    ORDER BY MaNV DESC;
END
GO

-- SP: Thêm nhân viên
CREATE PROCEDURE sp_InsertEmployee
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @DienThoai VARCHAR(20),
    @Email VARCHAR(100),
    @DiaChi NVARCHAR(300),
    @ChucVu NVARCHAR(50)
AS
BEGIN
    INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, DienThoai, Email, DiaChi, ChucVu, NgayVaoLam, TrangThai)
    VALUES (@HoTen, @NgaySinh, @GioiTinh, @DienThoai, @Email, @DiaChi, @ChucVu, CAST(GETDATE() AS DATE), 1);
END
GO

-- SP: Cập nhật nhân viên
CREATE PROCEDURE sp_UpdateEmployee
    @MaNV INT,
    @HoTen NVARCHAR(100),
    @NgaySinh DATE,
    @GioiTinh NVARCHAR(10),
    @DienThoai VARCHAR(20),
    @Email VARCHAR(100),
    @DiaChi NVARCHAR(300),
    @ChucVu NVARCHAR(50)
AS
BEGIN
    UPDATE NhanVien
    SET HoTen = @HoTen,
        NgaySinh = @NgaySinh,
        GioiTinh = @GioiTinh,
        DienThoai = @DienThoai,
        Email = @Email,
        DiaChi = @DiaChi,
        ChucVu = @ChucVu
    WHERE MaNV = @MaNV;
END
GO

-- ========================================
-- STORED PROCEDURE - KHÁCH HÀNG
-- ========================================

-- SP: Lấy danh sách khách hàng
CREATE PROCEDURE sp_GetAllCustomers
AS
BEGIN
    SELECT 
        MaKH,
        HoTen,
        DienThoai,
        Email,
        DiaChi,
        TongChiTieu,
        TrangThai
    FROM KhachHang
    ORDER BY MaKH DESC;
END
GO

-- SP: Thêm khách hàng
CREATE PROCEDURE sp_InsertCustomer
    @HoTen NVARCHAR(100),
    @DienThoai VARCHAR(20),
    @Email VARCHAR(100),
    @DiaChi NVARCHAR(300)
AS
BEGIN
    INSERT INTO KhachHang (HoTen, DienThoai, Email, DiaChi, TongChiTieu, TrangThai)
    VALUES (@HoTen, @DienThoai, @Email, @DiaChi, 0, 1);
END
GO

-- ========================================
-- STORED PROCEDURE - ĐĂNG NHẬP
-- ========================================

-- SP: Kiểm tra đăng nhập
CREATE PROCEDURE sp_CheckLogin
    @TenDangNhap VARCHAR(50),
    @MatKhau VARCHAR(255)
AS
BEGIN
    SELECT 
        tk.MaTK,
        tk.TenDangNhap,
        tk.LoaiTK,
        nv.MaNV,
        nv.HoTen,
        nv.DienThoai,
        nv.ChucVu
    FROM TaiKhoan tk
    INNER JOIN NhanVien nv ON tk.MaNV = nv.MaNV
    WHERE tk.TenDangNhap = @TenDangNhap 
      AND tk.MatKhau = @MatKhau 
      AND tk.TrangThai = 1;
END
GO

-- ========================================
-- STORED PROCEDURE - HÓA ĐƠN
-- ========================================

-- SP: Lấy danh sách hóa đơn
CREATE PROCEDURE sp_GetAllInvoices
AS
BEGIN
    SELECT 
        hd.MaHD,
        hd.MaKH,
        kh.HoTen AS TenKH,
        hd.MaNV,
        nv.HoTen AS TenNV,
        hd.NgayLap,
        hd.TongTien,
        hd.GiamGia,
        hd.ThanhTien,
        hd.GhiChu
    FROM HoaDon hd
    INNER JOIN KhachHang kh ON hd.MaKH = kh.MaKH
    INNER JOIN NhanVien nv ON hd.MaNV = nv.MaNV
    ORDER BY hd.MaHD DESC;
END
GO

-- ========================================
-- STORED PROCEDURE - THỐNG KÊ
-- ========================================

-- SP: Lấy thống kê doanh thu hôm nay
CREATE PROCEDURE sp_GetRevenueTodayByHour
AS
BEGIN
    SELECT 
        DATEPART(HOUR, NgayLap) AS Gio,
        SUM(ThanhTien) AS DoanhThu,
        COUNT(*) AS SoHoaDon
    FROM HoaDon
    WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)
    GROUP BY DATEPART(HOUR, NgayLap)
    ORDER BY Gio ASC;
END
GO

-- SP: Lấy thống kê sản phẩm bán chạy
CREATE PROCEDURE sp_GetBestSellingProducts
    @Top INT = 10
AS
BEGIN
    SELECT TOP (@Top)
        p.MaSP,
        p.TenSP,
        SUM(cthd.SoLuong) AS TongSoLuong,
        SUM(cthd.ThanhTien) AS TongDoanhThu
    FROM SanPham p
    INNER JOIN ChiTietHoaDon cthd ON p.MaSP = cthd.MaSP
    INNER JOIN HoaDon hd ON cthd.MaHD = hd.MaHD
    GROUP BY p.MaSP, p.TenSP
    ORDER BY TongSoLuong DESC;
END
GO

-- SP: Lấy thống kê tồn kho
CREATE PROCEDURE sp_GetStockStatistics
AS
BEGIN
    SELECT 
        p.MaSP,
        p.TenSP,
        h.TenHang,
        p.SoLuongTon,
        CASE 
            WHEN p.SoLuongTon < 5 THEN N'Sắp hết hàng'
            WHEN p.SoLuongTon < 10 THEN N'Hàng ít'
            ELSE N'Bình thường'
        END AS TrangThaiKho,
        (p.SoLuongTon * p.GiaBan) AS GiaTriKho
    FROM SanPham p
    INNER JOIN HangSanXuat h ON p.MaHang = h.MaHang
    WHERE p.TrangThai = 1
    ORDER BY p.SoLuongTon ASC;
END
GO

PRINT N'✓ Stored Procedures đã được tạo thành công!';
GO