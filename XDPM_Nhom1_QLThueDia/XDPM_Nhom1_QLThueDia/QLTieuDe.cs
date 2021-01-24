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
    public partial class QLTieuDe : Form
    {
        DataTable dts;
        busTieuDe busTD;
        busLoaiDia busLoai;
        busDia busD;
        List<eTieuDe> lst;
        public QLTieuDe()
        {
            InitializeComponent();
        }

        private void QLTieuDe_Load(object sender, EventArgs e)
        {
            busTD = new busTieuDe();
            busLoai = new busLoaiDia();
            busD = new busDia();
            dts = new DataTable();
            lst = busTD.LayToanBoTieuDe();
            LoadDataDgvTieuDe();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemTieuDe frmThemTieuDe = new ThemTieuDe();
            frmThemTieuDe.ShowDialog();
            lst = busTD.LayToanBoTieuDe();
            LoadDataDgvTieuDe();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvTieuDe.SelectedRows.Count > 0)
            {
                string maTieuDe = dgvTieuDe.SelectedRows[0].Cells[0].Value.ToString();
                if (busD.layDiaDangThueCuaTieuDe(maTieuDe).Count > 0)
                {
                    MessageBox.Show("Tiêu đề có đĩa đang được thuê hoặc đã đặt không thể xóa!");
                }
                else
                {
                    DialogResult result = MessageBox.Show("Việc xóa tiêu đề sẽ kèm theo việc xóa các đĩa và thông tin có liên quan," +
                        " bạn có chắc muốn xóa tiêu đề này? ", "Xác nhận", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        busTD.XoaTieuDe(maTieuDe);
                        lst = busTD.LayToanBoTieuDe();
                        LoadDataDgvTieuDe();
                    }
                }
            }
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

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void groupPanel1_Click(object sender, EventArgs e)
        {

        }

        private void dgvTieuDe_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
