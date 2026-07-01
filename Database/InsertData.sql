-- =====================================================
-- INSERT DỮ LIỆU MẪU - DI ĐỘNG VIỆT SALES
-- =====================================================

USE DiDongVietSales
GO

-- =====================================================
-- INSERT DỮ LIỆU LOẠI SẢN PHẨM (5 DÒNG)
-- =====================================================
INSERT INTO LoaiSanPham (TenLoai, MoTa, TrangThai) VALUES
(N'Điện thoại flagship', N'Điện thoại cao cấp nhất của hãng', N'Hoạt động'),
(N'Điện thoại mid-range', N'Điện thoại giá tầm trung', N'Hoạt động'),
(N'Điện thoại entry-level', N'Điện thoại giá rẻ, phổ biến', N'Hoạt động'),
(N'Máy tính bảng', N'iPad và tablet khác', N'Hoạt động'),
(N'Phụ kiện điện thoại', N'Sạc, cáp, bao, kính cường lực', N'Hoạt động')
GO

-- =====================================================
-- INSERT DỮ LIỆU HÃNG SẢN XUẤT (5 DÒNG)
-- =====================================================
INSERT INTO HangSanXuat (TenHang, QuocGia, TrangThai) VALUES
(N'Apple', N'Mỹ', N'Hoạt động'),
(N'Samsung', N'Hàn Quốc', N'Hoạt động'),
(N'Xiaomi', N'Trung Quốc', N'Hoạt động'),
(N'OPPO', N'Trung Quốc', N'Hoạt động'),
(N'Vivo', N'Trung Quốc', N'Hoạt động')
GO

-- =====================================================
-- INSERT DỮ LIỆU SẢN PHẨM (20 DÒNG)
-- =====================================================
INSERT INTO SanPham (MaSanPham, TenSP, MaHang, MaLoai, GiaNhap, GiaBan, SoLuongTon, MauSac, ThoiGianBaoHanh, DuongDanAnh, NgayTao, TrangThai) VALUES
('SP001', N'iPhone 15 Pro Max', 1, 1, 30000000, 32000000, 15, N'Đen', 12, 'Resources\ProductImages\iPhone 15 Pro Max.svg', GETDATE(), N'Hoạt động'),
('SP002', N'iPhone 15 Pro', 1, 1, 25000000, 27000000, 12, N'Bạc', 12, 'Resources\ProductImages\iPhone 15 Pro.svg', GETDATE(), N'Hoạt động'),
('SP003', N'iPhone 15', 1, 2, 20000000, 22000000, 20, N'Xanh lam', 12, 'Resources\ProductImages\iPhone 15.svg', GETDATE(), N'Hoạt động'),
('SP004', N'iPhone 14 Pro', 1, 1, 22000000, 24000000, 10, N'Vàng', 12, 'Resources\ProductImages\iPhone 14 Pro.svg', GETDATE(), N'Hoạt động'),
('SP005', N'Samsung Galaxy S24', 2, 1, 18000000, 20000000, 18, N'Xám', 12, 'Resources\ProductImages\Samsung Galaxy S24.svg', GETDATE(), N'Hoạt động'),
('SP006', N'Samsung Galaxy A55', 2, 2, 12000000, 13500000, 25, N'Xanh lá', 12, 'Resources\ProductImages\Samsung Galaxy A55.svg', GETDATE(), N'Hoạt động'),
('SP007', N'Samsung Galaxy Tab S10', 2, 4, 15000000, 17000000, 8, N'Bạc', 12, 'Resources\ProductImages\Samsung Galaxy Tab S10.svg', GETDATE(), N'Hoạt động'),
('SP008', N'Xiaomi 14 Ultra', 3, 1, 16000000, 18000000, 14, N'Đen', 12, 'Resources\ProductImages\Xiaomi 14 Ultra.svg', GETDATE(), N'Hoạt động'),
('SP009', N'Xiaomi Pad 6', 3, 4, 10000000, 11500000, 10, N'Xám', 12, 'Resources\ProductImages\Xiaomi Pad 6.svg', GETDATE(), N'Hoạt động'),
('SP010', N'OPPO Reno 11', 4, 2, 13000000, 14500000, 20, N'Đỏ', 12, 'Resources\ProductImages\OPPO Reno 11.svg', GETDATE(), N'Hoạt động'),
('SP011', N'Vivo X100', 5, 1, 17000000, 19000000, 12, N'Bạc', 12, 'Resources\ProductImages\Vivo X100.svg', GETDATE(), N'Hoạt động'),
('SP012', N'iPad Air 6', 1, 4, 20000000, 22000000, 9, N'Bạc', 12, 'Resources\ProductImages\iPad Air 6.svg', GETDATE(), N'Hoạt động'),
('SP013', N'OnePlus 12', 3, 1, 15000000, 17000000, 11, N'Đen', 12, 'Resources\ProductImages\OnePlus 12.svg', GETDATE(), N'Hoạt động'),
('SP014', N'Google Pixel 8', 2, 1, 14000000, 15500000, 13, N'Trắng', 12, 'Resources\ProductImages\Google Pixel 8.svg', GETDATE(), N'Hoạt động'),
('SP015', N'Realme 12', 3, 2, 11000000, 12500000, 22, N'Vàng', 12, 'Resources\ProductImages\Realme 12.svg', GETDATE(), N'Hoạt động'),
('SP016', N'Motorola Edge 50', 2, 2, 12500000, 14000000, 16, N'Đen', 12, 'Resources\ProductImages\Motorola Edge 50.svg', GETDATE(), N'Hoạt ��ộng'),
('SP017', N'Poco X6 Pro', 3, 2, 10500000, 12000000, 24, N'Xanh lá', 12, 'Resources\ProductImages\Poco X6 Pro.svg', GETDATE(), N'Hoạt động'),
('SP018', N'Honor 200', 4, 2, 14000000, 15500000, 17, N'Xám', 12, 'Resources\ProductImages\Honor 200.svg', GETDATE(), N'Hoạt động'),
('SP019', N'Nothing Phone 2', 5, 2, 13500000, 15000000, 19, N'Đen', 12, 'Resources\ProductImages\Nothing Phone 2.svg', GETDATE(), N'Hoạt động'),
('SP020', N'Sony Xperia 1', 1, 1, 19000000, 21000000, 11, N'Bạc', 12, 'Resources\ProductImages\Sony Xperia 1.svg', GETDATE(), N'Hoạt động')
GO

