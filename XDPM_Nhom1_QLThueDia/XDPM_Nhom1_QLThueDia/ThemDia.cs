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
    public partial class ThemDia : Form
    {
        DataTable dts;
        busTieuDe busTD;
        busLoaiDia busLoai;
        busDia busD;
        List<eTieuDe> lst;
        eTieuDe tdChon;
        public ThemDia()
        {
            InitializeComponent();
        }

        private void ThemDia_Load(object sender, EventArgs e)
        {
            busTD = new busTieuDe();
            busLoai = new busLoaiDia();
            busD = new busDia();
            dts = new DataTable();
            lst = busTD.LayToanBoTieuDe();
            tdChon = new eTieuDe();
            LoadDataDgvTieuDe();
        }

        private void tbxLoc_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxLoc.Text) && !String.IsNullOrWhiteSpace(tbxLoc.Text))
            {
                lst = busTD.LayTieuDeCoTen(tbxLoc.Text);
                LoadDataDgvTieuDe();
            }
            else
            {
                lst = busTD.LayToanBoTieuDe();
                LoadDataDgvTieuDe();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxDia.Text) && !String.IsNullOrWhiteSpace(tbxDia.Text))
            {
                eDia dia = new eDia()
                {
                    Madia = "",
                    Matieude = tdChon.MaTieuDe,
                    Tendia = tbxTen.Text + tbxDia.Text,
                    Trangthaidia = tbxTrangThai.Text
                };
                busD.ThemDia(dia);
                MessageBox.Show("Thêm thành công!");
                Close();
            }
            else
            {
                MessageBox.Show("Cần nhập thêm đuôi cho tên đĩa để phân biệt với tiêu đề!");
                tbxDia.Focus();
            }
        }


        #region Tạo tiêu đề cho bảng phí nợ
        public DataTable CreatData_TieuDe()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã tiêu đề");
            dt.Columns.Add("Tên tiêu đề");
            dt.Columns.Add("Nhà sản xuất");
            dt.Columns.Add("Loại đĩa");
            return dt;
        }
        #endregion

        #region Cập nhật dữ liệu bảng phí nợ
        void LoadDataDgvTieuDe()
        {
            dts.Clear();
            dts = CreatData_TieuDe();

            foreach (eTieuDe td in lst)
            {
                dts.Rows.Add(td.MaTieuDe, td.TenTieuDe, td.MaLoaiDia, busLoai.LayLoaiDiaTheoMa(td.MaLoaiDia).tenLoai);
            }
            dgvTieuDe.AllowUserToAddRows = false;
            dgvTieuDe.DataSource = dts;
        }
        #endregion

        private void dgvTieuDe_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvTieuDe.SelectedRows.Count > 0)
            {
                string maTieuDe = dgvTieuDe.SelectedRows[0].Cells[0].Value.ToString();
                tdChon = busTD.LayTieuDeTheoMa(maTieuDe);
                tbxTenTieuDe.Text = tdChon.TenTieuDe;
                tbxTen.Text = tdChon.TenTieuDe;
            }
        }
    }
}
