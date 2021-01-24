using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ENTITTY;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class DoiMatKhau : Form
    {
        busTaiKhoan busTK;
        private string tenDN;
        public DoiMatKhau(string tenDN)
        {
            InitializeComponent();
            this.tenDN = tenDN;
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            busTK = new busTaiKhoan();
            if(!tbxMatKhauCu.Text.Equals("") || !tbxMatKhauMoi.Text.Equals("") || !tbxNhapLai.Text.Equals(""))
            {
                if (tbxMatKhauMoi.Text.Equals(tbxNhapLai.Text))
                {
                    if (busTK.DoiMatKhau(tenDN,tbxMatKhauCu.Text, tbxMatKhauMoi.Text))
                    {
                        this.DialogResult = DialogResult.OK;

                    }
                    else
                    {
                        MessageBox.Show("Mật khẩu cũ nhập sai !");
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu nhập lại không trùng !");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
