using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using ENTITTY;

namespace BUS
{
    public class busLoaiDia
    {
        dalLoaiDia dalld = new dalLoaiDia();
        public List<eLoaiDia> layDanhSachLoaiDia()
        {
            return dalld.layDanhSachLoaiDia();
        }
        public eLoaiDia LayLoaiDiaTheoDia(eDia dia)
        {
            return dalld.LayLoaiDiaTheoDia(dia);
        }

        public eLoaiDia LayLoaiDiaTheoMa(string ma)
        {
            return dalld.LayLoaiDiaTheoMa(ma);
        }
        public List<eLoaiDia> LayDanhSachLoaiDia()
        {
            return dalld.LayDanhSachLoaiDia();
        }
        public string LayTenLoaiDiaTheoMaLoai(string maloaidia)
        {
            return dalld.LayTenLoaiDiaTheoMaLoai(maloaidia);
        }
        public int ThietLapGiaThue(eLoaiDia loaiDia)
        {
            return dalld.ThietLapGiaThue(loaiDia);
        }
        public int ThietLapThoiGianThue(eLoaiDia loaiDia)
        {
            return dalld.ThietLapThoiGianThue(loaiDia);
        }
    }
}
