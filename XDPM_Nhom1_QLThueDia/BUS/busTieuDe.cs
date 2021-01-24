using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using ENTITTY;

namespace BUS
{
    public class busTieuDe
    {
        dalTieuDe dalTD;
        public busTieuDe()
        {
            dalTD = new dalTieuDe();
        }
        public List<eTieuDe> LayDanhSachieuDe()
        {
            return dalTD.LayDanhSachieuDe();
        }
        public int KiemTraDiaTrongTieuDe(string maTD)
        {
            return dalTD.KiemTraDiaTrongTieuDe(maTD);
        }
        public List<eTieuDe> TimKiemTieuDeTheoTen(string tenTD)
        {
            return dalTD.TimKiemTieuDeTheoTen(tenTD);
        }
        public eTieuDe layTieuDeTheoMaTieuDe(string ma)
        {
            return dalTD.layTieuDeTheoMaTieuDe(ma);
        }
        public eTieuDe LayTieuDeTheoMaDia(string madia)
        {
            return dalTD.LayTieuDeTheoMaDia(madia);
        }

        public eTieuDe LayTieuDeTheoMa(string matieude)
        {
            return dalTD.LayTieuDeTheoMa(matieude);
        }

        public List<eTieuDe> LayToanBoTieuDe()
        {
            return dalTD.LayToanBoTieuDe();
        }

        public List<eTieuDe> LayTieuDeCoTen(string ten)
        {
            return dalTD.LayTieuDeCoTen(ten);
        }

        public int ThemTieuDe(eTieuDe them)
        {
            return dalTD.ThemTieuDe(them);
        }

        public int XoaTieuDe(string ma)
        {
            return dalTD.XoaTieuDe(ma);
        }
        public List<eTieuDe> LayDanhSachTieuDeTheoLoaiDia(string maloaidia)
        {
            return dalTD.LayDanhSachTieuDeTheoLoaiDia(maloaidia);
        }
        public List<eTieuDe> LayDanhSachTieuDe()
        {
            return dalTD.LayDanhSachTieuDe();
        }
    }
}
