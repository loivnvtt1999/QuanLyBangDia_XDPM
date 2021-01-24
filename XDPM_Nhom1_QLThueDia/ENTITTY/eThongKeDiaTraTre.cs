using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class eThongKeDiaTraTre
    {
        public eThongKeDiaTraTre(string maKhachHang, string hoTen, string diaChi, string sDT, string tenTieuDe, string tenDia, DateTime ngayHenTra)
        {
            this.maKhachHang = maKhachHang;
            this.hoTen = hoTen;
            this.diaChi = diaChi;
            this.sDT = sDT;
            this.tenTieuDe = tenTieuDe;
            this.tenDia = tenDia;
            this.ngayHenTra = ngayHenTra;
        }
        public eThongKeDiaTraTre() { }

        public string maKhachHang { get; set; }
        public string hoTen { get; set; }
        public string diaChi { get; set; }
        public string sDT { get; set; }
        public string tenTieuDe { get; set; }
        public string tenDia { get; set; }
        public DateTime ngayHenTra { get; set; }
    }
}
