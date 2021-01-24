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
    public partial class ThongKeDiaDangThue : Form
    {
        busThongKeTheoKhachHang busTKKH;
        List<eThongKeDiaDangThue> listTK;
        public ThongKeDiaDangThue()
        {
            InitializeComponent();
            listTK = new List<eThongKeDiaDangThue>();
            busTKKH = new busThongKeTheoKhachHang();
          
        }

        private void TaoSTT()
        {
            dgvDiaDangThue.Columns.Add("STT", "STT");
        }
        private void TaoTenCot()
        {
            //for (int i = 0; i < listTK.Count; i++)
            //{
            //    dgvDiaDangThue.Rows[i].Cells[0].Value = i + 1;
            //}
            dgvDiaDangThue.Columns["maKhachHang"].HeaderText = "Mã khách hàng";
            dgvDiaDangThue.Columns["hoTen"].HeaderText = "Họ tên";
            dgvDiaDangThue.Columns["diaChi"].HeaderText = "Địa chỉ";
            dgvDiaDangThue.Columns["sDT"].HeaderText = "Số điện thoại";
            dgvDiaDangThue.Columns["soLuong"].HeaderText = "Số lượng đĩa đang thuê";
        }

        private void ThongKeDiaDangThue_Load(object sender, EventArgs e)
        {
            listTK = busTKKH.ThongKeDiaDangThue(); ;
            if (listTK.Count > 0)
            {
                dgvDiaDangThue.Columns.Clear();
                //TaoSTT();
                dgvDiaDangThue.DataSource = listTK;
                TaoTenCot();
            }
            else
            {
                dgvDiaDangThue.Columns.Clear();
                MessageBox.Show("Khách hàng trống");
            }
        }
    }
}
