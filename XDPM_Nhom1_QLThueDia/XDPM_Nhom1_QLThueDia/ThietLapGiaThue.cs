using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using ENTITTY;
namespace XDPM_Nhom1_QLThueDia
{
    public partial class ThietLapGiaThue : Form
    {
        busLoaiDia busld;
        List<eLoaiDia> listeld;
        eLoaiDia eld;
        public ThietLapGiaThue()
        {
            InitializeComponent();
            this.tbxGiaThue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxGiaThue_KeyPress);
            busld = new busLoaiDia();
        }

        private void tbxGiaThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void ThietLapGiaThue_Load(object sender, EventArgs e)
        {
            unfocus();
            listeld = busld.LayDanhSachLoaiDia();
            loadDataToGridview();
            tbxGiaThue.TabStop = false;
            btnLuu.Enabled = false;
        }
        void loadDataToGridview()
        {
            tbxGiaThue.ReadOnly = true;
            datagridLoaiDia.DataSource = listeld;
            datagridLoaiDia.Refresh();
            customGridview();
        }
        void customGridview()
        {
            datagridLoaiDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridLoaiDia.ReadOnly = true;
            datagridLoaiDia.AutoResizeColumns();
            datagridLoaiDia.Columns["maLoai"].HeaderText = "Mã loại đĩa";
            datagridLoaiDia.Columns["maLoai"].Width = 130;
            datagridLoaiDia.Columns["tenLoai"].HeaderText = "Tên loại đĩa";
            datagridLoaiDia.Columns["tenLoai"].Width = 130;
            datagridLoaiDia.Columns["giaThue"].HeaderText = "Giá thuê";
            datagridLoaiDia.Columns["giaThue"].Width = 200;
            datagridLoaiDia.Columns["giaThue"].DefaultCellStyle.Format = String.Format("#,###,###" + " VND");
            datagridLoaiDia.Columns["thoiGianThue"].HeaderText = "Thời gian thuê";
            datagridLoaiDia.Columns["thoiGianThue"].Width = 200;
            datagridLoaiDia.Columns["thoiGianThue"].DisplayIndex = 3;
            datagridLoaiDia.Columns["thoiGianThue"].DefaultCellStyle.Format = String.Format("#" + " ngày");
            //datagridLoaiDia.Columns["ThoiGianThue"].Visible = false;
            datagridLoaiDia.Columns["giaPhat"].HeaderText = "Giá phạt";
            datagridLoaiDia.Columns["giaPhat"].Width = 200;
            datagridLoaiDia.Columns["giaPhat"].DefaultCellStyle.Format = String.Format("#,###,###" + " VND");
            //datagridLoaiDia.Columns["GiaPhat"].Visible = false;
        }
        private void datagridLoaiDia_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridLoaiDia.SelectedRows.Count > 0)
            {
                tbxGiaThue.ReadOnly = false;
                tbxLoaiDia.Text = datagridLoaiDia.SelectedRows[0].Cells["tenLoai"].Value.ToString();
                tbxGiaThue.Text = datagridLoaiDia.SelectedRows[0].Cells["giaThue"].Value.ToString();
                tbxGiaThue.TabStop = true;
                tbxGiaThue.Focus();
                btnLuu.Enabled = true;
            }
        }
        void unfocus()
        {
            tbxGiaThue.TabStop = false;
            tbxLoaiDia.TabStop = false;
            datagridLoaiDia.TabStop = false;
            btnLuu.TabStop = false;
        }
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (datagridLoaiDia.SelectedRows.Count > 0)
            {
                if (!String.IsNullOrEmpty(tbxGiaThue.Text) && double.Parse(tbxGiaThue.Text) >= 1000)
                {
                    if (double.Parse(tbxGiaThue.Text) <= 100000000)
                    {
                        eld = new eLoaiDia();
                        eld = busld.LayLoaiDiaTheoMa(datagridLoaiDia.SelectedRows[0].Cells["maLoai"].Value.ToString());
                        eld.giaThue = double.Parse(tbxGiaThue.Text);
                        busld.ThietLapGiaThue(eld);
                        btnLuu.Enabled = false;
                        listeld = busld.LayDanhSachLoaiDia();
                        loadDataToGridview();
                        datagridLoaiDia.ClearSelection();
                        tbxGiaThue.Text = "";
                        tbxLoaiDia.Text = "";
                        tbxGiaThue.ReadOnly = true;
                        btnLuu.Enabled = false;
                        MessageBox.Show("Thiết lập giá thuê thành công");
                        unfocus();
                    }
                    else
                    {
                        MessageBox.Show("Số tiền nhập vào quá lớn, vui lòng kiểm tra lại!");
                    }
                }
                else
                {
                    MessageBox.Show("Số tiền nhập vào không được bỏ trống và phải từ 1000 VND trở lên", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
