USE QLTV_Nhom7;
GO

-- BƯỚC 1: Chuyển toàn bộ phiếu mượn của 'admin1' và 'quanly' sang cho 'admin' giữ
-- (Để tránh mất dữ liệu mượn trả)
UPDATE PhieuMuon
SET MaTK = (SELECT MaTK FROM TaiKhoan WHERE TenDangNhap = 'admin')
WHERE MaTK IN (SELECT MaTK FROM TaiKhoan WHERE TenDangNhap IN ('admin1', 'quanly'));

-- BƯỚC 2: Sau khi đã "chuyển giao tài sản" xong, giờ xóa 2 ông này thoải mái
DELETE FROM TaiKhoan 
WHERE TenDangNhap IN ('admin1', 'quanly');

-- BƯỚC 3: Kiểm tra lại kết quả
SELECT * FROM TaiKhoan;