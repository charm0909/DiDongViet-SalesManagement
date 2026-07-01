-- ========================================
-- SCRIPT INSERT DỮ LIỆU MẪU
-- ========================================

USE DiDongVietDB;
GO

-- ========================================
-- INSERT BẢNG HỖ TRỢ
-- ========================================

-- Insert Hãng sản xuất (5 hãng)
INSERT INTO HangSanXuat (TenHang, QuocGia, TrangThai)
VALUES
    (N'Apple', N'Hoa Kỳ', 1),
    (N'Samsung', N'Hàn Quốc', 1),
    (N'Xiaomi', N'Trung Quốc', 1),
    (N'Oppo', N'Trung Quốc', 1),
    (N'Vivo', N'Trung Quốc', 1);

GO

-- Insert Loại sản phẩm (5 loại)
INSERT INTO LoaiSanPham (TenLoai, MoTa, TrangThai)
VALUES
    (N'Điện thoại', N'Các mẫu điện thoại di động', 1),
    (N'Tai nghe', N'Tai nghe bluetooth và có dây', 1),
    (N'Sạc', N'Sạc nhanh, sạc từ xa', 1),
    (N'Ốp lưng', N'Ốp lưng và miếng dán màn hình', 1),
    (N'Pin dự phòng', N'Pin sạc dự phòng các loại', 1);

GO

-- Insert Nhà cung cấp (5 nhà cung cấp)
INSERT INTO NhaCungCap (TenNCC, DienThoai, Email, DiaChi, NguoiDaiDien, TrangThai)
VALUES
    (N'Công ty Di Động Vàng', '0912345678', 'contact@didongvang.vn', N'Hà Nội', N'Trần Văn A', 1),
    (N'Phân phối Bình Minh', '0923456789', 'info@binhminh.vn', N'TP.HCM', N'Nguyễn Thị B', 1),
    (N'Nhập khẩu Sao Việt', '0934567890', 'sales@saoviet.com', N'Đà Nẵng', N'Lê Văn C', 1),
    (N'Thương mại Tây Hồ', '0945678901', 'admin@tayho.vn', N'Hà Nội', N'Phạm Văn D', 1),
    (N'Phân phối Nam Hà', '0956789012', 'contact@namha.vn', N'Hải Phòng', N'Đặng Thị E', 1);

GO

-- ========================================
-- INSERT BẢNG CHÍNH - SẢN PHẨM (20 sản phẩm)
-- ========================================

INSERT INTO SanPham (TenSP, MaHang, MaLoai, GiaNhap, GiaBan, SoLuongTon, MauSac, BaoHanh, TrangThai)
VALUES
    -- Apple (4 sản phẩm)
    (N'iPhone 15 Pro Max', 1, 1, 25000000, 28500000, 15, N'Bạc', 12, 1),
    (N'iPhone 15 Pro', 1, 1, 20000000, 23000000, 20, N'Đen', 12, 1),
    (N'iPhone 15', 1, 1, 16000000, 18500000, 25, N'Xanh', 12, 1),
    (N'AirPods Pro 2', 1, 2, 5000000, 5800000, 10, N'Trắng', 12, 1),
    -- Samsung (4 sản phẩm)
    (N'Galaxy S24 Ultra', 2, 1, 23000000, 26500000, 12, N'Đen', 12, 1),
    (N'Galaxy S24', 2, 1, 18000000, 20500000, 18, N'Trắng', 12, 1),
    (N'Galaxy A54', 2, 1, 8000000, 9500000, 30, N'Xanh', 12, 1),
    (N'Galaxy Buds2 Pro', 2, 2, 3000000, 3800000, 15, N'Bạc', 12, 1),
    -- Xiaomi (4 sản phẩm)
    (N'Xiaomi 14 Ultra', 3, 1, 15000000, 17500000, 20, N'Đen', 12, 1),
    (N'Xiaomi 14', 3, 1, 10000000, 12000000, 25, N'Bạc', 12, 1),
    (N'Xiaomi Redmi Note 13', 3, 1, 5500000, 6800000, 40, N'Xanh', 12, 1),
    (N'Xiaomi Airdots 4', 3, 2, 800000, 1200000, 50, N'Trắng', 6, 1),
    -- Oppo (4 sản phẩm)
    (N'Oppo Find X7', 4, 1, 14000000, 16000000, 10, N'Đen', 12, 1),
    (N'Oppo Reno11', 4, 1, 9000000, 10500000, 22, N'Bạc', 12, 1),
    (N'Oppo A78', 4, 1, 4500000, 5500000, 35, N'Xanh', 12, 1),
    (N'Oppo Enco Air3', 4, 2, 1200000, 1800000, 30, N'Trắng', 12, 1),
    -- Vivo (4 sản phẩm)
    (N'Vivo X100', 5, 1, 13000000, 15000000, 8, N'Đen', 12, 1),
    (N'Vivo V30', 5, 1, 8500000, 10000000, 20, N'Bạc', 12, 1),
    (N'Vivo Y100', 5, 1, 4000000, 5000000, 45, N'Xanh', 12, 1),
    (N'Vivo TWS 3', 5, 2, 900000, 1400000, 40, N'Trắng', 12, 1);

