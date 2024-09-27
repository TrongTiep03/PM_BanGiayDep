using PhanMemQuanLyBanGiayDep.Views;
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

namespace PhanMemQuanLyBanGiayDep
{
    public partial class frmDangNhap : Form
    {
        DangNhapControllers db = new DangNhapControllers();
        public static string manv;
        public static string tennv;
        public static string matkhau;
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void frmThoat_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            if (txtmanv.Text == "")
            {
                MessageBox.Show("Mã đăng nhập không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanv.Focus();
                return;
            }
            if (txtmatkhau.Text == "")
            {
                MessageBox.Show("Mật khẩu không được trống", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmatkhau.Focus();
                return;
            }
            DataTable dt = new DataTable();
            dt = db.DangNhap(txtmanv.Text.Trim(), txtmatkhau.Text.Trim());
            if (dt == null || dt.Rows.Count > 0)
            {
                this.Hide();
                frmMain frm = new frmMain();
                manv = txtmanv.Text.Trim();
                matkhau = txtmatkhau.Text.Trim();
                tennv = db.TenTK(manv).Rows[0][0].ToString();
                frm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Không đúng tên người dùng hoặc mật khẩu", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtmanv.Focus();
            }
        }

        private void frmDangNhap_Load(object sender, EventArgs e)
        {

        }
    }
}
