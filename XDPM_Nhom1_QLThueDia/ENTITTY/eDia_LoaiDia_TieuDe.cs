using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class eDia_LoaiDia_TieuDe
    {
        string madia, matieude, maloaidia, tendia, tentieude, maphieu, tenloai, trangthai;
        double giaphat;
        DateTime ngaythue;
        DateTime ngayhentra;
        DateTime ngayTra;
        int thoigianthue;
        public string Madia { get => madia; set => madia = value; }
        public string Matieude { get => matieude; set => matieude = value; }
        public string Maloaidia { get => maloaidia; set => maloaidia = value; }
        public double Giaphat { get => giaphat; set => giaphat = value; }
        public string Tendia { get => tendia; set => tendia = value; }
        public string Tentieude { get => tentieude; set => tentieude = value; }
        public int Thoigianthue { get => thoigianthue; set => thoigianthue = value; }
        public string Maphieu { get => maphieu; set => maphieu = value; }
        public DateTime Ngaythue { get => ngaythue; set => ngaythue = value; }
        public DateTime Ngayhentra { get => ngayhentra; set => ngayhentra = value; }
        public DateTime NgayTra { get => ngayTra; set => ngayTra = value; }
        public string Tenloai { get => tenloai; set => tenloai = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