-- =====================================================
-- INSERT DỮ LIỆU NHÀ CUNG CẤP (5 DÒNG)
-- =====================================================
INSERT INTO NhaCungCap (TenNCC, SoDienThoai, Email, DiaChi, NgayTao, TrangThai) VALUES
(N'Công ty cấp phát Apple Việt Nam', '0123456789', 'contact@applevn.com', N'123 Lê Lợi, Quận 1, TP.HCM', GETDATE(), N'Hoạt động'),
(N'Samsung Vietnam Distribution', '0234567890', 'sales@samsungvn.com', N'456 Nguyễn Hữu Cảnh, Quận Bình Thạnh, TP.HCM', GETDATE(), N'Hoạt động'),
(N'Xiaomi Official Distributor', '0345678901', 'distributor@xiaomivn.com', N'789 Trần Hưng Đạo, Quận 1, TP.HCM', GETDATE(), N'Hoạt động'),
(N'OPPO Việt Nam', '0456789012', 'sales@oppovn.com', N'321 Võ Văn Kiệt, Quận 4, TP.HCM', GETDATE(), N'Hoạt động'),
(N'Vivo Vietnam Co., Ltd', '0567890123', 'contact@vivovn.com', N'654 Pasteur, Quận 1, TP.HCM', GETDATE(), N'Hoạt động')
GO

