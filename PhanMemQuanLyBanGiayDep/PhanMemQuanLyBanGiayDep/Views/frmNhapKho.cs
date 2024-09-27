using PhanMemQuanLyBanGiayDep.Controllers;
using PhanMemQuanLyBanGiayDep.Models;
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
    public partial class frmNhapKho : Form
    {
        public frmNhapKho()
        {
            InitializeComponent();
        }
        NhapKhoControllers db = new NhapKhoControllers();
        DataTable dt;
        DataTable dt2;
        public static Boolean save;
        public static string MaHD;
        public static DateTime NgayHD;
        public static string MaTK_NV;
        public static string TongTien;
        private void frmNhapKho_Load(object sender, EventArgs e)
        {
            HienThiNhapKho();
            if (dtGVNhapKho.Rows.Count > 0)
            {
                var row = this.dtGVNhapKho.Rows[0];
                HienThiChiTietNhapKho(row.Cells["MaHD"].Value.ToString());
            }
            else
            {
                HienThiChiTietNhapKho("");
            }
        }
        private void HienThiNhapKho()
        {
            dt = db.HienThiNhapKho(dtNgayHD1.Value.ToString("yyyyMMdd"), dtNgayHD2.Value.ToString("yyyyMMdd"));
            dtGVNhapKho.DataSource = dt;
            dtGVNhapKho.Columns[0].HeaderText = "Số phiếu";
            dtGVNhapKho.Columns[1].HeaderText = "Ngày lập";
            dtGVNhapKho.Columns[2].HeaderText = "Mã nhân viên";
            dtGVNhapKho.Columns[3].HeaderText = "Tên nhân viên";
            dtGVNhapKho.Columns[4].HeaderText = "Tổng tiền";
        }
        private void HienThiChiTietNhapKho(string value)
        {
            dt2 = db.HienThiChiTietNhapKho(value);
            dtGVChiTietNhapKho.DataSource = dt2;
            dtGVChiTietNhapKho.Columns[0].HeaderText = "Loại hàng hóa";
            dtGVChiTietNhapKho.Columns[1].HeaderText = "Mã hàng hóa";
            dtGVChiTietNhapKho.Columns[2].HeaderText = "Tên hàng hóa";
            dtGVChiTietNhapKho.Columns[3].HeaderText = "Đơn giá";
            dtGVChiTietNhapKho.Columns[4].HeaderText = "Tồn kho";
            dtGVChiTietNhapKho.Columns[5].HeaderText = "Nhà cung cấp";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            save = true;
            frmNhapKhoInfor frm = new frmNhapKhoInfor();
            frm.Text = "Thêm mới";
            frm.ShowDialog();
            HienThiNhapKho();
            if (dtGVNhapKho.Rows.Count > 0)
            {
                var row = this.dtGVNhapKho.Rows[0];
                HienThiChiTietNhapKho(row.Cells["MaHD"].Value.ToString());
            }
            else
            {
                HienThiChiTietNhapKho("");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dtGVNhapKho.Rows.Count == 0)
            {
                return;
            }

            DataGridViewRow row = this.dtGVNhapKho.Rows[dtGVNhapKho.CurrentCell.RowIndex];
            save = false;
            frmNhapKhoInfor frm = new frmNhapKhoInfor();
            MaHD = row.Cells[0].Value.ToString();
            NgayHD = DateTime.Parse(row.Cells[1].Value.ToString());
            MaTK_NV = row.Cells[2].Value.ToString();
            TongTien = row.Cells[3].Value.ToString();

            frm.Text = "Sửa phiếu";
            frm.ShowDialog();
            HienThiNhapKho();
            if (dtGVNhapKho.Rows.Count > 0)
            {
                var row2 = this.dtGVNhapKho.Rows[0];
                HienThiChiTietNhapKho(row2.Cells["MaHD"].Value.ToString());
            }
            else
            {
                HienThiChiTietNhapKho("");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dtGVNhapKho.Rows.Count == 0)
            {
                return;
            }

            DialogResult dr = MessageBox.Show("Có chắc chắn xóa dòng dữ liệu này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                string del = "";
                for (int i = 0; i < dtGVChiTietNhapKho.Rows.Count; i++)
                {
                    del = del + " UPDATE HangHoa SET TonKho = TonKho - " + dtGVChiTietNhapKho.Rows[i].Cells["SoLuong"].Value.ToString() + " WHERE MaHH = '"+ dtGVChiTietNhapKho.Rows[i].Cells["MaHH"].Value.ToString() + "' ; ";
                }
                ConnectSQL.ExecuteNonQuery(del);

                db.Xoa(dtGVNhapKho.Rows[dtGVNhapKho.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiNhapKho();
                if (dtGVNhapKho.Rows.Count > 0)
                {
                    var row2 = this.dtGVNhapKho.Rows[0];
                    HienThiChiTietNhapKho(row2.Cells["SOPHIEU"].Value.ToString());
                }
                else
                {
                    HienThiChiTietNhapKho("");
                }
            }
            else
                return;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiNhapKho();
            if (dtGVNhapKho.Rows.Count > 0)
            {
                var row2 = this.dtGVNhapKho.Rows[0];
                HienThiChiTietNhapKho(row2.Cells["MaHD"].Value.ToString());
            }
            else
            {
                HienThiChiTietNhapKho("");
            }
        }

        private void dtGVNhapKho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtGVNhapKho.Rows[e.RowIndex];
                HienThiChiTietNhapKho(row.Cells[0].Value.ToString());
            }
        }
    }
}
