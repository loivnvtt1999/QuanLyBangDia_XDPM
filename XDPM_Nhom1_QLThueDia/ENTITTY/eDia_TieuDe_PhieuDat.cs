using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITTY
{
    public class eDia_TieuDe_PhieuDat
    {
        string madia, matieude, tentieude, madat, makh;
        DateTime ngaydat;

        public string Madia { get => madia; set => madia = value; }
        public string Matieude { get => matieude; set => matieude = value; }
        public string Tentieude { get => tentieude; set => tentieude = value; }
        public string Madat { get => madat; set => madat = value; }
        public string Makh { get => makh; set => makh = value; }
        public DateTime Ngaydat { get => ngaydat; set => ngaydat = value; }
    }
}
