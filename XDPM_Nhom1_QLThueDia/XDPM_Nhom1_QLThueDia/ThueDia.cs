using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using ENTITTY;
using BUS;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class ThueDia : Form
    {
        #region Khai báo các thành phần chính được sử dụng
        #region Dữ liệu cho bảng
        DataTable dts_Phi;
        DataTable dts_Dia;
        #endregion

        #region Bộ phận xử lý tầng dưới
        busDia busDIA;
        busPhieuThue busPT;
        busLoaiDia busLoai;
        busTieuDe busTieuDe;
        busPhieuDat busPDat;
        busKhachHang busKhachHang;
        busPhieuThue busThue;
        #endregion

        #region Thành phần xử lý chính
        eKhachHang kh;
        #endregion

        #region Các danh sách được sử dụng
        List<ePhieuThue> lstPhieuThue;
        List<ePhieuThue> lstTraNo;
        List<ePhieuThue> lstThue;
        List<ePhieuThue> lstThueDat;
        List<ePhieuDat> lstDatTruoc;
        #endregion
        #endregion

        public ThueDia()
        {
            InitializeComponent();
        }

        private void ThueDia_Load(object sender, EventArgs e)
        {
            #region Khởi tạo các thành phần được sử dụng
            busDIA = new busDia();
            busPT = new busPhieuThue();
            busKhachHang = new busKhachHang();
            busLoai = new busLoaiDia();
            busTieuDe = new busTieuDe();
            busPDat = new busPhieuDat();
            busThue = new busPhieuThue();
            lstPhieuThue = new List<ePhieuThue>();
            lstTraNo = new List<ePhieuThue>();
            lstThue = new List<ePhieuThue>();
            lstThueDat = new List<ePhieuThue>();
            lstDatTruoc = new List<ePhieuDat>();
            dts_Phi = new DataTable();
            dts_Dia = new DataTable();
            kh = new eKhachHang();
            #endregion

            #region Đóng các thành phần chưa dùng đến
            splitContainer1.Panel2.Enabled = false;
            splitContainer3.Panel2.Enabled = false;
            #endregion
        }

        #region Xử lý trên form
        #region Xử lý nút tìm khách hàng
        private void btnTimKH_Click(object sender, EventArgs e)
        {
            //Kiểm tra ô tìm kiếm mã khách hàng rỗng
            if (!String.IsNullOrEmpty(tbxMaKH.Text) && !String.IsNullOrWhiteSpace(tbxMaKH.Text))
            {
                //Tìm khách hàng theo mã
                kh = busKhachHang.layKhachHangTheoMaKhachHang(tbxMaKH.Text);
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
                    lstDatTruoc = busPDat.LayDanhSachPhieuDat_TheoMaKhachHang_DaCoDia(kh.Makh);
                    DanhSachThueDat(lstDatTruoc);
                    LoadDataDgvDia(dgvDia, lstThue);
                    #endregion

                    #region Cập nhật các ô dữ liệu tiền
                    CapNhatTien();
                    #endregion

                    #region Mở các vùng chức năng
                    splitContainer1.Panel2.Enabled = true;
                    splitContainer3.Panel2.Enabled = true;
                    #endregion
                }
            }
            else //Ô tìm kiếm mã khách hàng rỗng hoặc toàn khoảng trắng
            {
                MessageBox.Show("Vui lòng nhập mã khách hàng!");
            }
        }
        #endregion

        #region Xử lý nút thêm đĩa vào danh sách thuê
        private void btnThem_Click(object sender, EventArgs e)
        {
            //Kiểm tra ô tìm kiếm mã đĩa rỗng
            if (!String.IsNullOrEmpty(tbxMaDia.Text) && !String.IsNullOrWhiteSpace(tbxMaDia.Text))
            {
                //Tìm đĩa theo mã 
                eDia dia = busDIA.layDiaTheoMa(tbxMaDia.Text);
                if (dia == null) //Không tìm thấy đĩa
                {
                    MessageBox.Show("Mã đĩa không chính xác!");
                    tbxMaDia.Text = "";
                    return;
                }
                else //Tìm thấy đĩa
                {
                    #region Đĩa sẵn sàng cho thuê
                    if (dia.Trangthaidia.Equals("Sẵn sàng"))
                    {
                        #region Kiểm tra trùng trong danh sách đặt
                        foreach (var item in lstThueDat)
                        {
                            if (dia.Madia.Equals(item.Madia))
                            {
                                MessageBox.Show("Đĩa đã có trong danh sách thuê!");
                                return;
                            }
                        }
                        #endregion

                        #region Kiểm tra trùng trong danh sách thuê
                        foreach (var item in lstThue)
                        {
                            if (dia.Madia.Equals(item.Madia))
                            {
                                MessageBox.Show("Đĩa đã có trong danh sách thuê!");
                                return;
                            }
                        }
                        #endregion

                        #region Kiểm tra trùng tiêu đề
                        foreach (var item in lstThue)
                        {
                            eDia temp = busDIA.layDiaTheoMa(item.Madia);
                            if (dia.Matieude.Equals(temp.Matieude))
                            {
                                //Yêu cầu xác nhận thêm đĩa trùng tiêu đề
                                DialogResult result = MessageBox.Show("Đĩa này thuộc tiêu đề đã có trong danh sách thuê, " +
                                    "bạn có chắc muốn thuê thêm đĩa này?", "Xác nhận", MessageBoxButtons.YesNo);

                                #region Đồng ý thêm
                                if (result == DialogResult.Yes)
                                {
                                    ePhieuThue pt = phatSinhPhieuThueTheoDia(dia);
                                    if (pt != null) //Tạo được phiếu
                                    {
                                        lstThue.Add(pt);
                                        LoadDataDgvDia(dgvDia, lstThue);
                                        double? tongThue = lstThue.Sum(x => x.Giathue) + lstThueDat.Sum(x => x.Giathue);
                                        tbxTongThue.Text = tongThue.ToString();
                                        return;
                                    }
                                    else //Không tạo được phiếu
                                    {
                                        tbxMaDia.Text = "";
                                        return;
                                    }
                                }
                                #endregion

                                #region Không đồng ý thêm
                                else
                                {
                                    tbxMaDia.Text = "";
                                    return;
                                }
                                #endregion
                            }
                        }
                        #endregion

                        #region Thêm đĩa vào danh sách thuê
                        ePhieuThue ept = phatSinhPhieuThueTheoDia(dia);
                        if (ept != null)
                        {
                            lstThue.Add(ept);
                            LoadDataDgvDia(dgvDia, lstThue);
                            double? tongThue = lstThue.Sum(x => x.Giathue);
                            tbxTongThue.Text = tongThue.ToString();
                            return;
                        }
                        else
                        {
                            tbxMaDia.Text = "";
                            return;
                        }
                        #endregion
                    }
                    #endregion

                    #region Đĩa không sẵn sàng cho thuê
                    else
                    {
                        MessageBox.Show("Đĩa này không sẵn sàng cho thuê!");
                        tbxMaDia.Text = "";
                        return;
                    }
                    #endregion
                }
            }
            else //Ô tìm kiếm mã đĩa rỗng hoặc toàn khoảng trắng
            {
                MessageBox.Show("Vui lòng nhập mã đĩa trước!");
                tbxMaDia.Text = "";
                return;
            }
        }
        #endregion

        #region Xử lý nút xóa đĩa khỏi danh sách thuê
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDia.SelectedRows.Count > 0) //Có ít nhất 1 dòng trên bảng đĩa thuê được chọn
            {
                string str = dgvDia.SelectedRows[0].Cells[0].Value.ToString(); //Lấy mã đĩa đầu tiên
                #region Đĩa từ danh sách đặt không thể xóa
                foreach (var item in lstThueDat)
                {
                    if (item.Madia.Equals(str))
                    {
                        MessageBox.Show("Đây là đĩa đặt trước không thể xóa");
                        return;
                    }
                }
                #endregion

                #region Xóa đĩa trong danh sách thuê
                ePhieuThue tam = null;
                foreach (var item in lstThue)
                {
                    if (item.Madia.Equals(str))
                    {
                        tam = item;
                    }
                }
                if (tam != null)//Đĩa có trong danh sách thuê
                {
                    //Yêu cầu xác nhận xóa
                    DialogResult re = MessageBox.Show("Bạn có chắc muốn xóa đĩa " + tam.Madia + " khỏi danh sách thuê?", "Xác nhận", MessageBoxButtons.YesNo);
                    if (re == DialogResult.Yes) //Đồng ý xóa
                    {
                        lstThue.Remove(tam);
                        LoadDataDgvDia(dgvDia, lstThue);
                        double? tongThue = lstThue.Sum(x => x.Giathue) + lstThueDat.Sum(x => x.Giathue);
                        tbxTongThue.Text = tongThue.ToString();
                    }
                }
                #endregion
            }
        }
        #endregion

        #region Xử lý khi số tiền trả nợ thay đổi
        private void tbxNoTra_TextChanged(object sender, EventArgs e)
        {
            double? tongNo = lstPhieuThue.Sum(x => x.Phitramuon);
            double? noTra = lstTraNo.Sum(x => x.Phitramuon);
            double? noConLai = tongNo - noTra;
            double? tongThue = lstThue.Sum(x => x.Giathue) + lstThueDat.Sum(x => x.Giathue);
            double? thanhTien = noTra + tongThue;
            tbxNoConLai.Text = noConLai.ToString();
            tbxThanhTien.Text = thanhTien.ToString();
        }
        #endregion

        #region Xử lý khi số tiền thuê thay đổi
        private void tbxTongThue_TextChanged(object sender, EventArgs e)
        {
            double? noTra = lstTraNo.Sum(x => x.Phitramuon);
            double? tongThue = lstThue.Sum(x => x.Giathue) + lstThueDat.Sum(x => x.Giathue);
            double? thanhTien = noTra + tongThue;
            tbxThanhTien.Text = thanhTien.ToString();
        }
        #endregion

        #region Xử lý nút xem chi tiết nợ
        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            eKhachHang thongtinkhachhang = new eKhachHang();
            thongtinkhachhang = busPT.layThongTinKhachHangTheoPhieu(kh.Makh);
            ChiTietTraMuon frmChiTiet = new ChiTietTraMuon(thongtinkhachhang);
            frmChiTiet.ShowDialog();
        }
        #endregion

        #region Xử lý chọn phí trả nợ
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
        #endregion

        #region Xử lý nút hủy thuê (Đặt lại form)
        private void btnHuy_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
        #endregion

        #region Xử lý nút thuê
        private void btnThue_Click(object sender, EventArgs e)
        {
            #region Lưu phiếu thuê mới
            busThue.LuuPhieuThueMoi(lstThueDat);
            busThue.LuuPhieuThueMoi(lstThue);
            #endregion

            #region Xử lý thanh toán nợ
            foreach (var item in lstTraNo)
            {
                busPT.updatePhiTraMuonCu(item.Maphieuthue);
            }
            #endregion

            #region Đưa form về trạng thái ban đầu
            ResetForm();
            #endregion
        }
        #endregion
        #endregion

        #region Các hàm hỗ trợ
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

        #region Tạo tiêu đề cho bảng đĩa thuê
        public DataTable CreatData_Dia()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đĩa");
            dt.Columns.Add("Tiêu đề");
            dt.Columns.Add("Ngày thuê");
            dt.Columns.Add("Ngày hẹn trả");
            dt.Columns.Add("Giá thuê");
            dt.Columns.Add("Loại thuê");
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

        #region Cập nhật dữ liệu bảng đĩa thuê
        void LoadDataDgvDia(DataGridView dgr, List<ePhieuThue> l)
        {
            dts_Dia.Clear();
            dts_Dia = CreatData_Dia();

            #region Thêm dữ liệu từ danh sách đặt
            foreach (var ept in lstThueDat)
            {
                eTieuDe td = busTieuDe.LayTieuDeTheoMaDia(ept.Madia);
                if (td != null)
                {
                    dts_Dia.Rows.Add(ept.Madia, td.TenTieuDe,
                                     String.Format("{0:dd/MM/yyyy}", ept.Ngaymuon),
                                     String.Format("{0:dd/MM/yyyy}", ept.Ngayhentra),
                                     ept.Giathue.ToString(), "Đặt trước");
                }

            }
            #endregion

            #region Thêm dữ liệu từ danh sách thuê
            foreach (ePhieuThue pt in l)
            {
                eTieuDe td = busTieuDe.LayTieuDeTheoMaDia(pt.Madia);
                if (td != null)
                {
                    dts_Dia.Rows.Add(pt.Madia, td.TenTieuDe, String.Format("{0:dd/MM/yyyy}", pt.Ngaymuon),
                                        String.Format("{0:dd/MM/yyyy}", pt.Ngayhentra),
                                        pt.Giathue.ToString(), "Thêm mới");
                }
            }
            #endregion

            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts_Dia;
        }
        #endregion

        #region Tạo phiếu thuê theo đĩa được cung cấp
        ePhieuThue phatSinhPhieuThueTheoDia(eDia dia)
        {
            eLoaiDia loai = busLoai.LayLoaiDiaTheoDia(dia);//Tìm loại của đĩa
            if (loai == null) //Không tìm được loại
            {
                return null;
            }
            else //Tìm được loại
            {
                ePhieuThue ept = new ePhieuThue()
                {
                    Maphieuthue = "",
                    Giathue = loai.giaThue,
                    Ngaymuon = DateTime.Now,
                    Ngayhentra = DateTime.Now.AddDays(loai.thoiGianThue),
                    Makhachhang = kh.Makh,
                    Madia = dia.Madia,
                    Trangthaithue = "Đang thuê",
                    Ngaytra = null,
                    Phitramuon = null,
                    Trangthaiphi = null
                };
                return ept;
            }
        }
        #endregion

        #region Thêm các phiếu thuê từ danh sách đặt
        void DanhSachThueDat(List<ePhieuDat> lstDat)
        {
            foreach (var item in lstDat)
            {
                eDia temp = busDIA.layDiaTheoMa(item.MaDia);
                if (temp != null)
                {
                    ePhieuThue ept = phatSinhPhieuThueTheoDia(temp);
                    if (ept != null)
                    {
                        lstThueDat.Add(ept);
                    }
                }
            }
        }
        #endregion

        #region Cập nhật lại các ô dữ liệu tiền cùng lúc
        void CapNhatTien()
        {
            double? tongNo = lstPhieuThue.Sum(x => x.Phitramuon);
            double? noTra = lstTraNo.Sum(x => x.Phitramuon);
            double? noConLai = tongNo - noTra;
            double? tongThue = lstThue.Sum(x => x.Giathue) + lstThueDat.Sum(x => x.Giathue);
            double? thanhTien = noTra + tongThue;
            tbxTongNo.Text = tongNo.ToString();
            tbxNoTra.Text = noTra.ToString();
            tbxNoConLai.Text = noConLai.ToString();
            tbxTongThue.Text = tongThue.ToString();
            tbxThanhTien.Text = thanhTien.ToString();
        }
        #endregion

        #region Đưa form về trạng thái ban đầu
        void ResetForm()
        {
            #region Khởi tạo lại các danh sách
            lstPhieuThue = new List<ePhieuThue>();
            lstTraNo = new List<ePhieuThue>();
            lstThue = new List<ePhieuThue>();
            lstThueDat = new List<ePhieuThue>();
            kh = new eKhachHang();
            #endregion

            #region Xóa dữ liệu trong các bảng
            LoadDataDgvDia(dgvDia, lstThue);
            LoadDataDgvPhi(dgvPhiTraMuon, lstPhieuThue);
            #endregion

            #region Xóa dữ liệu trong các ô dữ liệu
            tbxMaKH.Text = "";
            tbxTenKH.Text = "";
            tbxSDT.Text = "";
            tbxDiaChi.Text = "";
            tbxMaDia.Text = "";
            tbxNoTra.Text = "";
            tbxTongThue.Text = "";
            tbxTongNo.Text = "";
            tbxNoConLai.Text = "";
            tbxThanhTien.Text = "";
            #endregion

            #region Khóa các thành phần chưa dùng tới khi khởi tạo form
            splitContainer1.Panel2.Enabled = false;
            splitContainer3.Panel2.Enabled = false;
            #endregion
        }
        #endregion

        #endregion


    }
}
