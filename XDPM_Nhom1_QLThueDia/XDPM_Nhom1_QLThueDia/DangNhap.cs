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
    public partial class DangNhap : Form
    {
        private eTaiKhoan eTK;
        private busTaiKhoan busTK;
        public string tenDN;
        public DangNhap()
        {
            InitializeComponent();
            tbxMatKhau.PasswordChar = '*';
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {            
            eTK = new eTaiKhoan(tbxTenDangNhap.Text,tbxMatKhau.Text);
            busTK = new busTaiKhoan();
            if (busTK.DangNhap(eTK))
            {            
                this.Close();
                tenDN = eTK.tenDN;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Đăng nhập thất bại !");
                this.DialogResult = DialogResult.Cancel;
            }
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
                
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            this.AcceptButton = btnDangNhap;
            this.CancelButton = btnThoat;
        }      
    }
}
