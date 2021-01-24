using BUS;
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
    public partial class HuyPhiTraMuon : Form
    {
        List<eKhachHang> lstKhachHang;
        List<ePhieuThue> lstPhieuThueChuaTra;
        DataTable dts = new DataTable();
        busKhachHang busKH;
        busPhieuThue busPT;
        busDia busD;
        List<ePhieuThue> lstPhieuHuy;
        public HuyPhiTraMuon()
        {
            InitializeComponent();
        }

        private void HuyPhiTraMuon_Load(object sender, EventArgs e)
        {
            tbxDiaChi.ReadOnly = true;
            tbxTenKhachHang.ReadOnly = true;
            tbxSDT.ReadOnly = true;
            btnHuyPhiTraMuon.Enabled = false;
            lstKhachHang = new List<eKhachHang>();
            busKH = new busKhachHang();
            busPT = new busPhieuThue();
            busD = new busDia();
            lstKhachHang = busKH.layDanhSachKhachHang();
            tbxMaKH.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbxMaKH.AutoCompleteSource = AutoCompleteSource.CustomSource;
            lstPhieuHuy = new List<ePhieuThue>();
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            foreach (var item in lstKhachHang)
            {
                DataCollection.Add(item.Makh);
            }
            tbxMaKH.AutoCompleteCustomSource = DataCollection;
            lstPhieuThueChuaTra = new List<ePhieuThue>();
        }
        public DataTable CreatData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phiếu");
            dt.Columns.Add("Tên đĩa");
            dt.Columns.Add("Ngày thuê");
            dt.Columns.Add("Ngày hẹn trả");
            dt.Columns.Add("Ngày trả");
            dt.Columns.Add("Số ngày trễ");
            dt.Columns.Add("Phí trả muộn (VNĐ)");
            dt.Columns.Add(new DataColumn("Chọn", typeof(bool)));
            return dt;
        }
        void LoadDataDataGridView(DataGridView dgr, List<ePhieuThue> l)
        {
            dts.Clear();
            dts = CreatData();
            foreach (ePhieuThue pt in l)
            {

                dts.Rows.Add(pt.Maphieuthue, busD.layDiaTheoMa(pt.Madia).Tendia,
                    String.Format("{0:dd/MM/yyyy}", pt.Ngaymuon), String.Format("{0:dd/MM/yyyy}", pt.Ngayhentra), String.Format("{0:dd/MM/yyyy}", pt.Ngaytra),
                    (DateTime.Parse(pt.Ngaytra.ToString()) - pt.Ngayhentra).TotalDays, pt.Phitramuon, false);
            }
            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts;

        }
        private void btnXemKhachHang_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(tbxMaKH.Text.ToString()))
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng");
            }
            else
            {
                eKhachHang kh = new eKhachHang();
                kh = busKH.layKhachHangTheoMaKhachHang(tbxMaKH.Text.ToString());
                if (kh == null)
                    MessageBox.Show("Thông tin chưa chính xác, vui lòng kiểm tra lại");
                else
                {
                    btnHuyPhiTraMuon.Enabled = true;
                    btnXemKhachHang.Enabled = false;
                    tbxTenKhachHang.Text = kh.Tenkh;
                    tbxDiaChi.Text = kh.Diachi;
                    tbxSDT.Text = kh.Sodt;
                    lstPhieuThueChuaTra = busPT.layDanhSachPhiMuonChuaThanhToanTheoKhachHang(kh.Makh);
                    if (lstPhieuThueChuaTra.Count == 0)
                        lblRong.Text = "Không có phiếu thuê nào chưa thanh toán";
                    LoadDataDataGridView(dataGridViewX1, lstPhieuThueChuaTra);
                }
            }
        }
        void ClearData()
        {
            btnXemKhachHang.Enabled = true;
            tbxDiaChi.Clear();
            tbxMaKH.Clear();
            tbxSDT.Clear();
            tbxTenKhachHang.Clear();
            lstPhieuHuy.Clear();
            btnHuyPhiTraMuon.Enabled = false;
            dataGridViewX1.DataSource = null;
            lblRong.Text = "";
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ClearData();
        }
        int updateDanhSachPhiMuonCu(List<ePhieuThue> l)
        {
            foreach (var item in l)
            {
                busPT.updatePhiTraMuonCu(item.Maphieuthue);
            }
            return 1;
        }
        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7)
            {
                ePhieuThue pthuethanhtoan = new ePhieuThue();
                if (Convert.ToBoolean(dataGridViewX1.Rows[e.RowIndex].Cells[7].EditedFormattedValue) == true)
                {
                    //MessageBox.Show("Test");
                    string maphieu = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    pthuethanhtoan = busPT.layPhieuThueTheoMaPhieu(maphieu);
                    lstPhieuHuy.Add(pthuethanhtoan);
                }
                else
                {
                    ePhieuThue ptxoa = new ePhieuThue();
                    string maphieu = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    foreach (var item in lstPhieuHuy)
                    {
                        if (item.Maphieuthue == maphieu)
                        {
                            ptxoa = item;
                        }
                    }
                    lstPhieuHuy.Remove(ptxoa);
                }
            }
        }

        private void btnHuyPhiTraMuon_Click(object sender, EventArgs e)
        {
            if (lstPhieuHuy.Count == 0)
                MessageBox.Show("Chưa có phí trả muộn nào được chọn, vui lòng kiểm tra lại");
            else
            {
                DialogResult dr = MessageBox.Show("Bạn có chắc sẽ hủy những phí trả muộn này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                if (dr == DialogResult.OK)
                {
                    int kq = updateDanhSachPhiMuonCu(lstPhieuHuy);
                    if (kq == 1)
                    {
                        MessageBox.Show("Cập nhật thành công");
                        ClearData();
                    }
                }
            }
        }
    }
}
