using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class sqlConnectionData {
        public static SqlConnection connectdata() {
            SqlConnection cnn = new SqlConnection(@"Data Source = HOME-PC\SQLEXPRESS; Database=QLPHONGKHAM; User ID = sa;Password=123456");
            return cnn;
        }
    }
    public class BenhNhan_DAO
    {
        //Load danh sách bệnh nhân
        public static DataTable LoadDSBenhNhan() {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Thêm bệnh nhân
        public static void ThemBenhNhan(BenhNhan_DTO benhnhan) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_themBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime);
            cmd.Parameters.Add("@SDT", SqlDbType.Int);
            cmd.Parameters.Add("@BenhAn", SqlDbType.NVarChar, 200);

            cmd.Parameters["@TenBN"].Value = benhnhan.TenBenhNhan;
            cmd.Parameters["@DiaChi"].Value = benhnhan.DiaChi;
            cmd.Parameters["@NgaySinh"].Value = benhnhan.NgaySinh;
            cmd.Parameters["@SDT"].Value = benhnhan.Sdt;
            cmd.Parameters["@BenhAn"].Value = benhnhan.BenhAn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //Tìm theo mã bệnh nhân
        public static DataTable TimTheoMaBenhNhan(int mabn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = mabn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo tên bệnh nhân
        public static DataTable TimTheoTenBenhNhan(string tenbn) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoTenBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = tenbn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo địa chỉ bệnh nhân
        public static DataTable TimTheoDiaChiBenhNhan(string diachi)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoDiaChiBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            cmd.Parameters["@DiaChi"].Value = diachi;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo ngày sinh bệnh nhân
        public static DataTable TimTheoNgaySinhBenhNhan(string ngaysinh)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoNgaySinhBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime);
            cmd.Parameters["@NgaySinh"].Value = ngaysinh;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo số điện thoại bệnh nhân
        public static DataTable TimTheoSDTBenhNhan(int sdt)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoSDTBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SDT", SqlDbType.Int);
            cmd.Parameters["@SDT"].Value = sdt;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo bệnh án bệnh nhân
        public static DataTable TimTheoBenhAnBenhNhan(string benhan)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoBenhAnBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@BenhAn", SqlDbType.NVarChar, 200);
            cmd.Parameters["@BenhAn"].Value = benhan;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Xóa bệnh nhân theo mã bệnh nhân
        public static void XoaBenhNhan(int mabn) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_XoaBenhNhan", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = mabn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Update bệnh nhân theo mã bệnh nhân
        public static void UpdateBenhNhan(int mabn, string tenbn, string diachi, string ngaysinh, int sdt, string benhan) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_updateThongTinBN", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@DiaChi", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgaySinh", SqlDbType.DateTime);
            cmd.Parameters.Add("@SDT", SqlDbType.Int);
            cmd.Parameters.Add("@BenhAn", SqlDbType.NVarChar, 200);

            cmd.Parameters["@MaBN"].Value = mabn;
            cmd.Parameters["@TenBN"].Value = tenbn;
            cmd.Parameters["@DiaChi"].Value = diachi;
            cmd.Parameters["@NgaySinh"].Value = ngaysinh;
            cmd.Parameters["@SDT"].Value = sdt;
            cmd.Parameters["@BenhAn"].Value = benhan;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }

    public class DichVu_DAO {
        //Load danh sách dịch vụ
        public static DataTable LoadDSDichVu() {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSDichVu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Thêm danh sách dịch vụ
        public static void ThemDichVu(DichVu_DTO dichvu) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_themDichVu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int);

            cmd.Parameters["@TenDV"].Value = dichvu.Tendv;
            cmd.Parameters["@GiaTien"].Value = dichvu.Giatien;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Tìm theo tên dịch vụ
        public static DataTable TimTheoTenDV(string tendv) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoTenDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenDV"].Value = tendv;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo mã dịch vụ
        public static DataTable TimTheoMaDV(int madv)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.Int);
            cmd.Parameters["@MaDV"].Value = madv;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo giá tiền dịch vụ
        public static DataTable TimTheoGiaTienDV(int giatien)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoGiaTienDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int);
            cmd.Parameters["@GiaTien"].Value = giatien;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Xóa danh sách dịch vụ
        public static void XoaDichVu(int madv) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_XoaDichVu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.Int);
            cmd.Parameters["@MaDV"].Value = madv;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Update danh sách dịch vụ
        public static void UpdateDichVu(int madv, string tendv, int giatien)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_updateThongTinDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaDV", SqlDbType.Int);
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int);
            cmd.Parameters["@MaDV"].Value = madv;
            cmd.Parameters["@TenDV"].Value = tendv;
            cmd.Parameters["@GiaTien"].Value = giatien;
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }

    public class Thuoc_DAO { 
        //Load danh sách thuốc
        public static DataTable LoadDSThuoc() {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Thêm vào danh sách thuốc
        public static void ThemThuoc(Thuoc_DTO thuoc) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_themThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.Int);
            cmd.Parameters.Add("@DVT", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 200);

            cmd.Parameters["@TenThuoc"].Value = thuoc.TenThuoc;
            cmd.Parameters["@SoLuongTon"].Value = thuoc.SoLuongTon;
            cmd.Parameters["@DVT"].Value = thuoc.DVT;
            cmd.Parameters["@GhiChu"].Value = thuoc.GhiChu;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Tìm mã thuốc
        public static DataTable TimTheoMaThuoc(int mathuoc)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters["@MaThuoc"].Value = mathuoc;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm tên thuốc
        public static DataTable TimTheoTenThuoc(string tenthuoc) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoTenThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenThuoc"].Value = tenthuoc;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Xóa thuốc
        public static void XoaThuoc(int mathuoc) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_XoaThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters["@MaThuoc"].Value = mathuoc;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Update danh sách thuốc
        public static void UpdateThuoc(int mathuoc, string tenthuoc, int soluongton, string dvt, string ghichu) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_updateThongTinThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@SoLuongTon", SqlDbType.Int);
            cmd.Parameters.Add("@DVT", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GhiChu", SqlDbType.NVarChar, 200);

            cmd.Parameters["@MaThuoc"].Value = mathuoc;
            cmd.Parameters["@TenThuoc"].Value = tenthuoc;
            cmd.Parameters["@SoLuongTon"].Value = soluongton;
            cmd.Parameters["@DVT"].Value = dvt;
            cmd.Parameters["@GhiChu"].Value = ghichu;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Lấy danh sách tên thuốc
        public static DataTable LayDSTenThuocDT()
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LayDSTenThuocDT", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
    }

    public class DonThuoc_DAO { 
        //Load danh sách đơn thuốc
        public static DataTable LoadDSDonThuoc() {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSDonThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Thêm vào danh sách đơn thuốc
        public static void ThemDonThuoc(DonThuoc_DTO donthuoc) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_ThemDonThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);

            cmd.Parameters["@TenThuoc"].Value = donthuoc.TenThuoc;
            cmd.Parameters["@MaThuoc"].Value = donthuoc.Mathuoc;
            cmd.Parameters["@SoLuong"].Value = donthuoc.SoLuong;
            cmd.Parameters["@GiaTien"].Value = donthuoc.GiaTien;
            cmd.Parameters["@MaBN"].Value = donthuoc.MaBN;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Tìm mã đơn thuốc
        public static DataTable TimTheoTenDT(string tenthuoc) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoTenDT", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenThuoc"].Value = tenthuoc;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo mã bệnh nhân trong đơn thuốc
        public static DataTable TimTheoMaBNDT(int mabn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaBNDT", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = mabn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Xóa đơn thuốc
        public static void XoaDonThuoc(int stt) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_XoaDonThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@STT", SqlDbType.Int);
            cmd.Parameters["@STT"].Value = stt;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Update danh sách đơn thuốc
        public static void UpdateDonThuoc(int stt, string tenthuoc, int mathuoc, int soluong, int giatien, int mabn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_updateThongTinDonThuoc", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@STT", SqlDbType.Int);
            cmd.Parameters.Add("@TenThuoc", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@SoLuong", SqlDbType.Int);
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);

            cmd.Parameters["@STT"].Value = stt;
            cmd.Parameters["@TenThuoc"].Value = tenthuoc;
            cmd.Parameters["@MaThuoc"].Value = mathuoc;
            cmd.Parameters["@SoLuong"].Value = soluong;
            cmd.Parameters["@GiaTien"].Value = giatien;
            cmd.Parameters["@MaBN"].Value = mabn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }

    public class DungDV_DAO { 
        //Load danh sách dùng dv
        public static DataTable LoadDSDichVu_DungDV() {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSDichVu_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Thêm vào danh sách dùng dv
        public static void ThemDichVu_DungDV(DungDV_DTO dungdv) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_ThemDichVu_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MaDV", SqlDbType.Int);
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@GiaTien", SqlDbType.Int);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);

            cmd.Parameters["@MaDV"].Value = dungdv.MaDv;
            cmd.Parameters["@TenDV"].Value = dungdv.TenDv;
            cmd.Parameters["@GiaTien"].Value = dungdv.GiaTien;
            cmd.Parameters["@MaBN"].Value = dungdv.MaBn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //Tìm theo mã dịch vụ
        public static DataTable TimTheoMaDV_DungDV(int madv) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaDV_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MaDV", SqlDbType.Int);
            cmd.Parameters["@MaDV"].Value = madv;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo mã bệnh nhân
        public static DataTable TimTheoMaBN_DungDV(int mabn) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaBN_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = mabn;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Tìm theo tên dịch vụ
        public static DataTable TimTheoTenDV_DungDV(string tendv) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoTenDV_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenDV"].Value = tendv;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }
        //Xóa danh sách dùng dịch vụ
        public static void XoaDV_DungDV(int stt) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_XoaDV_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@STT", SqlDbType.Int);
            cmd.Parameters["@STT"].Value = stt;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
        //update danh sách dùng dịch vụ
        public static void updateDichVu_DungDV(int stt, int madv, string tendv, int mabn) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_updateDichVu_DungDV", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@STT", SqlDbType.Int);
            cmd.Parameters.Add("@MaDV", SqlDbType.Int);
            cmd.Parameters.Add("@TenDV", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);

            cmd.Parameters["@STT"].Value = stt;
            cmd.Parameters["@MaDV"].Value = madv;
            cmd.Parameters["@TenDV"].Value = tendv;
            cmd.Parameters["@MaBN"].Value = mabn;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }
    }

    public class HoaDon_DAO {
        //Load danh sách hóa đơn
        public static DataTable LoadDSHoadon()
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSHoadon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Thêm hóa đơn
        public static void ThemHoadon(HoaDon_DTO hoadon)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_ThemHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@TienThuoc", SqlDbType.Int);
            cmd.Parameters.Add("@TienDV", SqlDbType.Int);
            cmd.Parameters.Add("@TongCong", SqlDbType.Int);
            cmd.Parameters.Add("@NgayKham", SqlDbType.DateTime);

            cmd.Parameters["@MaBN"].Value = hoadon.MaBN;
            cmd.Parameters["@TenBN"].Value = hoadon.TenBN;
            cmd.Parameters["@TienThuoc"].Value = hoadon.TienThuoc;
            cmd.Parameters["@TienDV"].Value = hoadon.TienDV;
            cmd.Parameters["@TongCong"].Value = hoadon.TongCong;
            cmd.Parameters["@NgayKham"].Value = hoadon.NgayKham;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //Tìm theo mã bệnh nhân tab hóa đơn
        public static DataTable TimTheoMaBenhNhan_Hoadon(int mabn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoMaBN_Hoadon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = mabn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Tìm theo tên bệnh nhân tab hóa đơn
        public static DataTable TimTheoTenBenhNhan_Hoadon(string tenbn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoTenBN_Hoadon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = tenbn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Tìm theo ngày khám bệnh nhân
        public static DataTable TimTheoNgayKhamBN(string ngaykham)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTheoNgay_Hoadon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham", SqlDbType.DateTime);
            cmd.Parameters["@NgayKham"].Value = ngaykham;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Xóa hóa đơn theo mã hóa đơn
        public static void XoaHoadon(int mahd)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_XoaHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHD", SqlDbType.Int);
            cmd.Parameters["@MaHD"].Value = mahd;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //Update hóa đơn theo mã hóa đơn
        public static void UpdateHoadon(int mahd, int mabn, string tenbn, string ngaykham)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_updateHoaDon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaHD", SqlDbType.Int);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@NgayKham", SqlDbType.DateTime);

            cmd.Parameters["@MaHD"].Value = mahd;
            cmd.Parameters["@MaBN"].Value = mabn;
            cmd.Parameters["@TenBN"].Value = tenbn;
            cmd.Parameters["@NgayKham"].Value = ngaykham;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //Tiền thuốc trong hóa đơn
        public static int tienthuoc_Hoadon(int mabn)
        {
            int tongtien;
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_tienthuoc_Hoadon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters["@MaBN"].Value = mabn;
            cnn.Open();
            tongtien = cmd.ExecuteNonQuery();
            cnn.Close();
            return tongtien;
        }

        //Tiền dịch vụ trong hóa đơn
        public static int tiendv_Hoadon(int mabn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_tiendv_Hoadon", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@tiendv", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.Parameters["@MaBN"].Value = mabn;

            cnn.Open();
            int tongtien = cmd.ExecuteNonQuery();
            cnn.Close();

            return tongtien;
        }
    }

    public class LichSu_DAO { 
        //Load danh sách lịch sử
        public static DataTable LoadDSLichsu() {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_LoadDSLichsu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Thêm lịch sử
        public static void ThemLichsu(LichSu_DTO lichsu) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_ThemLichSu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add("@NgayKham", SqlDbType.DateTime);
            cmd.Parameters.Add("@MaBN", SqlDbType.Int);
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters.Add("@MaHD", SqlDbType.Int);
            cmd.Parameters.Add("@TongTien", SqlDbType.Int);

            cmd.Parameters["@NgayKham"].Value = lichsu.NgayKham;
            cmd.Parameters["@MaBN"].Value = lichsu.MaBN;
            cmd.Parameters["@TenBN"].Value = lichsu.TenBN;
            cmd.Parameters["@MaHD"].Value = lichsu.MaHD;
            cmd.Parameters["@TongTien"].Value = lichsu.TongTien;

            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //Tìm theo ngày khám
        public static DataTable TimTheoNgayKham_lichsu(string ngaykham) {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimNgaykham_lichsu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@NgayKham", SqlDbType.DateTime);
            cmd.Parameters["@NgayKham"].Value = ngaykham;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Tìm mã bệnh nhân
        public static DataTable TimTheoMaBN_lichsu(int mabn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimMabn_lichsu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@MaBn", SqlDbType.Int);
            cmd.Parameters["@MaBn"].Value = mabn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

        //Tìm tên bệnh nhân
        public static DataTable TimTheoTenBN_lichsu(string tenbn)
        {
            SqlConnection cnn = sqlConnectionData.connectdata();
            SqlCommand cmd = new SqlCommand("sp_TimTenBN_lichsu", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@TenBN", SqlDbType.NVarChar, 50);
            cmd.Parameters["@TenBN"].Value = tenbn;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dtb = new DataTable();
            da.Fill(dtb);
            return dtb;
        }

    }
}
