using PhanMemQuanLyBanGiayDep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyBanGiayDep.Controllers
{
    public class LHHControllers
    {
        public DataTable HienThi(string TenLHH)
        {
            string Query = "select * from LoaiHangHoa WHERE TenLHH LIKE N'%" + TenLHH + "%'";
            return ConnectSQL.Load(Query);
        }
        public void Them(string MaLHH, string TenLHH)
        {
            string Query = "INSERT INTO LoaiHangHoa(MaLHH,TenLHH)  VALUES ( '" + MaLHH + "',N'" + TenLHH + "')";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Sua(string MaLHH, string TenLHH)
        {
            string Query = "UPDATE LoaiHangHoa SET TenLHH=N'" + TenLHH + "' WHERE MaLHH = '" + MaLHH + "' ";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Xoa(string MaLHH)
        {
            string Query = string.Format(@"DELETE LoaiHangHoa WHERE MaLHH = '" + MaLHH + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public int CheckExits(string MaLHH)
        {
            int i = 0;
            string Querys = "SELECT * FROM LoaiHangHoa WHERE MaLHH = '" + MaLHH + "'";
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
