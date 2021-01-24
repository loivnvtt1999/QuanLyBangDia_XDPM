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
using DevComponents.DotNetBar.Controls;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class XemThongTinKhachHang : Form
    {
        busThongKeTheoKhachHang busTKKH;
        List<eKhachHang> listKH;
        public XemThongTinKhachHang()
        {
            InitializeComponent();
        }

        private void XemThongTinKhachHang_Load(object sender, EventArgs e)
        {
            cboLoaiKhachHang.Items.Add("Tất cả khách hàng");//loai=0
            cboLoaiKhachHang.Items.Add("Khách hàng có mặt hàng quá hạn");//loai=1
            cboLoaiKhachHang.Items.Add("Khách hàng có phí trả muộn");//loai=2
            cboLoaiKhachHang.Text = "Chọn loại";
            cboLoaiKhachHang.DropDownStyle = ComboBoxStyle.DropDownList;
            busTKKH = new busThongKeTheoKhachHang();
            listKH = new List<eKhachHang>();
           
        }

        private void cboLoaiKhachHang_SelectedIndexChanged(object sender, EventArgs e)
        {            
            if(cboLoaiKhachHang.Text== "Tất cả khách hàng")
            {
                listKH= busTKKH.XemThongTinKhachHang(0); ;
                if (listKH.Count > 0)
                {
                    dgvKhachHang.Columns.Clear();
                    TaoSTT();
                    dgvKhachHang.DataSource = listKH;
                    TaoTenCot();
                }
                else
                {
                    dgvKhachHang.Columns.Clear();
                    MessageBox.Show("Khách hàng trống");
                }
                
            }else if(cboLoaiKhachHang.Text == "Khách hàng có mặt hàng quá hạn")
            {
                listKH = busTKKH.XemThongTinKhachHang(1); ;
                if (listKH.Count > 0)
                {
                    dgvKhachHang.Columns.Clear();
                    TaoSTT();
                    dgvKhachHang.DataSource = listKH;
                    TaoTenCot();

                }
                else
                {
                    dgvKhachHang.Columns.Clear();
                    MessageBox.Show("Khách hàng trống");
                }
            }
            else if (cboLoaiKhachHang.Text == "Khách hàng có phí trả muộn")
            {
                listKH = busTKKH.XemThongTinKhachHang(2); ;
                if (listKH.Count > 0)
                {             
                    dgvKhachHang.Columns.Clear();
                    TaoSTT();
                    dgvKhachHang.DataSource = listKH;
                    TaoTenCot();
                }
                else
                {
                    dgvKhachHang.Columns.Clear();
                    MessageBox.Show("Khách hàng trống");
                }

            }
        }
        private void TaoSTT()
        {
            dgvKhachHang.Columns.Add("STT", "STT");
        }
        private void TaoTenCot()
        {
            for (int i = 0; i < listKH.Count; i++)
            {
                dgvKhachHang.Rows[i].Cells[0].Value = i + 1;
            }
            dgvKhachHang.Columns["makh"].HeaderText = "Mã khách hàng";
            dgvKhachHang.Columns["tenkh"].HeaderText = "Họ tên";
            dgvKhachHang.Columns["diachi"].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns["sodt"].HeaderText = "Số điện thoại";
        }

    }
}
