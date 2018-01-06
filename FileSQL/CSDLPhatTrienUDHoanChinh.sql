--USE master;  
--GO  
--CREATE DATABASE QuanLyNhaAn_DoAn  
--ON   
--( NAME = QLNA_mdf,  
--    FILENAME = 'E:\1. Sinh viên Năm 3\III.ĐồÁn\Database\QLNA.mdf',  
--    SIZE = 10MB,  
--    MAXSIZE = 50MB,  
--    FILEGROWTH = 5MB )  
--LOG ON  
--( NAME = QLNA_log,  
--    FILENAME = 'E:\1. Sinh viên Năm 3\III.ĐồÁn\Database\QLNA.ldf',  
--    SIZE = 5MB,  
--    MAXSIZE = 25MB,  
--    FILEGROWTH = 5MB ) ;  
--GO 



USE [QuanLyNhaAn_DoAn]
GO

create table NhanVien
(
	MaNV int identity(10000,1) constraint PK_NhanVien_MaNV primary key not null,
	TenNV nvarchar(50) not null,
	SDT nvarchar(11) not null constraint AK_NhanVien_SDT unique,
	GioiTinh bit not null,--1 la nam 0 la nu
	CMND nvarchar(11) not null constraint AK_NhanVien_CMND unique,
	ChucVu nvarchar(20) not NULL,
	CapChucVu INT,
	TinhTrangTaiKhoan INT
)
--================================
create table TaiKhoan
(
	MaNV int constraint PK_TaiKhoan_MaNV primary key not null,
	Pass nvarchar(50) not null,
)
--===============================

create table BuaAn
(
	MaBuaAn int identity(10000,1)constraint PK_BuaAn_MaBuaAn primary key not null,
	SoLuong int not null,
	NgayAn date not null,
	MaNV int not null,
)

--========================================
create table ChiTietBuaAn
(
	MaBuaAn int not null,
	MaMonAn int not null,
	NgayAn date not null,
	DonGia money not null,
	SoLuong int not null
	constraint PK_ChiTietBuaAn_MaBuaAn_NgayAn primary key(
	MaBuaAn,
	MaMonAn
	)
)on [primary]
--===================================
create table ThucDon 
(
	
	MaMonAn int not null,
	NgayLenThucDon date not null,
	constraint PK_ThucDon_MaMonAn_NgayLenThucDon primary key clustered(
	MaMonAn,
	NgayLenThucDon
	)
)on [primary]
--==================================
create table MonAn
(
	MaMonAn int identity(10000,1)constraint PK_MonAn_MaMonAn primary key not null,
	TenMonAn nvarchar(50) not null,
	LoaiMonAn nvarchar(20) not null,
	DonGia money not NULL,
	Images NVARCHAR(100)
)
--==================================
create table NguyenLieu
(
	MaNguyenLieu int identity(10000,1)constraint PK_NguyenLieu_MaNguyenLieu primary key not null,
	TenNguyenLieu nvarchar(50) not null,
	DonGiaNL money not null
)
--==================================
create table ChiTietNguyenLieu
(
	MaNguyenLieu int not null,
	MaMonAn int not null,
	DonGiaNL money not null,
	SoLuong int not null,
	constraint PK_ChiTietNguyenLieu_MaNguyenLieu_MaMonAn primary key clustered(
	MaNguyenLieu,
	MaMonAn
	)
)on [primary]
--=======================================

alter table dbo.TaiKhoan with check add constraint FK_TaiKhoan_MaNV foreign key (MaNV) references dbo.NhanVien(MaNV)
go

alter table [dbo].[TaiKhoan] check constraint FK_TaiKhoan_MaNV
go
--=======================================
alter table [dbo].[BuaAn] with check add constraint FK_BuaAn_MaNV foreign key (MaNV) references dbo.TaiKhoan(MaNV)
go

alter table [dbo].[BuaAn] check constraint FK_BuaAn_MaNV
go
--=======================================
alter table [dbo].[ChiTietBuaAn] with check add constraint FK_ChiTietBuaAn_MaBuaAn foreign key (MaBuaAn) references [dbo].[BuaAn](MaBuaAn)
go

alter table [dbo].[ChiTietBuaAn] check constraint FK_ChiTietBuaAn_MaBuaAn
go
--=======================================
alter table [dbo].[ChiTietBuaAn] with check add constraint FK_ChiTietBuaAn_ThucDon_NgayAn_MaMonAn foreign key(MaMonAn,NgayAn) 
references [dbo].[ThucDon](MaMonAn,NgaylenThucDon)
go

alter table [dbo].[ChiTietBuaAn] check constraint FK_ChiTietBuaAn_ThucDon_NgayAn_MaMonAn
go
--=======================================
alter table [dbo].[ThucDon] with check add constraint FK_ThucDon_MonAn_MaMonAn foreign key (MaMonAn) 
references [dbo].[MonAn](MaMonAn)
go

alter table [dbo].[ThucDon] check constraint FK_ThucDon_MonAn_MaMonAn
go
--=======================================
alter table [dbo].[ChiTietNguyenLieu] with check add constraint FK_ChiTietNguyenLieu_MonAn_MaMonAn foreign key (MaMonAn) 
references [dbo].[MonAn](MaMonAn)
go

alter table [dbo].[ChiTietNguyenLieu] check constraint FK_ChiTietNguyenLieu_MonAn_MaMonAn
go
--=======================================
alter table [dbo].[ChiTietNguyenLieu] with check add constraint FK_ChiTietNguyenLieu_NguyenLieu_MaNguyenLieu foreign key (MaNguyenlieu) 
references [dbo].[NguyenLieu](MaNguyenLieu)
go

alter table [dbo].[ChiTietNguyenLieu] check constraint FK_ChiTietNguyenLieu_NguyenLieu_MaNguyenLieu
go


ALTER TABLE dbo.MonAn
ALTER COLUMN Images NVARCHAR(500)
GO

--- 
SET IDENTITY_INSERT QuanLyNhaAn_DoAn.dbo.NguyenLieu ON
GO

INSERT [QuanLyNhaAn_DoAn].dbo.NguyenLieu
        ( MaNguyenLieu ,
          TenNguyenLieu ,
          DonGiaNL
        )
SELECT MaNguyenLieu,TenNguyenLieu,DonGiaNL
FROM [QuanLyNhaAn].dbo.NguyenLieu
SET IDENTITY_INSERT QuanLyNhaAn_DoAn.dbo.NguyenLieu OFF
GO

SET IDENTITY_INSERT [QuanLyNhaAn_DoAn].dbo.MonAn ON
GO

INSERT [QuanLyNhaAn_DoAn].dbo.MonAn
        ( MaMonAn ,
          TenMonAn ,
          LoaiMonAn ,
          DonGia
        )
SELECT MaMonAn,TenMonAn,LoaiMonAn,DonGia
FROM [QuanLyNhaAn].dbo.MonAn
SET IDENTITY_INSERT [QuanLyNhaAn_DoAn].dbo.MonAn OFF
GO


INSERT [QuanLyNhaAn_DoAn].dbo.ChiTietNguyenLieu
        ( MaNguyenLieu ,
          MaMonAn ,
          DonGiaNL ,
          SoLuong
        )
SELECT MaNguyenLieu,MaMonAn,DonGiaNL,SoLuong
FROM [QuanLyNhaAn].dbo.ChiTietNguyenLieu
GO

ALTER TABLE dbo.NhanVien
ALTER COLUMN GioiTinh NVARCHAR(5)
GO


