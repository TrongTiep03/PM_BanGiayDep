using PhanMemQuanLyBanGiayDep.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhanMemQuanLyBanGiayDep.Controllers
{
    public class XuatKhoControllers
    {
        public DataTable HienThiXuatKho(string ngayban, string ngayban2)
        {
            string Query = "select MaHD,ngayban,a.makh,c.tenkh,a.manv,b.tennv,TongTien,trangthai FROM XuatKho a INNER JOIN nhanvien b ON a.manv = b.manv INNER JOIN khachhang c ON a.makh = c.makh WHERE CONVERT(varchar,ngayban,112) BETWEEN '" + ngayban + "' AND '" + ngayban2 + "'";
            return ConnectSQL.Load(Query);
        }
        public DataTable HienThiChiTietXuatKho(string MaHD)
        {
            string Query = "select a.MaHD,a.MaHH,b.tenhh,a.DonGia,a.SoLuong,a.ThanhTien from ChiTietXuatKho a INNER JOIN HangHoa b ON a.MaHH = b.MaHH WHERE a.MaHD = '" + MaHD + "'";
            return ConnectSQL.Load(Query);
        }
        public void ThemXuatKho(string MaHD, string makh, string ngayban, string manv, decimal TongTien)
        {
            string Query = "INSERT INTO XuatKho(MaHD,makh,ngayban,manv,TongTien,trangthai)  VALUES ( '" + MaHD + "','" + makh + "','" + ngayban + "','" + manv + "'," + TongTien + ",N'Chưa thanh toán')";
            ConnectSQL.ExecuteNonQuery(Query);
        }

        public void ThemChiTietXuatKho(string MaHD, string MaHH, decimal DonGia, decimal SoLuong, decimal ThanhTien)
        {
            string Query = "";
            Query += " INSERT INTO ChiTietXuatKho(MaHD,MaHH,DonGia,SoLuong,ThanhTien)  VALUES ( '" + MaHD + "','" + MaHH + "'," + DonGia + "," + SoLuong + "," + ThanhTien + ")";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void SuaXuatKho(string MaHD, string makh, string ngayban, string manv, decimal TongTien)
        {
            string Query = "UPDATE XuatKho SET makh = '" + makh + "', ngayban = '" + ngayban + "',manv='" + manv + "',TongTien =" + TongTien + " WHERE MaHD='" + MaHD + "'";
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void Xoa(string MaHD)
        {
            string Query = string.Format(@"DELETE ChiTietXuatKho WHERE MaHD = '" + MaHD + "'");
            Query += string.Format(@"DELETE XuatKho WHERE MaHD = '" + MaHD + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void XoaChiTietXuatKho(string MaHD, string MaHH)
        {
            string Query = string.Format(@"DELETE ChiTietXuatKho WHERE MaHD = '" + MaHD + "' AND MaHH = '" + MaHH + "'");
            ConnectSQL.ExecuteNonQuery(Query);
        }
        public void XoaXuatKhoKhongTonTaiTrongChiTietXuatKho()
        {
            string s = "DELETE XuatKho WHERE MaHD NOT IN (SELECT MaHD From ChiTietXuatKho)";
            ConnectSQL.ExecuteNonQuery(s);
        }
        public void UpdateTonKho(decimal soluong, string MaHH)
        {
            string s = "UPDATE HangHoa SET TonKho =  TonKho - " + soluong + " WHERE MaHH = '" + MaHH + "'";
            ConnectSQL.ExecuteNonQuery(s);
        }
        public void UpdateTrangThaiSauThanhToan(string MaHD)
        {
            string s = "UPDATE XuatKho SET trangthai =  N'Đã thanh toán' WHERE MaHD = '" + MaHD + "'";
            ConnectSQL.ExecuteNonQuery(s);
        }
        public void UpdateTongTien(string MaHD)
        {
            string Query = "UPDATE XuatKho SET TongTien = (SELECT sum(ThanhTien) FROM ChiTietXuatKho WHERE MaHD = '" + MaHD + "') WHERE MaHD = '" + MaHD + "'";
            ConnectSQL.ExecuteNonQuery(Query);
        }

        public void CapNhatSoLuongTienChiTietXuatKho(string MaHD, string MaHH, decimal soluong)
        {
            string sqlUpdate = "UPDATE ChiTietXuatKho SET SoLuong = SoLuong + " + soluong + " WHERE MaHD = '" + MaHD + "' And MaHH = '" + MaHH + "'";
            sqlUpdate += " UPDATE ChiTietXuatKho SET ThanhTien = SoLuong * DonGia WHERE MaHD = '" + MaHD + "' And MaHH = '" + MaHH + "'";
            ConnectSQL.ExecuteNonQuery(sqlUpdate);
        }

        public decimal KiemTraHangHoaTonKho(string mahd, string MaHH)
        {
            decimal i = 0;
            string Querys = "  DECLARE @x INT, @x1 INT,@x2 INT";
            Querys += "  SET @x1 = (SELECT TonKho FROM HangHoa WHERE MaHH = '" + MaHH + "')";
            Querys += "  SET @x2 = (SELECT SoLuong FROM ChiTietXuatKho WHERE mahd = '" + mahd + "' AND MaHH = '" + MaHH + "')";
            Querys += " IF @x1 IS NULL SET @x1 = 0";
            Querys += "  IF @x2 IS NULL SET @x2 = 0";
            Querys += " SET @x = @x1 - @x2";
            Querys += "  SELECT @x as x";
            DataTable dt = ConnectSQL.Load(Querys);
            if (dt.Rows.Count > 0)
            {
                i = decimal.Parse(dt.Rows[0][0].ToString());
            }
            return i;
        }
        public int CheckExits(string MaHD, string MaHH)
        {
            int i = 0;
            string s = "SELECT * FROM ChiTietXuatKho WHERE MaHD = '" + MaHD + "' AND MaHH = '" + MaHH + "'";
            DataTable dt = ConnectSQL.Load(s);
            if (dt == null || dt.Rows.Count > 0)
            {
                i = 0;
            }
            else
            {
                i = 1;
            }
            return i;
        }
        public int CheckExitsXuatKho(string MaHD)
        {
            int i = 0;
            string s = "SELECT * FROM XuatKho WHERE MaHD = '" + MaHD + "'";
            DataTable dt = ConnectSQL.Load(s);
            if (dt == null || dt.Rows.Count > 0)
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
