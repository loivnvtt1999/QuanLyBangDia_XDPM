using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class eThongKeNoCuaKhachHang
    {
        public eThongKeNoCuaKhachHang() { }

        public eThongKeNoCuaKhachHang(string tenTieuDe, string tenDia, DateTime ngayHenTra, DateTime ngayTra, double phiTraMuon)
        {
            this.tenTieuDe = tenTieuDe;
            this.tenDia = tenDia;
            this.ngayHenTra = ngayHenTra;
            this.ngayTra = ngayTra;
            this.phiTraMuon = phiTraMuon;
        }

        public string tenTieuDe { get; set; }
        public string tenDia { get; set; }
        public DateTime ngayHenTra { get; set; }
        public DateTime ngayTra { get; set; }
        public double phiTraMuon { get; set; }
    }
}
