using PhanMemQuanLyBanGiayDep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyBanGiayDep.Controllers
{
    public class NhapKhoControllers
    {
        public DataTable HienThiNhapKho(string NgayHD, string NgayHD2)
        {
            string Query = "select MaHD,NgayHD,a.MaNV,b.TenNV,TongTien FROM NhapKho a INNER JOIN NhanVien b ON a.MaNV = b.MaNV WHERE CONVERT(varchar,NgayHD,112) BETWEEN '" + NgayHD + "' AND '" + NgayHD2 + "'";
            return ConnectSQL.Load(Query);
        }
        public DataTable DonGiaHangHoa(string MaHH)
        {
            string sqlString = "select DonGia,TenHH from HangHoa WHERE MaHH  = N'" + MaHH + "'";
            return ConnectSQL.Load(sqlString);
        }
        public DataTable HienThiChiTietNhapKho(string MaHD)
        {
            string Query = "select a.MaHD,a.MaHH,b.TenHH,a.DonGia,a.SoLuong,a.ThanhTien from ChiTietNhapKho a INNER JOIN HangHoa b ON a.MaHH = b.MaHH WHERE a.MaHD = '" + MaHD + "'";
            return ConnectSQL.Load(Query);
        }
        public void ThemNhapKho(string MaHD, string NgayHD, string MaNV, decimal TongTien)
        {
            string Query = "INSERT INTO NhapKho(MaHD,NgayHD,MaNV,TongTien)  VALUES ( '" + MaHD + "','" + NgayHD + "','" + MaNV + "'," + TongTien + ")";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void UpdateTongTien(string MaHD)
        {
            string Query = "UPDATE NhapKho SET TongTien = (SELECT sum(ThanhTien) FROM ChiTietNhapKho WHERE MaHD = '" + MaHD + "') WHERE MaHD = '" + MaHD + "'";
            ConnectSQL.ExecuteNonQuery(Query);
        }

        public void ThemChiTietNhapKho(string MaHD, string MaHH, decimal DonGia, decimal SoLuong, decimal ThanhTien)
        {
            string Query = "";
            Query += " INSERT INTO ChiTietNhapKho(MaHD,MaHH,DonGia,SoLuong,ThanhTien)  VALUES ( '" + MaHD + "','" + MaHH + "'," + DonGia + "," + SoLuong + "," + ThanhTien + ")";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void SuaNhapKho(string MaHD, string NgayHD, string MaNV, decimal TongTien)
        {
            string Query = "UPDATE NhapKho SET NgayHD = '" + NgayHD + "',MaNV='" + MaNV + "',TongTien =" + TongTien + " WHERE MaHD='" + MaHD + "'";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Xoa(string MaHD)
        {
            string Query = string.Format(@"DELETE ChiTietNhapKho WHERE MaHD = '" + MaHD + "'");
            Query += string.Format(@"DELETE NhapKho WHERE MaHD = '" + MaHD + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void XoaChiTietNhapKho(string MaHD)
        {
            string Query = string.Format(@"DELETE ChiTietNhapKho WHERE MaHD = '" + MaHD + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public decimal KiemTraHangHoaTonKho(string MaHH)
        {
            decimal i = 0;
            string Querys = " SELECT TonKho FROM HangHoa WHERE MaHH = '" + MaHH + "'";
            DataTable dt = ConnectSQL.Load(Querys);
            if (dt.Rows.Count > 0)
            {
                i = decimal.Parse(dt.Rows[0][0].ToString());
            }
            return i;
        }
    }
}
