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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }
        DangNhapControllers dal = new DangNhapControllers();
        private bool luu;
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            HienThiNhanVien();
            boolcontrols(true);
        }
        private void HienThiNhanVien()
        {
            DataTable dt = new DataTable();
            dt = dal.HienThi(txtTenNVSearch.Text.Trim());
            gridview.Rows.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string MaNV = dt.Rows[i]["MaNV"].ToString();
                string TenNV = dt.Rows[i]["TenNV"].ToString();
                string MatKhau = dt.Rows[i]["MatKhau"].ToString();
                string DienThoai = dt.Rows[i]["DienThoai"].ToString();
                string DiaChi = dt.Rows[i]["DiaChi"].ToString();
                string v = dt.Rows[i]["hinhAnh"].ToString();
                if (v != "")
                {
                    System.Drawing.Image img = ConvertStringtoImage(dt.Rows[i]["hinhAnh"].ToString());
                    gridview.Rows.Add(new object[] { img,MaNV, TenNV, MatKhau, DienThoai, DiaChi });
                }
                else
                {
                    gridview.Rows.Add(new object[] { null, MaNV, TenNV, MatKhau, DienThoai, DiaChi });
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
                txtMaNV.Text = "";
                txtTenNV.Text = "";
                txtMatKhau.Text = "";
                txtDienThoai.Text = "";
                txtDiaChi.Text = "";
                pchinhAnh.Image = null;
            }
            else
            {
                var row = this.gridview.Rows[0];

                txtMaNV.Text = row.Cells[1].Value.ToString().Trim();
                txtTenNV.Text = row.Cells[2].Value.ToString().Trim();
                txtMatKhau.Text = row.Cells[3].Value.ToString().Trim();
                txtDienThoai.Text = row.Cells[4].Value.ToString().Trim();
                txtDiaChi.Text = row.Cells[5].Value.ToString().Trim();

                DataTable dtimg = new DataTable();
                dtimg = dal.HinhAnhNhanVien(txtMaNV.Text.Trim());
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
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            txtMatKhau.Text = "";
            txtDienThoai.Text = "";
            txtDiaChi.Text = "";
            pchinhAnh.Image = null;
            boolcontrols(false);
            luu = true;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            luu = false;
            txtMaNV.Enabled = false;
            boolcontrols(false);
            txtMaNV.Enabled = false;
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
            txtMaNV.Enabled = !iss;
            txtTenNV.Enabled = !iss;
            txtMatKhau.Enabled = !iss;
            txtDiaChi.Enabled = !iss;
            txtDienThoai.Enabled = !iss;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa nhân viên này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dal.Xoa(gridview.Rows[gridview.CurrentCell.RowIndex].Cells[1].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiNhanVien();
                boolcontrols(true);
            }
            else
                return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "")
            {
                MessageBox.Show("Mã nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaNV.Focus();
                return;
            }
            if (txtTenNV.Text == "")
            {
                MessageBox.Show("Tên nhân viên không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenNV.Focus();
                return;
            }
            if (txtMatKhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMatKhau.Focus();
                return;
            }
            if (luu == true)
            {
                try
                {
                    dal.Them(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), txtMatKhau.Text.Trim(), txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(),dtHinhAnh);
                    MessageBox.Show("Thêm thành công.");
                    HienThiNhanVien();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNV.Focus();
                    return;
                }
            }
            else
            {
                try
                {
                    dal.Sua(txtMaNV.Text.Trim(), txtTenNV.Text.Trim(), txtMatKhau.Text.Trim(), txtDienThoai.Text.Trim(), txtDiaChi.Text.Trim(), dtHinhAnh);
                    MessageBox.Show("Sửa thành công.");
                    HienThiNhanVien();
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaNV.Focus();
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
            boolcontrols(true);
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenNVSearch.Text = "";
            HienThiNhanVien();
            boolcontrols(true);
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiNhanVien();
        }

        private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridview.Rows[e.RowIndex];
                txtMaNV.Text = row.Cells[1].Value.ToString().Trim();
                txtTenNV.Text = row.Cells[2].Value.ToString().Trim();
                txtMatKhau.Text = row.Cells[3].Value.ToString().Trim();
                txtDienThoai.Text = row.Cells[4].Value.ToString().Trim();
                txtDiaChi.Text = row.Cells[5].Value.ToString().Trim();

                DataTable dtimg = new DataTable();
                dtimg = dal.HinhAnhNhanVien(txtMaNV.Text.Trim());
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
    }
}