-- =====================================================
-- INSERT DỮ LIỆU NHÂN VIÊN (20 DÒNG)
-- =====================================================
INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, SoDienThoai, Email, DiaChi, ChucVu, NgayVaoLam, NgayTao, TrangThai) VALUES
(N'Nguyễn Văn An', '1990-05-15', N'Nam', '0901234567', 'an.nguyen@didong.com', N'123 Cách Mạng Tháng 8, Quận 3, TP.HCM', N'Quản trị viên', '2020-01-10', GETDATE(), N'Hoạt động'),
(N'Trần Thị Bích', '1992-08-20', N'Nữ', '0912345678', 'bich.tran@didong.com', N'456 Nguyễn Trãi, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2021-03-15', GETDATE(), N'Hoạt động'),
(N'Phạm Văn Chính', '1995-03-10', N'Nam', '0923456789', 'chinh.pham@didong.com', N'789 Lý Thường Kiệt, Quận 10, TP.HCM', N'Nhân viên bán hàng', '2021-06-20', GETDATE(), N'Hoạt động'),
(N'Hoàng Thị Duyên', '1993-11-25', N'Nữ', '0934567890', 'duyen.hoang@didong.com', N'321 Bùi Viện, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2021-09-10', GETDATE(), N'Hoạt động'),
(N'Đặng Văn Em', '1998-07-05', N'Nam', '0945678901', 'em.dang@didong.com', N'654 Trần Hưng Đạo, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2022-01-20', GETDATE(), N'Hoạt động'),
(N'Lê Thị Phương', '1994-02-14', N'Nữ', '0956789012', 'phuong.le@didong.com', N'987 Hàng Xanh, Quận 5, TP.HCM', N'Nhân viên bán hàng', '2022-03-15', GETDATE(), N'Hoạt động'),
(N'Vũ Văn Giang', '1996-09-30', N'Nam', '0967890123', 'giang.vu@didong.com', N'147 Đồng Khởi, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2022-05-10', GETDATE(), N'Hoạt động'),
(N'Ngô Thị Hương', '1997-04-12', N'Nữ', '0978901234', 'huong.ngo@didong.com', N'258 Điện Biên Phủ, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2022-07-01', GETDATE(), N'Hoạt động'),
(N'Trương Văn Ích', '1991-12-08', N'Nam', '0989012345', 'ich.truong@didong.com', N'369 Nguyễn Công Trứ, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2022-08-15', GETDATE(), N'Hoạt động'),
(N'Đỗ Thị Khánh', '1999-06-22', N'Nữ', '0990123456', 'khanh.do@didong.com', N'456 Võ Văn Kiệt, Quận 4, TP.HCM', N'Nhân viên bán hàng', '2022-10-01', GETDATE(), N'Hoạt động'),
(N'Bùi Văn Long', '1993-01-17', N'Nam', '0901111111', 'long.bui@didong.com', N'789 Đại Lộ Giai Phóng, Quận 6, TP.HCM', N'Nhân viên bán hàng', '2023-01-10', GETDATE(), N'Hoạt động'),
(N'Phan Thị Minh', '1995-10-03', N'Nữ', '0902222222', 'minh.phan@didong.com', N'123 Bến Vân Đón, Quận 4, TP.HCM', N'Nhân viên bán hàng', '2023-02-20', GETDATE(), N'Hoạt động'),
(N'Tô Văn Nâm', '1997-05-29', N'Nam', '0903333333', 'nam.to@didong.com', N'456 Nguyễn Du, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2023-03-15', GETDATE(), N'Hoạt động'),
(N'Bế Thị Oanh', '1994-08-11', N'Nữ', '0904444444', 'oanh.be@didong.com', N'789 Lê Thánh Tôn, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2023-04-10', GETDATE(), N'Hoạt động'),
(N'Võ Văn Phúc', '1996-03-27', N'Nam', '0905555555', 'phuc.vo@didong.com', N'321 An Dương Vương, Quận 5, TP.HCM', N'Nhân viên bán hàng', '2023-05-20', GETDATE(), N'Hoạt động'),
(N'Hồ Thị Quỳnh', '1998-11-14', N'Nữ', '0906666666', 'quynh.ho@didong.com', N'654 Tú Xương, Quận 3, TP.HCM', N'Nhân viên bán hàng', '2023-06-15', GETDATE(), N'Hoạt động'),
(N'Dương Văn Rui', '1992-07-02', N'Nam', '0907777777', 'rui.duong@didong.com', N'987 Bùi Thị Xuân, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2023-07-10', GETDATE(), N'Hoạt động'),
(N'Mạc Thị Sinh', '1999-02-19', N'Nữ', '0908888888', 'sinh.mac@didong.com', N'147 Mạc Thiên Tích, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2023-08-20', GETDATE(), N'Hoạt động'),
(N'Tạ Văn Tâm', '1994-09-06', N'Nam', '0909999999', 'tam.ta@didong.com', N'258 Thạch Thị Thanh, Quận 1, TP.HCM', N'Nhân viên bán hàng', '2023-09-15', GETDATE(), N'Hoạt động'),
(N'Vương Thị Uyên', '1997-04-23', N'Nữ', '0900000000', 'uyen.vuong@didong.com', N'369 Nguyễn Đình Chiểu, Quận 3, TP.HCM', N'Nhân viên bán hàng', '2023-10-10', GETDATE(), N'Hoạt động')
GO

