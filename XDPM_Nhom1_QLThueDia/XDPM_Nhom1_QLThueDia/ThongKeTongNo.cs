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
    public partial class ThongKeTongNo : Form
    {
        busThongKeTheoKhachHang busTKKH;
        List<eThongKeNoCuaKhachHang> listTK;
        List<eKhachHang> listKH;
        public ThongKeTongNo()
        {
            InitializeComponent();
            listTK = new List<eThongKeNoCuaKhachHang>();
            busTKKH = new busThongKeTheoKhachHang();
            listKH = new List<eKhachHang>();
            
        }

        private void TaoSTTChoNo()
        {
            dgvThongTinNo.Columns.Add("STT", "STT");
        }
        private void TaoSTTChoKhach()
        {
            dgvKhachHang.Columns.Add("STT", "STT");
        }
        private void TaoTenCotChoThongTinNo()
        {
            for (int i = 0; i < listTK.Count; i++)
            {
                dgvThongTinNo.Rows[i].Cells[0].Value = i + 1;
            }
            dgvThongTinNo.Columns["tenTieuDe"].HeaderText = "Tiêu đề";
            dgvThongTinNo.Columns["tenDia"].HeaderText = "Tên đĩa";
            dgvThongTinNo.Columns["ngayHenTra"].HeaderText = "Ngày hẹn trả";
            dgvThongTinNo.Columns["ngayTra"].HeaderText = "Ngày trả";
            dgvThongTinNo.Columns["phiTraMuon"].HeaderText = "Phí trả muộn";
        }
        private void TaoTenCotChoKhachHang()
        {
            //for (int i = 0; i < listKH.Count; i++)
            //{
            //    dgvKhachHang.Rows[i].Cells[0].Value = i + 1;
            //}
            dgvKhachHang.Columns["makh"].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns["tenkh"].HeaderText = "Họ tên";
            dgvKhachHang.Columns["diachi"].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns["sodt"].HeaderText = "Số điện thoại";
        }

        private void dgvKhachHang_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (dgvKhachHang.SelectedRows.Count > 0)
            {
                listTK = busTKKH.ThongKeNoCuaKhachHang(dgvKhachHang.SelectedRows[0].Cells["makh"].Value.ToString());
                dgvThongTinNo.Columns.Clear();
                TaoSTTChoNo();
                dgvThongTinNo.DataSource = listTK;
                TaoTenCotChoThongTinNo();
                double tongNo=0.0;
                for(int i = 0; i<listTK.Count; i++)
                {
                    tongNo += listTK[i].phiTraMuon;
                }
                lblTongNo.Text = string.Format("{0:#,##0}", tongNo) + " VNĐ";
            }
        }

        private void ThongKeTongNo_Load(object sender, EventArgs e)
        {
            listKH = new List<eKhachHang>();
            listKH = busTKKH.LayDanhSachKhachHangNo();
           
            if (listKH.Count > 0)
            {
                dgvKhachHang.Columns.Clear();
                //TaoSTTChoKhach();
                dgvKhachHang.DataSource = listKH;               
                TaoTenCotChoKhachHang();
            }
            else
            {
                dgvThongTinNo.Columns.Clear();
                MessageBox.Show("Khách hàng trống");
            }
        }
    }
}
