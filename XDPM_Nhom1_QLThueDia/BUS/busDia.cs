using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using ENTITTY;

namespace BUS
{
    public class busDia
    {
        dalDia dalDIA = new dalDia();
        public int updateTrangThaiDiaChoDatTruoc(string madia)
        {
            return dalDIA.updateTrangThaiDiaChoDatTruoc(madia);
        }
        public int updateTrangThaiDiaTra(string madia)
        {
            return dalDIA.updateTrangThaiDiaTra(madia);
        }
        public eDia layDiaTheoMa(string madia)
        {
            return dalDIA.layDiaTheoMa(madia);
        }
        public List<eDia_LoaiDia_TieuDe> layDiaTheoLoaiDia(string maloai)
        {
            return dalDIA.layDanhSachDiaTheoLoai(maloai);
        }
        public List<eDia_LoaiDia_TieuDe> layToanBoDia()
        {
            return dalDIA.layTatCaDia();
        }
        public List<eDia_LoaiDia_TieuDe> layDiaTheoLoaiDiaVaTrangThai(string maloai, string trangthai)
        {
            return dalDIA.layDanhSachDiaTheoLoaiVaTheoTrangThai(maloai, trangthai);
        }
        public List<eDia> layDiaDangThueCuaTieuDe(string matieude)
        {
            return dalDIA.layDiaDangThueCuaTieuDe(matieude);
        }

        public int ThemDia(eDia d)
        {
            return dalDIA.ThemDia(d);
        }

        public int XoaDia(string maDia)
        {
            return dalDIA.XoaDia(maDia);
        }
        public List<eDia> LayDiaCoTen(string ten)
        {
            return dalDIA.LayDiaCoTen(ten);
        }
        public List<eDia> layToanBoDiaChoQLDia()
        {
            return dalDIA.layToanBoDiaChoQLDia();
        }
        public eThongKeSLDia ThongKeSoLuongDiaTheoTinhTrang(eTieuDe tieuDe)
        {
            return dalDIA.ThongKeSoLuongDiaTheoTinhTrang(tieuDe);
        }
    }
}
