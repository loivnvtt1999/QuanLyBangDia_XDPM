using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ENTITTY;

namespace DATA
{
    public class dalTaiKhoan
    {
        BangDiaDataClassesDataContext db;
        public dalTaiKhoan()
        {
            db = new BangDiaDataClassesDataContext();
        }
        public bool DangNhap(eTaiKhoan input)
        {
            var listTK = db.TaiKhoans.ToList();
            foreach(TaiKhoan tam in listTK)
            {
                if(tam.TenDN==input.tenDN && tam.MatKhau == input.matKhau)
                {
                    return true;
                }
            }
            return false;
        }
        public bool DoiMatKhau(string tenDN,string mkCu,string mkMoi)
        {
            TaiKhoan tk = db.TaiKhoans.Where(x => x.TenDN == tenDN).FirstOrDefault();
            if (tk == null)
            {              
                return false;
            }
            else
            {
                if (tk.MatKhau.Equals(mkCu))
                {
                    tk.MatKhau = mkMoi;
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }                                
            }
        }
    }
}
