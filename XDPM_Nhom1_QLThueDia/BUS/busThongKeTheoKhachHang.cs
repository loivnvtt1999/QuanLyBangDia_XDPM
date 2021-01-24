using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using ENTITTY;

namespace BUS
{
    public class busThongKeTheoKhachHang
    {
        dalThongKeTheoKhachHang dalTK;
        public busThongKeTheoKhachHang()
        {
            dalTK = new dalThongKeTheoKhachHang();
        }
        public List<eKhachHang> XemThongTinKhachHang(int loai)
        {
            return dalTK.XemThongTinKhachHang(loai);
        }
        public List<eThongKeDiaDangThue> ThongKeDiaDangThue()
        {
            return dalTK.ThongKeDiaDangThue();
        }
        public List<eThongKeDiaTraTre> ThongKeDiaTraTre()
        {
            return dalTK.ThongKeDiaTraTre();
        }
         public List<eThongKeNoCuaKhachHang> ThongKeNoCuaKhachHang(string maKH)
        {
            return dalTK.ThongKeNoCuaKhachHang(maKH);
        }
        public List<eKhachHang> LayDanhSachKhachHangNo()
        {
            return dalTK.LayDanhSachKhachHangNo();
        }
    }
}
