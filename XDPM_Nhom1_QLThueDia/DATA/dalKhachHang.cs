using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITTY;

namespace DATA
{
    public class dalKhachHang
    {
        BangDiaDataClassesDataContext db;
        public dalKhachHang()
        {
            db = new BangDiaDataClassesDataContext();
        }
        public eKhachHang layKhachHangTheoMaKhachHang(string makhachhang)
        {
            eKhachHang khachhang = new eKhachHang();
            KhachHang khtim = db.KhachHangs.Where(x => x.MaKhachHang == makhachhang).FirstOrDefault();
            if (khtim == null)
                return null;
            khachhang.Makh = khtim.MaKhachHang;
            khachhang.Tenkh = khtim.HoTen;
            khachhang.Diachi = khtim.DiaChi;
            khachhang.Sodt = khtim.SDT;
            return khachhang;
        }
        public List<eKhachHang> layDanhSachKhachHang()
        {
            List<eKhachHang> l1 = new List<eKhachHang>();
            List<KhachHang> l = db.KhachHangs.ToList();
            foreach (var item in l)
            {
                eKhachHang khachhang = new eKhachHang();
                khachhang.Makh = item.MaKhachHang;
                khachhang.Tenkh = item.HoTen;
                khachhang.Diachi = item.DiaChi;
                khachhang.Sodt = item.SDT;
                l1.Add(khachhang);
            }
            return l1;
        }
        //lấy danh sách toàn bộ khách hàng
        public List<eKhachHang> LayDanhSachKhachHang()
        {
            var listkh = db.KhachHangs.ToList();
            List<eKhachHang> listekh = new List<eKhachHang>();
            foreach (KhachHang kh in listkh)
            {
                eKhachHang ekh = new eKhachHang();
                ekh.Makh = kh.MaKhachHang;
                ekh.Tenkh = kh.HoTen;
                ekh.Diachi = kh.DiaChi;
                ekh.Sodt = kh.SDT;
                listekh.Add(ekh);
            }
            return listekh;
        }
        //phát sinh mã khách hàng tự động
        public string PhatSinhMaKhachHang()
        {
            List<KhachHang> khs = db.KhachHangs.ToList();
            KhachHang KhachHang = khs.LastOrDefault();
            string ma = "KH";
            int so = int.Parse(KhachHang.MaKhachHang.Substring(2, 4));
            if ((so + 1) < 10)
            {
                ma += "000" + (so + 1).ToString();
            }
            else if ((so + 1) < 100)
            {
                ma += "00" + (so + 1).ToString();
            }
            else
            {
                ma += (so + 1).ToString();
            }
            return ma;
        }
        //kiểm tra trùng mã khách hàng
        private bool KiemTraKhachHang(String ma)
        {
            KhachHang kh = db.KhachHangs.Where(x => x.MaKhachHang.Equals(ma)).FirstOrDefault();
            if (kh != null)
                return true;
            return false;
        }
        public int ThemKhachHang(eKhachHang kh)
        {
            if (KiemTraKhachHang(kh.Makh))
                return 0;
            KhachHang khmoi = new KhachHang();
            khmoi.MaKhachHang = kh.Makh;
            khmoi.HoTen = kh.Tenkh;
            khmoi.DiaChi = kh.Diachi;
            khmoi.SDT = kh.Sodt;
            db.KhachHangs.InsertOnSubmit(khmoi);
            db.SubmitChanges();
            return 1;
        }
        public int SuaKhachHang(eKhachHang kh)
        {
            if (!KiemTraKhachHang(kh.Makh))
                return 0;
            KhachHang khsua = db.KhachHangs.Where(x => x.MaKhachHang.Equals(kh.Makh)).FirstOrDefault();
            khsua.HoTen = kh.Tenkh;
            khsua.DiaChi = kh.Diachi;
            khsua.SDT = kh.Sodt;
            db.SubmitChanges();
            return 1;
        }
        public int XoaKhachHang(eKhachHang kh)
        {
            if (!KiemTraKhachHang(kh.Makh))
                return 0;
            KhachHang khxoa = db.KhachHangs.Where(x => x.MaKhachHang.Equals(kh.Makh)).FirstOrDefault();
            db.KhachHangs.DeleteOnSubmit(khxoa);
            db.SubmitChanges();
            return 1;
        }
    }

}
