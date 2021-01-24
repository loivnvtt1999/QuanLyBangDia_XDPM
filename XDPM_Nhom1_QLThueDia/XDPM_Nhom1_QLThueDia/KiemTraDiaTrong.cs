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
    public partial class KiemTraDiaTrong : Form
    {
        busTieuDe busTD;
        List<eTieuDe> listTD;
        public KiemTraDiaTrong()
        {
            InitializeComponent();
            busTD = new busTieuDe();
            listTD = new List<eTieuDe>();
            
        }

        private void groupPanel3_Click(object sender, EventArgs e)
        {

        }

        private void btnTim_Click(object sender, EventArgs e)
        {           
            
        }

        private void btnKiemTra_Click(object sender, EventArgs e)
        {
            if (dgvTieuDe.SelectedRows.Count > 0)
            {
                int soLuong = busTD.KiemTraDiaTrongTieuDe(dgvTieuDe.SelectedRows[0].Cells["maTieuDe"].Value.ToString());
                if (soLuong > 0)
                {
                    MessageBox.Show("Có " + soLuong + " đĩa còn trống.");
                }
                else
                {
                    MessageBox.Show("Không có đĩa trống !");
                }
            }
            else
            {
                MessageBox.Show("Chưa có tiêu đề nào được chọn !");
            }
        }
        

        private void KiemTraDiaTrong_Load(object sender, EventArgs e)
        {
            dgvTieuDe.Columns.Clear();
            TaoSTT();
            listTD = busTD.LayDanhSachieuDe();
            dgvTieuDe.DataSource = listTD;
            TaoTenCot();
        }
        private void TaoSTT()
        {
            dgvTieuDe.Columns.Add("STT", "STT");
        }
        private void TaoTenCot()
        {
            dgvTieuDe.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTieuDe.ReadOnly = true;
            for (int i = 0; i < listTD.Count; i++)
            {
                dgvTieuDe.Rows[i].Cells[0].Value = i + 1;
            }
            dgvTieuDe.Columns["maTieuDe"].HeaderText = " Mã tiêu đề";
            dgvTieuDe.Columns["tenTieuDe"].HeaderText = "Tên tiêu đề";
            dgvTieuDe.Columns["nhaSanXuat"].HeaderText = "Nhà sản xuất";
            dgvTieuDe.Columns["maLoaiDia"].HeaderText = "Loại đĩa";
        }

        private void tbxTimKiemTheoTen_TextChanged(object sender, EventArgs e)
        {
                dgvTieuDe.Columns.Clear();
                listTD = busTD.TimKiemTieuDeTheoTen(tbxTimKiemTheoTen.Text);
                    TaoSTT();
                    dgvTieuDe.DataSource = listTD;
                    TaoTenCot();
        }
    }
}
