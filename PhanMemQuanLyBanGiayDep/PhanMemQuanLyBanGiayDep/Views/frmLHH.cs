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
    public partial class frmLHH : Form
    {
        LHHControllers dal = new LHHControllers();
        private bool luu;
        public frmLHH()
        {
            InitializeComponent();
        }
        private void HienThiLHH(string TenNV)
        {
            gridview.DataSource = dal.HienThi(TenNV);
            gridview.Columns[0].HeaderText = "Mã LHH";
            gridview.Columns[1].HeaderText = "Tên LHH";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            txtMaLHH.Text = "";
            txtTenLHH.Text = "";
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
            txtMaLHH.Enabled = false;
            boolcontrols(false);
            txtMaLHH.Enabled = false;
        }
        private void boolcontrols(bool iss)
        {
            btnThem.Enabled = iss;
            btnSua.Enabled = iss;
            btnXoa.Enabled = iss;
            btnLuu.Enabled = !iss;
            btnHuy.Enabled = !iss;
            btnLamMoi.Enabled = iss;
            btnThoat.Enabled = iss;
            btnTim.Enabled = iss;
            txtMaLHH.Enabled = !iss;
            txtTenLHH.Enabled = !iss;
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            DialogResult dr = MessageBox.Show("Có chắc chắn xóa LHH này không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                dal.Xoa(gridview.Rows[gridview.CurrentCell.RowIndex].Cells[0].Value.ToString());
                MessageBox.Show("Xóa thành công ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                HienThiLHH("");
                boolcontrols(true);
            }
            else
                return;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaLHH.Text == "")
            {
                MessageBox.Show("Mã LHH không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLHH.Focus();
                return;
            }
            if (txtTenLHH.Text == "")
            {
                MessageBox.Show("Tên LHH không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLHH.Focus();
                return;
            }
            if (luu == true)
            {
                try
                {
                    dal.Them(txtMaLHH.Text.Trim(), txtTenLHH.Text.Trim());
                    MessageBox.Show("Thêm thành công.");
                    HienThiLHH("");
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã LHH đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaLHH.Focus();
                    return;
                }
            }
            else
            {
                try
                {
                    dal.Sua(txtMaLHH.Text.Trim(), txtTenLHH.Text.Trim());
                    MessageBox.Show("Sửa thành công.");
                    HienThiLHH("");
                    boolcontrols(true);
                }
                catch (Exception)
                {
                    MessageBox.Show("Mã LHH đã tồn tại, vui lòng tạo mã khác.", "Thông báo",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMaLHH.Focus();
                    return;
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            HienThiLHH("");
            boolcontrols(true);
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            var row = this.gridview.Rows[0];
            txtMaLHH.Text = row.Cells[0].Value.ToString();
            txtTenLHH.Text = row.Cells[1].Value.ToString();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            HienThiLHH("");
            boolcontrols(true);
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            var row = this.gridview.Rows[0];
            txtMaLHH.Text = row.Cells[0].Value.ToString();
            txtTenLHH.Text = row.Cells[1].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiLHH(txtTenSearch.Text);
        }

        private void gridview_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.gridview.Rows[e.RowIndex];
                txtMaLHH.Text = row.Cells[0].Value.ToString();
                txtTenLHH.Text = row.Cells[1].Value.ToString();
            }
        }

        private void frmLHH_Load(object sender, EventArgs e)
        {
            HienThiLHH("");
            boolcontrols(true);
            if (gridview.Rows.Count == 0)
            {
                return;
            }
            var row = this.gridview.Rows[0];
            txtMaLHH.Text = row.Cells[0].Value.ToString();
            txtTenLHH.Text = row.Cells[1].Value.ToString();
        }
    }
}
