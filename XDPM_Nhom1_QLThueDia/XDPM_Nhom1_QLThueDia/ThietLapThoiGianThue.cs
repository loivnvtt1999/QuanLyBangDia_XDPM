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
    public partial class ThietLapThoiGianThue : Form
    {
        busLoaiDia busld;
        List<eLoaiDia> listeld;
        eLoaiDia eld;
        public ThietLapThoiGianThue()
        {
            InitializeComponent();
            busld = new busLoaiDia();
            this.tbxThoiGianThue.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbxThoiGianThue_KeyPress);
        }

        private void tbxThoiGianThue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ThietLapThoiGianThue_Load(object sender, EventArgs e)
        {
            unfocus();
            listeld = busld.LayDanhSachLoaiDia();
            loadDataToGridview();
            tbxThoiGianThue.TabStop = false;
            btnLuu.Enabled = false;
        }
        void loadDataToGridview()
        {
            tbxThoiGianThue.ReadOnly = true;
            datagridLoaiDia.DataSource = listeld;
            datagridLoaiDia.Refresh();
            customGridview();
        }
        void customGridview()
        {
            datagridLoaiDia.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            datagridLoaiDia.ReadOnly = true;
            datagridLoaiDia.Columns["maLoai"].HeaderText = "Mã loại đĩa";
            datagridLoaiDia.Columns["maLoai"].Width = 130;
            datagridLoaiDia.Columns["tenLoai"].HeaderText = "Tên loại đĩa";
            datagridLoaiDia.Columns["tenLoai"].Width = 130;
            datagridLoaiDia.Columns["giaThue"].HeaderText = "Giá thuê";
            datagridLoaiDia.Columns["giaThue"].DefaultCellStyle.Format = String.Format("#,###,###" + " VND");
            datagridLoaiDia.Columns["giaThue"].Width = 200;
            datagridLoaiDia.Columns["thoiGianThue"].HeaderText = "Thời gian thuê";
            datagridLoaiDia.Columns["thoiGianThue"].DisplayIndex = 2;
            datagridLoaiDia.Columns["thoiGianThue"].Width = 200;
            datagridLoaiDia.Columns["thoiGianThue"].DefaultCellStyle.Format = String.Format("#" + " ngày");
            //datagridLoaiDia.Columns["ThoiGianThue"].Visible = false;
            datagridLoaiDia.Columns["giaPhat"].HeaderText = "Giá phạt";
            datagridLoaiDia.Columns["thoiGianThue"].Width = 200;
            datagridLoaiDia.Columns["giaPhat"].DefaultCellStyle.Format = String.Format("#,###,###" + " VND");
            //datagridLoaiDia.Columns["GiaPhat"].Visible = false;
        }
        void unfocus()
        {
            tbxThoiGianThue.TabStop = false;
            tbxLoaiDia.TabStop = false;
            datagridLoaiDia.TabStop = false;
            btnLuu.TabStop = false;
        }

        private void datagridLoaiDia_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (datagridLoaiDia.SelectedRows.Count > 0)
            {
                tbxThoiGianThue.ReadOnly = false;
                tbxLoaiDia.Text = datagridLoaiDia.SelectedRows[0].Cells["tenLoai"].Value.ToString();
                tbxThoiGianThue.Text = datagridLoaiDia.SelectedRows[0].Cells["thoiGianThue"].Value.ToString();
                tbxThoiGianThue.TabStop = true;
                tbxThoiGianThue.Focus();
                btnLuu.Enabled = true;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (datagridLoaiDia.SelectedRows.Count > 0)
            {
                if (!String.IsNullOrEmpty(tbxThoiGianThue.Text) && double.Parse(tbxThoiGianThue.Text) > 0)
                {
                    if (double.Parse(tbxThoiGianThue.Text) <= 10000)
                    {
                        eld = new eLoaiDia();
                        eld = busld.LayLoaiDiaTheoMa(datagridLoaiDia.SelectedRows[0].Cells["maLoai"].Value.ToString());
                        eld.thoiGianThue = int.Parse(tbxThoiGianThue.Text);
                        busld.ThietLapThoiGianThue(eld);
                        btnLuu.Enabled = false;
                        listeld = busld.LayDanhSachLoaiDia();
                        loadDataToGridview();
                        customGridview();
                        datagridLoaiDia.ClearSelection();
                        tbxThoiGianThue.Text = "";
                        tbxLoaiDia.Text = "";
                        tbxThoiGianThue.ReadOnly = true;
                        btnLuu.Enabled = false;
                        MessageBox.Show("Thiết lập giá thuê thành công");
                        unfocus();

                    }
                    else
                    {
                        MessageBox.Show("Thời gian nhập vào quá lớn, vui lòng kiểm tra lại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Thời gian nhập vào không được bỏ trống và phải lớn hơn 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
