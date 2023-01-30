namespace QL_NET
{
    partial class frmMain
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
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ptbMaximize = new System.Windows.Forms.PictureBox();
            this.ptbMinimize = new System.Windows.Forms.PictureBox();
            this.ptbExit = new System.Windows.Forms.PictureBox();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.hệThốngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.danhMụcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loaiPhongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.matHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.donvitinhToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhaCungCapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhanVienToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhapHangToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bánHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêBáoCáoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tồnKhoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doanhThuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ptnRight = new System.Windows.Forms.Panel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.grbContent = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.đổiMậtKhẩuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMaximize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.grbContent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.IndianRed;
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.ptbMaximize);
            this.pnlTop.Controls.Add(this.ptbMinimize);
            this.pnlTop.Controls.Add(this.ptbExit);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1308, 35);
            this.pnlTop.TabIndex = 0;
            this.pnlTop.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlTop_MouseMove);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(13, 10);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(52, 18);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "label1";
            // 
            // ptbMaximize
            // 
            this.ptbMaximize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMaximize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbMaximize.Image = global::QL_NET.Properties.Resources.maxi;
            this.ptbMaximize.Location = new System.Drawing.Point(1234, 5);
            this.ptbMaximize.Name = "ptbMaximize";
            this.ptbMaximize.Size = new System.Drawing.Size(22, 22);
            this.ptbMaximize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMaximize.TabIndex = 2;
            this.ptbMaximize.TabStop = false;
            this.ptbMaximize.Click += new System.EventHandler(this.ptbMaximize_Click);
            // 
            // ptbMinimize
            // 
            this.ptbMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbMinimize.Image = global::QL_NET.Properties.Resources.minimazar;
            this.ptbMinimize.Location = new System.Drawing.Point(1196, 5);
            this.ptbMinimize.Name = "ptbMinimize";
            this.ptbMinimize.Size = new System.Drawing.Size(22, 22);
            this.ptbMinimize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbMinimize.TabIndex = 1;
            this.ptbMinimize.TabStop = false;
            this.ptbMinimize.Click += new System.EventHandler(this.ptbMinimize_Click);
            // 
            // ptbExit
            // 
            this.ptbExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ptbExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ptbExit.Image = global::QL_NET.Properties.Resources.cerrar;
            this.ptbExit.Location = new System.Drawing.Point(1274, 5);
            this.ptbExit.Name = "ptbExit";
            this.ptbExit.Size = new System.Drawing.Size(22, 22);
            this.ptbExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ptbExit.TabIndex = 0;
            this.ptbExit.TabStop = false;
            this.ptbExit.Click += new System.EventHandler(this.ptbExit_Click);
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.IndianRed;
            this.pnlBottom.Controls.Add(this.lblNhanVien);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 612);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1308, 37);
            this.pnlBottom.TabIndex = 1;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.lblNhanVien.ForeColor = System.Drawing.Color.White;
            this.lblNhanVien.Location = new System.Drawing.Point(13, 10);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(52, 18);
            this.lblNhanVien.TabIndex = 4;
            this.lblNhanVien.Text = "label1";
            // 
            // hệThốngToolStripMenuItem
            // 
            this.hệThốngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.danhMụcToolStripMenuItem,
            this.nhapHangToolStripMenuItem,
            this.đổiMậtKhẩuToolStripMenuItem,
            this.thoatToolStripMenuItem});
            this.hệThốngToolStripMenuItem.Name = "hệThốngToolStripMenuItem";
            this.hệThốngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.hệThốngToolStripMenuItem.Text = "Hệ thống";
            // 
            // danhMụcToolStripMenuItem
            // 
            this.danhMụcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loaiPhongToolStripMenuItem,
            this.phongToolStripMenuItem,
            this.matHangToolStripMenuItem,
            this.donvitinhToolStripMenuItem,
            this.nhaCungCapToolStripMenuItem,
            this.nhanVienToolStripMenuItem});
            this.danhMụcToolStripMenuItem.Name = "danhMụcToolStripMenuItem";
            this.danhMụcToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.danhMụcToolStripMenuItem.Text = "Danh mục";
            // 
            // loaiPhongToolStripMenuItem
            // 
            this.loaiPhongToolStripMenuItem.Name = "loaiPhongToolStripMenuItem";
            this.loaiPhongToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.loaiPhongToolStripMenuItem.Text = "Loại phòng";
            this.loaiPhongToolStripMenuItem.Click += new System.EventHandler(this.loaiPhongToolStripMenuItem_Click);
            // 
            // phongToolStripMenuItem
            // 
            this.phongToolStripMenuItem.Name = "phongToolStripMenuItem";
            this.phongToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.phongToolStripMenuItem.Text = "Phòng";
            this.phongToolStripMenuItem.Click += new System.EventHandler(this.phongToolStripMenuItem_Click);
            // 
            // matHangToolStripMenuItem
            // 
            this.matHangToolStripMenuItem.Name = "matHangToolStripMenuItem";
            this.matHangToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.matHangToolStripMenuItem.Text = "Mặt Hàng";
            this.matHangToolStripMenuItem.Click += new System.EventHandler(this.matHangToolStripMenuItem_Click);
            // 
            // donvitinhToolStripMenuItem
            // 
            this.donvitinhToolStripMenuItem.Name = "donvitinhToolStripMenuItem";
            this.donvitinhToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.donvitinhToolStripMenuItem.Text = "Đơn vị tính";
            this.donvitinhToolStripMenuItem.Click += new System.EventHandler(this.donvitinhToolStripMenuItem_Click);
            // 
            // nhaCungCapToolStripMenuItem
            // 
            this.nhaCungCapToolStripMenuItem.Name = "nhaCungCapToolStripMenuItem";
            this.nhaCungCapToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhaCungCapToolStripMenuItem.Text = "Nhà cung cấp";
            this.nhaCungCapToolStripMenuItem.Click += new System.EventHandler(this.nhaCungCapToolStripMenuItem_Click);
            // 
            // nhanVienToolStripMenuItem
            // 
            this.nhanVienToolStripMenuItem.Name = "nhanVienToolStripMenuItem";
            this.nhanVienToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhanVienToolStripMenuItem.Text = "Nhân viên";
            this.nhanVienToolStripMenuItem.Click += new System.EventHandler(this.nhanVienToolStripMenuItem_Click);
            // 
            // nhapHangToolStripMenuItem
            // 
            this.nhapHangToolStripMenuItem.Name = "nhapHangToolStripMenuItem";
            this.nhapHangToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.nhapHangToolStripMenuItem.Text = "Nhập hàng";
            this.nhapHangToolStripMenuItem.Click += new System.EventHandler(this.nhapHangToolStripMenuItem_Click);
            // 
            // bánHàngToolStripMenuItem
            // 
            this.bánHàngToolStripMenuItem.Name = "bánHàngToolStripMenuItem";
            this.bánHàngToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.bánHàngToolStripMenuItem.Text = "Bán hàng";
            this.bánHàngToolStripMenuItem.Click += new System.EventHandler(this.bánHàngToolStripMenuItem_Click);
            // 
            // thốngKêBáoCáoToolStripMenuItem
            // 
            this.thốngKêBáoCáoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tồnKhoToolStripMenuItem,
            this.doanhThuToolStripMenuItem});
            this.thốngKêBáoCáoToolStripMenuItem.Name = "thốngKêBáoCáoToolStripMenuItem";
            this.thốngKêBáoCáoToolStripMenuItem.Size = new System.Drawing.Size(152, 24);
            this.thốngKêBáoCáoToolStripMenuItem.Text = "Thống kê - Báo cáo";
            // 
            // tồnKhoToolStripMenuItem
            // 
            this.tồnKhoToolStripMenuItem.Name = "tồnKhoToolStripMenuItem";
            this.tồnKhoToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.tồnKhoToolStripMenuItem.Text = "Tồn kho";
            this.tồnKhoToolStripMenuItem.Click += new System.EventHandler(this.tồnKhoToolStripMenuItem_Click);
            // 
            // doanhThuToolStripMenuItem
            // 
            this.doanhThuToolStripMenuItem.Name = "doanhThuToolStripMenuItem";
            this.doanhThuToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.doanhThuToolStripMenuItem.Text = "Doanh thu";
            this.doanhThuToolStripMenuItem.Click += new System.EventHandler(this.doanhThuToolStripMenuItem_Click);
            // 
            // liênHệToolStripMenuItem
            // 
            this.liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
            this.liênHệToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.liênHệToolStripMenuItem.Text = "Liên hệ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hệThốngToolStripMenuItem,
            this.bánHàngToolStripMenuItem,
            this.thốngKêBáoCáoToolStripMenuItem,
            this.liênHệToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 35);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1308, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ptnRight
            // 
            this.ptnRight.BackColor = System.Drawing.Color.IndianRed;
            this.ptnRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.ptnRight.Location = new System.Drawing.Point(1298, 63);
            this.ptnRight.Name = "ptnRight";
            this.ptnRight.Size = new System.Drawing.Size(10, 549);
            this.ptnRight.TabIndex = 3;
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.IndianRed;
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 63);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(10, 549);
            this.pnlLeft.TabIndex = 2;
            // 
            // grbContent
            // 
            this.grbContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbContent.BackColor = System.Drawing.Color.IndianRed;
            this.grbContent.Controls.Add(this.pictureBox1);
            this.grbContent.Location = new System.Drawing.Point(12, 66);
            this.grbContent.Name = "grbContent";
            this.grbContent.Size = new System.Drawing.Size(1284, 553);
            this.grbContent.TabIndex = 4;
            this.grbContent.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.IndianRed;
            this.pictureBox1.Image = global::QL_NET.Properties.Resources.logo_auto_x2;
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1278, 534);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // đổiMậtKhẩuToolStripMenuItem
            // 
            this.đổiMậtKhẩuToolStripMenuItem.Name = "đổiMậtKhẩuToolStripMenuItem";
            this.đổiMậtKhẩuToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đổiMậtKhẩuToolStripMenuItem.Text = "Đổi mật khẩu";
            this.đổiMậtKhẩuToolStripMenuItem.Click += new System.EventHandler(this.đổiMậtKhẩuToolStripMenuItem_Click);
            // 
            // thoatToolStripMenuItem
            // 
            this.thoatToolStripMenuItem.Name = "thoatToolStripMenuItem";
            this.thoatToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thoatToolStripMenuItem.Text = "Thoát";
            this.thoatToolStripMenuItem.Click += new System.EventHandler(this.thoatToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1308, 649);
            this.Controls.Add(this.ptnRight);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.grbContent);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QL NET";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMaximize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbMinimize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ptbExit)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.grbContent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.PictureBox ptbExit;
        private System.Windows.Forms.ToolStripMenuItem hệThốngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem danhMụcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhapHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bánHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêBáoCáoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liênHệToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.PictureBox ptbMaximize;
        private System.Windows.Forms.PictureBox ptbMinimize;
        private System.Windows.Forms.Panel ptnRight;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.ToolStripMenuItem loaiPhongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem matHangToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem donvitinhToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhaCungCapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhanVienToolStripMenuItem;
        private System.Windows.Forms.GroupBox grbContent;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem tồnKhoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doanhThuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem đổiMậtKhẩuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thoatToolStripMenuItem;
    }
}