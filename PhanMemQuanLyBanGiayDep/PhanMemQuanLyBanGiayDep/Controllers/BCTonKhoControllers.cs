using PhanMemQuanLyBanGiayDep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyBanGiayDep.Controllers
{
    public class BCTonKhoControllers
    {
        public DataTable HienThi(string MaHH, string TenHH, string TenNCC, string TenLHH, string TonKho,string DonGia)
        {
            string Query = "SELECT a.MaHH,a.TenHH,a.MaNCC,c.TenNCC,a.MaLHH,b.TenLHH,DonGia,TonKho FROM HangHoa a INNER JOIN LoaiHangHoa b ON a.MaLHH = b.MaLHH INNER JOIN NhaCungCap c ON a.MaNCC = c.MaNCC  WHERE a.MaHH LIKE N'%" + MaHH + "%' ";
            Query += " AND a.TenHH LIKE N'%" + TenHH + "%' AND c.TenNCC LIKE N'%" + TenNCC + "%' AND b.TenLHH LIKE N'%" + TenLHH + "%'";
            Query += " AND DonGia LIKE N'%" + DonGia + "%' AND TonKho LIKE N'%" + TonKho + "%'";
            return ConnectSQL.Load(Query);
        }
    }
}
