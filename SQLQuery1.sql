create database QuanlyCheDaNang
use QuanLyCheDaNang
create table hanghoa
(
	mahang int identity primary key not null,
	tenhang nvarchar(20) not null,
	soluong int not null,
	giathanh int not null,
	xuatxu nvarchar(50) not null,
	dovitinh nvarchar(20) not null,

)
create table hoadon
(
	sohoadon int identity primary key not null,
	ngaylap date,
	soban int,
	tinhtranght bit,
	tinhtrangchuyen bit,
	tinhtrangthanhtoan bit,
	tongtien int,
)

create table chitietphieuOder
(
	sophieu int identity primary key not null,
	sohoadon int not null foreign key references hoadon(sohoadon),
	mahang int not null foreign key references hanghoa(mahang),
	soluong int not null,
	Dongia int,
	TT nvarchar(10),
)



create table nhanvien
(
	manv int identity not null primary key,
	tennv nvarchar(50) not null,
	sdt nvarchar(20),
	diachi nvarchar(50),
	gioitinh nvarchar(10),
	namsinh int,
	
)

create table taikhoan
(
	tendangnhap nvarchar(50) not null primary key,
	matkhau nvarchar(50) not null ,
	chucvu nvarchar(50),
	manv int foreign key references nhanvien(manv) ,
	
)



select * from hoadon
INSERT INTO hoadon VALUES ('2018/12/1','1','1','1','1','1');
select top 1 sohoadon from hoadon ORDER BY sohoadon desc
insert into chitietphieuOder values ('10','1','1','1')
select * from chitietphieuOder where sohoadon = 13;
select tenhang,chitietphieuOder.soluong , dongia from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon = 14;
 select top 1 sohoadon from hoadon where soban = '1' and tinhtranght = 0 order by sohoadon desc
 UPDATE hoadon SET tinhtranght = '1' WHERE sohoadon = '13'
 select top 1 sohoadon from hoadon where tinhtranght = 0 ORDER BY sohoadon desc
 
 
 
 INSERT INTO soluong VALUES ('1',GETDATE(),'1');
 
  UPDATE hanghoa SET tenhang = '1' , soluong = 0 where mahang = 4
 select * from hanghoa WHERE mahang = 1
 
 INSERT INTO hanghoa VALUES ('ten','1','1','1','1');
 
 INSERT INTO hanghoa VALUES ('b','0','2','2','2')
 select mahang,tenhang,soluong,giathanh, xuatxu,donvitinh from hanghoa where mahang = '"+txt_tkiemdoan.Text+"'
 select * from taikhoan
 
 select * from nhanvien
 select  from hanghoa where mahang = '"+txt_tkiemdoan.Text+"'
 
 select tenhang,chitietphieuOder.soluong , dongia, TT, sohoadon from chitietphieuOder inner join hanghoa on chitietphieuOder.mahang = hanghoa.mahang where sohoadon =(select top 1 sohoadon from hoadon where soban = 36 and tinhtrangthanhtoan = 0 order by sohoadon desc)
 select top 1 sohoadon from hoadon where soban = 36 and tinhtrangthanhtoan = 0 order by sohoadon desc