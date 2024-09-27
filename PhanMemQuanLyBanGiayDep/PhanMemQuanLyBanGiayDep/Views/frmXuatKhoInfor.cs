using PhanMemQuanLyBanGiayDep.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyBanGiayDep.Views
{
    public partial class frmXuatKhoInfor : Form
    {
        public frmXuatKhoInfor()
        {
            InitializeComponent();
        }
        HangHoaControllers dbmp = new HangHoaControllers();
        KhachHangControllers dbkh = new KhachHangControllers();
        XuatKhoControllers dbhd = new XuatKhoControllers();
        private void frmXuatKhoInfor_Load(object sender, EventArgs e)
        {
            DanhSachKhachHang();
            HienThiHangHoa();
            if (frmXuatKho.save == true)
            {

                GenCode();
                HienThiChiTietXuatKho();
                txtTongTien.Text = "0";
                txtmanv.Text = frmDangNhap.tennv;
            }
            else
            {
                cbomakh.SelectedValue = frmXuatKho.makh;
                txtmahd.Text = frmXuatKho.mahd;
                txtmanv.Text = frmDangNhap.tennv;
                dtNgayHD.Value = frmXuatKho.ngayban;
                HienThiChiTietXuatKho();
                TongTienXuatKho();
            }
        }
        private void GenCode()
        {
            string sTemp = "PXK_" +  DateTime.Now.ToString("yyMMddhhmmss");
            txtmahd.Text = sTemp;
        }
        private void DanhSachKhachHang()
        {
            DataTable dt = new DataTable();
            dt = dbkh.HienThi("");
            cbomakh.DataSource = dt;
            cbomakh.DisplayMember = "tenkh";
            cbomakh.ValueMember = "makh";
        }
        private void HienThiHangHoa()
        {
            DataTable dt = new DataTable();
            dt = dbmp.HienThiHangHoaXuatKho(txttenhh.Text);
            grdHangHoa.DataSource = dt;
            grdHangHoa.Columns[0].HeaderText = "Mã hàng hóa";
            grdHangHoa.Columns[1].HeaderText = "Tên hàng hóa";
            grdHangHoa.Columns[2].HeaderText = "Mã loại hàng hóa";
            grdHangHoa.Columns[3].HeaderText = "Tồn kho";
            grdHangHoa.Columns[4].HeaderText = "Đơn giá";
            grdHangHoa.Columns[5].HeaderText = "Mã nhà cung cấp";
            
        }
        private void HienThiChiTietXuatKho()
        {
            DataTable dt = new DataTable();
            dt = dbhd.HienThiChiTietXuatKho(txtmahd.Text);
            grdCTHD.DataSource = dt;
            grdCTHD.Columns[0].HeaderText = "Mã hóa đơn";
            grdCTHD.Columns[1].HeaderText = "Mã hàng hóa";
            grdCTHD.Columns[2].HeaderText = "Tên hàng hóa";
            grdCTHD.Columns[3].HeaderText = "Đơn giá";
            grdCTHD.Columns[4].HeaderText = "Số lượng";
            grdCTHD.Columns[5].HeaderText = "Thành tiền";
        }
        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiHangHoa();
        }
        public void TongTienXuatKho()
        {
            if (grdCTHD.Rows.Count == 0)
            {
                return;
            }
            int tien = grdCTHD.Rows.Count;
            decimal thanhtien = 0;
            for (int i = 0; i < tien; i++)
            {
                thanhtien += decimal.Parse(grdCTHD.Rows[i].Cells["ThanhTien"].Value.ToString());
            }
            txtTongTien.Text = thanhtien.ToString("#,###");
            if (txtTongTien.Text == " VND")
            {
                txtTongTien.Text = "0 VND";
            }
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (grdHangHoa.Rows.Count == 0)
            {
                MessageBox.Show("Không có hàng hóa để tạo phiếu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataGridViewRow row = this.grdHangHoa.Rows[grdHangHoa.CurrentCell.RowIndex];
            string MaHD = txtmahd.Text;
            string MaHH = row.Cells[0].Value.ToString();
            decimal DonGia = decimal.Parse(row.Cells[4].Value.ToString() + "");
            decimal SoLuong = nmsoluong.Value;
            decimal ThanhTien = DonGia * SoLuong;

            if (dbhd.CheckExitsXuatKho(txtmahd.Text) == 1)
            {
                dbhd.ThemXuatKho(MaHD, cbomakh.SelectedValue.ToString(), dtNgayHD.Value.ToString("yyyy/MM/dd"), frmDangNhap.manv, decimal.Parse(txtTongTien.Text));

            }
            else
            {
                dbhd.SuaXuatKho(MaHD, cbomakh.SelectedValue.ToString(), dtNgayHD.Value.ToString("yyyy/MM/dd"), frmDangNhap.manv, decimal.Parse(txtTongTien.Text));
            }

            decimal a = dbhd.KiemTraHangHoaTonKho(MaHD, MaHH);
            decimal b = nmsoluong.Value;
            if (dbhd.KiemTraHangHoaTonKho(MaHD, MaHH) < nmsoluong.Value)
            {
                MessageBox.Show("Tồn kho của sản phẩm này không đủ để xuất bán.");
                return;
            }

            if (dbhd.CheckExits(MaHD, MaHH) == 0)
            {
                dbhd.CapNhatSoLuongTienChiTietXuatKho(MaHD, MaHH, SoLuong);
            }
            else
            {
                dbhd.ThemChiTietXuatKho(MaHD, MaHH, DonGia, SoLuong, ThanhTien);
            }
            dbhd.UpdateTongTien(MaHD);
            HienThiChiTietXuatKho();
            TongTienXuatKho();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txttenhh.Text = "";
            HienThiHangHoa();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = this.grdCTHD.Rows[grdCTHD.CurrentCell.RowIndex];
            dbhd.XoaChiTietXuatKho(txtmahd.Text, row.Cells[1].Value.ToString());
            HienThiChiTietXuatKho();
            TongTienXuatKho();
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (grdCTHD.Rows.Count == 0)
            {
                return;
            }
            try
            {
                DialogResult ok = new DialogResult();
                ok = MessageBox.Show("Bạn có muốn tính tiền cho khách hàng này Không ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ok == DialogResult.Yes)
                {
                    MessageBox.Show("TỔNG SỐ TIỀN THANH TOÁN LÀ " + txtTongTien.Text, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    for (int i = 0; i < grdCTHD.Rows.Count; i++)
                    {
                        dbhd.UpdateTonKho(decimal.Parse(grdCTHD.Rows[i].Cells["SoLuong"].Value.ToString()), grdCTHD.Rows[i].Cells["MaHH"].Value.ToString());
                    }
                    dbhd.UpdateTrangThaiSauThanhToan(txtmahd.Text);
                    this.Close();
                }
                else
                {
                    return;
                }
            }
            catch { MessageBox.Show("Lỗi", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information); }
        }

        private void frmXuatKhoInfor_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbhd.XoaXuatKhoKhongTonTaiTrongChiTietXuatKho();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
