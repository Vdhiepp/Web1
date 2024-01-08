CREATE DATABASE QUANLYQUANCAFE_63132946
GO
USE QUANLYQUANCAFE_63132946
GO
DROP DATABASE QUANLYQUANCAFE_63132946
GO
CREATE TABLE LOAIKHACHHANG (
	maLoaiKH NVARCHAR(10) PRIMARY KEY,
	tenLoaiKH NVARCHAR(100) NOT NULL,
	giamGia INT NOT NULL
)
GO
CREATE TABLE KHACHHANG (
	maKH NVARCHAR(10) PRIMARY KEY,
	hoKH NVARCHAR(100) NOT NULL,
	tenKH NVARCHAR(100) NOT NULL,
	diaChi NVARCHAR(100) NOT NULL,
	diemTichLuy INT NOT NULL,
	maLoaiKH NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES LOAIKHACHHANG(MaLoaiKH)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
CREATE TABLE QUANTRI (
	Email NVARCHAR(50) PRIMARY KEY,
	Admin BIT,
	HoTen NVARCHAR(50),
	Password NVARCHAR(50)
)
GO
CREATE TABLE CHUCVU (
	maCV NVARCHAR(10) PRIMARY KEY,
	tenCV NVARCHAR(100) NOT NULL,
)
GO
CREATE TABLE NHANVIEN (
	maNV NVARCHAR(10) PRIMARY KEY,
	hoNV NVARCHAR(50) NOT NULL,
	tenNV NVARCHAR(10) NOT NULL,
	gioiTinh BIT DEFAULT(1),
	ngaySinh DATE,
	luong INT,
	anhNV NVARCHAR(50),
	diaChi NVARCHAR(100) NOT NULL,
	maCV NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES CHUCVU(maCV)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
CREATE TABLE NHACUNGCAP (
	maNCC NVARCHAR(10) PRIMARY KEY,
	tenNCC NVARCHAR(100) NOT NULL,
	diaChi NVARCHAR(100) NOT NULL,
)
GO
CREATE TABLE LOAI (
	maLoai NVARCHAR(10) PRIMARY KEY,
	tenLoai NVARCHAR(100) NOT NULL,
)
GO
CREATE TABLE THUCDON (
	maMon NVARCHAR(10) PRIMARY KEY,
	tenMon NVARCHAR(100) NOT NULL,
	gia FLOAT NOT NULL,
	hinhAnh NVARCHAR(50),
	maNCC NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES NHACUNGCAP(maNCC),
	maLoai NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES LOAI(maLoai)
	ON UPDATE CASCADE
	ON DELETE CASCADE
)
GO
CREATE TABLE BILL (
	maBill NVARCHAR(10) PRIMARY KEY,
	tong INT NOT NULL,
	maNV NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES NHANVIEN(maNV),
	maMon NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES THUCDON(maMon),
	maKH NVARCHAR(10) NOT NULL FOREIGN KEY REFERENCES KHACHHANG(maKH)
)
GO
INSERT INTO QUANTRI VALUES('admin@gmail.com',1,N'Võ Đại Hiệp','123')
GO
INSERT INTO LOAIKHACHHANG (maLoaiKH, tenLoaiKH, giamGia) VALUES
    ('LKH001', N'Khách hàng BRONZE', 0.05),
    ('LKH002', N'Khách hàng SILVER', 0.1),
    ('LKH003', N'Khách hàng GOLD', 0.15),
    ('LKH004', N'Khách hàng VIP', 0.2);
GO
INSERT INTO KHACHHANG (maKH, hoKH, tenKH, diaChi, diemTichLuy, maLoaiKH) VALUES
    ('KH001', N'Nguyễn Văn', N' Anh', N'123 Đường ABC, Quận 1, TP.HCM', 50, 'LKH002'),
    ('KH002', N'Trần Thị', N' Bé', N'456 Đường XYZ, Quận 2, TP.HCM', 30, 'LKH002'),
	('KH003', N'Phạm Văn', N' Châu', N'789 Đường MNO, Quận 3, TP.HCM', 25, 'LKH001'),
    ('KH004', N'Lê Thị', N' Định', N'101 Đường UVW, Quận 4, TP.HCM', 60, 'LKH003'),
    ('KH005', N'Đinh Văn', N' Nam', N'202 Đường DEF, Quận 5, TP.HCM', 70, 'LKH003'),
    ('KH006', N'Vũ Thị', N' Phụng', N'303 Đường GHI, Quận 6, TP.HCM', 40, 'LKH002'),
    ('KH007', N'Hoàng Văn', N' Giang', N'404 Đường JKL, Quận 7, TP.HCM', 80, 'LKH004'),
    ('KH008', N'Trần Văn', N' Hậu', N'505 Đường QWE, Quận 8, TP.HCM', 20, 'LKH001'),
    ('KH009', N'Nguyễn Thị', N' Linh', N'606 Đường RTY, Quận 9, TP.HCM', 55, 'LKH003'),
    ('KH010', N'Lê Văn', N' Minh', N'707 Đường ZXC, Quận 10, TP.HCM', 100, 'LKH004'),
    ('KH011', N'Mai Thị', N' Khánh', N'808 Đường BNM, Quận 11, TP.HCM', 75, 'LKH004'),
    ('KH012', N'Đặng Văn', N' Lam', N'909 Đường ASD, Quận 12, TP.HCM', 35, 'LKH002'),
	('KH013', N'Võ Hoàng Yên', N' Thế', N'123 Đường FGD, Quận 9, TP.HCM', 25, 'LKH001'),
	('KH014', N'Nguyễn Ngọc Gia', N' Minh', N'45 Đường FFD, Quận 12, TP.HCM', 90, 'LKH004'),
	('KH015', N'Huỳnh', N' Vũ', N'10 Đường DFG, Quận 3, TP.HCM', 50, 'LKH002'),
	('KH016', N'Kim Thị', N' Lan', N'123 Đường IOD, Quận 4, TP.HCM', 35, 'LKH002'),
	('KH017', N'Vũ Ngọc Khánh', N' Linh', N'99 Đường ASD, Quận 6, TP.HCM', 30, 'LKH002'),
	('KH018', N'Trần Ngọc', N' Như', N'9 Đường GTY, Quận 1, TP.HCM', 15, 'LKH001'),
	('KH019', N'Hồ Thị', N' Như', N'121 Đường JKL, Quận 2, TP.HCM', 60, 'LKH003'),
    ('KH020', N'Trương Văn', N' Anh', N'232 Đường PQR, Quận 3, TP.HCM', 45, 'LKH002'),
    ('KH021', N'Nguyễn Thị', N' Phụng', N'343 Đường TUV, Quận 4, TP.HCM', 85, 'LKH004'),
    ('KH022', N'Lý Văn', N' Qúy', N'454 Đường WER, Quận 5, TP.HCM', 30, 'LKH002'),
    ('KH023', N'Phan Thị', N' Trinh', N'565 Đường YUI, Quận 6, TP.HCM', 70, 'LKH003'),
    ('KH024', N'Bùi Văn', N' Sơn', N'676 Đường FGH, Quận 7, TP.HCM', 20, 'LKH001'),
    ('KH025', N'Lê Thị Thu', N' Thảo', N'787 Đường JKL, Quận 8, TP.HCM', 15, 'LKH001'),
    ('KH026', N'Võ Văn', N' Vân', N'898 Đường RTY, Quận 9, TP.HCM', 15, 'LKH001'),
    ('KH027', N'Trần Thị Hoài', N' Vân', N'909 Đường ZXC, Quận 10, TP.HCM', 20, 'LKH001'),
    ('KH028', N'Đỗ Văn Huỳnh', N' Linh', N'010 Đường BNM, Quận 11, TP.HCM', 20, 'LKH001'),
    ('KH029', N'Lê Văn', N' Dũng', N'121 Đường ASD, Quận 12, TP.HCM', 20, 'LKH001'),
    ('KH030', N'Nguyễn Thị', N' Yến', N'232 Đường FGH, Quận 2, TP.HCM', 105, 'LKH004');
GO
INSERT INTO CHUCVU (maCV, tenCV) VALUES
	('QLC', N'Quản Lý chung'),
	('QLNS', N'Quản lý nhân sự'),
	('QLCH', N'Quản lý cửa hàng'),
	('NV', N'Nhân viên'),
	('PV', N'Phụ vụ'),
	('TV', N'Tạp vụ'),
	('BV', N'Bảo vệ');
GO 
INSERT INTO NHANVIEN (maNV, hoNV, tenNV, gioiTinh, ngaySinh, luong, anhNV, diaChi, maCV) VALUES
	('NV001', N'Nguyễn Văn', N' An', 1, '1980-01-01', 2000000, 'anh_nv001.jpg', N'TP.HCM', 'QLC'),
    ('NV002', N'Trần Thị', N' Bích', 0, '1985-02-15', 1800000, 'anh_nv001.jpg', N'TP.HCM', 'QLNS'),
    ('NV003', N'Phạm Văn', N' Châu', 1, '1988-05-20', 1800000, 'anh_nv001.jpg', N'TP.HCM', 'QLNS'),
    ('NV004', N'Lê Thị', N' Minh', 0, '1982-11-10', 1700000, 'anh_nv001.jpg', N'TP.HCM', 'QLCH'),
    ('NV005', N'Đinh Văn', N' Danh', 1, '1987-08-25', 1700000, 'anh_nv001.jpg', N'TP.HCM', 'QLCH'),
    ('NV006', N'Vũ Thị', N' Hiệp', 0, '1990-04-02', 1200000, 'anh_nv001.jpg', N'TP.HCM', 'PV'),
    ('NV007', N'Hoàng Văn', N' Roon', 1, '1995-06-15', 1200000, 'anh_nv001.jpg', N'TP.HCM', 'PV'),
    ('NV008', N'Trần Văn', N' Hiền', 1, '1986-03-20', 1200000, 'anh_nv001.jpg', N'TP.HCM', 'PV'),
    ('NV009', N'Nguyễn Thị', N' My', 0, '1989-09-12', 1200000, 'anh_nv001.jpg', N'TP.HCM', 'TV'),
    ('NV010', N'Lê Văn', N' Minh', 1, '1993-07-30', 1200000, 'anh_nv001.jpg', N'TP.HCM', 'TV'),
    ('NV011', N'Mai Thị', N' Khanh', 0, '1984-12-05', 1300000, 'anh_nv001.jpg', N'TP.HCM', 'BV'),
    ('NV012', N'Đặng Văn', N' Khang', 1, '1991-10-18', 1300000, 'anh_nv001.jpg', N'TP.HCM', 'BV'),
    ('NV013', N'Hồ Thị', N' Như', 0, '1983-04-15', 1000000, 'anh_nv001.jpg', N'TP.HCM', 'NV'),
    ('NV014', N'Trương Văn', N' Oanh', 1, '1988-08-22', 1000000, 'anh_nv001.jpg', N'TP.HCM', 'NV'),
	('NV015', N'Nguyễn Thị Huỳnh', N' My', 0, '1991-03-15', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV016', N'Trần Văn', N' Kha', 1, '1987-06-20', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
    ('NV017', N'Phạm Thị', N' Lan', 0, '1984-08-10', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV018', N'Lê Văn', N' Muội', 1, '1990-01-05', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
    ('NV019', N'Đặng Thị', N' Nhàn', 0, '1993-04-20', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV020', N'Mai Văn', N' Phi', 1, '1995-11-22', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
    ('NV021', N'Nguyễn Thị', N' Quỳnh', 0, '1989-07-12', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV022', N'Lý Văn Lê', N' Minh', 1, '1991-02-18', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV023', N'Phạm Thị', N' Xoan', 0, '1986-09-25', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
    ('NV024', N'Trần Văn', N' Trí', 1, '1994-05-30', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV025', N'Võ Thị', N' Uyên', 0, '1989-08-28', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
    ('NV026', N'Hoàng Văn', N' Vinh', 1, '1992-12-02', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV027', N'Nguyễn Thị', N' Ngọc', 0, '1983-03-18', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV028', N'Đỗ Văn', N' Bình', 1, '1985-07-05', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
    ('NV029', N'Nguyễn Thị', N' Xuyên', 0, '1990-01-10', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
	('NV030', N'Nguyễn Thị', N' Yến', 0, '1992-11-28', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
	('NV031', N'Trần Văn', N' Hùng', 1, '1990-03-15', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV032', N'Phan Thị', N' Thư', 0, '1995-06-20', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
    ('NV033', N'Lê Thị Minh', N' Ngọc', 0, '1992-08-10', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV034', N'Đặng Văn', N' Danh', 1, '1988-01-05', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
    ('NV035', N'Mai Văn', N' Nhã', 1, '1993-04-20', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV036', N'Nguyễn Thị', N' Huỳnh', 0, '1985-11-22', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
    ('NV037', N'Lý Văn', N' Quy', 1, '1987-07-12', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV038', N'Phạm Văn', N' Trang', 1, '1991-02-18', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV039', N'Trần Thị', N' Trinh', 0, '1986-09-25', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
    ('NV040', N'Võ Văn', N' Tài', 1, '1994-05-30', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV041', N'Hoàng Thị', N' Phúc', 0, '1989-08-28', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV'),
    ('NV042', N'Nguyễn Văn', N' Vinh', 1, '1992-12-02', 1000000, 'anh_nv001.jpg', N'Hà Nội', 'NV'),
    ('NV043', N'Bùi Thị', N' Nga', 0, '1983-03-18', 1000000, 'anh_nv001.jpg', N'Nha Trang', 'NV'),
    ('NV044', N'Đỗ Văn', N' Xuân', 1, '1985-07-05', 1000000, 'anh_nv001.jpg', N'Cần Thơ', 'NV'),
    ('NV045', N'Nguyễn Thị Minh', N' Thư', 0, '1990-01-10', 1000000, 'anh_nv001.jpg', N'Cam Ranh', 'NV');
GO
INSERT INTO NHACUNGCAP (maNCC, tenNCC, diaChi) VALUES
    ('NCC001', N'Công ty Cà Phê Việt', N'123 Đường ABC, Quận 1, TP.HCM'),
    ('NCC002', N'Global Coffee Corporation', N'456 International Street, City A'),
    ('NCC003', N'Mai Linh Coffee Co.', N'789 Đường XYZ, Quận 2, TP.HCM'),
    ('NCC004', N'European Beans Ltd.', N'101 Avenue de la Café, Paris'),
    ('NCC005', N'Asia Blend Coffee', N'202 Asia Square, Hong Kong'),
    ('NCC006', N'South American Roasters', N'303 Samba Street, Rio de Janeiro'),
    ('NCC007', N'Middle East Coffee Traders', N'404 Oasis Road, Dubai'),
	('NCC008', N'African Coffee Enterprises', N'505 Savanna Street, Nairobi'),
    ('NCC009', N'Australian Coffee Co.', N'606 Kangaroo Lane, Sydney'),
    ('NCC010', N'North Pole Coffee Supplies', N'707 Arctic Avenue, Santa Claus Village');
GO
INSERT INTO LOAI (maLoai, tenLoai) VALUES
	('CF', N'Cafe'),
	('PD', N'PhinDi'),
	('ES', N'Espresso'),
	('TR', N'Trà'),
	('FR', N'Freeze'),
	('BA', N'Bánh'),
	('KH', N'Khác');
GO
INSERT INTO THUCDON(maMon, tenMon, gia, hinhAnh, maNCC, maLoai) VALUES
	('M001', N'Phin Sữa Đá', 45000, 'phinsuada.jpg', 'NCC001', 'CF'),
	('M002', N'Phin Đen Đá', 39000, 'phindenda.jpg', 'NCC001', 'CF'),
	('M003', N'Bạc Xỉu', 45000, 'bacsiu.jpg', 'NCC002', 'CF'),
	('M004', N'PhinDi Hạnh Nhân', 55000, 'phindihanhnhan.jpg', 'NCC003', 'PD'),
	('M005', N'PhinDi Kem Sữa', 55000, 'phindikemsua.jpg', 'NCC003', 'PD'),
	('M006', N'PhinDi Choco', 55000, 'phindichoco.jpg', 'NCC004', 'PD'),
	('M007', N'Espresso / Americano', 55000, 'espresso.jpg', 'NCC005', 'ES'),
	('M008', N'Cappuccino / Latte', 79000, 'cappuccino.jpg', 'NCC005', 'ES'),
	('M009', N'Mocha / Caramel Macchiato', 85000, 'moch.jpg', 'NCC006', 'ES'),
	('M010', N'Trà Sen Vàng', 65000, 'trasenvang.jpg', 'NCC007', 'TR'),
	('M011', N'Trà Thạch Đào', 65000, 'trathachdao.jpg', 'NCC007', 'TR'),
	('M012', N'Trà Thanh Đào', 65000, 'trathanhdao.jpg', 'NCC007', 'TR'),
	('M013', N'Trà Thạch Vải', 65000, 'trathachvai.jpg', 'NCC007', 'TR'),
	('M014', N'Trà Xanh Đậu Đỏ', 65000, 'traxanhdaudo.jpg', 'NCC007', 'TR'),
	('M015', N'Freeze Trà Xanh', 69000, 'freezetraxanh.jpg', 'NCC008', 'FR'),
	('M016', N'Caramel Phin Freeze ', 69000, 'caramelphinfreeze.jpg', 'NCC008', 'FR'),
	('M017', N'Cookies & Cream', 69000, 'cookiescream.jpg', 'NCC008', 'FR'),
	('M018', N'Chocolate Freeze', 69000, 'chocolatefreeze.jpg', 'NCC008', 'FR'),
	('M019', N'Classic Phin Freeze', 69000, 'classicphinfreeze.jpg', 'NCC008', 'FR'),
	('M020', N'Bánh Chuối', 29000, 'banhchuoi.jpg', 'NCC009', 'BA'),
	('M021', N'Phô Mai Chanh Dây', 29000, 'phomaichanhday.jpg', 'NCC009', 'BA'),
	('M022', N'Phô Mai Cà Phê', 29000, 'phomaicaphe.jpg', 'NCC009', 'BA'),
	('M023', N'Tiramisu Cake', 35000, 'tiramisu.jpg', 'NCC009', 'BA'),
	('M024', N'Mousse Đào', 35000, 'moussedao.jpg', 'NCC009', 'BA'),
	('M025', N'Mousse Cacao', 35000, 'moussecacao.jpg', 'NCC009', 'BA'),
	('M026', N'Phô Mai Trà Xanh', 35000, 'phomaitraxanh.jpg', 'NCC009', 'BA'),
	('M027', N'Phô Mai Caramel', 35000, 'phomaicaramel.jpg', 'NCC009', 'BA'),
	('M028', N'Chocolate Highlands Cake', 35000, 'chocolatecake.jpg', 'NCC009', 'BA'),
	('M029', N'Bánh Mì Que Pate', 19000, 'pate.jpg', 'NCC009', 'BA'),
	('M030', N'Bánh Mì Que Gà Phô Mai', 19000, 'gaphomai.jpg', 'NCC009', 'BA'),
	('M031', N'Chanh Đá Xay/Đá Viên/Nóng', 55000, 'chanh.jpg', 'NCC010', 'KH'),
	('M032', N'Chanh Dây Đá Viên', 55000, 'chanhday.jpg', 'NCC010', 'KH'),
	('M033', N'Tắc/Quất Đá Viên', 55000, 'tac.jpg', 'NCC010', 'KH'),
	('M034', N'Chocolate Đá Viên/Nóng', 55000, 'chocolatedn.jpg', 'NCC010', 'KH');
GO
CREATE PROCEDURE NhanVien_TimKiem
    @maNV varchar(10)=NULL,
	@hoTen nvarchar(40)=NULL,
	@gioiTinh nvarchar(3)= NULL,
	@luongMin varchar(30)=NULL,
	@luongMax varchar(30)=NULL,
	@diaChi nvarchar(70)=NULL,
	@maCV nvarchar(10)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM NHANVIEN
       WHERE  (1=1)
       '
IF @maNV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maNV LIKE ''%'+@maNV+'%'')
              '
IF @hoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (hoNV+'' ''+tenNV LIKE N''%'+@hoTen+'%'')
              '
IF @gioiTinh IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (gioiTinh LIKE ''%'+@gioiTinh+'%'')
             '
IF @luongMin IS NOT NULL and @luongMax IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
             AND (luong Between Convert(int,'''+@luongMin+''') AND Convert(int, '''+@luongMax+'''))
             '
IF @diaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (diaChi LIKE N''%'+@diaChi+'%'')
              '
IF @maCV IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maCV LIKE N''%'+@maCV+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
GO
CREATE PROCEDURE KhachHang_TimKiem
    @maKH varchar(10)=NULL,
	@hoTen nvarchar(40)=NULL,
	@diaChi nvarchar(70)=NULL,
	@maLoaiKH nvarchar(10)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM KHACHHANG
       WHERE  (1=1)
       '
IF @maKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maKH LIKE ''%'+@maKH+'%'')
              '
IF @hoTen IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (hoKH+'' ''+tenKH LIKE N''%'+@hoTen+'%'')
              '
IF @diaChi IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (diaChi LIKE N''%'+@diaChi+'%'')
              '
IF @maLoaiKH IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maLoaiKH LIKE N''%'+@maLoaiKH+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END
GO
CREATE PROCEDURE ThucDon_TimKiem
    @maMon varchar(10)=NULL,
	@tenMon nvarchar(50)=NULL,
	@maLoai nvarchar(10)=NULL,
	@maNCC nvarchar(10)=NULL
AS
BEGIN
DECLARE @SqlStr NVARCHAR(4000),
		@ParamList nvarchar(2000)
SELECT @SqlStr = '
       SELECT * 
       FROM THUCDON
       WHERE  (1=1)
       '
IF @maMon IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maMon LIKE ''%'+@maMon+'%'')
              '
IF @tenMon IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (tenMon LIKE N''%'+@tenMon+'%'')
              '
IF @maLoai IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maLoai LIKE N''%'+@maLoai+'%'')
              '
IF @maNCC IS NOT NULL
       SELECT @SqlStr = @SqlStr + '
              AND (maNCC LIKE N''%'+@maNCC+'%'')
              '
	EXEC SP_EXECUTESQL @SqlStr
END