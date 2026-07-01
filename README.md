# Di Động Việt - Hệ thống Quản lý Bán hàng

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET Framework](https://img.shields.io/badge/.NET-v4.7.2-blue.svg)
![Status](https://img.shields.io/badge/status-Development-yellow.svg)

## 📱 Giới thiệu

**Di Động Việt** là ứng dụng quản lý bán hàng di động chuyên nghiệp, được xây dựng bằng **C# Windows Forms**. Ứng dụng cung cấp các tính năng toàn diện cho quản lý sản phẩm, bán hàng, nhập hàng và báo cáo thống kê.

## ✨ Tính năng chính

### 1️⃣ Quản lý Sản phẩm
- ✅ Thêm/sửa/xóa sản phẩm
- ✅ Quản lý giá nhập/bán
- ✅ Quản lý tồn kho
- ✅ Hỗ trợ hình ảnh sản phẩm
- ✅ Tìm kiếm nâng cao

### 2️⃣ Quản lý Hóa đơn
- ✅ Tạo hóa đơn bán hàng
- ✅ Quản lý chi tiết hóa đơn
- ✅ Tính toán tự động thành tiền
- ✅ Hỗ trợ giảm giá
- ✅ Lịch sử hóa đơn

### 3️⃣ Quản lý Nhập hàng
- ✅ Tạo phiếu nhập từ nhà cung cấp
- ✅ Quản lý chi tiết nhập hàng
- ✅ Theo dõi giá nhập
- ✅ Lịch sử nhập hàng

### 4️⃣ Báo cáo & Thống kê
- ✅ Doanh thu theo ngày/tháng/năm
- ✅ Sản phẩm bán chạy (Top 10)
- ✅ Báo cáo tồn kho
- ✅ **Xuất PDF** 📄
- ✅ **Xuất Excel** 📊

### 5️⃣ Xác thực người dùng
- ✅ Đăng nhập/Đăng xuất
- ✅ Quản lý phiên làm việc

## 🏗️ Kiến trúc ứng dụng

```
DiDongViet-SalesManagement/
├── GUI/                    # Giao diện người dùng (Windows Forms)
│   ├── frmLogin.cs        # Form đăng nhập
│   ├── frmProduct.cs      # Quản lý sản phẩm
│   ├── frmInvoice.cs      # Quản lý hóa đơn
│   ├── frmImport.cs       # Quản lý nhập hàng
│   └── frmReport.cs       # Báo cáo & Thống kê
├── BLL/                    # Business Logic Layer (Logic nghiệp vụ)
│   ├── InvoiceBLL.cs
│   ├── ImportBLL.cs
│   └── ProductBLL.cs
├── DAL/                    # Data Access Layer (Truy cập dữ liệu)
│   ├── DatabaseConnection.cs
│   ├── InvoiceDAL.cs
│   ├── ImportDAL.cs
│   ├── ProductDAL.cs
│   └── SupplierDAL.cs
├── DTO/                    # Data Transfer Object (Đối tượng truyền dữ liệu)
│   ├── InvoiceDTO.cs
│   ├── ImportDTO.cs
│   └── ProductDTO.cs
├── Resources/              # Tài nguyên
│   └── ProductImages/      # Ảnh sản phẩm
└── App.config             # Cấu hình ứng dụng
```

## 🛠️ Công nghệ sử dụng

- **Ngôn ngữ**: C# (.NET Framework 4.7.2)
- **Giao diện**: Windows Forms
- **Cơ sở dữ liệu**: SQL Server
- **Thư viện xuất file**:
  - **iTextSharp** - Xuất PDF
  - **EPPlus** - Xuất Excel

## 📋 Yêu cầu hệ thống

- Windows 7 trở lên
- .NET Framework 4.7.2
- SQL Server 2012 trở lên (hoặc SQL Server Express)
- Visual Studio 2019+ (để phát triển)

## 🚀 Hướng dẫn cài đặt

### 1️⃣ Clone repository
```bash
git clone https://github.com/charm0909/DiDongViet-SalesManagement.git
cd DiDongViet-SalesManagement
```

### 2️⃣ Cài đặt NuGet packages

Mở **Package Manager Console** trong Visual Studio và chạy:

```powershell
Install-Package iTextSharp
Install-Package EPPlus
```

### 3️⃣ Cấu hình cơ sở dữ liệu

Chỉnh sửa file `App.config`:

```xml
<add key="ConnectionString" value="Server=localhost;Database=DiDongVietDB;Integrated Security=true;" />
```

**Hoặc dùng SQL Authentication:**
```xml
<add key="ConnectionString" value="Server=localhost;Database=DiDongVietDB;User Id=sa;Password=your_password;" />
```

### 4️⃣ Tạo database

Chạy file SQL script để tạo cơ sở dữ liệu và bảng (sẽ được cung cấp riêng)

### 5️⃣ Chạy ứng dụng

Mở project trong Visual Studio → Nhấn **F5** hoặc **Run**

## 📊 Cấu trúc Database

### Các bảng chính:

| Bảng | Mô tả |
|------|-------|
| `HoaDon` | Hóa đơn bán hàng |
| `ChiTietHoaDon` | Chi tiết các sản phẩm trong hóa đơn |
| `PhieuNhap` | Phiếu nhập hàng từ nhà cung cấp |
| `ChiTietPhieuNhap` | Chi tiết sản phẩm nhập |
| `SanPham` | Danh sách sản phẩm |
| `NhaCungCap` | Danh sách nhà cung cấp |

## 📖 Hướng dẫn sử dụng

### Đăng nhập
1. Nhập tên đăng nhập và mật khẩu
2. Nhấn **Đăng nhập**

### Quản lý sản phẩm
1. Mở menu **Sản phẩm**
2. **Thêm**: Nhập thông tin sản phẩm → Nhấn **Thêm**
3. **Sửa**: Chọn sản phẩm từ danh sách → Sửa thông tin → Nhấn **Cập nhật**
4. **Xóa**: Chọn sản phẩm → Nhấn **Xóa** → Xác nhận
5. **Tìm kiếm**: Nhập từ khóa → Nhấn **Tìm**

### Tạo hóa đơn bán hàng
1. Mở menu **Hóa đơn**
2. Nhấn **Thêm hóa đơn mới**
3. Chọn khách hàng
4. Thêm sản phẩm vào chi tiết hóa đơn
5. Hệ thống tự động tính tổng tiền
6. Nhấn **Lưu**

### Xuất báo cáo
1. Mở menu **Báo cáo**
2. Chọn loại báo cáo (Doanh thu, Sản phẩm bán chạy, Tồn kho...)
3. Nhấn **Xem báo cáo**
4. **Xuất PDF** hoặc **Xuất Excel**
5. Chọn vị trí lưu file

## 🔐 Bảo mật

- ✅ Sử dụng **Parameterized Queries** để chống SQL Injection
- ✅ Xác thực người dùng bắt buộc
- ✅ Kiểm tra quyền hạn

## 🐛 Báo cáo lỗi

Nếu phát hiện lỗi, vui lòng tạo **Issue** trên GitHub hoặc liên hệ: **charm0909@example.com**

## 📝 License

Dự án này được phát hành dưới giấy phép **MIT**.

## 👥 Tác giả

- **vtttram0909-art** (charm0909)
- Phát triển bởi Di Động Việt Team

## 🙏 Cảm ơn

Cảm ơn tất cả những người đóng góp vào dự án này!

---

**Phiên bản**: v1.0.0  
**Cập nhật lần cuối**: 01/07/2026
