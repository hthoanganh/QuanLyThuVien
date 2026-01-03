# 📚 Library Management System (Hệ thống Quản lý Thư viện)

![.NET](https://img.shields.io/badge/.NET-Framework%204.8-purple)
![Language](https://img.shields.io/badge/Language-C%23-blue)
![Database](https://img.shields.io/badge/Database-SQL%20Server-red)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-violet)
![Status](https://img.shields.io/badge/Status-Completed-success)

> **Dự án Báo cáo môn Lập trình .NET (C# - WinForms)**
>
> Một giải pháp quản lý thư viện toàn diện, hiện đại, tích hợp các công nghệ xử lý dữ liệu nâng cao và tối ưu hóa trải nghiệm người dùng.

## 🌟 Giới thiệu (Overview)

Phần mềm được xây dựng nhằm giải quyết bài toán quản lý sách, độc giả và quy trình mượn trả tại các thư viện trường học/công cộng. Hệ thống tập trung vào tính **chính xác**, **bảo mật** và **trải nghiệm mượt mà** thông qua việc áp dụng các kỹ thuật lập trình bất đồng bộ (Asynchronous).

## 🚀 Công nghệ sử dụng (Tech Stack)

* **Ngôn ngữ:** C# (Windows Forms Application).
* **Cơ sở dữ liệu:** Microsoft SQL Server.
* **Truy vấn dữ liệu:** Entity Framework (ORM) - Giúp thao tác dữ liệu an toàn, tránh SQL Injection.
* **Giao diện (UI):** DevExpress & Standard WinForms Controls.
* **Công cụ khác:**
    * `Microsoft.Office.Interop.Excel`: Xuất báo cáo Excel chuyên nghiệp.
    * `QRCoder`: Tạo mã QR định danh cho sách.
    * `System.Security.Cryptography`: Mã hóa mật khẩu MD5.

## 🔥 Tính năng nâng cao (Key Features)

Dự án không chỉ dừng lại ở các chức năng CRUD cơ bản mà còn tích hợp nhiều tính năng nâng cao:

### 1. 🛡️ Hệ thống Bảo mật & Phân quyền
* **Mã hóa MD5:** Mật khẩu người dùng được mã hóa một chiều trước khi lưu vào Database, đảm bảo an toàn tuyệt đối ngay cả khi dữ liệu bị lộ.
* **Phân quyền chặt chẽ (RBAC):**
    * **Admin:** Toàn quyền hệ thống (Quản lý nhân viên, Sao lưu/Phục hồi dữ liệu, Cấu hình).
    * **Thủ thư:** Quản lý sách, Độc giả, Mượn trả.
    * **Độc giả:** Tra cứu sách, Xem lịch sử mượn.

### 2. ⚡ Xử lý Bất đồng bộ (Async/Await)
* Áp dụng kỹ thuật `async/await` cho các tác vụ nặng (như Load dữ liệu lớn, Gửi email, Kết nối Database).
* Tích hợp **Loading Animation** giúp giao diện không bị "đơ" (Not Responding) khi xử lý tác vụ lâu, mang lại trải nghiệm chuyên nghiệp.

### 3. 📊 Báo cáo & Xuất Excel (Report)
* **Nút Report thông minh:** Tích hợp tính năng xuất báo cáo nhanh tại các màn hình Quản lý Sách và Độc giả.
* **Xuất Excel "VIP":** Sử dụng thư viện `Interop.Excel` để xuất danh sách ra file Excel chuẩn định dạng.
* **Format tự động:** Code C# tự động căn chỉnh độ rộng cột, tô màu tiêu đề, kẻ khung bảng tính và thêm thông tin ngày giờ xuất file.

### 4. 📲 Công nghệ Mã QR (QR Code)
* Tự động tạo mã QR cho từng đầu sách chứa đầy đủ thông tin (Mã, Tên, Tác giả, Vị trí...).
* Hỗ trợ quét và quản lý sách nhanh chóng thông qua mã QR.

### 5. 💾 Sao lưu & Phục hồi Dữ liệu (Backup & Restore)
* Chức năng dành riêng cho Admin.
* Cho phép tạo file sao lưu `.bak` của cơ sở dữ liệu và phục hồi lại hệ thống khi có sự cố, thực hiện trực tiếp trên giao diện phần mềm mà không cần mở SQL Server Management Studio.

### 6. 🔎 Tra cứu & Quản lý Nghiệp vụ (Search & CRUD)
* **Tìm kiếm đa tiêu chí:** * *Sách:* Tìm theo Mã sách, Tên sách, Thể loại, Tác giả...
    * *Độc giả:* Tìm theo Mã độc giả, Tên, Số điện thoại.
* **Thêm/Sửa/Xóa (CRUD):** Giao diện nhập liệu được thiết kế tối ưu, tự động kiểm tra (Validate) dữ liệu trống hoặc sai định dạng trước khi lưu vào Database.
* **Cập nhật realtime:** Danh sách dữ liệu tự động làm mới ngay sau khi thao tác thành công.

## 📸 Hình ảnh Demo (Screenshots)

Dưới đây là hình ảnh thực tế của phần mềm:

| Đăng nhập (Login) | Quản lý Kho sách (Book Mgmt) |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/8af19634-31fc-4ffc-8b25-6a295e4341db" width="100%" /> | <img src="https://github.com/user-attachments/assets/c88a3ba3-053a-477c-98eb-69bea300ab34" width="100%" /> |

| Tạo mã QR | Xuất Excel (Báo cáo) |
|:---:|:---:|
| <img src="https://github.com/user-attachments/assets/f785462c-c490-4a16-bf5b-bba5111a7315" width="100%" /> | <img src="https://github.com/user-attachments/assets/f92c04d3-e1ba-44ef-8d3f-4751676c0804" width="100%" /> <br> <br> <img src="https://github.com/user-attachments/assets/a400153e-b5cb-41c6-bf89-86354c7bc0cf" width="100%" /> |

## ⚙️ Hướng dẫn cài đặt (Installation)

Để chạy được dự án trên máy cá nhân, vui lòng làm theo các bước sau:

**Bước 1: Clone dự án**
```bash
git clone https://github.com/HoangAnh/QuanLyThuVien.git
```

**Bước 2: Triển khai Cơ sở dữ liệu (Database Setup)**

Dự án đã đính kèm sẵn file Script SQL (`Database_QLTV.sql`) chứa toàn bộ cấu trúc bảng và dữ liệu mẫu.
1.  Mở **SQL Server Management Studio (SSMS)**.
2.  Chọn **File** > **Open** > **File...** và tìm đến file `Database_QLTV.sql` trong thư mục dự án vừa tải về.
3.  Nhấn nút **Execute** (hoặc phím `F5`) để chạy Script tạo cơ sở dữ liệu `QLTV_Nhom7`.

**Bước 3: Cấu hình kết nối (Connection String)**

Để phần mềm kết nối được với SQL Server trên máy bạn, cần cập nhật file cấu hình:
1.  Mở dự án trong Visual Studio.
2.  Mở file `App.config` (nằm trong Solution Explorer).
3.  Tìm thẻ `<connectionStrings>` và sửa lại mục `Data Source` cho phù hợp:
    ```xml
    <add name="QLTV_Connect" connectionString="Data Source=.;Initial Catalog=QLTV_Nhom7;Integrated Security=True" ... />
    
    <add name="QLTV_Connect" connectionString="Data Source=.\SQLEXPRESS;Initial Catalog=QLTV_Nhom7;Integrated Security=True" ... />
    ```

**Bước 4: Khởi chạy ứng dụng**
1.  Tại Visual Studio, nhấn menu **Build** > **Rebuild Solution** để nạp các thư viện (DevExpress, QR...).
2.  Nhấn **Start** (hoặc `F5`) để chạy chương trình.

---

## 🔐 Tài khoản Demo (Default Credentials)

Hệ thống đã nạp sẵn các tài khoản mẫu tương ứng với dữ liệu thực tế trong Database:

| Quyền hạn (Role) | Tài khoản (User) | Mật khẩu (Pass) | Mô tả quyền |
| :--- | :--- | :--- | :--- |
| **Admin (Quản trị)** | `admin` | `admin` | **Toàn quyền hệ thống**: Sao lưu/Phục hồi, Quản lý nhân viên, Thống kê. |
| **Nhân viên (Thủ thư)** | `nhanvien` | `123` | Quản lý Sách, Độc giả, Thực hiện Mượn - Trả. |
| **Độc giả** | `docgia` | `123456` | Tra cứu sách, Xem lịch sử mượn cá nhân. |

> **Lưu ý:** Mật khẩu trong Database đã được mã hóa MD5. Để đổi mật khẩu, vui lòng sử dụng chức năng "Đổi mật khẩu" trong phần mềm để đảm bảo mã hóa đúng chuẩn.

---

## 💻 Yêu cầu hệ thống (Prerequisites)

* **Hệ điều hành:** Windows 10/11 (64-bit).
* **Công cụ lập trình:** Visual Studio 2019 hoặc 2022.
* **Framework:** .NET Framework 4.8.
* **Cơ sở dữ liệu:** SQL Server 2022 (Từ 2014 trở lên).
* **Thư viện:** DevExpress (đã tích hợp trong bin), QRCoder, Excel Interop.

---

## ⚠️ Khắc phục sự cố (Troubleshooting)

* **Lỗi kết nối CSDL:** Kiểm tra kỹ `Data Source` trong `App.config` xem đã đúng tên máy SQL của bạn chưa (Ví dụ: `DESKTOP-ABC\SQLEXPRESS`).
* **Lỗi khi Backup dữ liệu:** Hãy chạy phần mềm dưới quyền Admin (*Run as Administrator*) để có quyền ghi file vào ổ đĩa hệ thống.
* **Lỗi giao diện (Designer):** Nếu mở Form bị lỗi trắng xóa, hãy chuột phải vào Project -> **Clean Solution**, sau đó **Rebuild** lại.

---

## 👨‍💻 Tác giả (Authors)

Dự án được thực hiện bởi:

* ⭐️ **Hoàng Anh** - *Trưởng nhóm (Leader) / Fullstack Dev*

---
<p align="center">
  <i>Cảm ơn mọi người đã theo dõi! Nếu thấy dự án hữu ích, hãy để lại 1 Star ⭐ nhé!</i>
</p>
