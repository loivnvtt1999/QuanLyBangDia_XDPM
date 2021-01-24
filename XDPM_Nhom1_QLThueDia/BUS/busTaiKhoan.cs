using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DATA;
using ENTITTY;

namespace BUS
{
    public class busTaiKhoan
    {
        dalTaiKhoan dalTK;
        public busTaiKhoan()
        {
            dalTK = new dalTaiKhoan();
        }
        public bool DangNhap(eTaiKhoan input)
        {
            return dalTK.DangNhap(input);
        }
        public bool DoiMatKhau(string tenDN,string mkCu, string mkMoi)
        {
            return dalTK.DoiMatKhau(tenDN,mkCu, mkMoi);
        }
    }
}
