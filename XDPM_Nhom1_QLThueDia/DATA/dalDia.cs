using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITTY;

namespace DATA
{
    public class dalDia
    {
        BangDiaDataClassesDataContext db = new BangDiaDataClassesDataContext();
        public int updateTrangThaiDiaChoDatTruoc(string madia)
        {
            Dia d = db.Dias.Where(x => x.MaDia == madia).FirstOrDefault();
            if (d == null)
                return 0;
            d.TrangThaiDia = "Đã đặt";
            db.SubmitChanges();
            return 1;
        }
        public int updateTrangThaiDiaTra(string madia)
        {
            Dia d = db.Dias.Where(x => x.MaDia == madia).FirstOrDefault();
            if (d == null)
                return 0;
            d.TrangThaiDia = "Sẵn sàng";
            db.SubmitChanges();
            return 1;
        }
        public eDia layDiaTheoMa(string madia)
        {
            Dia d = db.Dias.Where(x => x.MaDia == madia).FirstOrDefault();
            if (d != null)
            {
                eDia ed = new eDia();
                ed.Madia = d.MaDia;
                ed.Tendia = d.TenDia;
                ed.Matieude = d.MaTieuDe;
                ed.Trangthaidia = d.TrangThaiDia;
                return ed;
            }
            return null;
        }
        public List<eDia_LoaiDia_TieuDe> layTatCaDia()
        {
            var query = (from LoaiDia in db.LoaiDias
                         join TieuDe in db.TieuDes
                         on LoaiDia.MaLoaiDia equals TieuDe.MaLoaiDia
                         join Dia in db.Dias
                         on TieuDe.MaTieuDe equals Dia.MaTieuDe
                         select new
                         {
                             madianew = Dia.MaDia,
                             tenloaidianew = LoaiDia.TenLoaiDia,
                             tentieudenew = TieuDe.TenTieuDe,
                             tendianew = Dia.TenDia,
                             trangthaidianew = Dia.TrangThaiDia,
                         }).ToList();
            List<eDia_LoaiDia_TieuDe> l = new List<eDia_LoaiDia_TieuDe>();
            foreach (var item in query)
            {
                eDia_LoaiDia_TieuDe dulieulay = new eDia_LoaiDia_TieuDe();
                dulieulay.Madia = item.madianew;
                dulieulay.Tenloai = item.tenloaidianew;
                dulieulay.Tentieude = item.tentieudenew;
                dulieulay.Tendia = item.tendianew;
                dulieulay.Trangthai = item.trangthaidianew;
                l.Add(dulieulay);
            }
            return l;
        }
        public List<eDia_LoaiDia_TieuDe> layDanhSachDiaTheoLoai(string maLoai)
        {
            var query = from LoaiDia in db.LoaiDias
                        join TieuDe in db.TieuDes
                        on LoaiDia.MaLoaiDia equals TieuDe.MaLoaiDia
                        join Dia in db.Dias
                        on TieuDe.MaTieuDe equals Dia.MaTieuDe
                        where LoaiDia.MaLoaiDia == maLoai
                        select new
                        {
                            madianew = Dia.MaDia,
                            tenloaidianew = LoaiDia.TenLoaiDia,
                            tentieudenew = TieuDe.TenTieuDe,
                            tendianew = Dia.TenDia,
                            trangthaidianew = Dia.TrangThaiDia,
                        };
            List<eDia_LoaiDia_TieuDe> l = new List<eDia_LoaiDia_TieuDe>();
            foreach (var item in query)
            {
                eDia_LoaiDia_TieuDe dulieulay = new eDia_LoaiDia_TieuDe();
                dulieulay.Madia = item.madianew;
                dulieulay.Tenloai = item.tenloaidianew;
                dulieulay.Tentieude = item.tentieudenew;
                dulieulay.Tendia = item.tendianew;
                dulieulay.Trangthai = item.trangthaidianew;
                l.Add(dulieulay);
            }
            return l;
        }
        public List<eDia_LoaiDia_TieuDe> layDanhSachDiaTheoLoaiVaTheoTrangThai(string maLoai, string trangthai)
        {
            var query = from LoaiDia in db.LoaiDias
                        join TieuDe in db.TieuDes
                        on LoaiDia.MaLoaiDia equals TieuDe.MaLoaiDia
                        join Dia in db.Dias
                        on TieuDe.MaTieuDe equals Dia.MaTieuDe
                        where LoaiDia.MaLoaiDia == maLoai && Dia.TrangThaiDia == trangthai
                        select new
                        {
                            madianew = Dia.MaDia,
                            tenloaidianew = LoaiDia.TenLoaiDia,
                            tentieudenew = TieuDe.TenTieuDe,
                            tendianew = Dia.TenDia,
                            trangthaidianew = Dia.TrangThaiDia,
                        };
            List<eDia_LoaiDia_TieuDe> l = new List<eDia_LoaiDia_TieuDe>();
            foreach (var item in query)
            {
                eDia_LoaiDia_TieuDe dulieulay = new eDia_LoaiDia_TieuDe();
                dulieulay.Madia = item.madianew;
                dulieulay.Tenloai = item.tenloaidianew;
                dulieulay.Tentieude = item.tentieudenew;
                dulieulay.Tendia = item.tendianew;
                dulieulay.Trangthai = item.trangthaidianew;
                l.Add(dulieulay);
            }
            return l;
        }       
        public List<eDia> layToanBoDia()
        {
            List<eDia> l = new List<eDia>();
            List<Dia> lst = db.Dias.ToList();
            foreach (var item in lst)
            {
                eDia ed = new eDia();
                ed.Madia = item.MaDia;
                ed.Tendia = item.TenDia;
                ed.Matieude = item.MaTieuDe;
                ed.Trangthaidia = item.TrangThaiDia;
                l.Add(ed);
            }
            return l;
        }

