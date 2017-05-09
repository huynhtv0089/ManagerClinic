using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace frmQLPHONGKHAM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*
         * Start - Bệnh Nhân
         */
        int typeSearchBN = 0;
        string codeBN;
        private void btnThemBN_Click(object sender, EventArgs e)
        {
            string tenbenhnhan = txtTenBN.Text;
            string diachi = txtDiachiBN.Text;
            string ngaysinh = txtNgaysinhBN.Text;
            int sodienthoai = int.Parse(txtSdtBN.Text);
            string benhan = rtxtBenhanBN.Text;

            BenhNhan_DTO benhnhan = new BenhNhan_DTO(tenbenhnhan, diachi, ngaysinh, sodienthoai, benhan);
            BenhNhan_BUS.ThemBenhNhan(benhnhan);

            dgvResultBN.DataSource = BenhNhan_BUS.LoadDSBenhNhan();
        }

        private void btnDSBN_Click(object sender, EventArgs e)
        {
            dgvResultBN.DataSource = BenhNhan_BUS.LoadDSBenhNhan();
        }

        private void rdbMaBN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaBN.Checked == true)
            {
                typeSearchBN = 1;
            }
        }

        private void rdbTenBN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenBN.Checked == true) {
                typeSearchBN = 2;
            }
        }

        private void rdbDiachiBN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDiachiBN.Checked == true)
            {
                typeSearchBN = 3;
            }
        }

        private void rdbNgaysinhBN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNgaysinhBN.Checked == true)
            {
                typeSearchBN = 4;
            }
        }

        private void rbdSdtBN_CheckedChanged(object sender, EventArgs e)
        {
            if (rbdSdtBN.Checked == true)
            {
                typeSearchBN = 5;
            }
        }

        private void rdbBenhanBN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbBenhanBN.Checked == true)
            {
                typeSearchBN = 6;
            }
        }

        private void btnTimBN_Click(object sender, EventArgs e)
        {
            switch (typeSearchBN)
            {
                case 1:
                {
                    dgvResultBN.DataSource = BenhNhan_BUS.TimTheoMaBenhNhan(int.Parse(txtTimkiemBN.Text));
                    break;
                }
                case 2: 
                {
                    dgvResultBN.DataSource = BenhNhan_BUS.TimTheoTenBenhNhan(txtTimkiemBN.Text);
                    break;
                }
                case 3:
                {
                    dgvResultBN.DataSource = BenhNhan_BUS.TimTheoDiaChiBenhNhan(txtTimkiemBN.Text);
                    break;
                }
                case 4:
                {
                    dgvResultBN.DataSource = BenhNhan_BUS.TimTheoNgaySinhBenhNhan(txtTimkiemBN.Text);
                    break;
                }
                case 5:
                {
                    dgvResultBN.DataSource = BenhNhan_BUS.TimTheoSDTBenhNhan(int.Parse(txtTimkiemBN.Text));
                    break;
                }
                case 6:
                {
                    dgvResultBN.DataSource = BenhNhan_BUS.TimTheoBenhAnBenhNhan(txtTimkiemBN.Text);
                    break;
                }
            }
        }

        private void dgvResultBN_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try { 
                DataGridViewRow row = new DataGridViewRow();

                row = dgvResultBN.Rows[e.RowIndex];

                codeBN = row.Cells[0].Value.ToString();
                txtTenBN.Text = row.Cells[1].Value.ToString();
                txtDiachiBN.Text = row.Cells[2].Value.ToString();
                txtNgaysinhBN.Text = row.Cells[3].Value.ToString();
                txtSdtBN.Text = row.Cells[4].Value.ToString();
                rtxtBenhanBN.Text = row.Cells[5].Value.ToString();

            }catch(Exception ex) {
                throw ex;
            }
        }

        private void btnXoaBN_Click(object sender, EventArgs e)
        {
            BenhNhan_BUS.XoaBenhNhan(int.Parse(codeBN));
            //Load lại danh sách sau khi xóa 1 bệnh nhân
            dgvResultBN.DataSource = BenhNhan_BUS.LoadDSBenhNhan();
        }

        private void btnSuaBN_Click(object sender, EventArgs e)
        {
            BenhNhan_BUS.UpdateBenhNhan(int.Parse(codeBN), txtTenBN.Text, txtDiachiBN.Text, txtNgaysinhBN.Text, int.Parse(txtSdtBN.Text), rtxtBenhanBN.Text);
            //Load lại danh sách sau khi update 1 bệnh nhân
            dgvResultBN.DataSource = BenhNhan_BUS.LoadDSBenhNhan();
        }
        /* End - Bệnh nhân */

        /*
         * Start - Dich vu
         * 
         */
        int typeSrearchDV = 0;
        string codeDV;

        private void btnDSDV_Click(object sender, EventArgs e)
        {
            dgvResultDSDV.DataSource = DichVu_BUS.LoadDSDichVu();

            //Lấy combobox cho dùng dịch vụ
            cbTenDV_DungDV.DataSource = DichVu_BUS.LoadDSDichVu();
            cbTenDV_DungDV.DisplayMember = "TenDV";
            cbTenDV_DungDV.ValueMember = "GiaTien";
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string tendichvu = txtTenDV.Text;
            int giatien = int.Parse(txtGiaDV.Text);

            DichVu_DTO dv = new DichVu_DTO(tendichvu, giatien);
            DichVu_BUS.ThemDichVu(dv);

            dgvResultDSDV.DataSource = DichVu_BUS.LoadDSDichVu();
        }

        private void rdbMaDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaDV.Checked == true) {
                typeSrearchDV = 1;
            }
        }

        private void rdbTenDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenDV.Checked == true)
            {
                typeSrearchDV = 2;
            }
        }

        private void rdbGiaDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbGiaDV.Checked == true)
            {
                typeSrearchDV = 3;
            }
        }

        private void btnTimDV_Click(object sender, EventArgs e)
        {
            switch (typeSrearchDV)
            {
                case 1:
                {
                    dgvResultDSDV.DataSource = DichVu_BUS.TimTheoMaDV(int.Parse(txtTimKiemDV.Text));
                    break;
                }
                case 2:
                {
                    dgvResultDSDV.DataSource = DichVu_BUS.TimTheoTenDV(txtTimKiemDV.Text);
                    break;
                }
                case 3:
                {
                    dgvResultDSDV.DataSource = DichVu_BUS.TimTheoGiaTienDV(int.Parse(txtTimKiemDV.Text));
                    break;
                }
            }
        }

        private void dgvResultDSDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvResultDSDV.Rows[e.RowIndex];

                codeDV = row.Cells[0].Value.ToString();
                txtTenDV.Text = row.Cells[1].Value.ToString();
                txtGiaDV.Text = row.Cells[2].Value.ToString();
            }catch(Exception ex) {
                throw ex;
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            DichVu_BUS.XoaDichVu(int.Parse(codeDV));
            //Load lại danh sách sau khi xóa 1 dịch vụ
            dgvResultDSDV.DataSource = DichVu_BUS.LoadDSDichVu();
        }

        private void btnSuaDV_Click(object sender, EventArgs e)
        {
            DichVu_BUS.UpdateDichVu(int.Parse(codeDV), txtTenDV.Text, int.Parse(txtGiaDV.Text));
            //Load lại danh sách sau khi update 1 dịch vụ
            dgvResultDSDV.DataSource = DichVu_BUS.LoadDSDichVu();
        }

        /* End - Dịch vụ */

        /*
         * Start - Thuốc
         * 
         */
        int typeSearchThuoc = 0;
        string codeThuoc;

        private void btnDSThuoc_Click(object sender, EventArgs e)
        {
            dgvResultDSThuoc.DataSource = Thuoc_BUS.LoadDSThuoc();
        }

        private void btnThemThuoc_Click(object sender, EventArgs e)
        {
            string tenthuoc = txtTenThuoc.Text;
            int soluongton = int.Parse(txtSLTThuoc.Text);
            string dvt = txtDVTThuoc.Text;
            string ghichu = rtxtGhiChuThuoc.Text;

            Thuoc_DTO thuoc = new Thuoc_DTO(tenthuoc, soluongton, dvt, ghichu);
            Thuoc_BUS.ThemThuoc(thuoc);

            //Load danh sach benh nhan sau khi them
            dgvResultDSThuoc.DataSource = Thuoc_BUS.LoadDSThuoc();
        }

        private void rdbMaThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaThuoc.Checked == true)
            {
                typeSearchThuoc = 1;
            }
        }

        private void rdbTenThuoc_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenThuoc.Checked == true)
            {
                typeSearchThuoc = 2;
            }
        }

        private void btnTimKiemThuoc_Click_1(object sender, EventArgs e)
        {
            switch (typeSearchThuoc)
            {
                case 1:
                    {
                        dgvResultDSThuoc.DataSource = Thuoc_BUS.TimTheoMaThuoc(int.Parse(txtTimKiemThuoc.Text));
                        break;
                    }
                case 2:
                    {
                        dgvResultDSThuoc.DataSource = Thuoc_BUS.TimTheoTenThuoc(txtTimKiemThuoc.Text);
                        break;
                    }
            }
        }

        private void dgvResultDSThuoc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvResultDSThuoc.Rows[e.RowIndex];

                codeThuoc = row.Cells[0].Value.ToString();
                txtTenThuoc.Text = row.Cells[1].Value.ToString();
                txtSLTThuoc.Text = row.Cells[2].Value.ToString();
                txtDVTThuoc.Text = row.Cells[3].Value.ToString();
                rtxtGhiChuThuoc.Text = row.Cells[4].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnXoaThuoc_Click(object sender, EventArgs e)
        {
            Thuoc_BUS.XoaThuoc(int.Parse(codeThuoc));
            //Load lại danh sach sau khi xoa
            dgvResultDSThuoc.DataSource = Thuoc_BUS.LoadDSThuoc();
        }

        private void btnSuaThuoc_Click(object sender, EventArgs e)
        {
            Thuoc_BUS.UpdateThuoc(int.Parse(codeThuoc), txtTenThuoc.Text, int.Parse(txtSLTThuoc.Text), txtDVTThuoc.Text, rtxtGhiChuThuoc.Text);
            //Load lại danh sach sau khi update
            dgvResultDSThuoc.DataSource = Thuoc_BUS.LoadDSThuoc();
        }

        /* End - Thuốc */
        /*
         * Start - ĐơnThuốc
         * 
         */

        int typeSearchDT = 0;
        string sttDT;

        private void btnDSDT_Click(object sender, EventArgs e)
        {
            dgvResultDT.DataSource = DonThuoc_BUS.LoadDSDonThuoc();
        }

        private void btnThemDT_Click(object sender, EventArgs e)
        {
                string tenthuocDT = txtTenDT.Text;
                int mathuocDT = int.Parse(txtMaThuocDT.Text);
                int soluongDT = int.Parse(txtSoLuongDT.Text);
                int giatienDT = int.Parse(txtGiaTienDT.Text);
                int mabnDT = int.Parse(txtMaBNDT.Text);

                DonThuoc_DTO donthuoc = new DonThuoc_DTO(tenthuocDT, mathuocDT, soluongDT, giatienDT, mabnDT);
                DonThuoc_BUS.ThemDonThuoc(donthuoc);

                //Load lại danh sách đơn thuốc
                dgvResultDT.DataSource = DonThuoc_BUS.LoadDSDonThuoc();
                //Load lại danh sách thuốc
                dgvResultDSThuoc.DataSource = Thuoc_BUS.LoadDSThuoc();
                
        }

        private void rdbTenDT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenDT.Checked == true) {
                typeSearchDT = 1;
            }
        }

        private void rdbMaBNDT_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaBNDT.Checked == true)
            {
                typeSearchDT = 2;
            }
        }

        private void btnTimKiemDT_Click(object sender, EventArgs e)
        {
            switch (typeSearchDT)
            {
                case 1:
                {
                    dgvResultDT.DataSource = DonThuoc_BUS.TimTheoTenDT(txtTimKiemDT.Text);
                    break;       
                }
                case 2:
                {
                    dgvResultDT.DataSource = DonThuoc_BUS.TimTheoMaBNDT(int.Parse(txtTimKiemDT.Text));
                    break;
                }
            }
        }

        private void dgvResultDT_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvResultDT.Rows[e.RowIndex];

                sttDT = row.Cells[0].Value.ToString();
                txtMaThuocDT.Text = row.Cells[1].Value.ToString();
                txtTenDT.Text = row.Cells[2].Value.ToString();
                txtSoLuongDT.Text = row.Cells[3].Value.ToString();
                txtGiaTienDT.Text = row.Cells[4].Value.ToString();
                txtMaBNDT.Text = row.Cells[5].Value.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnXoaDT_Click(object sender, EventArgs e)
        {
            DonThuoc_BUS.XoaDonThuoc(int.Parse(sttDT));
            //Load lại danh sach sau khi xoa
            dgvResultDT.DataSource = DonThuoc_BUS.LoadDSDonThuoc();
        }

        private void btnSuaDT_Click(object sender, EventArgs e)
        {
            DonThuoc_BUS.UpdateDonThuoc(int.Parse(sttDT), txtTenDT.Text, int.Parse(txtMaThuocDT.Text), int.Parse(txtSoLuongDT.Text), int.Parse(txtGiaTienDT.Text), int.Parse(txtMaBNDT.Text));
            //Load lại danh sach sau khi sua
            dgvResultDT.DataSource = DonThuoc_BUS.LoadDSDonThuoc();
        }

        /* End - Thuốc */
        /*
        * Start - dùng dịch vụ
        * 
        */

        int typeSearchDungDV = 0;
        string sttDDV;

        private void btnDSDungDV_Click(object sender, EventArgs e)
        {
            dgvResult_DungDV.DataSource = DungDV_BUS.LoadDSDichVu_DungDV();
            //Lấy combobox cho dùng dịch vụ
            cbTenDV_DungDV.DataSource = DichVu_BUS.LoadDSDichVu();
            cbTenDV_DungDV.DisplayMember = "TenDV";
            cbTenDV_DungDV.ValueMember = "GiaTien";
        }

        private void btnThem_DungDV_Click(object sender, EventArgs e)
        {
            int madv_DungDV = int.Parse(txtMaDV_DungDV.Text);
            string tenDV_DungDV = cbTenDV_DungDV.Text;
            int giatien_DungDV = int.Parse(this.cbTenDV_DungDV.SelectedValue.ToString());
            int mabn_DungDV = int.Parse(txtMaBN_DungDV.Text);

            DungDV_DTO dungdv = new DungDV_DTO(madv_DungDV, tenDV_DungDV, giatien_DungDV, mabn_DungDV);
            DungDV_BUS.ThemDichVu_DungDV(dungdv);
            
            //Load lại danh sách dùng dịch vụ
            dgvResult_DungDV.DataSource = DungDV_BUS.LoadDSDichVu_DungDV();
        }

        private void rdbTenDV_DungDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenDV_DungDV.Checked == true)
            {
                typeSearchDungDV = 1;
            }
        }

        private void rdbMaDV_DungDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaDV_DungDV.Checked == true)
            {
                typeSearchDungDV = 2;
            }
        }

        private void rdbMaBN_DungDV_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaBN_DungDV.Checked == true)
            {
                typeSearchDungDV = 3;
            }
        }

        private void btnTimkiem_DungDV_Click(object sender, EventArgs e)
        {
            switch (typeSearchDungDV)
            {
                case 1:
                    {
                        dgvResult_DungDV.DataSource = DungDV_BUS.TimTheoTenDV_DungDV(txtTimkiem_DungDV.Text);
                        break;
                    }
                case 2:
                    {
                        dgvResult_DungDV.DataSource = DungDV_BUS.TimTheoMaDV_DungDV(int.Parse(txtTimkiem_DungDV.Text));
                        break;
                    }
                case 3:
                    {
                        dgvResult_DungDV.DataSource = DungDV_BUS.TimTheoMaBN_DungDV(int.Parse(txtTimkiem_DungDV.Text));
                        break;
                    }
            }
        }

        private void dgvResult_DungDV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvResult_DungDV.Rows[e.RowIndex];

                sttDDV = row.Cells[0].Value.ToString();
                txtMaDV_DungDV.Text = row.Cells[1].Value.ToString();
                cbTenDV_DungDV.Text = row.Cells[2].Value.ToString();
                txtMaBN_DungDV.Text = row.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnXoa_DungDV_Click(object sender, EventArgs e)
        {
            DungDV_BUS.XoaDV_DungDV(int.Parse(sttDDV));

            //Load lại danh sách dùng dịch vụ
            dgvResult_DungDV.DataSource = DungDV_BUS.LoadDSDichVu_DungDV();

            //làm mới combobox có thêm dữ liệu
            cbTenDV_DungDV.DataSource = DichVu_BUS.LoadDSDichVu();
            cbTenDV_DungDV.DisplayMember = "TenDV";
            cbTenDV_DungDV.ValueMember = "GiaTien";
        }

        private void btnSua_DungDV_Click(object sender, EventArgs e)
        {
            DungDV_BUS.updateDichVu_DungDV(int.Parse(sttDDV), int.Parse(txtMaDV_DungDV.Text), cbTenDV_DungDV.Text, int.Parse(txtMaBN_DungDV.Text));
            //Load lại danh sách dùng dịch vụ
            dgvResult_DungDV.DataSource = DungDV_BUS.LoadDSDichVu_DungDV();
            //Lấy combobox cho dùng dịch vụ
            cbTenDV_DungDV.DataSource = DichVu_BUS.LoadDSDichVu();
            cbTenDV_DungDV.DisplayMember = "TenDV";
            cbTenDV_DungDV.ValueMember = "GiaTien";
        }

        /* End - dùng dịch vụ */
        /*
        * Start - Hóa đơn
        * 
        */

        int typeSearchHoadon = 0;
        string mahoadon;

        private void btnDanhSach_Hoadon_Click(object sender, EventArgs e)
        {
            dgvHoadon.DataSource = HoaDon_BUS.LoadDSHoadon();
        }

        private void btnThem_Hoadon_Click(object sender, EventArgs e)
        {
            int mabn_hoadon = int.Parse(txtMaBN_Hoadon.Text);
            string tenbn_hoadon = txtTenBN_Hoadon.Text;
            int tienthuoc_hoadon = HoaDon_BUS.tienthuoc_Hoadon(mabn_hoadon);
            int tiendv_hoadon = HoaDon_BUS.tiendv_Hoadon(mabn_hoadon);
            int tongtien_hoadon = tienthuoc_hoadon + tiendv_hoadon;
            string ngaykham_hoadon = txtNgaykham_Hoadon.Text;

            HoaDon_DTO hoadon = new HoaDon_DTO(mabn_hoadon, tenbn_hoadon, tienthuoc_hoadon, tiendv_hoadon, tongtien_hoadon, ngaykham_hoadon);
            HoaDon_BUS.ThemHoadon(hoadon);

            //Load lại danh sách hóa đơn
            dgvHoadon.DataSource = HoaDon_BUS.LoadDSHoadon();
        }

        private void rdbMaBN_Hoadon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaBN_Hoadon.Checked == true)
            {
                typeSearchHoadon = 1;
            }
        }

        private void rdbTenBN_Hoadon_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenBN_Hoadon.Checked == true)
            {
                typeSearchHoadon = 2;
            }
        }

        private void rdbNgayKham_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNgayKham.Checked == true)
            {
                typeSearchHoadon = 3;
            }
        }

        private void btnTimKiem_Hoadon_Click(object sender, EventArgs e)
        {
            switch (typeSearchHoadon)
            {
                case 1:
                    {
                        dgvHoadon.DataSource = HoaDon_BUS.TimTheoMaBenhNhan_Hoadon(int.Parse(txtTimkiem_Hoadon.Text));
                        break;
                    }
                case 2:
                    {
                        dgvHoadon.DataSource = HoaDon_BUS.TimTheoTenBenhNhan_Hoadon(txtTimkiem_Hoadon.Text);
                        break;
                    }
                case 3:
                    {
                        dgvHoadon.DataSource = HoaDon_BUS.TimTheoNgayKhamBN(txtTimkiem_Hoadon.Text);
                        break;
                    }
            }
        }

        private void btnXoa_Hoadon_Click(object sender, EventArgs e)
        {
            HoaDon_BUS.XoaHoadon(int.Parse(mahoadon));
            //Load lại danh sách sau khi xóa
            dgvHoadon.DataSource = HoaDon_BUS.LoadDSHoadon();
        }

        private void dgvHoadon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                row = dgvHoadon.Rows[e.RowIndex];

                mahoadon = row.Cells[0].Value.ToString();
                txtMaBN_Hoadon.Text = row.Cells[1].Value.ToString();
                txtTenBN_Hoadon.Text = row.Cells[2].Value.ToString();
                txtNgaykham_Hoadon.Text = row.Cells[6].Value.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void btnSua_Hoadon_Click(object sender, EventArgs e)
        {
            HoaDon_BUS.UpdateHoadon(int.Parse(mahoadon), int.Parse(txtMaBN_Hoadon.Text), txtTenBN_Hoadon.Text, txtNgaykham_Hoadon.Text);
            //Load lại danh sách sau khi sửa 
            dgvHoadon.DataSource = HoaDon_BUS.LoadDSHoadon();
        }

        /* End - Hóa đơn */
        /*
        * Start - Lịch sử
        * 
        */

        int typeSearchLichsu = 0;

        private void rdbNgayKham_lichsu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbNgayKham_lichsu.Checked == true)
            {
                typeSearchLichsu = 1;
            }
        }

        private void rdbMaBN_lichsu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbMaBN_lichsu.Checked == true)
            {
                typeSearchLichsu = 2;
            }
            
        }

        private void rdbTenBN_lichsu_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbTenBN_lichsu.Checked == true)
            {
                typeSearchLichsu = 3;
            }
        }

        private void btnTimKiem_lichsu_Click(object sender, EventArgs e)
        {
            switch (typeSearchLichsu)
            {
                case 1:
                    {
                        dgvLichsu_result.DataSource = LichSu_BUS.TimTheoNgayKham_lichsu(txtTimKiem_lichsu.Text);
                        break;
                    }
                case 2:
                    {
                        dgvLichsu_result.DataSource = LichSu_BUS.TimTheoMaBN_lichsu(int.Parse(txtTimKiem_lichsu.Text));
                        break;
                    }
                case 3:
                    {
                        dgvLichsu_result.DataSource = LichSu_BUS.TimTheoTenBN_lichsu(txtTimKiem_lichsu.Text);
                        break;
                    }
            }
        }


    }
}
