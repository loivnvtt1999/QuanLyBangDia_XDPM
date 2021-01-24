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
    public partial class ThemTieuDe : Form
    {
        busTieuDe busTD;
        busLoaiDia busLoai;
        List<eLoaiDia> lstLoai;

        public ThemTieuDe()
        {
            InitializeComponent();
        }

        private void ThemTieuDe_Load(object sender, EventArgs e)
        {
            busTD = new busTieuDe();
            busLoai = new busLoaiDia();
            lstLoai = busLoai.layDanhSachLoaiDia();
            cboLoai.DataSource = lstLoai;
            cboLoai.DisplayMember = "TenLoai";
            cboLoai.ValueMember = "MaLoai";
            cboLoai.SelectedIndex = 0;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(tbxTen.Text) && !String.IsNullOrWhiteSpace(tbxTen.Text) &&
                !String.IsNullOrEmpty(tbxNSX.Text) && !String.IsNullOrWhiteSpace(tbxNSX.Text))
            {
                eTieuDe td = new eTieuDe()
                {
                    MaTieuDe = "",
                    TenTieuDe = tbxTen.Text,
                    NhaSanXuat = tbxNSX.Text,
                    MaLoaiDia = cboLoai.SelectedValue.ToString()
                };
                busTD.ThemTieuDe(td);
                MessageBox.Show("Đã thêm!");
                Close();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
            }
        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void cboLoai_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tbxTen_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbxNSX_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
