using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class eTaiKhoan
    {

        public string tenDN { get; set; }
        public string matKhau { get; set; }
        public eTaiKhoan(string tenDN, string matKhau)
        {
            this.tenDN = tenDN;
            this.matKhau = matKhau;
        }
        public eTaiKhoan()
        {
        }
    }
}
