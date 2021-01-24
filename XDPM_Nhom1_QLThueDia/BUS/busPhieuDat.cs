using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITTY;
using DATA;
 
namespace BUS
{
    public class busPhieuDat
    {
        dalPhieuDat dalPD;
        public busPhieuDat()
        {
            dalPD = new dalPhieuDat();
        }
        public List<eTieuDe> LayDanhSachTieuDeDuocDat()
        {
            return dalPD.LayDanhSachTieuDeDuocDat();
        }
        public int ThemDatTruoc(ePhieuDat input)
        {
            return dalPD.ThemDatTruoc(input);
        }
        public string PhatSinhDatTruoc()
        {
            return dalPD.PhatSinhDatTruoc();
        }
        public List<eKhachHang> layDanhSachKhachHangDaDatTruoc()
        {
            return dalPD.layDanhSachKhachHangDaDatTruoc();
        }
        public List<ePhieuDat> LayDanhSachDatTruocCuaKhach(string maKH)
        {
            return dalPD.LayDanhSachDatTruocCuaKhach(maKH);
        }
        public bool XoaDatTruoc(string ma)
        {
            return dalPD.XoaDatTruoc(ma);
        }
        public int updateGanDiaChoPhieuDatTruoc(string maphieu, string madia)
        {
            return dalPD.updateGanDiaChoPhieuDatTruoc(maphieu, madia);
        }
        public List<ePhieuDat> layDanhSachPhieuDatTheoDiaTra(string matd)
        {
            return dalPD.layDanhSachPhieuDatTheoTieuDeDat(matd);
        }
        public ePhieuDat layPhieuDatTheoMa(string maphieudat)
        {
            return dalPD.layPhieuDatTheoMa(maphieudat);
        }
        public int xoaDatTruoc(string maphieu)
        {
            return dalPD.xoaDatTruoc(maphieu);
        }
        public eDia layDiaGanDatTruoc(string ma)
        {
            return dalPD.layDiaGanDatTruoc(ma);
        }
        public List<ePhieuDat> LayDanhSachPhieuDat_TheoMaKhachHang_DaCoDia(string makh)
        {
            return dalPD.LayDanhSachPhieuDat_TheoMaKhachHang_DaCoDia(makh);
        }
        public eThongKeYeuCauDat ThongKeSoLuongDiaYeuCauDat(eTieuDe tieuDe)
        {
            return dalPD.ThongKeSoLuongDiaYeuCauDat(tieuDe);
        }
    }
}