GO

-- ========================================
-- INSERT BẢNG NHÂN VIÊN (20 nhân viên)
-- ========================================

INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, DienThoai, Email, DiaChi, ChucVu, NgayVaoLam, TrangThai)
VALUES
    (N'Nguyễn Văn A', '1990-05-15', N'Nam', '0912345670', 'nguyena@didongviet.vn', N'123 Đường Tây Sơn, Hà Nội', N'Quản trị viên', '2020-01-10', 1),
    (N'Trần Thị B', '1995-08-22', N'Nữ', '0912345671', 'tranb@didongviet.vn', N'456 Đường Láng, Hà Nội', N'Nhân viên bán hàng', '2021-03-15', 1),
    (N'Lê Văn C', '1992-12-03', N'Nam', '0912345672', 'levc@didongviet.vn', N'789 Đường Ba Đình, Hà Nội', N'Nhân viên bán hàng', '2021-06-20', 1),
    (N'Phạm Thị D', '1998-02-14', N'Nữ', '0912345673', 'phamd@didongviet.vn', N'321 Đường Võ Văn Tần, TP.HCM', N'Nhân viên bán hàng', '2022-01-05', 1),
    (N'Đặng Văn E', '1991-07-28', N'Nam', '0912345674', 'dange@didongviet.vn', N'654 Đường Nguyễn Huệ, TP.HCM', N'Nhân viên bán hàng', '2021-09-12', 1),
    (N'Hoàng Thị F', '1996-04-10', N'Nữ', '0912345675', 'hoangf@didongviet.vn', N'987 Đường Trần Hưng Đạo, Đà Nẵng', N'Nhân viên bán hàng', '2022-02-28', 1),
    (N'Bùi Văn G', '1993-09-19', N'Nam', '0912345676', 'buig@didongviet.vn', N'111 Đường Phan Bội Châu, Đà Nẵng', N'Nhân viên bán hàng', '2021-11-30', 1),
    (N'Võ Thị H', '1997-01-25', N'Nữ', '0912345677', 'voh@didongviet.vn', N'222 Đường Cách Mạng Tháng 8, Hải Phòng', N'Nhân viên bán hàng', '2022-04-15', 1),
    (N'Tô Văn I', '1994-06-11', N'Nam', '0912345678', 'toi@didongviet.vn', N'333 Đường Hàng Dương, Hải Phòng', N'Nhân viên bán hàng', '2021-07-20', 1),
    (N'Nước Thị J', '1999-03-08', N'Nữ', '0912345679', 'nuocj@didongviet.vn', N'444 Đường Ngô Gia Tự, Hải Phòng', N'Nhân viên bán hàng', '2023-01-10', 1),
    (N'Trần Văn K', '1988-11-30', N'Nam', '0912345680', 'trankv@didongviet.vn', N'555 Đường Đồng Khởi, Cần Thơ', N'Quản lý kho', '2020-06-15', 1),
    (N'Lý Thị L', '1996-08-07', N'Nữ', '0912345681', 'lyl@didongviet.vn', N'666 Đường Hoa Bình, Cần Thơ', N'Nhân viên bán hàng', '2022-03-20', 1),
    (N'Phan Văn M', '1991-05-12', N'Nam', '0912345682', 'panm@didongviet.vn', N'777 Đường Tự Do, Cần Thơ', N'Nhân viên bán hàng', '2021-05-10', 1),
    (N'Triệu Thị N', '1998-10-05', N'Nữ', '0912345683', 'trieun@didongviet.vn', N'888 Đường Võ Thị Sáu, Biên Hòa', N'Nhân viên bán hàng', '2022-07-15', 1),
    (N'Kiều Văn O', '1993-02-28', N'Nam', '0912345684', 'kieuo@didongviet.vn', N'999 Đường Nguyễn Trãi, Biên Hòa', N'Nhân viên bán hàng', '2021-10-25', 1),
    (N'Cao Thị P', '1997-07-14', N'Nữ', '0912345685', 'caop@didongviet.vn', N'1010 Đường Lạc Long Quân, Hà Nội', N'Nhân viên bán hàng', '2022-08-30', 1),
    (N'Vũ Văn Q', '1990-12-20', N'Nam', '0912345686', 'vuq@didongviet.vn', N'1111 Đường Láng Hạ, Hà Nội', N'Nhân viên bán hàng', '2020-09-05', 1),
    (N'Đông Thị R', '1996-04-16', N'Nữ', '0912345687', 'dongr@didongviet.vn', N'1212 Đường Hoàng Cầu, Hà Nội', N'Nhân viên bán hàng', '2021-12-10', 1),
    (N'Sơn Văn S', '1992-09-09', N'Nam', '0912345688', 'sons@didongviet.vn', N'1313 Đường Ngô Thì Nhậm, Hà Nội', N'Nhân viên bán hàng', '2022-02-14', 1),
    (N'Anh Thị T', '1999-06-22', N'Nữ', '0912345689', 'anht@didongviet.vn', N'1414 Đường Trương Định, Hà Nội', N'Nhân viên bán hàng', '2023-03-20', 1);

