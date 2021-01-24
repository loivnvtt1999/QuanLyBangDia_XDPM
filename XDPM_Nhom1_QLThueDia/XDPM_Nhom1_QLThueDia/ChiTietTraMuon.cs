using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ENTITTY;
using BUS;
namespace XDPM_Nhom1_QLThueDia
{
    public partial class ChiTietTraMuon : Form
    {
        DataTable dts;
        eKhachHang KhachHangChiTiet;
        busPhieuThue busPT;
        List<eDia_LoaiDia_TieuDe> lstChiTiet;
        public ChiTietTraMuon()
        {
            InitializeComponent();
        }
        public ChiTietTraMuon(eKhachHang kh)
        {
            InitializeComponent();
            KhachHangChiTiet = kh;
        }
        public DataTable CreatData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phiếu thuê");
            dt.Columns.Add("Tên tiêu đề");
            dt.Columns.Add("Tên đĩa");
            dt.Columns.Add("Ngày thuê");
            dt.Columns.Add("Ngày hẹn trả");
            dt.Columns.Add("Ngày trả");
            dt.Columns.Add("Số ngày muộn");
            dt.Columns.Add("Phí muộn");
            //DataGridViewCheckBoxColumn d = new DataGridViewCheckBoxColumn();
            //dataGridViewX1.Columns.Add(d);
            return dt;
        }
        void LoadDataDataGridView(DataGridView dgr, List<eDia_LoaiDia_TieuDe> l)
        {
            dts.Clear();
            dts = CreatData();
            foreach (eDia_LoaiDia_TieuDe pt in l)
            {
                //eDia_LoaiDia_TieuDe loaidiatheoma = new eDia_LoaiDia_TieuDe();
                //loaidiatheoma = busPT.layPhiTraMuon(pt.Madia);
                dts.Rows.Add(pt.Maphieu, pt.Tentieude, pt.Tendia, String.Format("{0:dd/MM/yyyy}", pt.Ngaythue), String.Format("{0:dd/MM/yyyy}", pt.Ngayhentra), String.Format("{0:dd/MM/yyyy}", pt.NgayTra), (pt.NgayTra - pt.Ngayhentra).TotalDays, pt.Giaphat);
            }
            dts.Rows.Add("", "", "", "", "", "", "TỔNG PHÍ: ", +l.Sum(x => x.Giaphat));
            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts;

        }
        private void ChiTietTraMuon_Load(object sender, EventArgs e)
        {
            lblTenKhachHang.Text = KhachHangChiTiet.Tenkh;
            dts = new DataTable();
            busPT = new busPhieuThue();
            lstChiTiet = new List<eDia_LoaiDia_TieuDe>();
            lstChiTiet = busPT.chiTietTraMuon(KhachHangChiTiet.Makh);
            LoadDataDataGridView(dgrChiTietTraMuon, lstChiTiet);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
