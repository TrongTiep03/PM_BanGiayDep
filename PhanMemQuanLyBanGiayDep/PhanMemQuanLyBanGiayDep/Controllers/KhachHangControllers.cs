using PhanMemQuanLyBanGiayDep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyBanGiayDep.Controllers
{
    public class KhachHangControllers
    {
        public DataTable HienThi(string TenKH)
        {
            string str = "select * from KhachHang WHERE TenKH LIKE N'%" + TenKH + "%'";
            return ConnectSQL.Load(str);
        }
        public void Xoa(string MaKH)
        {
            string str = string.Format(@"DELETE KhachHang WHERE MaKH = '" + MaKH + "'");
            ConnectSQL.ExecuteNonQuery(str);
        }
        public void Them(string MaKH, string TenKH, string DienThoai, string DiaChi)
        {
            string str = "INSERT INTO KhachHang(MaKH,TenKH,DienThoai,DiaChi)  VALUES ( '" + MaKH + "',N'" + TenKH + "','" + DienThoai + "',N'" + DiaChi + "')";
            ConnectSQL.ExecuteNonQuery(str);
        }
        public void Sua(string MaKH, string TenKH, string DienThoai, string DiaChi)
        {
            string str = "UPDATE KhachHang SET MaKH = '" + MaKH + "',TenKH=N'" + TenKH + "',DienThoai = N'" + DienThoai + "',DiaChi = N'" + DiaChi + "' WHERE MaKH = '" + MaKH + "'";
            ConnectSQL.ExecuteNonQuery(str);
        }
        public int CheckExits(string MaKH)
        {
            int i = 0;
            string Querys = "SELECT * FROM KhachHang WHERE MaKH = '" + MaKH + "'";
            DataTable dt = ConnectSQL.Load(Querys);
            if (dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
    }
}
