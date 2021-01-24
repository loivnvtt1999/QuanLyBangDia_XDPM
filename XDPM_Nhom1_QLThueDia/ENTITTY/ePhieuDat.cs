using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class ePhieuDat
    {
        string maPhieuDat, maDia, trangThai, maKhachHang, maTieuDe;
        DateTime ngayDat;

        public string MaPhieuDat { get => maPhieuDat; set => maPhieuDat = value; }       
        public DateTime NgayDat { get => ngayDat; set => ngayDat = value; }
        public string MaTieuDe { get => maTieuDe; set => maTieuDe = value; }
        public string MaDia { get => maDia; set => maDia = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string MaKhachHang { get => maKhachHang; set => maKhachHang = value; }
        
    }
}
