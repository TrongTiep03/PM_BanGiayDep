using PhanMemQuanLyBanGiayDep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyBanGiayDep.Controllers
{
    public class NCCControllers
    {
        public DataTable HienThi(string TenNCC)
        {
            string Query = "select * from NhaCungCap WHERE TenNCC LIKE N'%" + TenNCC + "%'";
            return ConnectSQL.Load(Query);
        }
        public void Them(string MaNCC, string TenNCC, string DienThoai, string DiaChi)
        {
            string Query = "INSERT INTO NhaCungCap(MaNCC,TenNCC,DienThoai,DiaChi)  VALUES ( '" + MaNCC + "',N'" + TenNCC + "','" + DienThoai + "',N'" + DiaChi + "')";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Sua(string MaNCC, string TenNCC, string DienThoai, string DiaChi)
        {
            string Query = "UPDATE NhaCungCap SET MaNCC = '" + MaNCC + "',TenNCC=N'" + TenNCC + "',DienThoai='" + DienThoai + "',DiaChi =N'" + DiaChi + "' WHERE MaNCC = '" + MaNCC + "'";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Xoa(string MaNCC)
        {
            string Query = string.Format(@"DELETE NhaCungCap WHERE MaNCC = '" + MaNCC + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public int CheckExits(string MaNCC)
        {
            int i = 0;
            string Querys = "SELECT * FROM NhaCungCap WHERE MaNCC = '" + MaNCC + "'";
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
