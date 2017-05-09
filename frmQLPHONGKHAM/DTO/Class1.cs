using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class BenhNhan_DTO
    {
        private string _tenBenhNhan;
        public string TenBenhNhan
        {
            get { return _tenBenhNhan; }
            set { _tenBenhNhan = value; }
        }

        private string _diaChi;
        public string DiaChi
        {
            get { return _diaChi; }
            set { _diaChi = value; }
        }

        private string _ngaySinh;
        public string NgaySinh
        {
            get { return _ngaySinh; }
            set { _ngaySinh = value; }
        }

        private int _sdt;
        public int Sdt
        {
            get { return _sdt; }
            set { _sdt = value; }
        }

        private string _benhAn;
        public string BenhAn
        {
            get { return _benhAn; }
            set { _benhAn = value; }
        }

        public BenhNhan_DTO(string tenbenhnhan, string diachi, string ngaysinh, int sdt, string benhan) {
            TenBenhNhan = tenbenhnhan;
            DiaChi = diachi;
            NgaySinh = ngaysinh;
            Sdt = sdt;
            BenhAn = benhan;
        }
    }

    public class DichVu_DTO {
        private string _tendv;
        public string Tendv
        {
            get { return _tendv; }
            set { _tendv = value; }
        }

        private int _giatien;
        public int Giatien
        {
            get { return _giatien; }
            set { _giatien = value; }
        }

        public DichVu_DTO(string tendv, int giatien) {
            Tendv = tendv;
            Giatien = giatien;
        }
    }

    public class Thuoc_DTO {
        private string _tenThuoc;
        public string TenThuoc
        {
            get { return _tenThuoc; }
            set { _tenThuoc = value; }
        }

        private int _soLuongTon;
        public int SoLuongTon
        {
            get { return _soLuongTon; }
            set { _soLuongTon = value; }
        }

        private string _dVT;
        public string DVT
        {
            get { return _dVT; }
            set { _dVT = value; }
        }

        private string _ghiChu;
        public string GhiChu
        {
            get { return _ghiChu; }
            set { _ghiChu = value; }
        }

        public Thuoc_DTO(string tenthuoc, int soluongton, string dvt, string ghichu) {
            TenThuoc = tenthuoc;
            SoLuongTon = soluongton;
            DVT = dvt;
            GhiChu = ghichu;
        }
    }

    public class DonThuoc_DTO {

        private string _tenThuoc;
        public string TenThuoc
        {
            get { return _tenThuoc; }
            set { _tenThuoc = value; }
        }

        private int _mathuoc;
        public int Mathuoc
        {
            get { return _mathuoc; }
            set { _mathuoc = value; }
        }

        private int _soLuong;
        public int SoLuong
        {
            get { return _soLuong; }
            set { _soLuong = value; }
        }

        private int _giaTien;
        public int GiaTien
        {
            get { return _giaTien; }
            set { _giaTien = value; }
        }

        private int _maBN;
        public int MaBN
        {
            get { return _maBN; }
            set { _maBN = value; }
        }

        public DonThuoc_DTO (string tenthuoc, int mathuoc, int soluong, int giatien, int mabn) {
            TenThuoc = tenthuoc;
            Mathuoc = mathuoc;
            SoLuong = soluong;
            GiaTien = giatien;
            MaBN = mabn;
        }
    }

    public class DungDV_DTO {
        private int maDv;
        public int MaDv
        {
            get { return maDv; }
            set { maDv = value; }
        }

        private string tenDv;
        public string TenDv
        {
            get { return tenDv; }
            set { tenDv = value; }
        }

        private int giaTien;
        public int GiaTien
        {
            get { return giaTien; }
            set { giaTien = value; }
        }

        private int maBn;
        public int MaBn
        {
            get { return maBn; }
            set { maBn = value; }
        }

        public DungDV_DTO(int madv, string tendv, int giatien, int mabn) {
            MaDv = madv;
            TenDv = tendv;
            GiaTien = giatien;
            MaBn = mabn;
        }
    }

    public class HoaDon_DTO {
        private int maBN;
        public int MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }

        private string tenBN;
        public string TenBN
        {
            get { return tenBN; }
            set { tenBN = value; }
        }

        private int tienThuoc;
        public int TienThuoc
        {
            get { return tienThuoc; }
            set { tienThuoc = value; }
        }

        private int tienDV;
        public int TienDV
        {
            get { return tienDV; }
            set { tienDV = value; }
        }

        private int tongCong;
        public int TongCong
        {
            get { return tongCong; }
            set { tongCong = value; }
        }

        private string ngayKham;
        public string NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }

        public HoaDon_DTO(int mabn, string tenbn, int tienthuoc, int tiendv, int tongcong, string ngaykham)
        {
            MaBN = mabn; 
            TenBN = tenbn;
            TienThuoc = tienthuoc;
            TienDV = tiendv;
            TongCong = tongcong;
            NgayKham = ngaykham;
        }
    }

    public class LichSu_DTO {

        private string ngayKham;
        public string NgayKham
        {
            get { return ngayKham; }
            set { ngayKham = value; }
        }

        private int maBN;
        public int MaBN
        {
            get { return maBN; }
            set { maBN = value; }
        }

        private string tenBN;
        public string TenBN
        {
            get { return tenBN; }
            set { tenBN = value; }
        }

        private int maHD;
        public int MaHD
        {
            get { return maHD; }
            set { maHD = value; }
        }

        private int tongTien;
        public int TongTien
        {
            get { return tongTien; }
            set { tongTien = value; }
        }

        public LichSu_DTO(string ngaykham, int mabn, string tenbn, int mahd, int tongtien) {
            NgayKham = ngaykham;
            MaBN = mabn;
            TenBN = tenbn;
            MaHD = mahd;
            TongTien = tongtien;
        }
    }
}
