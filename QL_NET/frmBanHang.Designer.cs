namespace QL_NET
{
    partial class frmBanHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBanHang));
            this.panelOder = new System.Windows.Forms.Panel();
            this.dgvChiTietBanHang = new System.Windows.Forms.DataGridView();
            this.pnlThoiGian = new System.Windows.Forms.Panel();
            this.btnBatDau = new System.Windows.Forms.Button();
            this.mtbKetThuc = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.mtbBatDau = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblChiTietPhong = new System.Windows.Forms.Label();
            this.lblPhongDangChon = new System.Windows.Forms.Label();
            this.dgvDanhSachMatHang = new System.Windows.Forms.DataGridView();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbcBanHang = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbcContent = new System.Windows.Forms.TabControl();
            this.tbcLSGD = new System.Windows.Forms.TabPage();
            this.dgvLSGD = new System.Windows.Forms.DataGridView();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.panelOder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).BeginInit();
            this.pnlThoiGian.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).BeginInit();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbcBanHang.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tbcLSGD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).BeginInit();
            this.SuspendLayout();
            // 
            // panelOder
            // 
            this.panelOder.BackColor = System.Drawing.Color.IndianRed;
            this.panelOder.Controls.Add(this.dgvChiTietBanHang);
            this.panelOder.Controls.Add(this.pnlThoiGian);
            this.panelOder.Controls.Add(this.lblChiTietPhong);
            this.panelOder.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelOder.Location = new System.Drawing.Point(0, 470);
            this.panelOder.Name = "panelOder";
            this.panelOder.Size = new System.Drawing.Size(845, 184);
            this.panelOder.TabIndex = 2;
            // 
            // dgvChiTietBanHang
            // 
            this.dgvChiTietBanHang.AllowUserToAddRows = false;
            this.dgvChiTietBanHang.AllowUserToDeleteRows = false;
            this.dgvChiTietBanHang.AllowUserToOrderColumns = true;
            this.dgvChiTietBanHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvChiTietBanHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvChiTietBanHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvChiTietBanHang.Location = new System.Drawing.Point(278, 42);
            this.dgvChiTietBanHang.MultiSelect = false;
            this.dgvChiTietBanHang.Name = "dgvChiTietBanHang";
            this.dgvChiTietBanHang.ReadOnly = true;
            this.dgvChiTietBanHang.RowHeadersWidth = 51;
            this.dgvChiTietBanHang.RowTemplate.Height = 24;
            this.dgvChiTietBanHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvChiTietBanHang.Size = new System.Drawing.Size(564, 139);
            this.dgvChiTietBanHang.TabIndex = 5;
            // 
            // pnlThoiGian
            // 
            this.pnlThoiGian.BackColor = System.Drawing.Color.IndianRed;
            this.pnlThoiGian.Controls.Add(this.btnBatDau);
            this.pnlThoiGian.Controls.Add(this.mtbKetThuc);
            this.pnlThoiGian.Controls.Add(this.label4);
            this.pnlThoiGian.Controls.Add(this.btnKetThuc);
            this.pnlThoiGian.Controls.Add(this.mtbBatDau);
            this.pnlThoiGian.Controls.Add(this.label3);
            this.pnlThoiGian.Location = new System.Drawing.Point(0, 42);
            this.pnlThoiGian.Name = "pnlThoiGian";
            this.pnlThoiGian.Size = new System.Drawing.Size(272, 139);
            this.pnlThoiGian.TabIndex = 3;
            // 
            // btnBatDau
            // 
            this.btnBatDau.BackColor = System.Drawing.Color.IndianRed;
            this.btnBatDau.Enabled = false;
            this.btnBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnBatDau.ForeColor = System.Drawing.Color.White;
            this.btnBatDau.Location = new System.Drawing.Point(15, 84);
            this.btnBatDau.Name = "btnBatDau";
            this.btnBatDau.Size = new System.Drawing.Size(109, 35);
            this.btnBatDau.TabIndex = 9;
            this.btnBatDau.Text = "Bắt đầu";
            this.btnBatDau.UseVisualStyleBackColor = false;
            this.btnBatDau.Click += new System.EventHandler(this.btnBatDau_Click);
            // 
            // mtbKetThuc
            // 
            this.mtbKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbKetThuc.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbKetThuc.Location = new System.Drawing.Point(99, 43);
            this.mtbKetThuc.Mask = "00/00/0000 90:00";
            this.mtbKetThuc.Name = "mtbKetThuc";
            this.mtbKetThuc.Size = new System.Drawing.Size(152, 22);
            this.mtbKetThuc.TabIndex = 8;
            this.mtbKetThuc.ValidatingType = typeof(System.DateTime);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(12, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Kết thúc";
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.BackColor = System.Drawing.Color.IndianRed;
            this.btnKetThuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnKetThuc.ForeColor = System.Drawing.Color.White;
            this.btnKetThuc.Location = new System.Drawing.Point(130, 84);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(121, 35);
            this.btnKetThuc.TabIndex = 6;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = false;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // mtbBatDau
            // 
            this.mtbBatDau.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbBatDau.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbBatDau.Location = new System.Drawing.Point(99, 6);
            this.mtbBatDau.Mask = "00/00/0000 90:00";
            this.mtbBatDau.Name = "mtbBatDau";
            this.mtbBatDau.Size = new System.Drawing.Size(152, 22);
            this.mtbBatDau.TabIndex = 5;
            this.mtbBatDau.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(12, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bắt đầu:";
            // 
            // lblChiTietPhong
            // 
            this.lblChiTietPhong.AutoSize = true;
            this.lblChiTietPhong.BackColor = System.Drawing.Color.IndianRed;
            this.lblChiTietPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblChiTietPhong.ForeColor = System.Drawing.Color.White;
            this.lblChiTietPhong.Location = new System.Drawing.Point(3, 12);
            this.lblChiTietPhong.Name = "lblChiTietPhong";
            this.lblChiTietPhong.Size = new System.Drawing.Size(370, 18);
            this.lblChiTietPhong.TabIndex = 1;
            this.lblChiTietPhong.Text = "DANH SÁCH MẶT HÀNG PHÒNG ĐÃ SỬ DỤNG";
            // 
            // lblPhongDangChon
            // 
            this.lblPhongDangChon.BackColor = System.Drawing.Color.IndianRed;
            this.lblPhongDangChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblPhongDangChon.ForeColor = System.Drawing.Color.White;
            this.lblPhongDangChon.Location = new System.Drawing.Point(6, 212);
            this.lblPhongDangChon.Name = "lblPhongDangChon";
            this.lblPhongDangChon.Size = new System.Drawing.Size(384, 25);
            this.lblPhongDangChon.TabIndex = 0;
            this.lblPhongDangChon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvDanhSachMatHang
            // 
            this.dgvDanhSachMatHang.AllowUserToAddRows = false;
            this.dgvDanhSachMatHang.AllowUserToDeleteRows = false;
            this.dgvDanhSachMatHang.AllowUserToOrderColumns = true;
            this.dgvDanhSachMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachMatHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachMatHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachMatHang.Location = new System.Drawing.Point(8, 240);
            this.dgvDanhSachMatHang.MultiSelect = false;
            this.dgvDanhSachMatHang.Name = "dgvDanhSachMatHang";
            this.dgvDanhSachMatHang.ReadOnly = true;
            this.dgvDanhSachMatHang.RowHeadersWidth = 51;
            this.dgvDanhSachMatHang.RowTemplate.Height = 24;
            this.dgvDanhSachMatHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachMatHang.Size = new System.Drawing.Size(390, 411);
            this.dgvDanhSachMatHang.TabIndex = 4;
            this.dgvDanhSachMatHang.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDanhSachMatHang_CellDoubleClick_1);
            // 
            // pnlControl
            // 
            this.pnlControl.BackColor = System.Drawing.Color.IndianRed;
            this.pnlControl.Controls.Add(this.pictureBox1);
            this.pnlControl.Controls.Add(this.dgvDanhSachMatHang);
            this.pnlControl.Controls.Add(this.lblPhongDangChon);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControl.Location = new System.Drawing.Point(845, 0);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(402, 654);
            this.pnlControl.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::QL_NET.Properties.Resources.logo_1;
            this.pictureBox1.Location = new System.Drawing.Point(8, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(390, 184);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // tbcBanHang
            // 
            this.tbcBanHang.Controls.Add(this.tabPage1);
            this.tbcBanHang.Controls.Add(this.tbcLSGD);
            this.tbcBanHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcBanHang.Location = new System.Drawing.Point(0, 0);
            this.tbcBanHang.Name = "tbcBanHang";
            this.tbcBanHang.SelectedIndex = 0;
            this.tbcBanHang.Size = new System.Drawing.Size(845, 470);
            this.tbcBanHang.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbcContent);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(837, 441);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Bán hàng";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbcContent
            // 
            this.tbcContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbcContent.Location = new System.Drawing.Point(3, 3);
            this.tbcContent.Name = "tbcContent";
            this.tbcContent.SelectedIndex = 0;
            this.tbcContent.Size = new System.Drawing.Size(831, 435);
            this.tbcContent.TabIndex = 1;
            this.tbcContent.SelectedIndexChanged += new System.EventHandler(this.tbcContent_SelectedIndexChanged);
            // 
            // tbcLSGD
            // 
            this.tbcLSGD.Controls.Add(this.dgvLSGD);
            this.tbcLSGD.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tbcLSGD.Location = new System.Drawing.Point(4, 25);
            this.tbcLSGD.Name = "tbcLSGD";
            this.tbcLSGD.Padding = new System.Windows.Forms.Padding(3);
            this.tbcLSGD.Size = new System.Drawing.Size(837, 441);
            this.tbcLSGD.TabIndex = 1;
            this.tbcLSGD.Text = "Lịch sử giao dịch";
            this.tbcLSGD.UseVisualStyleBackColor = true;
            // 
            // dgvLSGD
            // 
            this.dgvLSGD.BackgroundColor = System.Drawing.Color.White;
            this.dgvLSGD.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLSGD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLSGD.Location = new System.Drawing.Point(3, 3);
            this.dgvLSGD.Name = "dgvLSGD";
            this.dgvLSGD.RowHeadersWidth = 51;
            this.dgvLSGD.RowTemplate.Height = 24;
            this.dgvLSGD.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLSGD.Size = new System.Drawing.Size(831, 435);
            this.dgvLSGD.TabIndex = 0;
            this.dgvLSGD.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLSGD_CellClick);
            this.dgvLSGD.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLSGD_CellDoubleClick);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // frmBanHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1247, 654);
            this.Controls.Add(this.tbcBanHang);
            this.Controls.Add(this.panelOder);
            this.Controls.Add(this.pnlControl);
            this.Name = "frmBanHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmBanHang";
            this.Load += new System.EventHandler(this.frmBanHang_Load);
            this.panelOder.ResumeLayout(false);
            this.panelOder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvChiTietBanHang)).EndInit();
            this.pnlThoiGian.ResumeLayout(false);
            this.pnlThoiGian.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachMatHang)).EndInit();
            this.pnlControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbcBanHang.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tbcLSGD.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLSGD)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelOder;
        private System.Windows.Forms.Label lblChiTietPhong;
        private System.Windows.Forms.Panel pnlThoiGian;
        private System.Windows.Forms.MaskedTextBox mtbBatDau;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox mtbKetThuc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.DataGridView dgvChiTietBanHang;
        private System.Windows.Forms.Button btnBatDau;
        private System.Windows.Forms.Label lblPhongDangChon;
        private System.Windows.Forms.DataGridView dgvDanhSachMatHang;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.TabControl tbcBanHang;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tbcLSGD;
        private System.Windows.Forms.TabControl tbcContent;
        private System.Windows.Forms.DataGridView dgvLSGD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
    }
}