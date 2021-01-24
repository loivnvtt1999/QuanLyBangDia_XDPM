using DATA;
using ENTITTY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class busPhieuThue
    {
        dalPhieuThue dalPT = new dalPhieuThue();
        public ePhieuThue layPhieuThueTheoDiaDangThue(string madia)
        {
            return dalPT.layPhieuThueTheoDiaDangThue(madia);
        }
        public eDia_LoaiDia_TieuDe layPhiTraMuon(string madia)
        {
            return dalPT.layPhiTraMuon(madia);
        }
        public eKhachHang layThongTinKhachHangTheoPhieu(string makhachhang)
        {
            return dalPT.layKhachHangTheoPhieu(makhachhang);
        }
        public List<ePhieuThue> layDanhSachPhiMuonChuaThanhToanTheoKhachHang(string makh)
        {
            return dalPT.layDanhSachPhiMuonChuaThanhToanTheoKhachHang(makh);
        }
        public List<eDia_LoaiDia_TieuDe> chiTietTraMuon(string makh)
        {
            return dalPT.chiTietTraMuon(makh);
        }
        public int updatePhiTraMuonCu(string maphieu)
        {
            return dalPT.updatePhiTraMuonCu(maphieu);
        }
        public int updatePhiTraMuonMoiCoTraPhi(string maphieu, double phitramuon)
        {
            return dalPT.updatePhiTraMuonMoiCoTraPhi(maphieu, phitramuon);
        }
        public int updatePhiTraMuonMoiKhongTraPhi(string maphieu, double phitramuon)
        {
            return dalPT.updatePhiTraMuonMoiKhongTraPhi(maphieu, phitramuon);
        }
        public int updatePhiTraMuonThanhToanSau(string maphieu, double phitramuon)
        {
            return dalPT.updatePhiTraMuonThanhToanSau(maphieu, phitramuon);
        }
        public ePhieuThue layPhieuThueTheoMaPhieu(string ma)
        {
            return dalPT.layPhieuThueTheoMaPhieu(ma);
        }
        public ePhieuThue layPhieuThueTheoDia(string madia)
        {
            return dalPT.layPhieuThueTheoDia(madia);
        }
        public ePhieuThue layPhieuThueTheoMa(string ma)
        {
            return dalPT.layPhieuThueTheoMa(ma);
        }
        public void LuuPhieuThueMoi(List<ePhieuThue> l)
        {
            dalPT.LuuPhieuThueMoi(l);
        }
    }
}
