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
    public partial class ThongKeDiaTraTre : Form
    {
        busThongKeTheoKhachHang busTKKH;
        List<eThongKeDiaTraTre> listTK;
        public ThongKeDiaTraTre()
        {
            InitializeComponent();
            listTK = new List<eThongKeDiaTraTre>();
            busTKKH = new busThongKeTheoKhachHang();
        }
        private void TaoSTT()
        {
            dgvDiaTraTre.Columns.Add("STT", "STT");
        }
        private void TaoTenCot()
        {
            //for (int i = 0; i < listTK.Count; i++)
            //{
            //    dgvDiaTraTre.Rows[i].Cells[0].Value = i + 1;
            //}
            dgvDiaTraTre.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgvDiaTraTre.Columns["hoTen"].HeaderText = "Họ tên";
            dgvDiaTraTre.Columns["diaChi"].HeaderText = "Địa chỉ";
            dgvDiaTraTre.Columns["sDT"].HeaderText = "Số điện thoại";
            dgvDiaTraTre.Columns["tenTieuDe"].HeaderText = "Tiều đề";
            dgvDiaTraTre.Columns["tenDia"].HeaderText = "Tên đĩa";
            dgvDiaTraTre.Columns["ngayHenTra"].HeaderText = "Ngày hẹn trả";
        }

        private void ThongKeDiaTraTre_Load(object sender, EventArgs e)
        {
            listTK = busTKKH.ThongKeDiaTraTre(); ;
            if (listTK.Count > 0)
            {
                dgvDiaTraTre.Columns.Clear();
                //TaoSTT();
                dgvDiaTraTre.DataSource = listTK;
                TaoTenCot();
            }
            else
            {
                dgvDiaTraTre.Columns.Clear();
                MessageBox.Show("Khách hàng trống");
            }
        }
    }
}
