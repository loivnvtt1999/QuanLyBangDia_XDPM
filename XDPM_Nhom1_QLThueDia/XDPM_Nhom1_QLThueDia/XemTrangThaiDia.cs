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
    public partial class XemTrangThaiDia : Form
    {
        busLoaiDia loaidiabus;
        busDia diaBUS;
        List<eLoaiDia> lstLoaiDia;
        List<eDia_LoaiDia_TieuDe> lstDiaXem;
        string loaidialay;
        string trangthai;
        DataTable dts = new DataTable();
        public XemTrangThaiDia()
        {
            InitializeComponent();
        }

        private void XemTrangThaiDia_Load(object sender, EventArgs e)
        {
            loaidiabus = new busLoaiDia();
            diaBUS = new busDia();
            lstLoaiDia = new List<eLoaiDia>();
            lstDiaXem = new List<eDia_LoaiDia_TieuDe>();
            lstLoaiDia = loaidiabus.layDanhSachLoaiDia();
            tbxMaDia.AutoCompleteMode = AutoCompleteMode.Suggest;
            tbxMaDia.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //cbxLoaiDia.Items.Add("Tất cả");
            cbxLoaiDia.Focus();
            cbxLoaiDia.DataSource = lstLoaiDia;
            cbxLoaiDia.DisplayMember = "tenLoai";
            cbxLoaiDia.ValueMember = "maLoai";
            cbxLoaiDia.SelectedIndex = 1;
            cbxLoaiDia.SelectedIndex = 0;
            cbxLoaiDia.DropDownStyle = ComboBoxStyle.DropDownList;
            //lstDiaXem = diaBUS.layDiaTheoLoaiDia(cbxLoaiDia.SelectedValue.ToString());
            //LoadDataToDatagridview(dataGridViewX1,lstDiaXem);
            loadDataTrangThai();
        }
        void loadDataTrangThai()
        {
            cbxTrangThai.Items.Clear();
            cbxTrangThai.Items.Add("Tất cả đĩa");
            cbxTrangThai.Items.Add("Sẵn sàng");
            cbxTrangThai.Items.Add("Đã thuê");
            cbxTrangThai.Items.Add("Đã đặt");
            cbxTrangThai.SelectedIndex = 0;
            cbxTrangThai.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public DataTable CreatData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã đĩa");
            dt.Columns.Add("Loại đĩa");
            dt.Columns.Add("Tên tiêu đề");
            dt.Columns.Add("Tên đĩa");
            dt.Columns.Add("Trạng thái đĩa");
            return dt;
        }
        void LoadDataToDatagridview(DataGridView dgr, List<eDia_LoaiDia_TieuDe> l)
        {
            dts.Clear();
            dts = CreatData();
            foreach (var item in l)
            {
                dts.Rows.Add(item.Madia, item.Tenloai, item.Tentieude, item.Tendia, item.Trangthai);
            }
            dgr.AllowUserToAddRows = false;
            dgr.DataSource = dts;
        }
        private void cbxLoaiDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataTrangThai();
            if (cbxLoaiDia.SelectedIndex >= 0)
            {
                loaidialay = cbxLoaiDia.SelectedValue.ToString();
                lstDiaXem = diaBUS.layDiaTheoLoaiDia(loaidialay);
                LoadDataToDatagridview(dataGridViewX1, lstDiaXem);
            }
            else
            {
                lstDiaXem = diaBUS.layToanBoDia();
                LoadDataToDatagridview(dataGridViewX1, lstDiaXem);
            }

        }

        private void cbxTrangThai_SelectedIndexChanged(object sender, EventArgs e)
        {
            trangthai = cbxTrangThai.Text.ToString();
            if (cbxLoaiDia.SelectedValue == null)
            {
                lstDiaXem = diaBUS.layToanBoDia();
                LoadDataToDatagridview(dataGridViewX1, lstDiaXem);
            }
            else if (trangthai.Equals("Tất cả đĩa"))
            {
                lstDiaXem = diaBUS.layDiaTheoLoaiDia(loaidialay);
                LoadDataToDatagridview(dataGridViewX1, lstDiaXem);
            }
            else
            {
                lstDiaXem = diaBUS.layDiaTheoLoaiDiaVaTrangThai(loaidialay, trangthai);
                LoadDataToDatagridview(dataGridViewX1, lstDiaXem);
            }
        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            List<eDia_LoaiDia_TieuDe> lstTimKiem = new List<eDia_LoaiDia_TieuDe>();
            foreach (var item in lstDiaXem)
            {
                if (item.Madia.Equals(tbxMaDia.Text.ToString()))
                    lstTimKiem.Add(item);
            }
            if (lstTimKiem.Count > 0)
                LoadDataToDatagridview(dataGridViewX1, lstTimKiem);
            else
                MessageBox.Show("Không tìm thấy kết quả");
        }

        private void tbxMaDia_TextChanged(object sender, EventArgs e)
        {
            AutoCompleteStringCollection DataCollection = new AutoCompleteStringCollection();
            foreach (var item in lstDiaXem)
            {
                DataCollection.Add(item.Madia);
            }
            tbxMaDia.AutoCompleteCustomSource = DataCollection;
        }
    }
}
