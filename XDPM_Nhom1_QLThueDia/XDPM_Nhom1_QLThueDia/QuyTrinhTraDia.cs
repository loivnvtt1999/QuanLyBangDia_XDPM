﻿using ENTITTY;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XDPM_Nhom1_QLThueDia
{
    public partial class QuyTrinhTraDia : Form
    {
        TraDia tra;
        GanDia gan;
        public QuyTrinhTraDia()
        {
            InitializeComponent();
        }

        private void QuyTrinhTraDia_Load(object sender, EventArgs e)
        {
            ResetForm();
        }

        void ShowForm()
        {
            this.pnlChucNang.Controls[0].Show();
            this.pnlChucNang.Controls[0].BringToFront();
        }

        public void ResetForm()
        {
            this.pnlChucNang.Controls.Clear();
            tra = new TraDia(this);
            ThemGiaiDoan(tra);
            ShowForm();
        }

        void ThemGiaiDoan(Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowInTaskbar = false;
            frm.Dock = DockStyle.Fill;
            this.pnlChucNang.Controls.Add(frm);
        }

        public void GoNext()
        {
            this.pnlChucNang.Controls.Clear();
            gan = new GanDia(this, tra.dia);
            ThemGiaiDoan(gan);
            ShowForm();
        }
    }
}
