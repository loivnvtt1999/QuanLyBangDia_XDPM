using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITTY;

namespace DATA
{
    public class dalTieuDe
    {
        BangDiaDataClassesDataContext db;
        public dalTieuDe()
        {
            db = new BangDiaDataClassesDataContext();
        }
        public List<eTieuDe> LayDanhSachieuDe()
        {
            List<eTieuDe> listTD = new List<eTieuDe>();
            var list = (from td in db.TieuDes
                        join ld in db.LoaiDias on td.MaLoaiDia equals ld.MaLoaiDia
                        group td by new { td.MaTieuDe, td.TenTieuDe, td.NhaSanXuat, ld.TenLoaiDia } into g
                        select new { g.Key.MaTieuDe, g.Key.TenLoaiDia, g.Key.NhaSanXuat,g.Key.TenTieuDe });
            foreach(var e in list)
            {
                eTieuDe tam = new eTieuDe();
                tam.MaTieuDe = e.MaTieuDe;
                tam.TenTieuDe = e.TenTieuDe;
                tam.NhaSanXuat = e.NhaSanXuat;
                tam.MaLoaiDia = e.TenLoaiDia;
                listTD.Add(tam);
            }
            return listTD;
        }
        public int KiemTraDiaTrongTieuDe(string maTD)
        {
            int soLuong =db.Dias.Where(x=>x.MaTieuDe.Equals(maTD)).Where(y=>y.TrangThaiDia.Equals("Sẵn sàng")).Count();
            if (soLuong > 0)
            {
                return soLuong;
            }
            else
            {
                return 0;
            }
        }
        public List<eTieuDe> TimKiemTieuDeTheoTen(string tenTD)
        {
            List<eTieuDe> listTD = new List<eTieuDe>();
            var list = (from td in db.TieuDes
                        join ld in db.LoaiDias on td.MaLoaiDia equals ld.MaLoaiDia
                        where(td.TenTieuDe.Contains(tenTD))
                        select new { td.MaTieuDe, ld.TenLoaiDia, td.NhaSanXuat, td.TenTieuDe });
            foreach (var e in list)
            {
                eTieuDe tam = new eTieuDe();
                tam.MaTieuDe = e.MaTieuDe;
                tam.TenTieuDe = e.TenTieuDe;
                tam.NhaSanXuat = e.NhaSanXuat;
                tam.MaLoaiDia = e.TenLoaiDia;
                listTD.Add(tam);
            }
            return listTD;
        }
        public eTieuDe layTieuDeTheoMaTieuDe(string matd)
        {
            TieuDe td = db.TieuDes.Where(x => x.MaTieuDe.Equals(matd)).FirstOrDefault();
            eTieuDe etd = new eTieuDe();
            etd.MaTieuDe = td.MaTieuDe;
            etd.MaLoaiDia = td.MaLoaiDia;
            etd.TenTieuDe = td.TenTieuDe;
            etd.NhaSanXuat = td.NhaSanXuat;
            return etd;
        }
        public eTieuDe LayTieuDeTheoMaDia(string madia)
        {
            Dia dia = db.Dias.Where(x => x.MaDia.Equals(madia)).FirstOrDefault();
            if (dia != null)
            {
                TieuDe tieude = db.TieuDes.Where(x => x.MaTieuDe.Equals(dia.MaTieuDe)).FirstOrDefault();
                if (tieude != null)
                {
                    eTieuDe eTieuDe = new eTieuDe();
                    eTieuDe.MaTieuDe = tieude.MaTieuDe;
                    eTieuDe.TenTieuDe = tieude.TenTieuDe;
                    eTieuDe.NhaSanXuat = tieude.NhaSanXuat;
                    eTieuDe.MaLoaiDia = tieude.MaLoaiDia;
                    return eTieuDe;
                }
            }
            return null;
        }

        public eTieuDe LayTieuDeTheoMa(string matieude)
        {
            TieuDe tieude = db.TieuDes.Where(x => x.MaTieuDe.Equals(matieude)).FirstOrDefault();
            if (tieude != null)
            {
                eTieuDe eTieuDe = new eTieuDe();
                eTieuDe.MaTieuDe = tieude.MaTieuDe;
                eTieuDe.TenTieuDe = tieude.TenTieuDe;
                eTieuDe.NhaSanXuat = tieude.NhaSanXuat;
                eTieuDe.MaLoaiDia = tieude.MaLoaiDia;
                return eTieuDe;
            }
            return null;
        }

