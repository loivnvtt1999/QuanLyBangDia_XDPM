using ENTITTY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DATA
{
    public class dalLoaiDia
    {
        BangDiaDataClassesDataContext db = new BangDiaDataClassesDataContext();
        public List<eLoaiDia> layDanhSachLoaiDia()
        {
            List<eLoaiDia> l1 = new List<eLoaiDia>();
            List<LoaiDia> l = db.LoaiDias.ToList();
            foreach (var item in l)
            {
                eLoaiDia eld = new eLoaiDia();
                eld.maLoai = item.MaLoaiDia;
                eld.tenLoai = item.TenLoaiDia;
                eld.thoiGianThue = item.ThoiGianThue;
                eld.giaThue = item.GiaThue;
                eld.giaPhat = item.GiaPhat;
                l1.Add(eld);
            }
            return l1;
        }
        public eLoaiDia LayLoaiDiaTheoDia(eDia dia)
        {
            TieuDe td = db.TieuDes.Where(x => x.MaTieuDe.Equals(dia.Matieude)).FirstOrDefault();
            if (td != null)
            {
                LoaiDia loai = db.LoaiDias.Where(x => x.MaLoaiDia.Equals(td.MaLoaiDia)).FirstOrDefault();
                if (loai != null)
                {
                    eLoaiDia eloai = new eLoaiDia();
                    eloai.maLoai = loai.MaLoaiDia;
                    eloai.tenLoai = loai.TenLoaiDia;
                    eloai.thoiGianThue = loai.ThoiGianThue;
                    eloai.giaThue = loai.GiaThue;
                    eloai.giaPhat = loai.GiaPhat;
                    return eloai;
                }
            }
            return null;
        }

        public eLoaiDia LayLoaiDiaTheoMa(string ma)
        {
            LoaiDia loai = db.LoaiDias.Where(x => x.MaLoaiDia.Equals(ma)).FirstOrDefault();
            if (loai != null)
            {
                eLoaiDia eloai = new eLoaiDia();
                eloai.maLoai = loai.MaLoaiDia;
                eloai.tenLoai = loai.TenLoaiDia;
                eloai.thoiGianThue = loai.ThoiGianThue;
                eloai.giaThue = loai.GiaThue;
                eloai.giaPhat = loai.GiaPhat;
                return eloai;
            }
            return null;
        }
        public List<eLoaiDia> LayDanhSachLoaiDia()
        {
            var listld = db.LoaiDias.ToList();
            List<eLoaiDia> listeld = new List<eLoaiDia>();
            foreach (LoaiDia ld in listld)
            {
                eLoaiDia eld = new eLoaiDia();
                eld.maLoai = ld.MaLoaiDia;
                eld.tenLoai = ld.TenLoaiDia;
                eld.thoiGianThue = ld.ThoiGianThue;
                eld.giaThue = (float)ld.GiaThue;
                eld.giaPhat = (float)ld.GiaPhat;
                listeld.Add(eld);
            }
            return listeld;
        }       
        public string LayTenLoaiDiaTheoMaLoai(string maloaidia)
        {
            LoaiDia loaidia = db.LoaiDias.Where(x => x.MaLoaiDia == maloaidia).FirstOrDefault();
            if (loaidia == null)
            {
                return null;
            }
            return loaidia.TenLoaiDia;
        }
        private bool KiemTraLoaiDia(string maloaidia)
        {
            LoaiDia loaidia = db.LoaiDias.Where(x => x.MaLoaiDia == maloaidia).FirstOrDefault();
            if (loaidia != null)
                return true;
            return false;
        }
        public int ThietLapGiaThue(eLoaiDia loaiDia)
        {
            if (!KiemTraLoaiDia(loaiDia.maLoai))
                return 0;
            LoaiDia loaidia = db.LoaiDias.Where(x => x.MaLoaiDia.Equals(loaiDia.maLoai)).FirstOrDefault();
            loaidia.GiaThue = loaiDia.giaThue;
            db.SubmitChanges();
            return 1;
        }
        public int ThietLapThoiGianThue(eLoaiDia loaiDia)
        {
            if (!KiemTraLoaiDia(loaiDia.maLoai))
                return 0;
            LoaiDia loaidia = db.LoaiDias.Where(x => x.MaLoaiDia.Equals(loaiDia.maLoai)).FirstOrDefault();
            loaidia.ThoiGianThue = loaiDia.thoiGianThue;
            db.SubmitChanges();
            return 1;
        }
    }
}
