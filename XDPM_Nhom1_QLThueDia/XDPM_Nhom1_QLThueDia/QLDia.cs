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
    public partial class QLDia : Form
    {
        busDia busD;
        busTieuDe busTD;
        List<eDia> lst;
        DataTable dts;
        public QLDia()
        {
            InitializeComponent();
        }

        private void QLDia_Load(object sender, EventArgs e)
        {
            busD = new busDia();
            busTD = new busTieuDe();
            lst = new List<eDia>();
            dts = new DataTable();

            lst = busD.layToanBoDiaChoQLDia();
            LoadDataDgvDia();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemDia frmThemTieuDe = new ThemDia();
            frmThemTieuDe.ShowDialog();
            lst = busD.layToanBoDiaChoQLDia();
            LoadDataDgvDia();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDia.SelectedRows.Count > 0)
            {
                string maDia = dgvDia.SelectedRows[0].Cells[0].Value.ToString();
                DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa đĩa này? ", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (busD.XoaDia(maDia) == 1)
                    {
                        lst = busD.layToanBoDiaChoQLDia();
                        LoadDataDgvDia();
                    }
                    else
                    {
                        MessageBox.Show("Đĩa đang được thuê hoặc đã đặt không thể xóa");
                    }
                }
            }
        }

        private void tbxLoc_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxLoc.Text) && !String.IsNullOrWhiteSpace(tbxLoc.Text))
            {
                lst = busD.LayDiaCoTen(tbxLoc.Text);
                LoadDataDgvDia();
            }
            else
            {
                lst = busD.layToanBoDiaChoQLDia ();
                LoadDataDgvDia();
            }
        }

        #region Tạo tiêu đề cho bảng phí nợ
        public DataTable CreatData_Dia()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đĩa");
            dt.Columns.Add("Tên đĩa");
            dt.Columns.Add("Trạng thái");
            dt.Columns.Add("Tiêu đề");
            return dt;
        }
        #endregion

        #region Cập nhật dữ liệu bảng phí nợ
        void LoadDataDgvDia()
        {
            dts.Clear();
            dts = CreatData_Dia();

            foreach (eDia d in lst)
            {
                dts.Rows.Add(d.Madia, d.Tendia, d.Trangthaidia, busTD.LayTieuDeTheoMaDia(d.Madia).TenTieuDe);
            }
            dgvDia.AllowUserToAddRows = false;
            dgvDia.DataSource = dts;
        }
        #endregion

    }
}
