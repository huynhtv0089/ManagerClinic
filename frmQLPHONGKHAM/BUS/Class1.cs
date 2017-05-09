using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;
using DTO;

namespace BUS
{
    public class BenhNhan_BUS
    {
        //Load danh sách bệnh nhân
        public static DataTable LoadDSBenhNhan() {
            return BenhNhan_DAO.LoadDSBenhNhan();
        }
        //Thêm bệnh nhân
        public static void ThemBenhNhan(BenhNhan_DTO benhnhan) {
            BenhNhan_DAO.ThemBenhNhan(benhnhan);
        }

        //Tìm theo mã bệnh nhân
        public static DataTable TimTheoMaBenhNhan(int mabn) {
            return BenhNhan_DAO.TimTheoMaBenhNhan(mabn);
        }
        //Tìm theo tên bệnh nhân
        public static DataTable TimTheoTenBenhNhan(string tenbn) {
            return BenhNhan_DAO.TimTheoTenBenhNhan(tenbn);
        }
        //Tìm theo địa chỉ bệnh nhân
        public static DataTable TimTheoDiaChiBenhNhan(string diachi) {
            return BenhNhan_DAO.TimTheoDiaChiBenhNhan(diachi);
        }
        //Tìm theo ngày sinh bệnh nhân
        public static DataTable TimTheoNgaySinhBenhNhan(string ngaysinh) {
            return BenhNhan_DAO.TimTheoNgaySinhBenhNhan(ngaysinh);
        }
        //Tìm theo số điện thoại bệnh nhân
        public static DataTable TimTheoSDTBenhNhan(int sdt) {
            return BenhNhan_DAO.TimTheoSDTBenhNhan(sdt);
        }
        //Tìm theo bệnh án bệnh nhân
        public static DataTable TimTheoBenhAnBenhNhan(string benhan) {
            return BenhNhan_DAO.TimTheoBenhAnBenhNhan(benhan);
        }
        //Xóa bệnh nhân theo mã bệnh nhân
        public static void XoaBenhNhan(int mabn) {
            BenhNhan_DAO.XoaBenhNhan(mabn);
        }
        //Update bệnh nhân theo mã bệnh nhân
        public static void UpdateBenhNhan(int mabn, string tenbn, string diachi, string ngaysinh, int sdt, string benhan) {
            BenhNhan_DAO.UpdateBenhNhan(mabn, tenbn, diachi, ngaysinh, sdt, benhan);
        }
    }

    public class DichVu_BUS { 
        //Load danh sách dịch vụ
        public static DataTable LoadDSDichVu() {
            return DichVu_DAO.LoadDSDichVu();
        }
        //Thêm danh sách dịch vụ
        public static void ThemDichVu(DichVu_DTO dichvu) {
            DichVu_DAO.ThemDichVu(dichvu);
        }
        //Tìm theo mã dịch vụ
        public static DataTable TimTheoMaDV(int madv) {
            return DichVu_DAO.TimTheoMaDV(madv);
        }
        //Tìm theo tên dịch vụ
        public static DataTable TimTheoTenDV(string tendv) {
            return DichVu_DAO.TimTheoTenDV(tendv);
        }
        
        //Tìm theo giá tiền dịch vụ
        public static DataTable TimTheoGiaTienDV(int giatien) {
            return DichVu_DAO.TimTheoGiaTienDV(giatien);
        }
        //Xóa danh sách dịch vụ
        public static void XoaDichVu(int madv) {
            DichVu_DAO.XoaDichVu(madv);
        }
        //Update danh sách dịch vụ
        public static void UpdateDichVu(int madv, string tendv, int giatien) {
            DichVu_DAO.UpdateDichVu(madv, tendv, giatien);
        }
    }

    public class Thuoc_BUS { 
        //Load danh sách thuốc
        public static DataTable LoadDSThuoc() {
            return Thuoc_DAO.LoadDSThuoc();
        }
        //Thêm vào danh sách thuốc
        public static void ThemThuoc(Thuoc_DTO thuoc) {
            Thuoc_DAO.ThemThuoc(thuoc);
        }
        //Tìm ma thuốc
        public static DataTable TimTheoMaThuoc(int mathuoc) {
            return Thuoc_DAO.TimTheoMaThuoc(mathuoc);
        }
        //Tìm tên thuốc
        public static DataTable TimTheoTenThuoc(string tenthuoc) {
            return Thuoc_DAO.TimTheoTenThuoc(tenthuoc);
        }
        //Xóa thuốc
        public static void XoaThuoc(int mathuoc) {
            Thuoc_DAO.XoaThuoc(mathuoc);
        }
        //Update danh sách thuốc
        public static void UpdateThuoc(int mathuoc, string tenthuoc, int soluongton, string dvt, string ghichu) {
            Thuoc_DAO.UpdateThuoc(mathuoc, tenthuoc, soluongton, dvt, ghichu);
        }
        //Lấy danh sách tên thuốc
        public static DataTable LayDSTenThuocDT()
        {
            return Thuoc_DAO.LayDSTenThuocDT();
        }
    }

