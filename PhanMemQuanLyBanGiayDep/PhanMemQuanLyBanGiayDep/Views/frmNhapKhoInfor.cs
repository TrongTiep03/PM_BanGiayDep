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
    public partial class frmNhapKhoInfor : Form
    {
        NhapKhoControllers db = new NhapKhoControllers();
        HangHoaControllers dbhh = new HangHoaControllers();
        DataTable dtct = new DataTable();
        public Boolean ischeck = true;
        public frmNhapKhoInfor()
        {
            InitializeComponent();
        }
        private void HienThiChiTietNhapKho()
        {
            dtct = db.HienThiChiTietNhapKho(txtMaHD.Text.Trim());
            dtGVChiTietNhapKho.DataSource = dtct;
            dtGVChiTietNhapKho.Columns[0].HeaderText = "Số phiếu";
            dtGVChiTietNhapKho.Columns[1].HeaderText = "Mã hàng hóa";
            dtGVChiTietNhapKho.Columns[2].HeaderText = "Tên hàng hóa";
            dtGVChiTietNhapKho.Columns[3].HeaderText = "Đơn giá";
            dtGVChiTietNhapKho.Columns[4].HeaderText = "Số lượng";
            dtGVChiTietNhapKho.Columns[5].HeaderText = "Thành tiền";
        }
        private void frmNhapHangInfor_Load(object sender, EventArgs e)
        {
            if (frmNhapKho.save == true)
            {
                HienThiHangHoa();
                txtMaTK_NV.Text = frmDangNhap.manv;
                txtMaTK_NV.ReadOnly = true;
                txtMaHD.ReadOnly = true;
                HienThiChiTietNhapKho();
                GenCode();
            }
            else
            {
                HienThiHangHoa();
                txtMaHD.Text = frmNhapKho.MaHD;
                txtMaTK_NV.ReadOnly = true;
                HienThiChiTietNhapKho();
                txtMaTK_NV.Text = frmNhapKho.MaTK_NV;
                dtNgayHD.Value = frmNhapKho.NgayHD;

            }
        }
        private void HienThiHangHoa()
        {
            DataTable dt = dbhh.HienThi("");
            cboMaHH.DataSource = dt;
            cboMaHH.DisplayMember = "TenHH";
            cboMaHH.ValueMember = "MAHH";
        }
        private void GenCode()
        {
            string sTemp = "PNK_" + DateTime.Now.ToString("yyMMddhhmmss");
            txtMaHD.Text = sTemp;
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cboMaHH.Text == "")
            {
                MessageBox.Show("Mã hàng hóa không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMaHH.Focus();
                return;
            }
            if (nmSoLuong.Value == 0)
            {
                MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboMaHH.Focus();
                return;
            }
            ischeck = true;
            if (dtGVChiTietNhapKho.Rows.Count > 0)
            {
                for (int i = 0; i < dtct.Rows.Count; i++)
                {
                    try
                    {
                        if (dtct.Rows[i]["MaHH"].ToString() == cboMaHH.SelectedValue.ToString())
                        {
                            dtct.Rows[i]["SoLuong"] = int.Parse(dtct.Rows[i]["SoLuong"].ToString()) + nmSoLuong.Value;
                            ischeck = false;
                            break;
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }


            if (ischeck == true)
            {
                DataTable DonGia = new DataTable();
                DonGia = db.DonGiaHangHoa(cboMaHH.SelectedValue.ToString());
                decimal x = decimal.Parse(DonGia.Rows[0][0].ToString()) * nmSoLuong.Value;
                DataRow toInsert = dtct.NewRow();
                dtct.Rows.Add(new Object[]{
                txtMaHD.Text.Trim(),
                cboMaHH.SelectedValue.ToString(),
                DonGia.Rows[0][1].ToString(),
                DonGia.Rows[0][0].ToString(),
                nmSoLuong.Value,
                x});
            }
            dtct.AcceptChanges();
            dtGVChiTietNhapKho.DataSource = dtct;
            dtct.AcceptChanges();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            dtGVChiTietNhapKho.Rows.RemoveAt(dtGVChiTietNhapKho.CurrentCell.RowIndex);

            dtGVChiTietNhapKho.DataSource = dtct;
            dtct.AcceptChanges();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (dtGVChiTietNhapKho.Rows.Count == 0)
            {
                MessageBox.Show("Chưa nhập sách cần mượn", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            decimal c;
            for (int i = 0; i < dtGVChiTietNhapKho.RowCount; i++)
            {
                c = db.KiemTraHangHoaTonKho(dtGVChiTietNhapKho.Rows[0].Cells[1].Value.ToString());
                if (c < decimal.Parse(dtGVChiTietNhapKho.Rows[0].Cells[4].Value.ToString()))
                {
                    MessageBox.Show("Thêm thất bại, số lượng tồn của hàng hóa là '" + dtGVChiTietNhapKho.Rows[0].Cells[1].Value.ToString() + "' còn lại là '" + c + "'", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (frmNhapKho.save == true)
            {

                db.ThemNhapKho(txtMaHD.Text.Trim(), dtNgayHD.Value.ToString("yyyy/MM/dd"), txtMaTK_NV.Text.Trim(), 0);
                db.XoaChiTietNhapKho(txtMaHD.Text.Trim());
                for (int i = 0; i < dtct.Rows.Count; i++)
                {
                    db.ThemChiTietNhapKho(txtMaHD.Text.Trim(), dtct.Rows[i]["MaHH"].ToString(), decimal.Parse(dtct.Rows[i]["DonGia"].ToString()), decimal.Parse(dtct.Rows[i]["SOLUONG"].ToString()), decimal.Parse(dtct.Rows[i]["ThanhTien"].ToString()));
                }

                MessageBox.Show("Thêm thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            if (frmNhapKho.save == false)
            {
                db.XoaChiTietNhapKho(txtMaHD.Text.Trim());
                db.SuaNhapKho(txtMaHD.Text.Trim(), dtNgayHD.Value.ToString("yyyy/MM/dd"), txtMaTK_NV.Text.Trim(), 0);
                for (int i = 0; i < dtct.Rows.Count; i++)
                {
                    db.ThemChiTietNhapKho(txtMaHD.Text.Trim(), dtct.Rows[i]["MaHH"].ToString(), decimal.Parse(dtct.Rows[i]["DonGia"].ToString()), decimal.Parse(dtct.Rows[i]["SOLUONG"].ToString()), decimal.Parse(dtct.Rows[i]["ThanhTien"].ToString()));
                }
                MessageBox.Show("Sửa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }
            db.UpdateTongTien(txtMaHD.Text.Trim());
            for (int i = 0; i < dtGVChiTietNhapKho.Rows.Count; i++)
            {
                string s1 = "UPDATE HangHoa SET TonKho =  TonKho + '" + decimal.Parse(dtGVChiTietNhapKho.Rows[i].Cells["SoLuong"].Value.ToString()) + "' WHERE MaHH = '" + dtGVChiTietNhapKho.Rows[i].Cells["MaHH"].Value.ToString() + "'";
                ConnectSQL.ExecuteNonQuery(s1);
            }
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
