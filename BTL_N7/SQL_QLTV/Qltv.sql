USE master;
GO

-- 1. Xóa Database cũ đi làm lại cho sạch (Nếu đang tồn tại)
IF EXISTS (SELECT name FROM sys.databases WHERE name = 'QLTV_Nhom7')
BEGIN
    ALTER DATABASE QLTV_Nhom7 SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QLTV_Nhom7;
END
GO

CREATE DATABASE QLTV_Nhom7;
GO
USE QLTV_Nhom7;
GO

-- 2. Tạo bảng Độc Giả (Dữ liệu chuẩn)
CREATE TABLE DocGia (
    MaDocGia INT IDENTITY(1,1) PRIMARY KEY,
    TenDocGia NVARCHAR(100) NOT NULL,
    DiaChi NVARCHAR(200),
    SoDienThoai VARCHAR(15),
    Lop NVARCHAR(20),  
    Khoa NVARCHAR(50)  
);

-- 3. Tạo bảng Sách
CREATE TABLE Sach (
    MaSach INT IDENTITY(1,1) PRIMARY KEY,
    TenSach NVARCHAR(200) NOT NULL,
    TacGia NVARCHAR(100),
    TheLoai NVARCHAR(50), 
    NamXB INT,            
    NhaXB NVARCHAR(100),  
    SoLuong INT DEFAULT 0 
);

-- 4. Tạo bảng Tài Khoản (Đã thêm cột HoTen từ file SQL+)
CREATE TABLE TaiKhoan (
    MaTK INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL,
    MatKhau VARCHAR(50) NOT NULL,
    QuyenHan NVARCHAR(20),
    HoTen NVARCHAR(100) DEFAULT N'Chưa cập nhật' -- Cột mới thêm
);

-- 5. Tạo bảng Phiếu Mượn (Đã thêm cột NgayTra từ file QLTVBOSUNG)
CREATE TABLE PhieuMuon (
    MaPhieu INT IDENTITY(1,1) PRIMARY KEY,
    NgayMuon DATETIME DEFAULT GETDATE(),
    HanTra DATETIME,
    NgayTra DATETIME NULL, -- Cột mới thêm
    TrangThai NVARCHAR(50) DEFAULT N'Đang mượn', -- Đã sửa tiếng Việt
    MaDocGia INT,
    MaTK INT, 
    FOREIGN KEY (MaDocGia) REFERENCES DocGia(MaDocGia),
    FOREIGN KEY (MaTK) REFERENCES TaiKhoan(MaTK)
);

-- 6. Tạo bảng Chi Tiết (Đã thêm TienPhat, NgayTraSach từ file SQL++)
CREATE TABLE ChiTietPhieuMuon (
    MaPhieu INT,
    MaSach INT,
    SoLuongMuon INT DEFAULT 1,
    GhiChu NVARCHAR(100),
    TienPhat DECIMAL(18, 0) DEFAULT 0, -- Cột mới thêm (quản lý tiền phạt)
    NgayTraSach DATETIME NULL,         -- Cột mới thêm (trả từng cuốn)
    PRIMARY KEY (MaPhieu, MaSach),
    FOREIGN KEY (MaPhieu) REFERENCES PhieuMuon(MaPhieu),
    FOREIGN KEY (MaSach) REFERENCES Sach(MaSach)
);
GO

-- --- PHẦN QUAN TRỌNG: DỮ LIỆU TIẾNG VIỆT CHUẨN ---

INSERT INTO DocGia (TenDocGia, DiaChi, SoDienThoai, Lop, Khoa) VALUES 
(N'Nguyễn Văn An', N'Hà Nội', '0901111111', 'CNTT1', N'CNTT'),
(N'Trần Thị Bích', N'Hồ Chí Minh', '0902222222', 'KTE1', N'Kinh Tế'),
(N'Lê Văn Cường', N'Đà Nẵng', '0903333333', 'XDG1', N'Xây Dựng'),
(N'Phạm Thị Duyên', N'Cần Thơ', '0904444444', 'NNA1', N'Ngoại Ngữ'),
(N'Hoàng Văn Em', N'Hải Phòng', '0905555555', 'CNTT2', N'CNTT'),
(N'Vũ Thị Phương', N'Nghệ An', '0906666666', 'DL1', N'Du Lịch');

INSERT INTO Sach (TenSach, TacGia, TheLoai, NamXB, NhaXB, SoLuong) VALUES 
(N'Lập trình C# cơ bản', N'Microsoft', N'Giáo trình', 2020, N'NXB Giáo Dục', 50),
(N'SQL Server toàn tập', N'Đỗ Trung Tuấn', N'Giáo trình', 2019, N'NXB Bách Khoa', 30),
(N'Đắc Nhân Tâm', N'Dale Carnegie', N'Kỹ năng', 2021, N'NXB Trẻ', 100),
(N'Nhà Giả Kim', N'Paulo Coelho', N'Văn học', 2018, N'NXB Văn Học', 40),
(N'Harry Potter tập 1', N'J.K. Rowling', N'Thiếu nhi', 2005, N'NXB Kim Đồng', 20),
(N'Dế Mèn Phiêu Lưu Ký', N'Tô Hoài', N'Thiếu nhi', 2015, N'NXB Kim Đồng', 60);

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, QuyenHan, HoTen) VALUES 
('admin', '123', 'Admin', N'Quản Trị Viên'),
('nhanvien', '123', 'NhanVien', N'Nguyễn Văn Nhân Viên'),
('quanly', '123', 'QuanLy', N'Trần Quản Lý');

INSERT INTO PhieuMuon (NgayMuon, HanTra, MaDocGia, MaTK) VALUES 
('2023-10-01', '2023-10-15', 1, 1),
('2023-10-02', '2023-10-16', 2, 2),
('2023-10-03', '2023-10-17', 3, 3),
('2023-10-04', '2023-10-18', 4, 1),
('2023-10-05', '2023-10-19', 5, 2),
('2023-10-06', '2023-10-20', 6, 3);

INSERT INTO ChiTietPhieuMuon (MaPhieu, MaSach, SoLuongMuon, GhiChu) VALUES 
(1, 1, 1, N'Mới'),
(1, 2, 1, N'Cũ'),
(2, 3, 2, N''),
(3, 4, 1, N''),
(4, 5, 1, N'Rách bìa'),
(5, 6, 1, N'');

SELECT * FROM DocGia; -- Chạy xong nó sẽ hiện bảng ra để bạn kiểm tra