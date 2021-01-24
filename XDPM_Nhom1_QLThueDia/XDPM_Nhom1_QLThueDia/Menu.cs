using ENTITTY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class Menu : Form
    {
        private string tenDN;
        public Menu()
        {
            InitializeComponent();
        }

        private void MenuQuanLy_Load(object sender, EventArgs e)
        {
            đổiMậtKhẩuToolStripMenuItem.Visible = false;
            đăngXuấtToolStripMenuItem.Visible = false;
            quảnLýTiêuĐềToolStripMenuItem.Visible = false;
            quảnLýĐĩaDVDToolStripMenuItem.Visible = false;
            hủyPhíTrảMuộnToolStripMenuItem1.Visible = false;
            thốngKêToolStripMenuItem.Visible = false;
            thayĐổiĐiềuKhoảnChoThuêToolStripMenuItem.Visible = false;
        }

        private void đăngNhậpQuyềnQuảnLýToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            DangNhap frmDN = new DangNhap();
            if (frmDN.ShowDialog() == DialogResult.OK)
            {
                tenDN = frmDN.tenDN;
                đăngNhậpQuyềnQuảnLýToolStripMenuItem.Visible = false;
                đổiMậtKhẩuToolStripMenuItem.Visible = true;
                đăngXuấtToolStripMenuItem.Visible = true;
                quảnLýTiêuĐềToolStripMenuItem.Visible = true;
                quảnLýĐĩaDVDToolStripMenuItem.Visible = true;
                hủyPhíTrảMuộnToolStripMenuItem1.Visible = true;
                thốngKêToolStripMenuItem.Visible = true;
                thayĐổiĐiềuKhoảnChoThuêToolStripMenuItem.Visible = true;
                frmDN.Close();
            }
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            đổiMậtKhẩuToolStripMenuItem.Visible = false;
            đăngXuấtToolStripMenuItem.Visible = false;
            quảnLýTiêuĐềToolStripMenuItem.Visible = false;
            quảnLýĐĩaDVDToolStripMenuItem.Visible = false;
            hủyPhíTrảMuộnToolStripMenuItem1.Visible = false;
            thốngKêToolStripMenuItem.Visible = false;
            thayĐổiĐiềuKhoảnChoThuêToolStripMenuItem.Visible = false;
            đăngNhậpQuyềnQuảnLýToolStripMenuItem.Visible = true;
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DoiMatKhau frmDMK = new DoiMatKhau(tenDN);
            if (frmDMK.ShowDialog() == DialogResult.OK)
            {
                đổiMậtKhẩuToolStripMenuItem.Visible = false;
                đăngXuấtToolStripMenuItem.Visible = false;
                quảnLýTiêuĐềToolStripMenuItem.Visible = false;
                quảnLýĐĩaDVDToolStripMenuItem.Visible = false;
                hủyPhíTrảMuộnToolStripMenuItem1.Visible = false;
                thốngKêToolStripMenuItem.Visible = false;
                thayĐổiĐiềuKhoảnChoThuêToolStripMenuItem.Visible = false;
                đăngNhậpQuyềnQuảnLýToolStripMenuItem.Visible = true;
            }           
        }

        #region
        /// <summary>
        /// Hiển thị form
        /// </summary>
        void hienForm(Form frm)
        {
            this.pnlChucNang.Controls.Clear();
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowInTaskbar = false;
            frm.Show();
            frm.Dock = DockStyle.Fill;
            this.pnlChucNang.Controls.Add(frm);
        }
        #endregion

        private void xemThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XemThongTinKhachHang frmXemTT = new XemThongTinKhachHang();
            hienForm(frmXemTT);
        }

        private void thôngTinĐĩaTrảTrễToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDiaTraTre frmTKDiaTraTre = new ThongKeDiaTraTre();
            hienForm(frmTKDiaTraTre);
        }

        private void đĩaThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeDiaDangThue frmDiaThue = new ThongKeDiaDangThue();
            hienForm(frmDiaThue);
        }

        private void tổngThôngTinNợToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeTongNo frmTongNo = new ThongKeTongNo();
            hienForm(frmTongNo);
        }

        private void kiểmTraĐĩaTrốngTrongTiêuĐềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KiemTraDiaTrong frmDiaTrong = new KiemTraDiaTrong();
            hienForm(frmDiaTrong);
        }

        private void đặtTrướcToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DatTruoc frmQLDT = new DatTruoc();
            hienForm(frmQLDT);
        }

        private void xóaĐặtTrướcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuyTrinhXoaDat frmXDT = new QuyTrinhXoaDat();
            hienForm(frmXDT);
        }

        private void hủyPhíTrảMuộnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            HuyPhiTraMuon frmHuyPTM= new HuyPhiTraMuon();
            hienForm(frmHuyPTM);
        }

        private void xemTrạngTháiĐĩaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            XemTrangThaiDia frmTRDia = new XemTrangThaiDia();
            hienForm(frmTRDia);
        }

        private void trảĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuyTrinhTraDia frmTRDia = new QuyTrinhTraDia();
            hienForm(frmTRDia);
        }

        private void quảnLýĐĩaDVDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLDia frmQLDia = new QLDia();
            hienForm(frmQLDia);
        }

        private void quảnLýTiêuĐềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QLTieuDe frmQLTieuDe = new QLTieuDe();
            hienForm(frmQLTieuDe);
        }

        private void thuêĐĩaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThueDia frmThueDia = new ThueDia();
            hienForm(frmThueDia);
        }

        private void thanhToánPhíTrảMuộnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            TraNo frmTraNo = new TraNo();
            hienForm(frmTraNo);
        }

        private void quảnLýKháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuanLyKhachHang frmQLKH = new QuanLyKhachHang();
            hienForm(frmQLKH);
        }

        private void thiếtLậpGiáThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThietLapGiaThue frmTLGT = new ThietLapGiaThue();
            hienForm(frmTLGT);
        }

        private void thiếtLậpThờiGianThuêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThietLapThoiGianThue frmTLTG = new ThietLapThoiGianThue();
            hienForm(frmTLTG);
        }

        private void sôLươngĐiaCuaTiêuĐêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeSoLuongDiaCuaTieuDe frmSLTD = new ThongKeSoLuongDiaCuaTieuDe();
            hienForm(frmSLTD);
        }

        private void sôLươngĐiaYêuCâuĐătToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongKeSoLuongDiaYeuCauDat frmTKYC = new ThongKeSoLuongDiaYeuCauDat();
            hienForm(frmTKYC);
        }
    }
}
