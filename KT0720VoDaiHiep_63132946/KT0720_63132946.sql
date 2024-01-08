CREATE DATABASE KT0720_63132946
GO
DROP DATABASE KT0720_63132946
GO
USE KT0720_63132946
GO
CREATE TABLE LOP
(
	MaLop nvarchar(10) PRIMARY KEY,
	TenLop nvarchar(50) NOT NULL
)
GO
CREATE TABLE SINHVIEN
(
	MaSV nvarchar(10) PRIMARY KEY,
	HoSV nvarchar(50) NOT NULL,
	TenSV nvarchar(50) NOT NULL,
	NgaySinh date,
	GioiTinh bit DEFAULT(1),
	AnhSV nvarchar(50),
	DiaChi nvarchar(100) NOT NULL,
	MaLop nvarchar(10) NOT NULL FOREIGN KEY REFERENCES LOP(MaLop)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO LOP VALUES('CNTT',N'Công Nghệ Thông Tin 1'),('QTKD',N'Quản Trị Kinh Doanh 2'),('NNA', N'Ngôn Ngữ Anh 3')
GO
INSERT SINHVIEN VALUES ('63132946', N'Võ Đại', N'Hiệp', CAST(N'2003-09-02' AS Date), 1, N'sinhvien.png', N'Diên Khánh, Khánh Hòa', N'CNTT')
INSERT SINHVIEN VALUES ('63134128', N'Phạm Thế', N'Hùng', CAST(N'2002-06-08' AS Date), 1, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'QTKD')
INSERT SINHVIEN VALUES ('63132986', N'Nguyễn Ngọc Anh', N'Thư', CAST(N'2003-12-11' AS Date), 0, N'sinhvien.png', N'Nha Trang, Khánh Hòa', N'NNA')
GO

CREATE PROCEDURE SinhVien_TimKiem
    @MaSV varchar(8) = NULL,
    @HoTen nvarchar(40) = NULL
AS
BEGIN
    DECLARE @SqlStr NVARCHAR(4000),
            @ParamList nvarchar(2000)

    SELECT @SqlStr = '
           SELECT * 
           FROM SINHVIEN
           WHERE  (1=1)
           '

    IF @MaSV <> ''
           SELECT @SqlStr = @SqlStr + '
                  AND (MaSV = '''+@MaSV+''')
                  '

    IF @HoTen IS NOT NULL
           SELECT @SqlStr = @SqlStr + '
                  AND (HoSV+'' ''+TenSV LIKE N''%'+@HoTen+'%'')
                  '
    EXEC SP_EXECUTESQL @SqlStr
END
