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
using ENTITTY;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class DatTruoc : Form
    {
        List<eTieuDe> listTD;
        ePhieuDat dt;
        busPhieuDat busPD;
        busKhachHang busKH;
        private string maKH;
        public DatTruoc()
        {
            InitializeComponent();
            listTD = new List<eTieuDe>();
            dt = new ePhieuDat();
            busPD = new busPhieuDat();
            busKH = new busKhachHang();
            dtiNgayDat.Value = DateTime.Now;
            dtiNgayDat.Enabled = false;
            txbKH.Enabled = true;            
        }

        private void QuanLyDatTruoc_Load(object sender, EventArgs e)
        {
            dgvTieuDe.Columns.Clear();
            listTD = busPD.LayDanhSachTieuDeDuocDat();
            dgvTieuDe.DataSource = listTD;
            TaoTenCot();
            dgvTieuDe.ReadOnly = true;
        }

        private void btnDatTruoc_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txbKH.Text))
            {
                if (dgvTieuDe.SelectedRows.Count > 0)
                {
                    busPD = new busPhieuDat();
                    dt.MaPhieuDat = busPD.PhatSinhDatTruoc();
                    dt.NgayDat = dtiNgayDat.Value;
                    dt.TrangThai = "Đang đặt";
                    dt.MaKhachHang = txbKH.Text;
                    dt.MaTieuDe = dgvTieuDe.SelectedRows[0].Cells[0].Value.ToString();
                    dt.MaDia = null;
                    int trangThai = busPD.ThemDatTruoc(dt);
                    if (trangThai == 1)
                    {
                        MessageBox.Show("Thêm thành công");
                    }
                    else if (trangThai == 0)
                    {
                        MessageBox.Show("Thêm thất bại");
                    }
                    else if (trangThai == -1)
                    {
                        MessageBox.Show("Khách hàng đã đặt trước tiêu đề này rồi");

                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn tiêu đề cần đặt !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng thêm khách hàng cần đặt trước !");
            }
        }

        private void dgvTieuDe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void TaoTenCot()
        {
            dgvTieuDe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTieuDe.ReadOnly = true;
            dgvTieuDe.Columns["maTieuDe"].HeaderText = "Mã tiêu đề";
            dgvTieuDe.Columns["maTieuDe"].ReadOnly = true;
            dgvTieuDe.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgvTieuDe.Columns["tenTieuDe"].ReadOnly = true;
            dgvTieuDe.Columns["nhaSanXuat"].HeaderText = "Nhà sản xuất";
            dgvTieuDe.Columns["nhaSanXuat"].ReadOnly = true;
            dgvTieuDe.Columns["maLoaiDia"].HeaderText = "Loại đĩa";
            dgvTieuDe.Columns["maLoaiDia"].ReadOnly = true;
        }

    }
}
