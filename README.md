# Hệ Thống Quản Lý Bán Hàng Di Động Việt

## 📱 Giới Thiệu

Hệ thống thông tin quản lý bán hàng cho chuỗi cửa hàng bán lẻ điện thoại di động **Di Động Việt**, phục vụ quản lý sản phẩm, nhân viên, khách hàng, bán hàng, nhập hàng, kho và báo cáo thống kê.

## 🛠️ Công Nghệ Sử Dụng

- **Ngôn ngữ:** C# (.NET Framework)
- **Giao diện:** Windows Forms (WinForms)
- **IDE:** Visual Studio 2022
- **Cơ sở dữ liệu:** Microsoft SQL Server
- **Kiến trúc:** 3-Tier (Presentation, Business Logic, Data Access)

## 📋 Chức Năng Chính

### 1. Đăng nhập & Phân quyền
- Xác thực người dùng (Username/Password)
- Phân quyền: Admin và Nhân viên bán hàng
- Mã hóa mật khẩu

### 2. Dashboard
- Thống kê tổng quát (sản phẩm, tồn kho, doanh thu hôm nay)
- Giao diện trực quan với các thẻ thông tin
- Hiển thị tên người dùng đang đăng nhập

### 3. Quản lý Sản phẩm
- Thêm, sửa, xóa, tìm kiếm sản phẩm
- Quản lý thông tin: mã SP, tên, hãng, loại, giá, tồn kho, màu sắc, bảo hành
- Lọc theo hãng, loại, khoảng giá

### 4. Quản lý Nhân viên
- Thêm, sửa, xóa, tìm kiếm nhân viên
- Quản lý thông tin cá nhân, chức vụ, ngày vào làm

### 5. Quản lý Khách hàng
- Thêm, sửa, xóa, tìm kiếm khách hàng
- Tự động tính tổng chi tiêu

### 6. Bán hàng (Hóa đơn)
- Lập hóa đơn bán hàng
- Chọn khách hàng, sản phẩm, tính tổng tiền
- In hóa đơn
- Cập nhật tồn kho tự động

### 7. Nhập hàng (Phiếu nhập)
- Lập phiếu nhập hàng
- Quản lý nhà cung cấp, sản phẩm, số lượng
- Tự động cập nhật tồn kho

### 8. Quản lý Kho
- Xem danh sách tồn kho
- Cảnh báo sản phẩm sắp hết hàng
- Lịch sử nhập/xuất kho

### 9. Báo cáo & Thống kê
- Báo cáo doanh thu theo ngày/tháng/năm
- Báo cáo sản phẩm bán chạy
- Báo cáo tồn kho

## 📁 Cấu Trúc Project

```
DiDongViet-SalesManagement/
├── Database/
│   ├── CreateDB.sql              # Script tạo database
│   ├── InsertData.sql            # Script dữ liệu mẫu
│   └── StoredProcedure.sql       # Script Stored Procedures
├── GUI/                          # Các Form giao diện
│   ├── frmLogin.cs              # Form đăng nhập
│   ├── frmMainDashboard.cs      # Form dashboard chính
│   ├── frmProduct.cs            # Quản lý sản phẩm
│   ├── frmEmployee.cs           # Quản lý nhân viên
│   ├── frmCustomer.cs           # Quản lý khách hàng
│   ├── frmInvoice.cs            # Quản lý hóa đơn
│   ├── frmImport.cs             # Quản lý phiếu nhập
│   ├── frmWarehouse.cs          # Quản lý kho
│   └── frmReport.cs             # Báo cáo thống kê
├── BLL/                          # Business Logic Layer
│   ├── ProductBLL.cs
│   ├── EmployeeBLL.cs
│   ├── CustomerBLL.cs
│   ├── InvoiceBLL.cs
│   └── ...
├── DAL/                          # Data Access Layer
│   ├── DatabaseConnection.cs
│   ├── ProductDAL.cs
│   ├── EmployeeDAL.cs
│   └── ...
├── DTO/                          # Data Transfer Objects
│   ├── ProductDTO.cs
│   ├── EmployeeDTO.cs
│   ├── CustomerDTO.cs
│   └── ...
├── Resources/                    # Hình ảnh, icon
│   └── Images/
└── DiDongViet-SalesManagement.sln
```

## 🚀 Hướng Dẫn Cài Đặt

### Yêu Cầu
- Visual Studio 2022 (với .NET Desktop Development)
- SQL Server 2019 hoặc 2022
- .NET Framework 4.8+

### Các Bước

#### 1. Tạo Database
```sql
-- Mở SQL Server Management Studio (SSMS)
-- Chạy script CreateDB.sql để tạo database
-- Chạy script InsertData.sql để insert dữ liệu mẫu
-- Chạy script StoredProcedure.sql để tạo stored procedures
```

#### 2. Cấu Hình Kết Nối Database
Sửa file `DatabaseConnection.cs` trong DAL:
```csharp
private static string connectionString = 
    @"Server=YOUR_SERVER_NAME;Database=DiDongVietDB;User Id=sa;Password=YOUR_PASSWORD;";
```

#### 3. Mở Project
- Mở file `.sln` trong Visual Studio 2022
- Restore NuGet packages (nếu có)
- Build solution (Ctrl + Shift + B)

#### 4. Chạy Ứng Dụng
- Nhấn F5 hoặc Debug > Start Debugging
- Đăng nhập với tài khoản: `admin` / `admin123`

## 👤 Tài Khoản Demo

| Tên Đăng Nhập | Mật Khẩu | Quyền |
|---|---|---|
| admin | admin123 | Admin |
| staff1 | staff123 | Nhân viên |
| staff2 | staff123 | Nhân viên |
| staff3 | staff123 | Nhân viên |
| staff4 | staff123 | Nhân viên |

## 🎨 Giao Diện

- **Màu chủ đạo:** Đỏ (Di Động Việt), Trắng, Xám đậm
- **Font:** Segoe UI, Arial (hỗ trợ tiếng Việt có dấu)
- **Phong cách:** Modern, trực quan, responsive
- **Icon:** Font Awesome / Material Design Icons

## 📊 Dữ Liệu Mẫu

- **20 Sản phẩm**: iPhone, Samsung, Xiaomi, Oppo, Vivo
- **20 Nhân viên**: Quản trị viên + Nhân viên bán hàng
- **20 Khách hàng**: Khách hàng mẫu
- **5 Hãng**: Apple, Samsung, Xiaomi, Oppo, Vivo
- **5 Loại**: Điện thoại, Tai nghe, Sạc, Ốp lưng, Pin dự phòng
- **5 Nhà cung cấp**: NCC mẫu
- **5 Tài khoản**: Admin + 4 Nhân viên

## 🔒 Bảo Mật

- Mã hóa mật khẩu
- Xác thực người dùng
- Phân quyền truy cập
- Validate dữ liệu đầu vào
- Xử lý lỗi toàn diện

## 📝 Ghi Chú

- Hỗ trợ tiếng Việt có dấu
- Cân nhắc tối ưu hóa hiệu suất
- Dữ liệu nhất quán giữa các bảng
- Code tuân thủ chuẩn 3-Tier Architecture

## 👨‍💻 Nhà Phát Triển

**charm0909** - Đề tài Thực hành Nghề Nghiệp (THNN)

## 📄 License

MIT License

---

**Ngày cập nhật:** Tháng 7, 2026
