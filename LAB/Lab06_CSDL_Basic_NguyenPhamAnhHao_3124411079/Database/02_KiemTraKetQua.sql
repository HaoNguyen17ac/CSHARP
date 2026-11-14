-- Nguyễn Phạm Anh Hào - MSSV 3124411079
-- Chỉ đọc dữ liệu để đối chiếu sau thao tác trên các form Lab06a và Lab06b.
-- Kết nối đúng SQL Server/instance đã ghi trong App.config của chương trình.
USE QLSinhVien;
GO
-- Dữ liệu khoa dùng để nhập mã khoa hợp lệ ở bài quản lý lớp.
SELECT MaKhoa, TenKhoa FROM dbo.Khoa ORDER BY MaKhoa;

-- Hai bảng được cập nhật trong Lab06a.
SELECT MaMonHoc, TenMonHoc FROM dbo.MonHoc ORDER BY MaMonHoc;
SELECT MaLop, TenLop, MaKhoa FROM dbo.Lop ORDER BY MaLop;

-- Hai bảng được cập nhật trong Lab06b.
SELECT MaSinhVien, HoTen, NgaySinh,
       YEAR(GETDATE()) - YEAR(NgaySinh) AS TuoiTheoNam, MaLop
FROM dbo.SinhVien ORDER BY MaSinhVien;

SELECT MaSinhVien, MaMonHoc, Diem
FROM dbo.Diem ORDER BY MaSinhVien, MaMonHoc;
GO
