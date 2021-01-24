using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class eThongKeDiaDangThue
    {
        public eThongKeDiaDangThue(string maKhachHang, string hoTen, string diaChi, string sDT, int soLuong)
        {
            this.maKhachHang = maKhachHang;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.soLuong = soLuong;
        }
        public eThongKeDiaDangThue()
        {
        }

        public string maKhachHang { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public string sDT { get; set; }
        public int soLuong { get; set; }
    }
}
