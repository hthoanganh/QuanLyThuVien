USE QLTV_Nhom7; 
GO

-- 1. CẬP NHẬT TÀI KHOẢN ADMIN
-- User: admin / Pass: admin (Mã MD5: 21232F...)
-- Quyền: Admin
UPDATE TaiKhoan
SET MatKhau = '21232F297A57A5A743894A0E4A801FC3', 
    QuyenHan = 'Admin',
    HoTen = N'Quản Trị Viên'
WHERE TenDangNhap = 'admin';

-- 2. CẬP NHẬT TÀI KHOẢN NHÂN VIÊN
-- User: nhanvien / Pass: 123 (Mã MD5: 202CB9...)
-- Quyền: NhanVien
UPDATE TaiKhoan
SET MatKhau = '202CB962AC59075B964B07152D234B70',
    QuyenHan = 'NhanVien',
    HoTen = N'Nhân Viên Thư Viện'
WHERE TenDangNhap = 'nhanvien';

-- 3. CẬP NHẬT TÀI KHOẢN QUẢN LÝ (Cho làm nhân viên luôn để test)
-- User: quanly / Pass: 123
UPDATE TaiKhoan
SET MatKhau = '202CB962AC59075B964B07152D234B70',
    QuyenHan = 'NhanVien',
    HoTen = N'Trần Quản Lý'
WHERE TenDangNhap = 'quanly';

-- Kiểm tra lại kết quả
SELECT * FROM TaiKhoan;