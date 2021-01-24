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
using BUS;
namespace XDPM_Nhom1_QLThueDia
{
    public partial class GanDia : Form
    {
        eDia diaGan;
        busPhieuDat busPD;
        busKhachHang busKh;
        busDia busD;
        busTieuDe busTD;
        DataTable dts;
        List<ePhieuDat> lstPhieuDatTheoDia;
        QuyTrinhTraDia frmTra;
        QuyTrinhXoaDat frmXDat;
        string tenFormGoi;
        public GanDia()
        {
            InitializeComponent();
        }
        public GanDia(QuyTrinhXoaDat frmMain, eDia dia)
        {
            InitializeComponent();
            frmXDat = frmMain;
            tenFormGoi = "QuyTrinhXoaDat";
            diaGan = new eDia();
            diaGan = dia;
        }
        public GanDia(QuyTrinhTraDia frmMain, eDia dia)
        {
            InitializeComponent();
            frmTra = frmMain;
            tenFormGoi = "QuyTrinhTraDia";
            diaGan = new eDia();
            diaGan = dia;
        }
        public DataTable CreatData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã phiếu đặt");
            dt.Columns.Add("Tiêu đề đặt");
            dt.Columns.Add("Khách hàng");
            dt.Columns.Add("Ngày đặt");
            return dt;
        }
        void LoadDataToDatagridview(DataGridView dgr, List<ePhieuDat> l)
        {
            dts.Clear();
            dts = CreatData();
            foreach (ePhieuDat pd in l)
            {

                dts.Rows.Add(pd.MaPhieuDat, busTD.layTieuDeTheoMaTieuDe(pd.MaTieuDe).TenTieuDe, busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Tenkh,
                    String.Format("{0:dd/MM/yyyy}", pd.NgayDat));
            }
            dgr.AllowUserToOrderColumns = true;
            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts;
        }
        private void GanDia_Load(object sender, EventArgs e)
        {
            tbxDiaChi.ReadOnly = true;
            tbxMaPhieu.ReadOnly = true;
            tbxNgayDat.ReadOnly = true;
            tbxSDT.ReadOnly = true;
            tbxTenKhachHang.ReadOnly = true;
            tbxTieuDeDat.ReadOnly = true;
            dts = new DataTable();
            busPD = new busPhieuDat();
            busKh = new busKhachHang();
            busD = new busDia();
            busTD = new busTieuDe();
            dataGridViewX1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewX1.ReadOnly = true;
            lstPhieuDatTheoDia = new List<ePhieuDat>();
            lstPhieuDatTheoDia = busPD.layDanhSachPhieuDatTheoDiaTra(diaGan.Matieude);
            if (lstPhieuDatTheoDia.Count == 0)
            {
                lblRong.Text = "Đĩa không có khách hàng đặt trước";
                btnBoQua.Visible = false;
            }
            else
            {
                LoadDataToDatagridview(dataGridViewX1, lstPhieuDatTheoDia);
                if (dataGridViewX1.Rows.Count > 0)
                {
                    dataGridViewX1.Rows[0].Selected = true;
                    string maphieudat = dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString();
                    ePhieuDat pd = busPD.layPhieuDatTheoMa(maphieudat);
                    tbxMaKhachHang.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Makh;
                    tbxTenKhachHang.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Tenkh;
                    tbxSDT.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Sodt;
                    tbxDiaChi.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Diachi;
                    tbxMaPhieu.Text = pd.MaPhieuDat;
                    tbxNgayDat.Text = String.Format("{0:dd/MM/yyyy}", pd.NgayDat);
                    tbxTieuDeDat.Text = busTD.layTieuDeTheoMaTieuDe(pd.MaTieuDe).TenTieuDe;
                }
                
                lblRong.Text = "Lưu ý: Danh sách đã được sắp xếp theo thời gian khách hàng đặt";
            }

        }

