-- Họ tên: Nguyễn Phạm Anh Hào - MSSV: 3124411079
-- CSDL dùng chung cho Lab06a và Lab06b.
-- Chạy toàn bộ tập tin trong SQL Server Management Studio (SSMS).
-- Script không DROP DATABASE/TABLE và không xóa dữ liệu đang có.
-- Nếu đã có QLSinhVien khác cấu trúc, cần dùng một CSDL riêng và sửa App.config.
USE master;
GO
IF DB_ID(N'QLSinhVien') IS NULL
    CREATE DATABASE QLSinhVien;
GO
USE QLSinhVien;
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;

IF OBJECT_ID(N'dbo.Khoa', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Khoa
    (
        MaKhoa VARCHAR(10) NOT NULL CONSTRAINT PK_Khoa PRIMARY KEY,
        TenKhoa NVARCHAR(100) NOT NULL
    );
END;

IF OBJECT_ID(N'dbo.Lop', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Lop
    (
        MaLop VARCHAR(10) NOT NULL CONSTRAINT PK_Lop PRIMARY KEY,
        TenLop NVARCHAR(100) NOT NULL,
        MaKhoa VARCHAR(10) NOT NULL,
        CONSTRAINT FK_Lop_Khoa FOREIGN KEY (MaKhoa) REFERENCES dbo.Khoa(MaKhoa)
    );
END;

IF OBJECT_ID(N'dbo.SinhVien', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.SinhVien
    (
        MaSinhVien VARCHAR(10) NOT NULL CONSTRAINT PK_SinhVien PRIMARY KEY,
        HoTen NVARCHAR(100) NOT NULL,
        NgaySinh DATE NOT NULL,
        MaLop VARCHAR(10) NOT NULL,
        CONSTRAINT FK_SinhVien_Lop FOREIGN KEY (MaLop) REFERENCES dbo.Lop(MaLop)
    );
END;

IF OBJECT_ID(N'dbo.MonHoc', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.MonHoc
    (
        MaMonHoc VARCHAR(10) NOT NULL CONSTRAINT PK_MonHoc PRIMARY KEY,
        TenMonHoc NVARCHAR(100) NOT NULL
    );
END;

IF OBJECT_ID(N'dbo.Diem', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Diem
    (
        MaSinhVien VARCHAR(10) NOT NULL,
        MaMonHoc VARCHAR(10) NOT NULL,
        Diem DECIMAL(4,2) NOT NULL,
        CONSTRAINT PK_Diem PRIMARY KEY (MaSinhVien, MaMonHoc),
        CONSTRAINT FK_Diem_SinhVien FOREIGN KEY (MaSinhVien)
            REFERENCES dbo.SinhVien(MaSinhVien),
        CONSTRAINT FK_Diem_MonHoc FOREIGN KEY (MaMonHoc)
            REFERENCES dbo.MonHoc(MaMonHoc),
        CONSTRAINT CK_Diem_GiaTri CHECK (Diem BETWEEN 0 AND 10)
    );
END;

-- Chỉ bổ sung mã còn thiếu: chạy lại không nhân đôi dữ liệu mẫu.
INSERT INTO dbo.Khoa (MaKhoa, TenKhoa)
SELECT v.MaKhoa, v.TenKhoa
FROM (VALUES
    ('CNTT', N'Công nghệ thông tin'),
    ('QTKD', N'Quản trị kinh doanh'),
    ('KETOAN', N'Kế toán'),
    ('DTVT', N'Điện tử viễn thông'),
    ('NGONNGU', N'Ngoại ngữ')
) AS v(MaKhoa, TenKhoa)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Khoa k WHERE k.MaKhoa = v.MaKhoa);

INSERT INTO dbo.Lop (MaLop, TenLop, MaKhoa)
SELECT v.MaLop, v.TenLop, v.MaKhoa
FROM (VALUES
    ('DCT1241', N'Công nghệ thông tin 1 khóa 2024', 'CNTT'),
    ('DCT1242', N'Công nghệ thông tin 2 khóa 2024', 'CNTT'),
    ('DKD1241', N'Quản trị kinh doanh 1 khóa 2024', 'QTKD'),
    ('DKT1241', N'Kế toán 1 khóa 2024', 'KETOAN'),
    ('DNN1241', N'Ngôn ngữ Anh 1 khóa 2024', 'NGONNGU')
) AS v(MaLop, TenLop, MaKhoa)
WHERE NOT EXISTS (SELECT 1 FROM dbo.Lop l WHERE l.MaLop = v.MaLop);

INSERT INTO dbo.SinhVien (MaSinhVien, HoTen, NgaySinh, MaLop)
SELECT v.MaSinhVien, v.HoTen, CONVERT(DATE, v.NgaySinh, 112), v.MaLop
FROM (VALUES
    ('SV001', N'Nguyễn An', '20060510', 'DCT1241'),
    ('SV002', N'Trần Bình', '20060115', 'DCT1242'),
    ('SV003', N'Lê Chi', '20060820', 'DKD1241'),
    ('SV004', N'Phạm Dũng', '20061201', 'DKT1241'),
    ('SV005', N'Võ Hà', '20060325', 'DNN1241')
) AS v(MaSinhVien, HoTen, NgaySinh, MaLop)
WHERE NOT EXISTS (SELECT 1 FROM dbo.SinhVien s WHERE s.MaSinhVien = v.MaSinhVien);

INSERT INTO dbo.MonHoc (MaMonHoc, TenMonHoc)
SELECT v.MaMonHoc, v.TenMonHoc
FROM (VALUES
    ('CSHARP', N'Ngôn ngữ lập trình C#'),
    ('SQL', N'Hệ quản trị cơ sở dữ liệu'),
    ('CSDL', N'Cơ sở dữ liệu'),
    ('CTDL', N'Cấu trúc dữ liệu'),
    ('LTWEB', N'Lập trình Web')
) AS v(MaMonHoc, TenMonHoc)
WHERE NOT EXISTS (SELECT 1 FROM dbo.MonHoc m WHERE m.MaMonHoc = v.MaMonHoc);

INSERT INTO dbo.Diem (MaSinhVien, MaMonHoc, Diem)
SELECT v.MaSinhVien, v.MaMonHoc, v.Diem
FROM (VALUES
    ('SV001', 'CSHARP', 8.50),
    ('SV002', 'SQL', 7.00),
    ('SV003', 'CSDL', 8.00),
    ('SV004', 'CTDL', 6.50),
    ('SV005', 'LTWEB', 9.00)
) AS v(MaSinhVien, MaMonHoc, Diem)
WHERE NOT EXISTS (
    SELECT 1 FROM dbo.Diem d
    WHERE d.MaSinhVien = v.MaSinhVien AND d.MaMonHoc = v.MaMonHoc
);

COMMIT TRANSACTION;
GO
-- Trên CSDL mới, mỗi bảng có đúng 5 mẫu tin như yêu cầu của đề.
SELECT N'Khoa' AS Bang, COUNT(*) AS SoMauTin FROM dbo.Khoa
UNION ALL SELECT N'Lop', COUNT(*) FROM dbo.Lop
UNION ALL SELECT N'SinhVien', COUNT(*) FROM dbo.SinhVien
UNION ALL SELECT N'MonHoc', COUNT(*) FROM dbo.MonHoc
UNION ALL SELECT N'Diem', COUNT(*) FROM dbo.Diem;
GO
