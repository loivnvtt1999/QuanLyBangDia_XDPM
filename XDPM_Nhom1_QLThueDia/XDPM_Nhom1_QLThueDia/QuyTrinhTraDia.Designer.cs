namespace XDPM_Nhom1_QLThueDia
{
    partial class QuyTrinhTraDia
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlChucNang = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // pnlChucNang
            // 
            this.pnlChucNang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChucNang.Location = new System.Drawing.Point(0, 0);
            this.pnlChucNang.Name = "pnlChucNang";
            this.pnlChucNang.Size = new System.Drawing.Size(1248, 617);
            this.pnlChucNang.TabIndex = 0;
            // 
            // QuyTrinhTraDia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 617);
            this.Controls.Add(this.pnlChucNang);
            this.Font = new System.Drawing.Font("Times New Roman", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "QuyTrinhTraDia";
            this.Text = "QuyTrinhTraDia";
            this.Load += new System.EventHandler(this.QuyTrinhTraDia_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlChucNang;
    }
}