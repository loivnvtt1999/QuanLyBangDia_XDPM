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
    public partial class TraNo : Form
    {
        DataTable dts_Phi;
        busDia busDIA;
        busPhieuThue busPT;
        busKhachHang busKH;
        eKhachHang kh;
        List<ePhieuThue> lstPhieuThue;
        List<ePhieuThue> lstTraNo;
        public TraNo()
        {
            InitializeComponent();
        }

        private void TraNo_Load(object sender, EventArgs e)
        {
            dts_Phi = new DataTable();
            busDIA = new busDia();
            busPT = new busPhieuThue();
            busKH = new busKhachHang();
            kh = new eKhachHang();
            lstPhieuThue = new List<ePhieuThue>();
            lstTraNo = new List<ePhieuThue>();

            #region Đóng các thành phần chưa dùng đến
            splitContainer1.Panel2.Enabled = false;
            splitContainer2.Panel2.Enabled = false;
            #endregion
        }



        #region Tạo tiêu đề cho bảng phí nợ
        public DataTable CreatData_Phi()
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
        #endregion

        #region Cập nhật dữ liệu bảng phí nợ
        void LoadDataDgvPhi(DataGridView dgr, List<ePhieuThue> l)
        {
            dts_Phi.Clear();
            dts_Phi = CreatData_Phi();

            foreach (ePhieuThue pt in l)
            {
                dts_Phi.Rows.Add(false, pt.Maphieuthue,
                    busDIA.layDiaTheoMa(pt.Madia).Tendia,
                    String.Format("{0:dd/MM/yyyy}", pt.Ngaymuon),
                    (DateTime.Parse(pt.Ngaytra.ToString()) - pt.Ngayhentra).TotalDays,
                    pt.Phitramuon);
            }
            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts_Phi;
        }
        #endregion

        #region Cập nhật lại các ô dữ liệu tiền cùng lúc
        void CapNhatTien()
        {
            double? tongNo = lstPhieuThue.Sum(x => x.Phitramuon);
            double? noTra = lstTraNo.Sum(x => x.Phitramuon);
            double? noConLai = tongNo - noTra;
            tbxTongNo.Text = tongNo.ToString();
            tbxNoTra.Text = noTra.ToString();
            tbxNoConLai.Text = noConLai.ToString();
        }
        #endregion

        #region Đưa form về trạng thái ban đầu
        void ResetForm()
        {
            #region Khởi tạo lại các danh sách
            lstPhieuThue = new List<ePhieuThue>();
            lstTraNo = new List<ePhieuThue>();
            kh = new eKhachHang();
            #endregion

            #region Xóa dữ liệu trong các bảng
            LoadDataDgvPhi(dgvPhiTraMuon, lstPhieuThue);
            #endregion

            #region Xóa dữ liệu trong các ô dữ liệu
            tbxMaKH.Text = "";
            tbxTenKH.Text = "";
            tbxSDT.Text = "";
            tbxDiaChi.Text = "";
            tbxNoTra.Text = "";
            tbxTongNo.Text = "";
            tbxNoConLai.Text = "";
            #endregion

            #region Khóa các thành phần chưa dùng tới khi khởi tạo form
            splitContainer1.Panel2.Enabled = false;
            splitContainer2.Panel2.Enabled = false;
            #endregion
        }
        #endregion

        private void btnTimKH_Click(object sender, EventArgs e)
        {
            //Kiểm tra ô tìm kiếm mã khách hàng rỗng
            if (!String.IsNullOrEmpty(tbxMaKH.Text) && !String.IsNullOrWhiteSpace(tbxMaKH.Text))
            {
                //Tìm khách hàng theo mã
                kh = busKH.layKhachHangTheoMaKhachHang(tbxMaKH.Text);
                if (kh == null) //Không tìm thấy khách hàng
                {
                    MessageBox.Show("Mã khách hàng không chính xác!");
                }
                else //Tìm thấy khách hàng
                {
                    #region Cập nhật các ô dữ liệu thông tin khách hàng
                    tbxTenKH.Text = kh.Tenkh;
                    tbxSDT.Text = kh.Sodt;
                    tbxDiaChi.Text = kh.Diachi;
                    #endregion

                    #region Cập nhật dữ liệu cho các bảng
                    lstPhieuThue = busPT.layDanhSachPhiMuonChuaThanhToanTheoKhachHang(kh.Makh);
                    LoadDataDgvPhi(dgvPhiTraMuon, lstPhieuThue);
                    #endregion

                    #region Cập nhật các ô dữ liệu tiền
                    CapNhatTien();
                    #endregion

                    #region Mở các vùng chức năng
                    splitContainer1.Panel2.Enabled = true;
                    splitContainer2.Panel2.Enabled = true;
                    #endregion
                }
            }
            else //Ô tìm kiếm mã khách hàng rỗng hoặc toàn khoảng trắng
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!");
            }
        }

        private void tbxNoTra_TextChanged(object sender, EventArgs e)
        {
            double? tongNo = lstPhieuThue.Sum(x => x.Phitramuon);
            double? noTra = lstTraNo.Sum(x => x.Phitramuon);
            double? noConLai = tongNo - noTra;
            tbxNoConLai.Text = noConLai.ToString();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void btnXemCT_Click(object sender, EventArgs e)
        {
            eKhachHang thongtinkhachhang = new eKhachHang();
            thongtinkhachhang = busPT.layThongTinKhachHangTheoPhieu(kh.Makh);
            ChiTietTraMuon frmChiTiet = new ChiTietTraMuon(thongtinkhachhang);
            frmChiTiet.ShowDialog();
        }

        private void btnThue_Click(object sender, EventArgs e)
        {
            #region Xử lý thanh toán nợ
            foreach (var item in lstTraNo)
            {
                busPT.updatePhiTraMuonCu(item.Maphieuthue);
            }
            #endregion

            ResetForm();
        }

        private void dgvPhiTraMuon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0) //Cột đầu tiên là cột chọn phí trả
            {
                ePhieuThue pthue = new ePhieuThue();
                #region Nợ được chọn
                if (Convert.ToBoolean(dgvPhiTraMuon.Rows[e.RowIndex].Cells[0].EditedFormattedValue) == true)
                {
                    string maphieu = dgvPhiTraMuon.Rows[e.RowIndex].Cells[1].Value.ToString();
                    pthue = busPT.layPhieuThueTheoMa(maphieu);
                    lstTraNo.Add(pthue);
                    double? noTra = lstTraNo.Sum(x => x.Phitramuon);
                    tbxNoTra.Text = noTra.ToString();
                }
                #endregion

                #region Nợ được bỏ chọn
                else
                {
                    string maphieu = dgvPhiTraMuon.Rows[e.RowIndex].Cells[1].Value.ToString();
                    foreach (var item in lstTraNo)
                    {
                        if (item.Maphieuthue == maphieu)
                        {
                            pthue = item;
                        }
                    }
                    lstTraNo.Remove(pthue);
                    double? noTra = lstTraNo.Sum(x => x.Phitramuon);
                    tbxNoTra.Text = noTra.ToString();
                }
                #endregion
            }
        }
    }
}
