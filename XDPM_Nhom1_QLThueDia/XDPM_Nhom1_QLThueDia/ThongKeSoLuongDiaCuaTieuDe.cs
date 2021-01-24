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
    public partial class ThongKeSoLuongDiaCuaTieuDe : Form
    {
        busTieuDe bustd;
        busLoaiDia busld;
        List<eTieuDe> listetdphim;
        List<eTieuDe> listetdgame;
        eTieuDe etd;
        eThongKeSLDia etk;
        busDia busdia;
        public ThongKeSoLuongDiaCuaTieuDe()
        {
            InitializeComponent();
            bustd = new busTieuDe();
            busld = new busLoaiDia();
            busdia = new busDia();
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
        private void ThongKeSoLuongDiaCuaTieuDe_Load(object sender, EventArgs e)
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
                lblTongSoLuongDia.Text = etk.TongSoLuong.ToString();
                lblSoLuongDaDuocThue.Text = etk.SoLuongDaThue.ToString();
                lblSoLuongDatTruoc.Text = etk.SoLuongDaDatTruoc.ToString();
                lblSoLuongSanSang.Text = etk.SoLuongSanSang.ToString();
            }
            else if (datagridTieuDePhim.SelectedRows.Count > 0 && etd != null)
            {
                lblTenTieuDe.Text = etd.TenTieuDe;
                lblTongSoLuongDia.Text = etk.TongSoLuong.ToString();
                lblSoLuongDaDuocThue.Text = etk.SoLuongDaThue.ToString();
                lblSoLuongDatTruoc.Text = etk.SoLuongDaDatTruoc.ToString();
                lblSoLuongSanSang.Text = etk.SoLuongSanSang.ToString();
            }
            else
            {
                MessageBox.Show("Chọn tiêu đề cần xem số lượng!");
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
                etk = busdia.ThongKeSoLuongDiaTheoTinhTrang(etd);
                lblTenTieuDe.Text = "";
                lblTongSoLuongDia.Text = "";
                lblSoLuongDaDuocThue.Text = "";
                lblSoLuongDatTruoc.Text = "";
                lblSoLuongSanSang.Text = "";
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
                etk = busdia.ThongKeSoLuongDiaTheoTinhTrang(etd);
                lblTenTieuDe.Text = "";
                lblTongSoLuongDia.Text = "";
                lblSoLuongDaDuocThue.Text = "";
                lblSoLuongDatTruoc.Text = "";
                lblSoLuongSanSang.Text = "";
            }
        }
        private void superTabItem1_Click(object sender, EventArgs e)
        {
            etd = null;
            lblTenTieuDe.Text = "";
            lblTongSoLuongDia.Text = "";
            lblSoLuongDaDuocThue.Text = "";
            lblSoLuongDatTruoc.Text = "";
            lblSoLuongSanSang.Text = "";
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }

        private void superTabItem5_Click(object sender, EventArgs e)
        {
            etd = null;
            lblTenTieuDe.Text = "";
            lblTongSoLuongDia.Text = "";
            lblSoLuongDaDuocThue.Text = "";
            lblSoLuongDatTruoc.Text = "";
            lblSoLuongSanSang.Text = "";
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }

        private void superTabControl1_Click(object sender, EventArgs e)
        {

        }

        private void datagridTieuDeGame_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