GO

-- ========================================
-- INSERT BẢNG KHÁCH HÀNG (20 khách hàng)
-- ========================================

INSERT INTO KhachHang (HoTen, DienThoai, Email, DiaChi, TongChiTieu, TrangThai)
VALUES
    (N'Nguyễn Minh Anh', '0913456701', 'minhanh@email.com', N'456 Đường Tây Sơn, Hà Nội', 0, 1),
    (N'Trần Hữu Bằng', '0913456702', 'huuband@email.com', N'789 Đường Láng, Hà Nội', 0, 1),
    (N'Lê Thị Cẩm', '0913456703', 'thicamp@email.com', N'321 Đường Ba Đình, Hà Nội', 0, 1),
    (N'Phạm Quốc Dũng', '0913456704', 'quocdung@email.com', N'654 Đường Võ Văn Tần, TP.HCM', 0, 1),
    (N'Đặng Thúy Evy', '0913456705', 'thuyevy@email.com', N'987 Đường Nguyễn Huệ, TP.HCM', 0, 1),
    (N'Hoàng Anh Tuấn', '0913456706', 'anhtuand@email.com', N'111 Đường Trần Hưng Đạo, Đà Nẵng', 0, 1),
    (N'Bùi Thị Giang', '0913456707', 'thigiangle@email.com', N'222 Đường Phan Bội Châu, Đà Nẵng', 0, 1),
    (N'Võ Hồng Hà', '0913456708', 'hongha@email.com', N'333 Đường Cách Mạng Tháng 8, Hải Phòng', 0, 1),
    (N'Tô Quang Hùng', '0913456709', 'quanghung@email.com', N'444 Đường Hàng Dương, Hải Phòng', 0, 1),
    (N'Nước Văn Huy', '0913456710', 'vanhuy@email.com', N'555 Đường Ngô Gia Tự, Hải Phòng', 0, 1),
    (N'Trần Thanh Hương', '0913456711', 'thanhhang@email.com', N'666 Đường Đồng Khởi, Cần Thơ', 0, 1),
    (N'Lý Anh Hùng', '0913456712', 'anhhung@email.com', N'777 Đường Hoa Bình, Cần Thơ', 0, 1),
    (N'Phan Thị Huyền', '0913456713', 'thihuyen@email.com', N'888 Đường Tự Do, Cần Thơ', 0, 1),
    (N'Triệu Văn Huy', '0913456714', 'vanhuy2@email.com', N'999 Đường Võ Thị Sáu, Biên Hòa', 0, 1),
    (N'Kiều Thị Huyền', '0913456715', 'thihuyen2@email.com', N'1010 Đường Nguyễn Trãi, Biên Hòa', 0, 1),
    (N'Cao Anh Hùng', '0913456716', 'anhhung2@email.com', N'1111 Đường Lạc Long Quân, Hà Nội', 0, 1),
    (N'Vũ Thị Hương', '0913456717', 'thuong@email.com', N'1212 Đường Láng Hạ, Hà Nội', 0, 1),
    (N'Đông Anh Hùng', '0913456718', 'anhhung3@email.com', N'1313 Đường Hoàng Cầu, Hà Nội', 0, 1),
    (N'Sơn Thị Hằng', '0913456719', 'thihang@email.com', N'1414 Đường Ngô Thì Nhậm, Hà Nội', 0, 1),
    (N'Anh Văn Hùng', '0913456720', 'vanhung@email.com', N'1515 Đường Trương Định, Hà Nội', 0, 1);

GO

-- ========================================
-- INSERT BẢNG TÀI KHOẢN (5 tài khoản)
-- ========================================

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, MaNV, LoaiTK, TrangThai)
VALUES
    ('admin', 'admin123', 1, N'Admin', 1),
    ('staff1', 'staff123', 2, N'Nhân viên', 1),
    ('staff2', 'staff123', 3, N'Nhân viên', 1),
    ('staff3', 'staff123', 4, N'Nhân viên', 1),
    ('staff4', 'staff123', 5, N'Nhân viên', 1);

GO

PRINT N'✓ Dữ liệu mẫu đã được insert thành công!';
GO