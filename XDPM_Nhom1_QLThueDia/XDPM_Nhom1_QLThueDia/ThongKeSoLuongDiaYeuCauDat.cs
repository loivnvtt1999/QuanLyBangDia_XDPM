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
    public partial class ThongKeSoLuongDiaYeuCauDat : Form
    {
        busTieuDe bustd;
        busLoaiDia busld;
        List<eTieuDe> listetdphim;
        List<eTieuDe> listetdgame;
        eTieuDe etd;
        eThongKeYeuCauDat etk;
        busPhieuDat buspd;
        public ThongKeSoLuongDiaYeuCauDat()
        {
            InitializeComponent();
            bustd = new busTieuDe();
            busld = new busLoaiDia();
            buspd = new busPhieuDat();
        }
        void loadDataToGridview()
        {
            datagridTieuDeGame.DataSource = listetdgame;
            datagridTieuDeGame.Refresh();
            datagridTieuDePhim.DataSource = listetdphim;
            datagridTieuDePhim.Refresh();
        }
        void customGridview()
        {
            datagridTieuDeGame.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridTieuDeGame.ReadOnly = true;
            datagridTieuDeGame.AutoResizeColumns();
            datagridTieuDeGame.Columns["maTieuDe"].Visible = false;
            datagridTieuDeGame.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            datagridTieuDeGame.Columns["tenTieuDe"].Width = 500;
            datagridTieuDeGame.Columns["nhaSanXuat"].Visible = false;
            datagridTieuDeGame.Columns["maLoaiDia"].Visible = false;
            datagridTieuDePhim.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridTieuDePhim.ReadOnly = true;
            datagridTieuDePhim.AutoResizeColumns();
            datagridTieuDePhim.Columns["maTieuDe"].Visible = false;
            datagridTieuDePhim.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            datagridTieuDePhim.Columns["tenTieuDe"].Width = 500;
            datagridTieuDePhim.Columns["nhaSanXuat"].Visible = false;
            datagridTieuDePhim.Columns["maLoaiDia"].Visible = false;
        }
        private void ThongKeSoLuongDiaYeuCauDat_Load(object sender, EventArgs e)
        {
            superTabControl1.SelectedTabIndex = 0;
            listetdgame = bustd.LayDanhSachTieuDeTheoLoaiDia("LD01");
            listetdphim = bustd.LayDanhSachTieuDeTheoLoaiDia("LD02");
            loadDataToGridview();
            customGridview();
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }

        private void btnXemSoLuong_Click(object sender, EventArgs e)
        {
            if (datagridTieuDeGame.SelectedRows.Count > 0 && etd != null)
            {
                lblTenTieuDe.Text = etd.TenTieuDe;
                lblTongSoLuongDia.Text = etk.TongSoLuongDia.ToString();
                lblSoLuongYeuCauDat.Text = etk.SoLuongYeuCau.ToString();
                lblSoLuongDaDuocDat.Text = etk.SoLuongDiaDaDuocDat.ToString();
                lblSoLuongChuaDuocDat.Text = etk.SoLuongDiaChuaDuocDat.ToString();
            }
            else if (datagridTieuDePhim.SelectedRows.Count > 0 && etd != null)
            {
                lblTenTieuDe.Text = etd.TenTieuDe;
                lblTongSoLuongDia.Text = etk.TongSoLuongDia.ToString();
                lblSoLuongYeuCauDat.Text = etk.SoLuongYeuCau.ToString();
                lblSoLuongDaDuocDat.Text = etk.SoLuongDiaDaDuocDat.ToString();
                lblSoLuongChuaDuocDat.Text = etk.SoLuongDiaChuaDuocDat.ToString();
            }
            else
            {
                MessageBox.Show("Chọn tiêu đề cần xem yêu cầu!");
            }
        }

        private void datagridTieuDeGame_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridTieuDeGame.SelectedRows.Count > 0)
            {
                etd = new eTieuDe();
                etd.MaTieuDe = datagridTieuDeGame.SelectedRows[0].Cells["maTieuDe"].Value.ToString();
                etd.TenTieuDe = datagridTieuDeGame.SelectedRows[0].Cells["tenTieuDe"].Value.ToString();
                etd.NhaSanXuat = datagridTieuDeGame.SelectedRows[0].Cells["nhaSanXuat"].Value.ToString();
                etd.MaLoaiDia = datagridTieuDeGame.SelectedRows[0].Cells["maLoaiDia"].Value.ToString();
                etk = buspd.ThongKeSoLuongDiaYeuCauDat(etd);
                lblTenTieuDe.Text = "";
                lblTongSoLuongDia.Text = "";
                lblSoLuongYeuCauDat.Text = "";
                lblSoLuongDaDuocDat.Text = "";
                lblSoLuongChuaDuocDat.Text = "";
            }
        }

        private void datagridTieuDePhim_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridTieuDePhim.SelectedRows.Count > 0)
            {
                etd = new eTieuDe();
                etd.MaTieuDe = datagridTieuDePhim.SelectedRows[0].Cells["maTieuDe"].Value.ToString();
                etd.TenTieuDe = datagridTieuDePhim.SelectedRows[0].Cells["tenTieuDe"].Value.ToString();
                etd.NhaSanXuat = datagridTieuDePhim.SelectedRows[0].Cells["nhaSanXuat"].Value.ToString();
                etd.MaLoaiDia = datagridTieuDePhim.SelectedRows[0].Cells["maLoaiDia"].Value.ToString();
                etk = buspd.ThongKeSoLuongDiaYeuCauDat(etd);
                lblTenTieuDe.Text = "";
                lblTongSoLuongDia.Text = "";
                lblSoLuongYeuCauDat.Text = "";
                lblSoLuongDaDuocDat.Text = "";
                lblSoLuongChuaDuocDat.Text = "";
            }
        }

        private void superTabItem1_Click(object sender, EventArgs e)
        {
            etd = null;
            lblTenTieuDe.Text = "";
            lblTongSoLuongDia.Text = "";
            lblSoLuongYeuCauDat.Text = "";
            lblSoLuongDaDuocDat.Text = "";
            lblSoLuongChuaDuocDat.Text = "";
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }

        private void superTabItem5_Click(object sender, EventArgs e)
        {
            etd = null;
            lblTenTieuDe.Text = "";
            lblTongSoLuongDia.Text = "";
            lblSoLuongYeuCauDat.Text = "";
            lblSoLuongDaDuocDat.Text = "";
            lblSoLuongChuaDuocDat.Text = "";
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }
    }
}