        private void dataGridViewX1_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            //if (dataGridViewX1.SelectedRows.Count > 0)
            //{
            //    string maphieudat = e.Row.Cells[0].Value.ToString();
            //    ePhieuDat pd = busPD.layPhieuDatTheoMa(maphieudat);
            //    tbxMaKhachHang.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Makh;
            //    tbxTenKhachHang.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Tenkh;
            //    tbxSDT.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Sodt;
            //    tbxDiaChi.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Diachi;
            //    tbxMaPhieu.Text = pd.MaPhieuDat;
            //    tbxNgayDat.Text = String.Format("{0:dd/MM/yyyy}", pd.NgayDat);
            //    tbxTieuDeDat.Text = busTD.layTieuDeTheoMaTieuDe(pd.MaTieuDe).TenTieuDe;
            //}
        }

        private void btnHoanTat_Click(object sender, EventArgs e)
        {
            if (lstPhieuDatTheoDia.Count > 0)
            {
                if (dataGridViewX1.SelectedRows.Count == 0)
                    MessageBox.Show("Vui lòng chọn khách hàng cần gán");
                else
                {
                    int kq = busPD.updateGanDiaChoPhieuDatTruoc(tbxMaPhieu.Text.ToString(), diaGan.Madia);
                    int kq2 = busD.updateTrangThaiDiaChoDatTruoc(diaGan.Madia);
                    if (kq == 1 && kq2 == 1)
                    {
                        MessageBox.Show("Đĩa đã được gán thành công cho khách hàng: " + tbxTenKhachHang.Text.ToString());
                        if (tenFormGoi.Equals("QuyTrinhTraDia"))
                        {
                            frmTra.ResetForm();
                        }
                        else
                        {
                            frmXDat.ResetForm();
                        }
                    }
                    else
                        MessageBox.Show("Gán đĩa thất bại");
                }
            }
            else
            {
                int kq = busD.updateTrangThaiDiaTra(diaGan.Madia);
                if (kq == 1)
                {
                    MessageBox.Show("Đĩa: " + diaGan.Madia + "đã được trả thành công");
                    if (tenFormGoi.Equals("QuyTrinhTraDia"))
                    {
                        frmTra.ResetForm();
                    }
                    else
                    {
                        frmXDat.ResetForm();
                    }
                }
                else
                    MessageBox.Show("Trả đĩa thất bại");
            }
        }
        void ResetData()
        {
            tbxDiaChi.Clear();
            tbxMaKhachHang.Clear();
            tbxMaPhieu.Clear();
            tbxNgayDat.Clear();
            tbxSDT.Clear();
            tbxTenKhachHang.Clear();
            tbxTieuDeDat.Clear();
        }

        private void btnBoQua_Click(object sender, EventArgs e)
        {
            if (dataGridViewX1.SelectedRows.Count == 0)
                MessageBox.Show("Vui lòng chọn phiếu đặt");
            else
            {
                int kq = busPD.xoaDatTruoc(tbxMaPhieu.Text.ToString());
                if (kq == 1)
                {
                    ResetData();
                    lstPhieuDatTheoDia = busPD.layDanhSachPhieuDatTheoDiaTra(diaGan.Matieude);
                    if (lstPhieuDatTheoDia.Count == 0)
                    {
                        dts.Clear();
                        lblRong.Text = "Đĩa không có khách hàng đặt trước";
                        btnBoQua.Visible = false;
                    }
                    else
                    {
                        LoadDataToDatagridview(dataGridViewX1, lstPhieuDatTheoDia);
                        if (dataGridViewX1.Rows.Count > 0)
                        {
                            dataGridViewX1.Rows[0].Selected = true;
                            string maphieudat = dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString();
                            ePhieuDat pd = busPD.layPhieuDatTheoMa(maphieudat);
                            tbxMaKhachHang.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Makh;
                            tbxTenKhachHang.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Tenkh;
                            tbxSDT.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Sodt;
                            tbxDiaChi.Text = busKh.layKhachHangTheoMaKhachHang(pd.MaKhachHang).Diachi;
                            tbxMaPhieu.Text = pd.MaPhieuDat;
                            tbxNgayDat.Text = String.Format("{0:dd/MM/yyyy}", pd.NgayDat);
                            tbxTieuDeDat.Text = busTD.layTieuDeTheoMaTieuDe(pd.MaTieuDe).TenTieuDe;
                        }
                        lblRong.Text = "Lưu ý: Danh sách đã được sắp xếp theo thời gian khách hàng đặt";
                    }
                }

            }
        }
    }
}