        public List<eTieuDe> LayToanBoTieuDe()
        {
            List<eTieuDe> l = new List<eTieuDe>();
            List<TieuDe> lst = db.TieuDes.ToList();
            foreach (var tieude in lst)
            {
                eTieuDe eTieuDe = new eTieuDe();
                eTieuDe.MaTieuDe = tieude.MaTieuDe;
                eTieuDe.TenTieuDe = tieude.TenTieuDe;
                eTieuDe.NhaSanXuat = tieude.NhaSanXuat;
                eTieuDe.MaLoaiDia = tieude.MaLoaiDia;
                l.Add(eTieuDe);
            }
            return l;
        }

        public List<eTieuDe> LayTieuDeCoTen(string ten)
        {
            List<eTieuDe> l = new List<eTieuDe>();
            List<TieuDe> lst = db.TieuDes.Where(x => x.TenTieuDe.Contains(ten)).ToList();
            foreach (var tieude in lst)
            {
                eTieuDe eTieuDe = new eTieuDe();
                eTieuDe.MaTieuDe = tieude.MaTieuDe;
                eTieuDe.TenTieuDe = tieude.TenTieuDe;
                eTieuDe.NhaSanXuat = tieude.NhaSanXuat;
                eTieuDe.MaLoaiDia = tieude.MaLoaiDia;
                l.Add(eTieuDe);
            }
            return l;
        }

        public int ThemTieuDe(eTieuDe them)
        {
            TieuDe td = new TieuDe();
            td.MaTieuDe = sinhMaTieuDeTuSo(chisoTieuDe() + 1);
            td.TenTieuDe = them.TenTieuDe;
            td.NhaSanXuat = them.NhaSanXuat;
            td.MaLoaiDia = them.MaLoaiDia;
            db.TieuDes.InsertOnSubmit(td);
            db.SubmitChanges();
            return 1;
        }

        public int XoaTieuDe(string ma)
        {
            TieuDe td = db.TieuDes.Where(x => x.MaTieuDe.Equals(ma)).FirstOrDefault();
            if (td != null)
            {
                db.TieuDes.DeleteOnSubmit(td);
                db.SubmitChanges();
                return 1;
            }
            return 0;
        }

        int chisoTieuDe()
        {
            TieuDe pt = db.TieuDes.ToList().LastOrDefault();
            if (pt != null)
            {
                return Int32.Parse(pt.MaTieuDe.Substring(2));
            }
            return 0;
        }

        string sinhMaTieuDeTuSo(int chiso)
        {
            if (chiso < 10)
            {
                return "TD000" + chiso;
            }
            else if (chiso < 100)
            {
                return "TD00" + chiso;
            }
            else if (chiso < 1000)
            {
                return "TD0" + chiso;
            }
            else
            {
                return "TD" + chiso;
            }
        }
        public List<eTieuDe> LayDanhSachTieuDe()
        {
            var listtd = db.TieuDes.ToList();
            List<eTieuDe> listetd = new List<eTieuDe>();
            foreach (TieuDe td in listtd)
            {
                eTieuDe etd = new eTieuDe();
                etd.MaTieuDe = td.MaTieuDe;
                etd.TenTieuDe = td.TenTieuDe;
                etd.NhaSanXuat = td.NhaSanXuat;
                etd.MaLoaiDia = td.MaLoaiDia;
                listetd.Add(etd);
            }
            return listetd;
        }
        public List<eTieuDe> LayDanhSachTieuDeTheoLoaiDia(string maloaidia)
        {
            var listtd = db.TieuDes.Where(x => x.MaLoaiDia.Equals(maloaidia)).ToList();
            List<eTieuDe> listetd = new List<eTieuDe>();
            foreach (TieuDe td in listtd)
            {
                eTieuDe etd = new eTieuDe();
                etd.MaTieuDe = td.MaTieuDe;
                etd.TenTieuDe = td.TenTieuDe;
                etd.NhaSanXuat = td.NhaSanXuat;
                etd.MaLoaiDia = td.MaLoaiDia;
                listetd.Add(etd);
            }
            return listetd;
        }
    }
}
