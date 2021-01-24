using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using ENTITTY;

namespace BUS
{
    public class busKhachHang
    {
        dalKhachHang dalKH = new dalKhachHang();
        public eKhachHang layKhachHangTheoMaKhachHang(string ma)
        {
            return dalKH.layKhachHangTheoMaKhachHang(ma);
        }
        public List<eKhachHang> layDanhSachKhachHang()
        {
            return dalKH.layDanhSachKhachHang();
        }
        public List<eKhachHang> LayDanhSachKhachHang()
        {
            return dalKH.LayDanhSachKhachHang();
        }
        public string PhatSinhMaKhachHang()
        {
            return dalKH.PhatSinhMaKhachHang();
        }
        public int ThemKhachHang(eKhachHang kh)
        {
            return dalKH.ThemKhachHang(kh);
        }
        public int SuaKhachHang(eKhachHang kh)
        {
            return dalKH.SuaKhachHang(kh);
        }
        public int XoaKhachHang(eKhachHang kh)
        {
            return dalKH.XoaKhachHang(kh);
        }
    }
}
