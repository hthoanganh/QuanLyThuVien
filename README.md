# 📚 Library Management System (Hệ thống Quản lý Thư viện)

![.NET](https://img.shields.io/badge/.NET-Framework%204.8-purple)
![Language](https://img.shields.io/badge/Language-C%23-blue)
![Database](https://img.shields.io/badge/Database-SQL%20Server-red)
![IDE](https://img.shields.io/badge/IDE-Visual%20Studio-violet)
![Status](https://img.shields.io/badge/Status-Completed-success)

> **Dự án Báo cáo môn Lập trình Windows (WinForms)**
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

### 3. 📊 Báo cáo & Xuất Excel "VIP"
* Sử dụng thư viện `Interop.Excel` để xuất báo cáo danh sách sách, độc giả, tình hình mượn trả.
* **Format tự động:** Tự động căn chỉnh độ rộng cột, tô màu tiêu đề, kẻ khung bảng tính và thêm thông tin ngày giờ xuất file ngay trong code C#.

### 4. 📲 Công nghệ Mã QR (QR Code)
* Tự động tạo mã QR cho từng đầu sách chứa đầy đủ thông tin (Mã, Tên, Tác giả, Vị trí...).
* Hỗ trợ quét và quản lý sách nhanh chóng thông qua mã QR.

### 5. 💾 Sao lưu & Phục hồi Dữ liệu (Backup & Restore)
* Chức năng dành riêng cho Admin.
* Cho phép tạo file sao lưu `.bak` của cơ sở dữ liệu và phục hồi lại hệ thống khi có sự cố, thực hiện trực tiếp trên giao diện phần mềm mà không cần mở SQL Server Management Studio.

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
git clone [https://github.com/HoangAnh/QuanLyThuVien_Nhom7.git](https://github.com/HoangAnh/QuanLyThuVien_Nhom7.git)
