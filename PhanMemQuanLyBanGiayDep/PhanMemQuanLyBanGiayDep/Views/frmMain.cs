using PhanMemQuanLyBanGiayDep.Views;
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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private void btnTKNV_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }
        private void btnDMNCC_Click(object sender, EventArgs e)
        {
            frmNCC frm = new frmNCC();
            frm.ShowDialog();
        }
        private void btnDMLHH_Click(object sender, EventArgs e)
        {
            frmLHH frm = new frmLHH();
            frm.ShowDialog();
        }
        private void btnDMHH_Click(object sender, EventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.ShowDialog();
        }
        private void btnDMKH_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }
        private void btnPNK_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            frm.ShowDialog();
        }
        private void btnPXK_Click(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            frm.ShowDialog();
        }
        private void btnBCTK_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho frm = new frmBaoCaoTonKho();
            frm.ShowDialog();
        }
        private void btnDX_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
        }
        private void quảnLýTàiKhoảnNhânViênToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();
            frm.ShowDialog();
        }
        private void nhàCungCấpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNCC frm = new frmNCC();
            frm.ShowDialog();
        }
        private void loạiHàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLHH frm = new frmLHH();
            frm.ShowDialog();
        }
        private void hàngHóaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmHangHoa frm = new frmHangHoa();
            frm.ShowDialog();
        }
        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmKhachHang frm = new frmKhachHang();
            frm.ShowDialog();
        }
        private void phiếuNhậpKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNhapKho frm = new frmNhapKho();
            frm.ShowDialog();
        }
        private void phiếuXuấtKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmXuatKho frm = new frmXuatKho();
            frm.ShowDialog();
        }
        private void báoCáoTồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBaoCaoTonKho frm = new frmBaoCaoTonKho();
            frm.ShowDialog();
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có muốn thoát chương trình ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                this.Close();
            }
            else
                return;
        }
    }
}
