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
    public partial class frmBaoCaoTonKho : Form
    {
        public frmBaoCaoTonKho()
        {
            InitializeComponent();
        }
        BCTonKhoControllers db = new BCTonKhoControllers();
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void HienThiHangHoa()
        {
            gridview.DataSource = db.HienThi(txtMaHH.Text,txtTenHH.Text,txtTenNCC.Text,txtTenLHH.Text,txtTonKho.Text,txtDonGia.Text);
            gridview.Columns[0].HeaderText = "Mã hàng hóa";
            gridview.Columns[1].HeaderText = "Tên hàng hóa";
            gridview.Columns[2].HeaderText = "Mã NCC";
            gridview.Columns[3].HeaderText = "Tên NCC";
            gridview.Columns[4].HeaderText = "Mã LHH";
            gridview.Columns[5].HeaderText = "Tên LHH";
            gridview.Columns[6].HeaderText = "Đơn giá";
            gridview.Columns[7].HeaderText = "Tồn kho";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            HienThiHangHoa();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHH.Text = "";
            txtTenHH.Text = "";
            txtDonGia.Text = "";
            txtTonKho.Text = "";
            txtTenLHH.Text = "";
            txtTenNCC.Text = "";
            HienThiHangHoa();
        }

        private void frmBaoCaoTonKho_Load(object sender, EventArgs e)
        {
            HienThiHangHoa();
        }
    }
}
