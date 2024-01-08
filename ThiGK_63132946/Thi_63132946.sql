CREATE DATABASE Thi_63132946
GO
USE Thi_63132946
GO
CREATE TABLE LOAIQUANAO 
(
	MaLQA nvarchar(10) PRIMARY KEY,
	TenLQA nvarchar(100) NOT NULL
)
GO
CREATE TABLE QUANAO
(
	MaQA nvarchar(10) PRIMARY KEY,
	TenQA nvarchar(100) NOT NULL,
	MoTa nvarchar(100),
	XuatXu bit DEFAULT(1),
	DonGia float NOT NULL,
	AnhMH nvarchar(50),
	MaLQA nvarchar(10) NOT NULL FOREIGN KEY REFERENCES LOAIQUANAO(MaLQA)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
INSERT INTO LOAIQUANAO VALUES('MX',N'Quần áo mùa Xuân'),('MH',N'Quần áo mùa Hè'),('MD', N'Quần áo mùa Đông')
GO
INSERT QUANAO VALUES ('A001', N'Áo thun', N'Mát mẻ, thoải mái',1,100000, N'anh.jpg', 'MX')
INSERT QUANAO VALUES ('A002', N'Áo thể thao', N'Năng động, trẻ trung',1,150000, N'anh.jpg', 'MH')
INSERT QUANAO VALUES ('A003', N'Áo khoác', N'Giữ nhiệt, ấm áp',0,230000, N'anh.jpg', 'MD')
GO
CREATE PROCEDURE QuanAo_TimKiem
    @MaQA varchar(10) = NULL,
    @TenQA nvarchar(100) = NULL
AS
BEGIN
    DECLARE @SqlStr NVARCHAR(4000),
            @ParamList nvarchar(2000)

    SELECT @SqlStr = '
           SELECT * 
           FROM QUANAO
           WHERE  (1=1)
           '

    IF @MaQA <> ''
           SELECT @SqlStr = @SqlStr + '
                  AND (MaQA = '''+@MaQA+''')
                  '

    IF @TenQA IS NOT NULL
           SELECT @SqlStr = @SqlStr + '
                  AND (TenQA LIKE N''%'+@TenQA+'%'')
                  '
    EXEC SP_EXECUTESQL @SqlStr
END
