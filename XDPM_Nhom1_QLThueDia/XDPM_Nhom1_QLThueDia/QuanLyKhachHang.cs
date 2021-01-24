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
    public partial class QuanLyKhachHang : Form
    {
        busKhachHang buskh;
        List<eKhachHang> listkh;
        public QuanLyKhachHang()
        {
            InitializeComponent();
            buskh = new busKhachHang();
            this.tbxSDTKhachHang.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxSDTKhachHang_KeyPress);
        }

        private void QuanLyKhachHang_Load(object sender, EventArgs e)
        {
            listkh = buskh.LayDanhSachKhachHang();
            loadDataToGridview();
            customGridview();
            BlockTextBox();
            BlockButton();
            unFocus();
        }
        void unFocus()
        {
            tbxMaKhachHang.TabStop = false;
            tbxHoTenKhachHang.TabStop = false;
            tbxDiaChiKhachHang.TabStop = false;
            tbxSDTKhachHang.TabStop = false;
            datagridKhachHang.TabStop = false;
        }
        void Focus()
        {
            tbxHoTenKhachHang.TabStop = true;
            tbxDiaChiKhachHang.TabStop = true;
            tbxSDTKhachHang.TabStop = true;
        }
        void customGridview()
        {
            datagridKhachHang.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridKhachHang.ReadOnly = true;
            datagridKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            datagridKhachHang.Columns[0].Width = 100;
            datagridKhachHang.Columns[1].HeaderText = "Họ tên khách hàng";
            datagridKhachHang.Columns[1].Width = 300;
            datagridKhachHang.Columns[2].HeaderText = "Địa chỉ";
            datagridKhachHang.Columns[2].Width = 400;
            datagridKhachHang.Columns[3].HeaderText = "Số điện thoại";
            datagridKhachHang.Columns[3].Width = 230;
        }
        void loadDataToGridview()
        {
            datagridKhachHang.DataSource = listkh;
            datagridKhachHang.Refresh();
        }
        void BlockButton()
        {
            btnSua.Enabled = false;
            btnLuu.Enabled = false;
            btnXoa.Enabled = false;
        }
        void BlockTextBox()
        {
            tbxMaKhachHang.ReadOnly = true;
            tbxHoTenKhachHang.ReadOnly = true;
            tbxDiaChiKhachHang.ReadOnly = true;
            tbxSDTKhachHang.ReadOnly = true;
        }
        void UnBlockTextBox()
        {
            tbxHoTenKhachHang.ReadOnly = false;
            tbxDiaChiKhachHang.ReadOnly = false;
            tbxSDTKhachHang.ReadOnly = false;
        }
        private void datagridKhachHang_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridKhachHang.SelectedRows.Count > 0)
            {
                if (btnThem.Text == "Hủy")
                {
                    unFocus();
                    BlockButton();
                    BlockTextBox();
                    btnThem.Text = "Thêm khách hàng";
                    btnSua.Enabled = true;
                    panelThongtin.Text = "Thông tin";
                }
                if (btnSua.Text == "Hủy")
                {
                    unFocus();
                    BlockButton();
                    BlockTextBox();
                    btnThem.Enabled = true;
                    btnSua.Text = "Cập nhật";
                    panelThongtin.Text = "Thông tin";

                }
                unFocus();
                btnXoa.Enabled = true;
                btnSua.Enabled = true;
                tbxMaKhachHang.Text = datagridKhachHang.SelectedRows[0].Cells[0].Value.ToString();
                tbxHoTenKhachHang.Text = datagridKhachHang.SelectedRows[0].Cells[1].Value.ToString();
                tbxDiaChiKhachHang.Text = datagridKhachHang.SelectedRows[0].Cells[2].Value.ToString();
                tbxSDTKhachHang.Text = datagridKhachHang.SelectedRows[0].Cells[3].Value.ToString();
            }
        }
        void ClearTextBox()
        {
            tbxHoTenKhachHang.Text = "";
            tbxMaKhachHang.Text = "";
            tbxDiaChiKhachHang.Text = "";
            tbxSDTKhachHang.Text = "";
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (btnThem.Text.Equals("Thêm khách hàng"))
            {
                ClearTextBox();
                UnBlockTextBox();
                tbxMaKhachHang.Text = buskh.PhatSinhMaKhachHang();
                btnThem.Text = "Hủy";
                btnLuu.Enabled = true;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
                tbxSDTKhachHang.Enabled = true;
                tbxDiaChiKhachHang.Enabled = true;
                panelThongtin.Text = "Thêm khách hàng";
                datagridKhachHang.ClearSelection();
                tbxHoTenKhachHang.Focus();
                Focus();
            }
            else
            {
                ClearTextBox();
                BlockTextBox();
                btnThem.Text = "Thêm khách hàng";
                tbxSDTKhachHang.Enabled = false;
                tbxDiaChiKhachHang.Enabled = false;
                btnLuu.Enabled = false;
                btnSua.Enabled = false;
                datagridKhachHang.ClearSelection();
                panelThongtin.Text = "Thông tin";
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (btnSua.Text.Equals("Cập nhật"))
            {
                btnSua.Text = "Hủy";
                btnLuu.Enabled = true;
                btnThem.Enabled = false;
                btnXoa.Enabled = false;
                panelThongtin.Text = "Cập nhật thông tin khách hàng";
                UnBlockTextBox();
                tbxHoTenKhachHang.Focus();
                Focus();
            }
            else
            {
                BlockTextBox();
                btnSua.Text = "Cập nhật";
                btnLuu.Enabled = false;
                btnThem.Enabled = true;
                btnXoa.Enabled = true;
                panelThongtin.Text = "Thông tin";
            }
        }
        eKhachHang TaoKhachHang()
        {
            eKhachHang ekh = new eKhachHang();
            ekh.Makh = tbxMaKhachHang.Text;
            ekh.Tenkh = tbxHoTenKhachHang.Text;
            ekh.Diachi = tbxDiaChiKhachHang.Text;
            ekh.Sodt = tbxSDTKhachHang.Text;
            return ekh;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbxMaKhachHang.Text) || string.IsNullOrEmpty(tbxHoTenKhachHang.Text) || string.IsNullOrEmpty(tbxDiaChiKhachHang.Text) || string.IsNullOrEmpty(tbxSDTKhachHang.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (btnThem.Text == "Hủy")
                {
                    unFocus();
                    eKhachHang ekh = TaoKhachHang();
                    buskh.ThemKhachHang(ekh);
                    listkh = buskh.LayDanhSachKhachHang();
                    datagridKhachHang.DataSource = listkh;
                    datagridKhachHang.ClearSelection();
                    customGridview();
                    ClearTextBox();
                    BlockButton();
                    BlockTextBox();
                    ClearTextBox();
                    MessageBox.Show("Thêm khách hàng thành công");
                }
                else
                {
                    unFocus();
                    eKhachHang ekh = TaoKhachHang();
                    buskh.SuaKhachHang(ekh);
                    listkh = buskh.LayDanhSachKhachHang();
                    datagridKhachHang.DataSource = listkh;
                    datagridKhachHang.ClearSelection();
                    customGridview();
                    ClearTextBox();
                    BlockButton();
                    BlockTextBox();
                    MessageBox.Show("Cập nhật thành công");

                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show("Có chắc chắn xóa khách hàng này ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (rs == DialogResult.OK)
            {
                unFocus();
                eKhachHang ekh = TaoKhachHang();
                buskh.XoaKhachHang(ekh);
                listkh = buskh.LayDanhSachKhachHang();
                datagridKhachHang.DataSource = listkh;
                customGridview();
                ClearTextBox();
                datagridKhachHang.ClearSelection();
                BlockButton();
                BlockTextBox();
                ClearTextBox();
                MessageBox.Show("Xóa thành công");
            }
        }

        private void tbxSDTKhachHang_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
