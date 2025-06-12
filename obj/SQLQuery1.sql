-- T?o co s? d? li?u
CREATE DATABASE QuanLyNhanSu;
GO

-- S? d?ng co s? d? li?u v?a t?o
USE QuanLyNhanSu;
GO

-- B?ng B? ph?n
CREATE TABLE BoPhan (
    MaBoPhan VARCHAR(50) PRIMARY KEY,
    TenBoPhan VARCHAR(100) NOT NULL
);

-- B?ng Ðang nh?p
CREATE TABLE Login (
    TenTaiKhoan VARCHAR(50) PRIMARY KEY,
    MatKhau VARCHAR(255) NOT NULL
);

-- B?ng Ðang ký
CREATE TABLE DangKy (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    TenHienThi VARCHAR(100),
    LoaiNhanVien VARCHAR(10) CHECK (LoaiNhanVien IN ('Admin', 'QuanLy', 'NhanVien')),
    CONSTRAINT FK_DangKy_Login FOREIGN KEY (TenDangNhap) REFERENCES Login(TenTaiKhoan)
);

-- B?ng Ð?i m?t kh?u (không nên là b?ng chính th?c n?u ch? d? ph?c v? thay d?i t?m th?i)
CREATE TABLE DoiMatKhau (
    TenDangNhap VARCHAR(50) PRIMARY KEY,
    TenHienThi VARCHAR(100),
    MatKhauCu VARCHAR(255),
    MatKhauMoi VARCHAR(255),
    NhapLaiMatKhau VARCHAR(255)
);

