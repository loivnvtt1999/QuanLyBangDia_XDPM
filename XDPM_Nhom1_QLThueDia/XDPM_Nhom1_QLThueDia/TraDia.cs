using BUS;
using ENTITTY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class TraDia : Form
    {
        List<ePhieuThue> lstthanhtoan;
        double thanhtoan = 0;
        busPhieuThue busPT;
        busDia busDIA;
        ePhieuThue ePT;
        DataTable dts = new DataTable();
        List<ePhieuThue> lstPhiChuaThanhToan;
        public eDia dia;
        QuyTrinhTraDia main;
        public TraDia()
        {
            InitializeComponent();
        }
        public TraDia(QuyTrinhTraDia frmMain)
        {
            InitializeComponent();
            main = frmMain;
        }
        public DataTable CreatData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("Chọn", typeof(bool)));
            dt.Columns.Add("Mã phiếu");
            dt.Columns.Add("Tên đĩa");
            dt.Columns.Add("Ngày thuê");
            dt.Columns.Add("Số ngày trễ");
            dt.Columns.Add("Phí trả muộn (VNĐ)");
            return dt;
        }
        void LoadDataDataGridView(DataGridView dgr, List<ePhieuThue> l)
        {
            dts.Clear();
            dts = CreatData();
            foreach (ePhieuThue pt in l)
            {

                dts.Rows.Add(false, pt.Maphieuthue, busDIA.layDiaTheoMa(pt.Madia).Tendia,
                    String.Format("{0:dd/MM/yyyy}", pt.Ngaymuon),
                    (DateTime.Parse(pt.Ngaytra.ToString()) - pt.Ngayhentra).TotalDays, pt.Phitramuon);
            }
            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts;

        }


        private void TraDia_Load(object sender, EventArgs e)
        {
            busPT = new busPhieuThue();
            busDIA = new busDia();
            ePT = new ePhieuThue();
            dia = new eDia();
            tbxTenKH.ReadOnly = true;
            tbxDiaChi.ReadOnly = true;
            tbxSoDienThoai.ReadOnly = true;
            tbxMaPhieu.ReadOnly = true;
            tbxNgayHenTra.Enabled = false;
            tbxNgayThue.Enabled = false;
            tbxNgayTra.Enabled = false;
            tbxPhiMuon.ReadOnly = true;
            btnThanhToan.Enabled = false;
            lstthanhtoan = new List<ePhieuThue>();
            lstPhiChuaThanhToan = new List<ePhieuThue>();
        }

        void ResetData()
        {
            lstthanhtoan.Clear();
            lstPhiChuaThanhToan.Clear();
            checkBox1.Enabled = true;
            checkBox1.Checked = false;
            thanhtoan = 0;
            lblTienThanhToan.Text = thanhtoan.ToString();
            lblRong.Text = "";
            btnXemDia.Enabled = true;
            tbxDiaChi.Clear();
            tbxMaPhieu.Clear();
            tbxNgayHenTra.Clear();
            tbxNgayThue.Clear();
            tbxNgayTra.Clear();
            tbxPhiMuon.Clear();
            tbxSoDienThoai.Clear();
            tbxTenKH.Clear();
            btnThanhToan.Enabled = false;
            lblTongPhi.Text = "0";
            dataGridViewX1.DataSource = null;
        }
        private void btnXemDia_Click(object sender, EventArgs e)
        {
            ResetData();
            if (String.IsNullOrWhiteSpace(tbxMaDia.Text.ToString()))
            {
                MessageBox.Show("Vui lòng nhập mã đĩa cần trả");
            }
            else
            {
                ePT = busPT.layPhieuThueTheoDiaDangThue(tbxMaDia.Text.ToString());
                if (ePT == null)
                {
                    MessageBox.Show("Thông tin chưa chính xác, vui lòng kiểm tra lại");
                }
                else
                {
                    btnThanhToan.Enabled = true;
                    eKhachHang thongtinkhachhang = new eKhachHang();
                    lstPhiChuaThanhToan = new List<ePhieuThue>();
                    thongtinkhachhang = busPT.layThongTinKhachHangTheoPhieu(ePT.Makhachhang);
                    lstPhiChuaThanhToan = busPT.layDanhSachPhiMuonChuaThanhToanTheoKhachHang(thongtinkhachhang.Makh);
                    if (lstPhiChuaThanhToan.Count == 0)
                        lblRong.Text = "Không có phiếu thuê chưa thanh toán";
                    LoadDataDataGridView(dataGridViewX1, lstPhiChuaThanhToan);
                    lblTongPhi.Text = lstPhiChuaThanhToan.Sum(x => x.Phitramuon).ToString();
                    tbxTenKH.Text = thongtinkhachhang.Tenkh;
                    tbxDiaChi.Text = thongtinkhachhang.Diachi;
                    tbxSoDienThoai.Text = thongtinkhachhang.Sodt;
                    tbxMaPhieu.Text = ePT.Maphieuthue;
                    tbxNgayThue.Text = String.Format("{0:dd/MM/yyyy}", ePT.Ngaymuon);
                    tbxNgayTra.Text = String.Format("{0:dd/MM/yyyy}", DateTime.Today); ;
                    tbxNgayHenTra.Text = String.Format("{0:dd/MM/yyyy}", ePT.Ngayhentra);
                    if (DateTime.Today > ePT.Ngayhentra)
                    {
                        eDia_LoaiDia_TieuDe loaidiatheomadia = new eDia_LoaiDia_TieuDe();
                        loaidiatheomadia = busPT.layPhiTraMuon(tbxMaDia.Text.ToString());
                        tbxPhiMuon.Text = loaidiatheomadia.Giaphat.ToString();
                    }
                    else
                        tbxPhiMuon.Text = "0";
                    if (tbxPhiMuon.Text == "0")
                    {
                        checkBox1.Enabled = false;
                        checkBox1.Checked = true;
                    }

                }
            }
        }

        private void dataGridViewX1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                ePhieuThue pthuethanhtoan = new ePhieuThue();
                if (Convert.ToBoolean(dataGridViewX1.Rows[e.RowIndex].Cells[0].EditedFormattedValue) == true)
                {
                    string maphieu = dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    pthuethanhtoan = busPT.layPhieuThueTheoMaPhieu(maphieu);
                    lstthanhtoan.Add(pthuethanhtoan);
                    thanhtoan += Double.Parse(pthuethanhtoan.Phitramuon.ToString());
                    lblTienThanhToan.Text = thanhtoan.ToString();
                }
                else
                {
                    ePhieuThue ptxoa = new ePhieuThue();
                    string maphieu = dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    foreach (var item in lstthanhtoan)
                    {
                        if (item.Maphieuthue == maphieu)
                        {
                            ptxoa = item;
                        }
                    }
                    lstthanhtoan.Remove(ptxoa);
                    thanhtoan -= Double.Parse(ptxoa.Phitramuon.ToString());
                    lblTienThanhToan.Text = thanhtoan.ToString();
                }

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                eDia_LoaiDia_TieuDe loaidiatheoma = new eDia_LoaiDia_TieuDe();
                loaidiatheoma = busPT.layPhiTraMuon(tbxMaDia.Text.ToString());
                thanhtoan = thanhtoan + Double.Parse(tbxPhiMuon.Text.ToString());
            }
            else
            {
                eDia_LoaiDia_TieuDe loaidiatheoma = new eDia_LoaiDia_TieuDe();
                loaidiatheoma = busPT.layPhiTraMuon(tbxMaDia.Text.ToString());
                thanhtoan = thanhtoan - Double.Parse(tbxPhiMuon.Text.ToString());
            }
            lblTienThanhToan.Text = thanhtoan.ToString();
        }

        private void lblTienThanhToan_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkChitiet_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            eKhachHang thongtinkhachhang = new eKhachHang();
            thongtinkhachhang = busPT.layThongTinKhachHangTheoPhieu(ePT.Makhachhang);
            ChiTietTraMuon frmChiTiet = new ChiTietTraMuon(thongtinkhachhang);
            frmChiTiet.ShowDialog();
        }
        
        int updateDanhSachPhiMuonCu(List<ePhieuThue> l)
        {
            foreach (var item in l)
            {
                busPT.updatePhiTraMuonCu(item.Maphieuthue);
            }
            return 1;
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Bạn có chắc chắn thực hiện ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (dr == DialogResult.OK)
            {
                //Xu ly neu thanh toan dia moi

                if (lstthanhtoan.Count == 0 && checkBox1.Checked == true)
                {

                    int kq = busPT.updatePhiTraMuonMoiCoTraPhi(tbxMaPhieu.Text.ToString(), Double.Parse(tbxPhiMuon.Text.ToString()));
                    if (kq == 1)
                    {
                        DialogResult dr1 = MessageBox.Show("Đĩa đã được trả, số tiền thanh toán là:" + Double.Parse(lblTienThanhToan.Text.ToString()));
                        if (dr1 == DialogResult.OK)
                        {
                            dia = busDIA.layDiaTheoMa(ePT.Madia);
                            main.GoNext();
                        }
                    }
                }
                //Xu ly neu thanh toan dia cu ma khong thanh toan dia moi
                else if (lstthanhtoan.Count > 0 && checkBox1.Checked == false)
                {
                    int kq = updateDanhSachPhiMuonCu(lstthanhtoan);
                    int kq2 = busPT.updatePhiTraMuonMoiKhongTraPhi(tbxMaPhieu.Text.ToString(), Double.Parse(tbxPhiMuon.Text.ToString()));
                    if (kq == 1 && kq2 == 1)
                    {
                        DialogResult dr1 = MessageBox.Show("Phí muộn cũ đã được thanh toán, số tiền thanh toán là:" + Double.Parse(lblTienThanhToan.Text.ToString()));
                        if (dr1 == DialogResult.OK)
                        {
                            dia = busDIA.layDiaTheoMa(ePT.Madia);
                            main.GoNext();
                        }
                    }
                }
                //Xu ly neu thanh toan dia moi va dia cu
                else if (lstthanhtoan.Count > 0 && checkBox1.Checked == true)
                {
                    int kq = busPT.updatePhiTraMuonMoiCoTraPhi(tbxMaPhieu.Text.ToString(), Double.Parse(tbxPhiMuon.Text.ToString()));
                    int kq2 = updateDanhSachPhiMuonCu(lstthanhtoan);
                    if (kq == 1 && kq2 == 1)
                    {
                        DialogResult dr1 = MessageBox.Show("Trả đĩa thành công, phí muộn cũ đã được thanh toán, số tiền thanh toán là:" + Double.Parse(lblTienThanhToan.Text.ToString()));
                        if (dr1 == DialogResult.OK)
                        {
                            dia = busDIA.layDiaTheoMa(ePT.Madia);
                            main.GoNext();
                        }
                    }
                }
                else
                {
                    int kq = busPT.updatePhiTraMuonMoiKhongTraPhi(tbxMaPhieu.Text.ToString(), Double.Parse(tbxPhiMuon.Text.ToString()));
                    if (kq == 1)
                    {
                        DialogResult dr1 = MessageBox.Show("Trả đĩa thành công,số tiền thanh toán là:" + Double.Parse(lblTienThanhToan.Text.ToString()));
                        if (dr1 == DialogResult.OK)
                        {
                            dia = busDIA.layDiaTheoMa(ePT.Madia);
                            main.GoNext();
                        }
                    }

                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetData();
        }
    }
}
