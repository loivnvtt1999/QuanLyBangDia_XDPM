using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class ePhieuThue
    {
        string maphieuthue, trangthaithue, trangthaiphi, madia, makhachhang;
        DateTime ngaymuon, ngayhentra;
        DateTime? ngaytra;
        double giathue;
        double? phitramuon;
        public string Maphieuthue { get => maphieuthue; set => maphieuthue = value; }
        public string Trangthaithue { get => trangthaithue; set => trangthaithue = value; }
        public string Trangthaiphi { get => trangthaiphi; set => trangthaiphi = value; }
        public string Madia { get => madia; set => madia = value; }
        public string Makhachhang { get => makhachhang; set => makhachhang = value; }
        public DateTime Ngaymuon { get => ngaymuon; set => ngaymuon = value; }
        public DateTime Ngayhentra { get => ngayhentra; set => ngayhentra = value; }
        public DateTime? Ngaytra { get => ngaytra; set => ngaytra = value; }
        public double Giathue { get => giathue; set => giathue = value; }
        public double? Phitramuon { get => phitramuon; set => phitramuon = value; }
    }
}
