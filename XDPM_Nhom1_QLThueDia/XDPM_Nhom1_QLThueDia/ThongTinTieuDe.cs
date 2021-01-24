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
    public partial class ThongTinTieuDe : Form
    {
        busTieuDe bustd;
        busLoaiDia busld;
        List<eTieuDe> listetdphim;
        List<eTieuDe> listetdgame;
        eTieuDe etd;
        public ThongTinTieuDe()
        {
            InitializeComponent();
            bustd = new busTieuDe();
            busld = new busLoaiDia();
        }
        void loadDataToGridview()
        {
            datagridTieuDeGame.DataSource = listetdgame;
            datagridTieuDeGame.Refresh();
            datagridTieuDePhim.DataSource = listetdphim;
            datagridTieuDePhim.Refresh();
            customGridview();
        }
        void customGridview()
        {
            datagridTieuDeGame.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridTieuDeGame.ReadOnly = true;
            datagridTieuDeGame.AutoResizeColumns();
            datagridTieuDeGame.Columns["MaTieuDe"].Visible = false;
            datagridTieuDeGame.Columns["TenTieuDe"].HeaderText = "Tên tiêu đề";
            datagridTieuDeGame.Columns["TenTieuDe"].Width = 500;
            datagridTieuDeGame.Columns["NhaSanXuat"].Visible = false;
            datagridTieuDeGame.Columns["MaLoaiDia"].Visible = false;
            datagridTieuDePhim.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridTieuDePhim.ReadOnly = true;
            datagridTieuDePhim.AutoResizeColumns();
            datagridTieuDePhim.Columns["MaTieuDe"].Visible = false;
            datagridTieuDePhim.Columns["TenTieuDe"].HeaderText = "Tên tiêu đề";
            datagridTieuDePhim.Columns["TenTieuDe"].Width = 500;
            datagridTieuDePhim.Columns["NhaSanXuat"].Visible = false;
            datagridTieuDePhim.Columns["MaLoaiDia"].Visible = false;
        }
        private void ThongTinTieuDe_Load(object sender, EventArgs e)
        {
            superTabControl1.SelectedTabIndex = 0;
            listetdgame = bustd.LayDanhSachTieuDeTheoLoaiDia("LD01");
            listetdphim = bustd.LayDanhSachTieuDeTheoLoaiDia("LD02");
            loadDataToGridview();
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }

        private void datagridTieuDeGame_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridTieuDeGame.SelectedRows.Count > 0)
            {
                etd = new eTieuDe();
                etd.MaTieuDe = datagridTieuDeGame.SelectedRows[0].Cells["MaTieuDe"].Value.ToString();
                etd.TenTieuDe = datagridTieuDeGame.SelectedRows[0].Cells["TenTieuDe"].Value.ToString();
                etd.NhaSanXuat = datagridTieuDeGame.SelectedRows[0].Cells["NhaSanXuat"].Value.ToString();
                etd.MaLoaiDia = datagridTieuDeGame.SelectedRows[0].Cells["MaLoaiDia"].Value.ToString();
            }
        }

        private void datagridTieuDePhim_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridTieuDePhim.SelectedRows.Count > 0)
            {
                etd = new eTieuDe();
                etd.MaTieuDe = datagridTieuDePhim.SelectedRows[0].Cells["MaTieuDe"].Value.ToString();
                etd.TenTieuDe = datagridTieuDePhim.SelectedRows[0].Cells["TenTieuDe"].Value.ToString();
                etd.NhaSanXuat = datagridTieuDePhim.SelectedRows[0].Cells["NhaSanXuat"].Value.ToString();
                etd.MaLoaiDia = datagridTieuDePhim.SelectedRows[0].Cells["MaLoaiDia"].Value.ToString();
            }
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            if (datagridTieuDeGame.SelectedRows.Count > 0 && etd != null)
            {
                lblMaTieuDe.Text = etd.MaTieuDe;
                lblTenTieuDe.Text = etd.TenTieuDe;
                lblNhaSanXuat.Text = etd.NhaSanXuat;
                lblMaLoaiDia.Text = busld.LayTenLoaiDiaTheoMaLoai(etd.MaLoaiDia);
            }
            else if (datagridTieuDePhim.SelectedRows.Count > 0 && etd != null)
            {
                lblMaTieuDe.Text = etd.MaTieuDe;
                lblTenTieuDe.Text = etd.TenTieuDe;
                lblNhaSanXuat.Text = etd.NhaSanXuat;
                lblMaLoaiDia.Text = busld.LayTenLoaiDiaTheoMaLoai(etd.MaLoaiDia);
            }
            else
            {
                MessageBox.Show("Chọn tiêu đề cần xem chi tiết!");
            }
        }

        private void superTabItem5_Click(object sender, EventArgs e)
        {
            etd = null;
            lblMaTieuDe.Text = "";
            lblTenTieuDe.Text = "";
            lblNhaSanXuat.Text = "";
            lblMaLoaiDia.Text = "";
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }

        private void superTabItem1_Click(object sender, EventArgs e)
        {
            etd = null;
            lblMaTieuDe.Text = "";
            lblTenTieuDe.Text = "";
            lblNhaSanXuat.Text = "";
            lblMaLoaiDia.Text = "";
            datagridTieuDeGame.ClearSelection();
            datagridTieuDePhim.ClearSelection();
        }
    }
}
