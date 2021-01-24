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
    public partial class XoaDatTruoc : Form
    {
        busPhieuDat busPD;
        busDia busDia;
        List<ePhieuDat> listPD;
        List<eKhachHang> listKH;
        private string maKH;
        public eDia dia;
        QuyTrinhXoaDat main;
        public XoaDatTruoc(QuyTrinhXoaDat frmMain)
        {
            InitializeComponent();
            main = frmMain;
        }

        public XoaDatTruoc()
        {
            InitializeComponent();
           
        }

        private void btnXoaDatTruoc_Click(object sender, EventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                if (dgvKhachHang.SelectedRows.Count > 0)
                {
                    maKH = dgvKhachHang.CurrentRow.Cells["makh"].Value.ToString();
                    dia = new eDia();
                    dia = busPD.layDiaGanDatTruoc(dgvTieuDe.CurrentRow.Cells["maPhieuDat"].Value.ToString());
                    if (busPD.XoaDatTruoc(dgvTieuDe.CurrentRow.Cells["maPhieuDat"].Value.ToString()))
                    {
                        MessageBox.Show("Xóa thành công");
                        if (dia == null)
                        {
                            dgvKhachHang.Columns.Clear();
                            listKH = busPD.layDanhSachKhachHangDaDatTruoc();
                            dgvKhachHang.DataSource = listKH;
                            TaoTenCotChoKhachHang();
                            dgvTieuDe.Columns.Clear();
                            listPD = busPD.LayDanhSachDatTruocCuaKhach(maKH);
                            dgvTieuDe.DataSource = listPD;
                            TaoTenCotChoTieuDe();
                        }
                        else
                        {
                            busDia.updateTrangThaiDiaTra(dia.Madia);
                            main.GoNext();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại");

                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tiều đề cần xóa !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xóa !");
            }
        }

        private void XoaDatTruoc_Load(object sender, EventArgs e)
        {
            busPD = new busPhieuDat();
            listKH = new List<eKhachHang>();
            listPD = new List<ePhieuDat>();
            busDia = new busDia();
            dgvKhachHang.Columns.Clear();
            listKH = busPD.layDanhSachKhachHangDaDatTruoc();
            dgvKhachHang.DataSource = listKH;
            TaoTenCotChoKhachHang();
        }
        private void TaoTenCotChoTieuDe()
        {
            dgvTieuDe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTieuDe.ReadOnly = true;
            dgvTieuDe.Columns["maPhieuDat"].HeaderText = "Mã phiếu đặt";
            dgvTieuDe.Columns["ngayDat"].HeaderText = "Ngày đặt";
            dgvTieuDe.Columns["maTieuDe"].HeaderText = "Tên tiêu đề";
            dgvTieuDe.Columns["maDia"].HeaderText = "Mã đĩa";
            dgvTieuDe.Columns["trangThai"].HeaderText = "Trạng thái";
            dgvTieuDe.Columns["maKhachHang"].Visible = false;
        }
        private void TaoTenCotChoKhachHang()
        {
            dgvKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhachHang.ReadOnly = true;
            dgvKhachHang.Columns["makh"].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns["tenkh"].HeaderText = "Họ tên";
            dgvKhachHang.Columns["diachi"].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns["sodt"].HeaderText = "Số điện thoại";
        }

        private void dgvKhachHang_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                dgvTieuDe.Columns.Clear();
                listPD = busPD.LayDanhSachDatTruocCuaKhach(dgvKhachHang.SelectedRows[0].Cells["makh"].Value.ToString());
                dgvTieuDe.DataSource = listPD;
                TaoTenCotChoTieuDe();
            }

        }
    }
}