-- B?ng Ch?m công
CREATE TABLE ChamCong (
    MaChamCong VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    Ngay DATE,
    GioVao TIME,
    GioRa TIME,
    DiTre AS CASE WHEN GioVao > '08:00:00' THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END,
    CONSTRAINT FK_ChamCong_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_ChamCong_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Luong nhân viên
CREATE TABLE LuongNhanVien (
    MaLuong VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    LuongCoBan DECIMAL(15,2),
    PhuCap DECIMAL(15,2),
    NgayCapNhat DATE,
    CONSTRAINT FK_LuongNhanVien_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_LuongNhanVien_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Tính luong
CREATE TABLE TinhLuong (
    MaTinhLuong VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    TuNgay DATE,
    DenNgay DATE,
    TongLuong DECIMAL(15,2),
    NgayTinh DATE,
    CONSTRAINT FK_TinhLuong_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_TinhLuong_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng H?p d?ng
CREATE TABLE HopDong (
    MaHopDong VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    LoaiHopDong VARCHAR(100),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    CONSTRAINT FK_HopDong_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_HopDong_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng H? so nhân viên
CREATE TABLE HoSoNhanVien (
    MaHoSo VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    HoTen VARCHAR(100),
    NgaySinh DATE,
    GioiTinh VARCHAR(10) CHECK (GioiTinh IN ('Nam', 'Nu', 'Khac')),
    DiaChi VARCHAR(255),
    SoDienThoai VARCHAR(20),
    Email VARCHAR(100),
    CONSTRAINT FK_HoSoNhanVien_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_HoSoNhanVien_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng B?o hi?m
CREATE TABLE BaoHiem (
    MaBaoHiem VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    LoaiBaoHiem VARCHAR(100),
    SoHieuBH VARCHAR(100),
    NgayCap DATE,
    NgayHetHan DATE,
    GhiChu NVARCHAR(MAX),
    CONSTRAINT FK_BaoHiem_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_BaoHiem_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Khen thu?ng
CREATE TABLE KhenThuong (
    MaKhenThuong VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    NoiDung VARCHAR(255),
    NgayKT DATE,
    CONSTRAINT FK_KhenThuong_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_KhenThuong_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng K? lu?t
CREATE TABLE KyLuat (
    MaKyLuat VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    LyDo VARCHAR(255),
    NgayKL DATE,
    CONSTRAINT FK_KyLuat_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_KyLuat_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Thai s?n
CREATE TABLE ThaiSan (
    MaThaiSan VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    NgayBatDau DATE,
    NgayKetThuc DATE,
    GhiChu NVARCHAR(MAX),
    CONSTRAINT FK_ThaiSan_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_ThaiSan_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Nhân viên di tr?
CREATE TABLE NhanVienDiTre (
    MaBaoCao VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    Ngay DATE,
    GioVao TIME,
    CONSTRAINT FK_NhanVienDiTre_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_NhanVienDiTre_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Làm thêm gi?
CREATE TABLE LamThemGio (
    MaLamThem VARCHAR(50) PRIMARY KEY,
    TenTaiKhoan VARCHAR(50),
    MaBoPhan VARCHAR(50),
    Ngay DATE,
    SoGio DECIMAL(5,2),
    CONSTRAINT FK_LamThemGio_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_LamThemGio_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- B?ng Thâm niên nhân viên
CREATE TABLE ThamNienNhanVien (
    TenTaiKhoan VARCHAR(50) PRIMARY KEY,
    MaBoPhan VARCHAR(50) NOT NULL,
    NgayVaoLam DATE NOT NULL,
    SoNamLamViec INT,
    CONSTRAINT FK_ThamNien_Login FOREIGN KEY (TenTaiKhoan) REFERENCES Login(TenTaiKhoan),
    CONSTRAINT FK_ThamNien_BoPhan FOREIGN KEY (MaBoPhan) REFERENCES BoPhan(MaBoPhan)
);

-- Chèn d? li?u vào b?ng BoPhan
INSERT INTO BoPhan (MaBoPhan, TenBoPhan) VALUES
('BP001', N'Phòng Nhân s?'),
('BP002', N'Phòng K? toán'),
('BP003', N'Phòng Kinh doanh'),
('BP004', N'Phòng K? thu?t'),
('BP005', N'Phòng Marketing'),
('BP006', N'Phòng IT'),
('BP007', N'Phòng Hành chính'),
('BP008', N'Phòng Cham sóc khách hàng'),
('BP009', N'Phòng Phát tri?n s?n ph?m'),
('BP010', N'Phòng Qu?n lý ch?t lu?ng');


DELETE FROM ThamNienNhanVien;
DELETE FROM NhanVienDiTre;
DELETE FROM LamThemGio;
DELETE FROM ThaiSan;
DELETE FROM KyLuat;
DELETE FROM KhenThuong;
DELETE FROM BaoHiem;
DELETE FROM HoSoNhanVien;
DELETE FROM HopDong;
DELETE FROM TinhLuong;
DELETE FROM LuongNhanVien;
DELETE FROM ChamCong;
DELETE FROM DoiMatKhau;
DELETE FROM DangKy;
DELETE FROM Login;
DELETE FROM BoPhan;

-- Chèn d? li?u vào b?ng Login
INSERT INTO Login (TenTaiKhoan, MatKhau) VALUES
('user001', 'Pass@123'),
('user002', 'Secure#456'),
('user003', 'Random!789'),
('user004', 'Secret$101'),
('user005', 'Safe%202'),
('user006', 'Strong^303'),
('user007', 'Guard*404'),
('user008', 'Lock&505'),
('user009', 'Key#606'),
('user010', 'Shield_707');

-- Chèn d? li?u vào b?ng DangKy
INSERT INTO DangKy (TenDangNhap, TenHienThi, LoaiNhanVien) VALUES
('user001', N'Nguy?n Van An', 'Admin'),
('user002', N'Tr?n Th? Bình', 'QuanLy'),
('user003', N'Lê Van Cu?ng', 'NhanVien'),
('user004', N'Ph?m Th? Dung', 'NhanVien'),
('user005', N'Hoàng Van Em', 'QuanLy'),
('user006', N'Ð? Th? Phu?ng', 'NhanVien'),
('user007', N'Vu Van Giang', 'Admin'),
('user008', N'Bùi Th? H?nh', 'NhanVien'),
('user009', N'Ngô Van In', 'QuanLy'),
('user010', N'Mai Th? Kim', 'NhanVien');

-- Chèn d? li?u vào b?ng DoiMatKhau
INSERT INTO DoiMatKhau (TenDangNhap, TenHienThi, MatKhauCu, MatKhauMoi, NhapLaiMatKhau) VALUES
('user001', N'Nguy?n Van An', 'Pass@123', 'NewPass#001', 'NewPass#001'),
('user002', N'Tr?n Th? Bình', 'Secure#456', 'NewSafe$002', 'NewSafe$002'),
('user003', N'Lê Van Cu?ng', 'Random!789', 'NewLock%003', 'NewLock%003'),
('user004', N'Ph?m Th? Dung', 'Secret$101', 'NewKey^004', 'NewKey^004'),
('user005', N'Hoàng Van Em', 'Safe%202', 'NewShield_005', 'NewShield_005'),
('user006', N'Ð? Th? Phu?ng', 'Strong^303', 'NewGuard*006', 'NewGuard*006'),
('user007', N'Vu Van Giang', 'Guard*404', 'NewSecure#007', 'NewSecure#007'),
('user008', N'Bùi Th? H?nh', 'Lock&505', 'NewSafe%008', 'NewSafe%008'),
('user009', N'Ngô Van In', 'Key#606', 'NewPass@009', 'NewPass@009'),
('user010', N'Mai Th? Kim', 'Shield_707', 'NewSecret$010', 'NewSecret$010');

-- Chèn d? li?u vào b?ng ChamCong
INSERT INTO ChamCong (MaChamCong, TenTaiKhoan, MaBoPhan, Ngay, GioVao, GioRa) VALUES
('CC001', 'user001', 'BP001', '2025-06-01', '07:50:00', '17:00:00'),
('CC002', 'user002', 'BP002', '2025-06-01', '08:10:00', '17:30:00'),
('CC003', 'user003', 'BP003', '2025-06-01', '07:45:00', '16:50:00'),
('CC004', 'user004', 'BP004', '2025-06-01', '08:05:00', '17:10:00'),
('CC005', 'user005', 'BP005', '2025-06-01', '07:55:00', '17:20:00'),
('CC006', 'user006', 'BP006', '2025-06-01', '08:15:00', '17:40:00'),
('CC007', 'user007', 'BP007', '2025-06-01', '07:40:00', '16:45:00'),
('CC008', 'user008', 'BP008', '2025-06-01', '08:20:00', '17:50:00'),
('CC009', 'user009', 'BP009', '2025-06-01', '07:50:00', '17:00:00'),
('CC010', 'user010', 'BP010', '2025-06-01', '08:00:00', '17:15:00');

-- Chèn d? li?u vào b?ng LuongNhanVien
INSERT INTO LuongNhanVien (MaLuong, TenTaiKhoan, MaBoPhan, LuongCoBan, PhuCap, NgayCapNhat) VALUES
('L001', 'user001', 'BP001', 15000000, 2000000, '2025-06-01'),
('L002', 'user002', 'BP002', 12000000, 1500000, '2025-06-01'),
('L003', 'user003', 'BP003', 10000000, 1000000, '2025-06-01'),
('L004', 'user004', 'BP004', 13000000, 1800000, '2025-06-01'),
('L005', 'user005', 'BP005', 14000000, 2000000, '2025-06-01'),
('L006', 'user006', 'BP006', 11000000, 1200000, '2025-06-01'),
('L007', 'user007', 'BP007', 16000000, 2500000, '2025-06-01'),
('L008', 'user008', 'BP008', 9000000, 800000, '2025-06-01'),
('L009', 'user009', 'BP009', 12500000, 1500000, '2025-06-01'),
('L010', 'user010', 'BP010', 13500000, 1700000, '2025-06-01');

-- Chèn d? li?u vào b?ng TinhLuong
INSERT INTO TinhLuong (MaTinhLuong, TenTaiKhoan, MaBoPhan, TuNgay, DenNgay, TongLuong, NgayTinh) VALUES
('TL001', 'user001', 'BP001', '2025-05-01', '2025-05-31', 17000000, '2025-06-01'),
('TL002', 'user002', 'BP002', '2025-05-01', '2025-05-31', 13500000, '2025-06-01'),
('TL003', 'user003', 'BP003', '2025-05-01', '2025-05-31', 11000000, '2025-06-01'),
('TL004', 'user004', 'BP004', '2025-05-01', '2025-05-31', 14800000, '2025-06-01'),
('TL005', 'user005', 'BP005', '2025-05-01', '2025-05-31', 16000000, '2025-06-01'),
('TL006', 'user006', 'BP006', '2025-05-01', '2025-05-31', 12200000, '2025-06-01'),
('TL007', 'user007', 'BP007', '2025-05-01', '2025-05-31', 18500000, '2025-06-01'),
('TL008', 'user008', 'BP008', '2025-05-01', '2025-05-31', 9800000, '2025-06-01'),
('TL009', 'user009', 'BP009', '2025-05-01', '2025-05-31', 14000000, '2025-06-01'),
('TL010', 'user010', 'BP010', '2025-05-01', '2025-05-31', 15200000, '2025-06-01');

-- Chèn d? li?u vào b?ng HopDong
INSERT INTO HopDong (MaHopDong, TenTaiKhoan, MaBoPhan, LoaiHopDong, NgayBatDau, NgayKetThuc) VALUES
('HD001', 'user001', 'BP001', N'H?p d?ng dài h?n', '2024-01-01', '2026-12-31'),
('HD002', 'user002', 'BP002', N'H?p d?ng ng?n h?n', '2025-01-01', '2025-12-31'),
('HD003', 'user003', 'BP003', N'H?p d?ng th? vi?c', '2025-03-01', '2025-05-31'),
('HD004', 'user004', 'BP004', N'H?p d?ng dài h?n', '2023-06-01', '2026-05-31'),
('HD005', 'user005', 'BP005', N'H?p d?ng ng?n h?n', '2025-02-01', '2025-08-31'),
('HD006', 'user006', 'BP006', N'H?p d?ng th? vi?c', '2025-04-01', '2025-06-30'),
('HD007', 'user007', 'BP007', N'H?p d?ng dài h?n', '2022-01-01', '2027-12-31'),
('HD008', 'user008', 'BP008', N'H?p d?ng ng?n h?n', '2025-01-01', '2025-12-31'),
('HD009', 'user009', 'BP009', N'H?p d?ng dài h?n', '2024-06-01', '2027-05-31'),
('HD010', 'user010', 'BP010', N'H?p d?ng th? vi?c', '2025-05-01', '2025-07-31');

-- Chèn d? li?u vào b?ng HoSoNhanVien
INSERT INTO HoSoNhanVien (MaHoSo, TenTaiKhoan, MaBoPhan, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Email) VALUES
('HS001', 'user001', 'BP001', N'Nguy?n Van An', '1990-01-15', 'Nam', N'Hà N?i', '0912345671', 'an.nguyen@gmail.com'),
('HS002', 'user002', 'BP002', N'Tr?n Th? Bình', '1992-03-22', 'Nu', N'TP.HCM', '0912345672', 'binh.tran@gmail.com'),
('HS003', 'user003', 'BP003', N'Lê Van Cu?ng', '1995-07-10', 'Nam', N'Ðà N?ng', '0912345673', 'cuong.le@gmail.com'),
('HS004', 'user004', 'BP004', N'Ph?m Th? Dung', '1993-11-05', 'Nu', N'H?i Phòng', '0912345674', 'dung.pham@gmail.com'),
('HS005', 'user005', 'BP005', N'Hoàng Van Em', '1988-04-18', 'Nam', N'C?n Tho', '0912345675', 'em.hoang@gmail.com'),
('HS006', 'user006', 'BP006', N'Ð? Th? Phu?ng', '1994-09-25', 'Nu', N'Hu?', '0912345676', 'phuong.do@gmail.com'),
('HS007', 'user007', 'BP007', N'Vu Van Giang', '1991-02-12', 'Nam', N'Nha Trang', '0912345677', 'giang.vu@gmail.com'),
('HS008', 'user008', 'BP008', N'Bùi Th? H?nh', '1996-06-30', 'Nu', N'Vung Tàu', '0912345678', 'hanh.bui@gmail.com'),
('HS009', 'user009', 'BP009', N'Ngô Van In', '1989-12-01', 'Nam', N'B?c Ninh', '0912345679', 'in.ngo@gmail.com'),
('HS010', 'user010', 'BP010', N'Mai Th? Kim', '1997-08-20', 'Nu', N'Qu?ng Ninh', '0912345680', 'kim.mai@gmail.com');

-- Chèn d? li?u vào b?ng BaoHiem
INSERT INTO BaoHiem (MaBaoHiem, TenTaiKhoan, MaBoPhan, LoaiBaoHiem, SoHieuBH, NgayCap, NgayHetHan, GhiChu) VALUES
('BH001', 'user001', 'BP001', N'B?o hi?m y t?', 'BH001', '2024-01-01', '2025-12-31', N''),
('BH002', 'user002', 'BP002', N'B?o hi?m xã h?i', 'BH002', '2024-02-01', '2025-12-31', N''),
('BH003', 'user003', 'BP003', N'B?o hi?m y t?', 'BH003', '2024-03-01', '2025-12-31', N''),
('BH004', 'user004', 'BP004', N'B?o hi?m xã h?i', 'BH004', '2024-04-01', '2025-12-31', N''),
('BH005', 'user005', 'BP005', N'B?o hi?m y t?', 'BH005', '2024-05-01', '2025-12-31', N''),
('BH006', 'user006', 'BP006', N'B?o hi?m xã h?i', 'BH006', '2024-06-01', '2025-12-31', N''),
('BH007', 'user007', 'BP007', N'B?o hi?m y t?', 'BH007', '2024-07-01', '2025-12-31', N''),
('BH008', 'user008', 'BP008', N'B?o hi?m xã h?i', 'BH008', '2024-08-01', '2025-12-31', N''),
('BH009', 'user009', 'BP009', N'B?o hi?m y t?', 'BH009', '2024-09-01', '2025-12-31', N''),
('BH010', 'user010', 'BP010', N'B?o hi?m xã h?i', 'BH010', '2024-10-01', '2025-12-31', N'');

-- Chèn d? li?u vào b?ng KhenThuong
INSERT INTO KhenThuong (MaKhenThuong, TenTaiKhoan, MaBoPhan, NoiDung, NgayKT) VALUES
('KT001', 'user001', 'BP001', N'Hoàn thành xu?t s?c d? án', '2025-06-01'),
('KT002', 'user002', 'BP002', N'Ðóng góp tích c?c cho d?i nhóm', '2025-06-01'),
('KT003', 'user003', 'BP003', N'Ð?t doanh s? cao nh?t tháng', '2025-06-01'),
('KT004', 'user004', 'BP004', N'Sáng t?o trong công vi?c', '2025-06-01'),
('KT005', 'user005', 'BP005', N'H? tr? d?ng nghi?p hi?u qu?', '2025-06-01'),
('KT006', 'user006', 'BP006', N'Hoàn thành dúng h?n d? án', '2025-06-01'),
('KT007', 'user007', 'BP007', N'Ð? xu?t c?i ti?n quy trình', '2025-06-01'),
('KT008', 'user008', 'BP008', N'Cham sóc khách hàng xu?t s?c', '2025-06-01'),
('KT009', 'user009', 'BP009', N'Phát tri?n s?n ph?m m?i', '2025-06-01'),
('KT010', 'user010', 'BP010', N'Ð?m b?o ch?t lu?ng s?n ph?m', '2025-06-01');

-- Chèn d? li?u vào b?ng KyLuat
INSERT INTO KyLuat (MaKyLuat, TenTaiKhoan, MaBoPhan, LyDo, NgayKL) VALUES
('KL001', 'user001', 'BP001', N'Ði tr? 3 l?n trong tháng', '2025-06-01'),
('KL002', 'user002', 'BP002', N'Không hoàn thành công vi?c dúng h?n', '2025-06-01'),
('KL003', 'user003', 'BP003', N'Vi ph?m n?i quy công ty', '2025-06-01'),
('KL004', 'user004', 'BP004', N'S? d?ng tài s?n công ty không dúng m?c dích', '2025-06-01'),
('KL005', 'user005', 'BP005', N'Xung d?t v?i d?ng nghi?p', '2025-06-01'),
('KL006', 'user006', 'BP006', N'Không tuân th? quy trình làm vi?c', '2025-06-01'),
('KL007', 'user007', 'BP007', N'Báo cáo sai l?ch thông tin', '2025-06-01'),
('KL008', 'user008', 'BP008', N'Ði tr? nhi?u l?n', '2025-06-01'),
('KL009', 'user009', 'BP009', N'Không tham gia h?p nhóm', '2025-06-01'),
('KL010', 'user010', 'BP010', N'Vi ph?m quy d?nh an toàn lao d?ng', '2025-06-01');

-- Chèn d? li?u vào b?ng ThaiSan
INSERT INTO ThaiSan (MaThaiSan, TenTaiKhoan, MaBoPhan, NgayBatDau, NgayKetThuc, GhiChu) VALUES
('TS001', 'user002', 'BP002', '2025-07-01', '2026-01-01', N'Ngh? thai s?n 6 tháng'),
('TS002', 'user004', 'BP004', '2025-08-01', '2026-02-01', N'Ngh? thai s?n 6 tháng'),
('TS003', 'user006', 'BP006', '2025-09-01', '2026-03-01', N'Ngh? thai s?n 6 tháng'),
('TS004', 'user008', 'BP008', '2025-10-01', '2026-04-01', N'Ngh? thai s?n 6 tháng'),
('TS005', 'user010', 'BP010', '2025-11-01', '2026-05-01', N'Ngh? thai s?n 6 tháng'),
('TS006', 'user002', 'BP002', '2024-06-01', '2024-12-01', N'Ngh? thai s?n l?n tru?c'),
('TS007', 'user004', 'BP004', '2024-07-01', '2025-01-01', N'Ngh? thai s?n l?n tru?c'),
('TS008', 'user006', 'BP006', '2024-08-01', '2025-02-01', N'Ngh? thai s?n l?n tru?c'),
('TS009', 'user008', 'BP008', '2024-09-01', '2025-03-01', N'Ngh? thai s?n l?n tru?c'),
('TS010', 'user010', 'BP010', '2024-10-01', '2025-04-01', N'Ngh? thai s?n l?n tru?c');

-- Chèn d? li?u vào b?ng NhanVienDiTre
INSERT INTO NhanVienDiTre (MaBaoCao, TenTaiKhoan, MaBoPhan, Ngay, GioVao) VALUES
('BC001', 'user001', 'BP001', '2025-06-01', '08:10:00'),
('BC002', 'user002', 'BP002', '2025-06-02', '08:15:00'),
('BC003', 'user003', 'BP003', '2025-06-03', '08:20:00'),
('BC004', 'user004', 'BP004', '2025-06-04', '08:25:00'),
('BC005', 'user005', 'BP005', '2025-06-05', '08:30:00'),
('BC006', 'user006', 'BP006', '2025-06-06', '08:12:00'),
('BC007', 'user007', 'BP007', '2025-06-07', '08:18:00'),
('BC008', 'user008', 'BP008', '2025-06-08', '08:22:00'),
('BC009', 'user009', 'BP009', '2025-06-09', '08:27:00'),
('BC010', 'user010', 'BP010', '2025-06-10', '08:35:00');

-- Chèn d? li?u vào b?ng LamThemGio
INSERT INTO LamThemGio (MaLamThem, TenTaiKhoan, MaBoPhan, Ngay, SoGio) VALUES
('LT001', 'user001', 'BP001', '2025-06-01', 2.5),
('LT002', 'user002', 'BP002', '2025-06-02', 3.0),
('LT003', 'user003', 'BP003', '2025-06-03', 1.5),
('LT004', 'user004', 'BP004', '2025-06-04', 2.0),
('LT005', 'user005', 'BP005', '2025-06-05', 4.0),
('LT006', 'user006', 'BP006', '2025-06-06', 2.5),
('LT007', 'user007', 'BP007', '2025-06-07', 3.5),
('LT008', 'user008', 'BP008', '2025-06-08', 1.0),
('LT009', 'user009', 'BP009', '2025-06-09', 2.0),
('LT010', 'user010', 'BP010', '2025-06-10', 3.0);

-- Chèn d? li?u vào b?ng ThamNienNhanVien
INSERT INTO ThamNienNhanVien (TenTaiKhoan, MaBoPhan, NgayVaoLam) VALUES
('user001', 'BP001', '2020-01-01'),
('user002', 'BP002', '2021-03-15'),
('user003', 'BP003', '2022-07-10'),
('user004', 'BP004', '2019-11-05'),
('user005', 'BP005', '2020-04-18'),
('user006', 'BP006', '2023-09-25'),
('user007', 'BP007', '2018-02-12'),
('user008', 'BP008', '2022-06-30'),
('user009', 'BP009', '2021-12-01'),
('user010', 'BP010', '2023-08-20');