-- =====================================================
-- INSERT DỮ LIỆU KHÁCH HÀNG (20 DÒNG)
-- =====================================================
INSERT INTO KhachHang (HoTen, SoDienThoai, Email, DiaChi, TongChiTieu, NgayTao, TrangThai) VALUES
(N'Lý Thị Anh', '0911111111', 'anh@email.com', N'123 Lê Lợi, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Trần Văn Bình', '0922222222', 'binh@email.com', N'456 Nguyễn Trãi, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Hoàng Thị Cẩm', '0933333333', 'cam@email.com', N'789 Lý Thường Kiệt, Quận 10', 0, GETDATE(), N'Hoạt động'),
(N'Đinh Văn Dũng', '0944444444', 'dung@email.com', N'321 Bùi Viện, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Phạm Thị Ép', '0955555555', 'ep@email.com', N'654 Trần Hưng Đạo, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Nguyễn Văn Phú', '0966666666', 'phu@email.com', N'987 Hàng Xanh, Quận 5', 0, GETDATE(), N'Hoạt động'),
(N'Bùi Thị Giang', '0977777777', 'giang@email.com', N'147 Đồng Khởi, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Vũ Văn Hải', '0988888888', 'hai@email.com', N'258 Điện Biên Phủ, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Đặng Thị Ích', '0999999999', 'ich@email.com', N'369 Nguyễn Công Trứ, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Tô Văn Khánh', '0910101010', 'khanh@email.com', N'456 Võ Văn Kiệt, Quận 4', 0, GETDATE(), N'Hoạt động'),
(N'Lê Thị Long', '0911212121', 'long@email.com', N'789 Đại Lộ Giai Phóng, Quận 6', 0, GETDATE(), N'Hoạt động'),
(N'Phan Văn Minh', '0912323232', 'minh@email.com', N'123 Bến Vân Đón, Quận 4', 0, GETDATE(), N'Hoạt động'),
(N'Hồ Thị Nhi', '0913434343', 'nhi@email.com', N'456 Nguyễn Du, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Võ Văn Oanh', '0914545454', 'oanh@email.com', N'789 Lê Thánh Tôn, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Mạc Thị Phương', '0915656565', 'phuong@email.com', N'321 An Dương Vương, Quận 5', 0, GETDATE(), N'Hoạt động'),
(N'Bế Văn Quý', '0916767676', 'quy@email.com', N'654 Tú Xương, Quận 3', 0, GETDATE(), N'Hoạt động'),
(N'Dương Thị Rui', '0917878787', 'rui@email.com', N'987 Bùi Thị Xuân, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Trương Văn Sam', '0918989898', 'sam@email.com', N'147 Mạc Thiên Tích, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Ngô Thị Tâm', '0919090909', 'tam@email.com', N'258 Thạch Thị Thanh, Quận 1', 0, GETDATE(), N'Hoạt động'),
(N'Ứng Văn Uyên', '0910111213', 'uyen@email.com', N'369 Nguyễn Đình Chiểu, Quận 3', 0, GETDATE(), N'Hoạt động')
GO

-- =====================================================
-- INSERT DỮ LIỆU TÀI KHOẢN (5 DÒNG)
-- =====================================================
INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, Quyen, NgayTao, TrangThai) VALUES
(N'admin', 'admin123', 1, N'Quản trị viên', GETDATE(), N'Hoạt động'),
(N'nhanvien1', 'pass123', 2, N'Nhân viên', GETDATE(), N'Hoạt động'),
(N'nhanvien2', 'pass123', 3, N'Nhân viên', GETDATE(), N'Hoạt động'),
(N'nhanvien3', 'pass123', 4, N'Nhân viên', GETDATE(), N'Hoạt động'),
(N'nhanvien4', 'pass123', 5, N'Nhân viên', GETDATE(), N'Hoạt động')
GO

PRINT 'Insert dữ liệu mẫu thành công!'
GO