    public class DonThuoc_BUS { 
        //Load danh sách đơn thuốc
        public static DataTable LoadDSDonThuoc() {
            return DonThuoc_DAO.LoadDSDonThuoc();
        }
        //Thêm vào danh sách đơn thuốc
        public static void ThemDonThuoc(DonThuoc_DTO donthuoc) {
            DonThuoc_DAO.ThemDonThuoc(donthuoc);
        }
        //Tìm mã đơn thuốc
        public static DataTable TimTheoTenDT(string tenthuoc) {
            return DonThuoc_DAO.TimTheoTenDT(tenthuoc);
        }
        //Tìm theo mã bệnh nhân trong đơn thuốc
        public static DataTable TimTheoMaBNDT(int mabn) {
            return DonThuoc_DAO.TimTheoMaBNDT(mabn);
        }
        //Xóa đơn thuốc
        public static void XoaDonThuoc(int madt) {
            DonThuoc_DAO.XoaDonThuoc(madt);
        }
        //Update danh sách đơn thuốc
        public static void UpdateDonThuoc(int madt, string tenthuoc, int mathuoc, int soluong, int giatien, int mabn) {
            DonThuoc_DAO.UpdateDonThuoc(madt, tenthuoc, mathuoc, soluong, giatien, mabn);
        }

    }

    public class DungDV_BUS { 
        //Load danh sách dùng dv
        public static DataTable LoadDSDichVu_DungDV() {
            return DungDV_DAO.LoadDSDichVu_DungDV();
        }
        //Thêm vào danh sách dùng dv
        public static void ThemDichVu_DungDV(DungDV_DTO dungdv) {
            DungDV_DAO.ThemDichVu_DungDV(dungdv);
        }
        //Tìm theo mã dịch vụ
        public static DataTable TimTheoMaDV_DungDV(int madv) {
            return DungDV_DAO.TimTheoMaDV_DungDV(madv);
        }
        //Tìm theo mã bệnh nhân
        public static DataTable TimTheoMaBN_DungDV(int mabn) {
            return DungDV_DAO.TimTheoMaBN_DungDV(mabn);
        }
        //Tìm theo tên dịch vụ
        public static DataTable TimTheoTenDV_DungDV(string tendv) {
            return DungDV_DAO.TimTheoTenDV_DungDV(tendv);
        }
        //Xóa danh sách dùng dịch vụ
        public static void XoaDV_DungDV(int stt) {
            DungDV_DAO.XoaDV_DungDV(stt);
        }
        //update danh sách dùng dịch vụ
        public static void updateDichVu_DungDV(int stt, int madv, string tendv, int mabn) {
            DungDV_DAO.updateDichVu_DungDV(stt, madv, tendv, mabn);
        }
    }

    public class HoaDon_BUS { 
        //Load danh sách hóa đơn
        public static DataTable LoadDSHoadon() {
            return HoaDon_DAO.LoadDSHoadon();
        }
        //Thêm hóa đơn
        public static void ThemHoadon(HoaDon_DTO hoadon) {
            HoaDon_DAO.ThemHoadon(hoadon);
        }
        //Tìm theo mã bệnh nhân tab hóa đơn
        public static DataTable TimTheoMaBenhNhan_Hoadon(int mabn) {
            return HoaDon_DAO.TimTheoMaBenhNhan_Hoadon(mabn);
        }
        //Tìm theo tên bệnh nhân tab hóa đơn
        public static DataTable TimTheoTenBenhNhan_Hoadon(string tenbn) {
            return HoaDon_DAO.TimTheoTenBenhNhan_Hoadon(tenbn);
        }
        //Tìm theo ngày khám bệnh nhân
        public static DataTable TimTheoNgayKhamBN(string ngaykham) {
            return HoaDon_DAO.TimTheoNgayKhamBN(ngaykham);
        }
        //Xóa hóa đơn theo mã hóa đơn
        public static void XoaHoadon(int mahd) {
            HoaDon_DAO.XoaHoadon(mahd);
        }
        //Update hóa đơn theo mã hóa đơn
        public static void UpdateHoadon(int mahd, int mabn, string tenbn, string ngaykham) {
            HoaDon_DAO.UpdateHoadon(mahd, mabn, tenbn, ngaykham);
        }
        //Tiền thuốc trong hóa đơn
        public static int tienthuoc_Hoadon(int mahd) {
            return HoaDon_DAO.tienthuoc_Hoadon(mahd);
        }
        //Tiền dịch vụ trong hóa đơn
        public static int tiendv_Hoadon(int mahd)
        {
            return HoaDon_DAO.tiendv_Hoadon(mahd);
        }
    }

    public class LichSu_BUS { 
        //Load danh sách lịch sử
        public static DataTable LoadDSLichsu() {
            return LichSu_DAO.LoadDSLichsu();
        }

        //Thêm lịch sử
        public static void ThemLichsu(LichSu_DTO lichsu) {
            LichSu_DAO.ThemLichsu(lichsu);
        }

        //Tìm theo ngày khám
        public static DataTable TimTheoNgayKham_lichsu(string ngaykham) {
            return LichSu_DAO.TimTheoNgayKham_lichsu(ngaykham);
        }

        //Tìm mã bệnh nhân
        public static DataTable TimTheoMaBN_lichsu(int mabn) {
            return LichSu_DAO.TimTheoMaBN_lichsu(mabn);
        }

        //Tìm tên bệnh nhân
        public static DataTable TimTheoTenBN_lichsu(string tenbn) {
            return LichSu_DAO.TimTheoTenBN_lichsu(tenbn);
        }
    }
}