        public List<eDia> LayDiaCoTen(string ten)
        {
            List<eDia> l = new List<eDia>();
            List<Dia> lst = db.Dias.Where(x => x.TenDia.Contains(ten)).ToList();
            foreach (var item in lst)
            {
                eDia ed = new eDia();
                ed.Madia = item.MaDia;
                ed.Tendia = item.TenDia;
                ed.Matieude = item.MaTieuDe;
                ed.Trangthaidia = item.TrangThaiDia;
                l.Add(ed);
            }
            return l;
        }

        public List<eDia> layDiaDangThueCuaTieuDe(string matieude)
        {
            List<eDia> l = new List<eDia>();
            List<Dia> lst = db.Dias.Where(x => x.MaTieuDe.Equals(matieude) && (x.TrangThaiDia.Equals("Đã thuê") || x.TrangThaiDia.Equals("Đã đặt"))).ToList();
            foreach (var item in lst)
            {
                eDia ed = new eDia();
                ed.Madia = item.MaDia;
                ed.Tendia = item.TenDia;
                ed.Matieude = item.MaTieuDe;
                ed.Trangthaidia = item.TrangThaiDia;
                l.Add(ed);
            }
            return l;
        }

        public int ThemDia(eDia d)
        {
            Dia dia = new Dia();
            dia.MaDia = sinhMaDiaTuSo(chisoDia() + 1);
            dia.TenDia = d.Tendia;
            dia.MaTieuDe = d.Matieude;
            dia.TrangThaiDia = d.Trangthaidia;
            db.Dias.InsertOnSubmit(dia);
            db.SubmitChanges();
            return 1;
        }

        public int XoaDia(string maDia)
        {
            Dia d = db.Dias.Where(x => x.MaDia.Equals(maDia)).FirstOrDefault();
            if (d.TrangThaiDia.Equals("Sẵn sàng"))
            {
                db.Dias.DeleteOnSubmit(d);
                db.SubmitChanges();
                return 1;
            }
            return 0;
        }

        int chisoDia()
        {
            Dia d = db.Dias.ToList().LastOrDefault();
            if (d != null)
            {
                return Int32.Parse(d.MaDia.Substring(1));
            }
            return 0;
        }

        string sinhMaDiaTuSo(int chiso)
        {
            if (chiso < 10)
            {
                return "D000" + chiso;
            }
            else if (chiso < 100)
            {
                return "D00" + chiso;
            }
            else if (chiso < 1000)
            {
                return "D0" + chiso;
            }
            else
            {
                return "D" + chiso;
            }
        }
        public List<eDia> layToanBoDiaChoQLDia()
        {
            List<eDia> l = new List<eDia>();
            List<Dia> lst = db.Dias.ToList();
            foreach (var item in lst)
            {
                eDia ed = new eDia();
                ed.Madia = item.MaDia;
                ed.Tendia = item.TenDia;
                ed.Matieude = item.MaTieuDe;
                ed.Trangthaidia = item.TrangThaiDia;
                l.Add(ed);
            }
            return l;
        }
        public eThongKeSLDia ThongKeSoLuongDiaTheoTinhTrang(eTieuDe tieuDe)
        {
            var listdia = db.Dias.Where(x => x.MaTieuDe.Equals(tieuDe.MaTieuDe)).ToList();
            eThongKeSLDia eThongKe = new eThongKeSLDia();
            List<Dia> listDiaDaThue = new List<Dia>();
            List<Dia> listDiaDaDatTruoc = new List<Dia>();
            List<Dia> listDiaSanSang = new List<Dia>();
            foreach (Dia dia in listdia)
            {
                if (dia.TrangThaiDia.Equals("Đã thuê"))
                    listDiaDaThue.Add(dia);
                else if (dia.TrangThaiDia.Equals("Đã đặt"))
                    listDiaDaDatTruoc.Add(dia);
                else
                    listDiaSanSang.Add(dia);
            }
            eThongKe.TenTieuDe = tieuDe.TenTieuDe;
            eThongKe.TongSoLuong = listdia.Count;
            eThongKe.SoLuongDaDatTruoc = listDiaDaDatTruoc.Count;
            eThongKe.SoLuongDaThue = listDiaDaThue.Count;
            eThongKe.SoLuongSanSang = listDiaSanSang.Count;
            return eThongKe;
        }
    }
}
