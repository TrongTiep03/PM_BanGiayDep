using PhanMemQuanLyBanGiayDep.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemQuanLyBanGiayDep.Views
{
    public partial class frmHangHoa : Form
    {
        public frmHangHoa()
        {
            InitializeComponent();
        }
        HangHoaControllers db = new HangHoaControllers();
        NCCControllers dbNCC = new NCCControllers();
        LHHControllers dbLHH = new LHHControllers();
        private bool luu;
        private void frmHangHoa_Load(object sender, EventArgs e)
        {
            HienThiHangHoa();
            boolcontrols(true);
            DanhSachLHH();
            DanhSachNCC();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            DanhSachLHH();
            DanhSachNCC();
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtTonKho.Value = 1;
            txtDonGia.Value = 1;

            boolcontrols(false);
            luu = true;
        }
        private void boolcontrols(bool iss)
        {
            btnThem.Enabled = iss;
            btnSua.Enabled = iss;
            btnXoa.Enabled = iss;
            btnChonHinh.Enabled = !iss;
            btnXoaHinh.Enabled = !iss;
            btnLuu.Enabled = !iss;
            btnHuy.Enabled = !iss;
            btnLamMoi.Enabled = iss;
            btnThoat.Enabled = iss;
            btnTim.Enabled = iss;
            txtMaHH.Enabled = !iss;
            txtTenHH.Enabled = !iss;
            txtTonKho.Enabled = !iss;
            txtDonGia.Enabled = !iss;
            cboMaNCC.Enabled = !iss;
            cboMaLHH.Enabled = !iss;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            luu = false;
            txtMaHH.Enabled = false;
            boolcontrols(false);
            txtMaHH.Enabled = false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa hàng hóa này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                db.Xoa(gridview.Rows[gridview.CurrentCell.RowIndex].Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiHangHoa();
                boolcontrols(true);
            }
            else
                return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaHH.Text == "")
            {
                MessageBox.Show("Mã hàng hóa không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHH.Focus();
                return;
            }
            if (txtTenHH.Text == "")
            {
                MessageBox.Show("Tên hàng hóa không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHH.Focus();
                return;
            }

            if (luu == true)
            {
                try
                {
                    db.Them(txtMaHH.Text.Trim(), txtTenHH.Text.Trim(), txtTonKho.Value, txtDonGia.Value, cboMaNCC.SelectedValue.ToString(), cboMaLHH.SelectedValue.ToString(),dtHinhAnh);
                    MessageBox.Show("Thêm thành công.");
                    HienThiHangHoa();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHH.Focus();
                    return;
                }
            }
            else
            {
                try
                {
                    db.Sua(txtMaHH.Text.Trim(), txtTenHH.Text.Trim(), txtTonKho.Value, txtDonGia.Value, cboMaLHH.SelectedValue.ToString(), cboMaNCC.SelectedValue.ToString(), dtHinhAnh);
                    MessageBox.Show("Sửa thành công.");
                    HienThiHangHoa();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã hàng hóa đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaHH.Focus();
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienThiHangHoa();
            boolcontrols(true);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenSearch.Text = "";
            HienThiHangHoa();
            boolcontrols(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiHangHoa();
        }
        private void HienThiHangHoa()
        {
            DataTable dt = new DataTable();
            dt = db.HienThi(txtTenSearch.Text.Trim());
            gridview.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string MaHH = dt.Rows[i]["MaHH"].ToString();
                string TenHH = dt.Rows[i]["TenHH"].ToString();
                string TonKho = dt.Rows[i]["TonKho"].ToString();
                string DonGia = dt.Rows[i]["DonGia"].ToString();
                string MaNCC = dt.Rows[i]["MaNCC"].ToString();
                string MaLHH = dt.Rows[i]["MaLHH"].ToString();
                string v = dt.Rows[i]["hinhAnh"].ToString();
                if (v != "")
                {
                    System.Drawing.Image img = ConvertStringtoImage(dt.Rows[i]["hinhAnh"].ToString());
                    gridview.Rows.Add(new object[] { img, MaHH, TenHH, TonKho, DonGia, MaNCC, MaLHH });
                }
                else
                {
                    gridview.Rows.Add(new object[] { null, MaHH, TenHH, TonKho, DonGia, MaNCC, MaLHH });
                    foreach (var column in gridview.Columns)
                    {
                        if (column is DataGridViewImageColumn)
                            (column as DataGridViewImageColumn).DefaultCellStyle.NullValue = null;
                    }
                }
            }
            foreach (DataGridViewRow r in gridview.Rows)
                r.Height = 60;
            if (gridview.Rows.Count == 0)
            {
                txtMaHH.Text = "";
                txtTenHH.Text = "";
                txtTonKho.Text = "";
                txtDonGia.Text = "";
                pchinhAnh.Image = null;
            }
            else
            {
                var row = this.gridview.Rows[0];

                txtMaHH.Text = row.Cells[1].Value.ToString().Trim();
                txtTenHH.Text = row.Cells[2].Value.ToString().Trim();
                txtTonKho.Text = row.Cells[3].Value.ToString().Trim();
                txtDonGia.Text = row.Cells[4].Value.ToString().Trim();
                cboMaNCC.SelectedValue = row.Cells[5].Value.ToString().Trim();
                cboMaLHH.SelectedValue = row.Cells[6].Value.ToString().Trim();

                DataTable dtimg = new DataTable();
                dtimg = db.HinhAnhHangHoa(txtMaHH.Text.Trim());
                if (dtimg.Rows.Count > 0)
                {
                    if (dtimg.Rows[0]["HinhAnh"].ToString() != "")
                    {
                        pchinhAnh.Image = ConvertStringtoImage(dtimg.Rows[0]["HinhAnh"].ToString());
                    }
                    else
                    {
                        dtHinhAnh = "";
                        pchinhAnh.Image = null;
                    }
                }
                
            }
        }
        public System.Drawing.Image ConvertStringtoImage(string commands)
        {
            byte[] photoarray = Convert.FromBase64String(commands);
            MemoryStream ms = new MemoryStream(photoarray, 0, photoarray.Length);
            ms.Write(photoarray, 0, photoarray.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms);
            return image;
        }
        private void DanhSachLHH()
        {
            DataTable dt = dbLHH.HienThi("");
            cboMaLHH.DataSource = dt;
            cboMaLHH.DisplayMember = "TenLHH";
            cboMaLHH.ValueMember = "MaLHH";
        }
        private void DanhSachNCC()
        {
            DataTable dt = dbNCC.HienThi("");
            cboMaNCC.DataSource = dt;
            cboMaNCC.DisplayMember = "TenNCC";
            cboMaNCC.ValueMember = "MaNCC";
        }
        private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridview.Rows[e.RowIndex];
                txtMaHH.Text = row.Cells[1].Value.ToString().Trim();
                txtTenHH.Text = row.Cells[2].Value.ToString().Trim();
                txtTonKho.Text = row.Cells[3].Value.ToString().Trim();
                txtDonGia.Text = row.Cells[4].Value.ToString().Trim();
                cboMaNCC.SelectedValue = row.Cells[5].Value.ToString().Trim();
                cboMaLHH.SelectedValue = row.Cells[6].Value.ToString().Trim();

                DataTable dtimg = new DataTable();
                dtimg = db.HinhAnhHangHoa(txtMaHH.Text.Trim());
                if (dtimg.Rows.Count > 0)
                {
                    if (dtimg.Rows[0]["HinhAnh"].ToString() != "")
                    {
                        pchinhAnh.Image = ConvertStringtoImage(dtimg.Rows[0]["HinhAnh"].ToString());
                    }
                    else
                    {
                        dtHinhAnh = "";
                        pchinhAnh.Image = null;
                    }
                }
               
            }
        }
        private Boolean choseImage = false;
        public static System.Drawing.Image img2;
        private string dtHinhAnh;
        private void btnChonHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog OpenFile = new OpenFileDialog();
            string filename;
            OpenFile.Multiselect = false;
            OpenFile.Filter = "Images (*.png, *.gif, *.tif, *.tiff, *.bmp, *.jpg, *.jpeg, *.jpe, *.jfif)|*.png;*.gif;*.tif;*.tiff;*.bmp;*.jpg;*.jpeg;*.jpe;*.jfif";
            if (OpenFile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                filename = OpenFile.FileName;
                OpenFile.Dispose();
                if (filename != "")
                {
                    choseImage = true;
                    System.Drawing.Image img;
                    try
                    {
                        img = System.Drawing.Image.FromFile(filename);
                        if (img != null)
                        {
                            pchinhAnh.Image = img;
                            img2 = img;
                            ImageConverter converter = new ImageConverter();
                            var bytes = (byte[])converter.ConvertTo((Bitmap)pchinhAnh.Image, typeof(byte[]));
                            dtHinhAnh = Convert.ToBase64String(bytes);
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }

        private void btnXoaHinh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            choseImage = true;
            pchinhAnh.Image = null;
            img2 = null;
            dtHinhAnh = "";
        }

        private void txtDonGia_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
