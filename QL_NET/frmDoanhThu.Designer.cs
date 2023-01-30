namespace QL_NET
{
    partial class frmDoanhThu
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
            this.dgvDoanhThu = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.mtbTuNgay = new System.Windows.Forms.MaskedTextBox();
            this.mtbToiNgay = new System.Windows.Forms.MaskedTextBox();
            this.rbtTatCa = new System.Windows.Forms.RadioButton();
            this.rbtMatHang = new System.Windows.Forms.RadioButton();
            this.rbtDichVu = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rbtPhong = new System.Windows.Forms.RadioButton();
            this.cbbItems = new System.Windows.Forms.ComboBox();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDoanhThu
            // 
            this.dgvDoanhThu.AllowUserToAddRows = false;
            this.dgvDoanhThu.AllowUserToDeleteRows = false;
            this.dgvDoanhThu.AllowUserToOrderColumns = true;
            this.dgvDoanhThu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDoanhThu.BackgroundColor = System.Drawing.Color.White;
            this.dgvDoanhThu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDoanhThu.Location = new System.Drawing.Point(12, 161);
            this.dgvDoanhThu.Name = "dgvDoanhThu";
            this.dgvDoanhThu.ReadOnly = true;
            this.dgvDoanhThu.RowHeadersWidth = 51;
            this.dgvDoanhThu.RowTemplate.Height = 24;
            this.dgvDoanhThu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDoanhThu.Size = new System.Drawing.Size(1009, 459);
            this.dgvDoanhThu.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(758, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(257, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "THỐNG KÊ DOANH THU";
            // 
            // mtbTuNgay
            // 
            this.mtbTuNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbTuNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbTuNgay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbTuNgay.Location = new System.Drawing.Point(576, 53);
            this.mtbTuNgay.Mask = "00/00/0000 90:00";
            this.mtbTuNgay.Name = "mtbTuNgay";
            this.mtbTuNgay.Size = new System.Drawing.Size(151, 22);
            this.mtbTuNgay.TabIndex = 3;
            this.mtbTuNgay.ValidatingType = typeof(System.DateTime);
            // 
            // mtbToiNgay
            // 
            this.mtbToiNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mtbToiNgay.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.mtbToiNgay.InsertKeyMode = System.Windows.Forms.InsertKeyMode.Overwrite;
            this.mtbToiNgay.Location = new System.Drawing.Point(859, 53);
            this.mtbToiNgay.Mask = "00/00/0000 90:00";
            this.mtbToiNgay.Name = "mtbToiNgay";
            this.mtbToiNgay.Size = new System.Drawing.Size(156, 22);
            this.mtbToiNgay.TabIndex = 4;
            this.mtbToiNgay.ValidatingType = typeof(System.DateTime);
            // 
            // rbtTatCa
            // 
            this.rbtTatCa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtTatCa.AutoSize = true;
            this.rbtTatCa.Checked = true;
            this.rbtTatCa.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtTatCa.ForeColor = System.Drawing.Color.White;
            this.rbtTatCa.Location = new System.Drawing.Point(237, 108);
            this.rbtTatCa.Name = "rbtTatCa";
            this.rbtTatCa.Size = new System.Drawing.Size(72, 20);
            this.rbtTatCa.TabIndex = 5;
            this.rbtTatCa.TabStop = true;
            this.rbtTatCa.Text = "Tất cả";
            this.rbtTatCa.UseVisualStyleBackColor = true;
            this.rbtTatCa.CheckedChanged += new System.EventHandler(this.rbtTatCa_CheckedChanged);
            // 
            // rbtMatHang
            // 
            this.rbtMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtMatHang.AutoSize = true;
            this.rbtMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtMatHang.ForeColor = System.Drawing.Color.White;
            this.rbtMatHang.Location = new System.Drawing.Point(325, 108);
            this.rbtMatHang.Name = "rbtMatHang";
            this.rbtMatHang.Size = new System.Drawing.Size(91, 20);
            this.rbtMatHang.TabIndex = 5;
            this.rbtMatHang.TabStop = true;
            this.rbtMatHang.Text = "Mặt hàng";
            this.rbtMatHang.UseVisualStyleBackColor = true;
            this.rbtMatHang.CheckedChanged += new System.EventHandler(this.rbtTatCa_CheckedChanged);
            // 
            // rbtDichVu
            // 
            this.rbtDichVu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtDichVu.AutoSize = true;
            this.rbtDichVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtDichVu.ForeColor = System.Drawing.Color.White;
            this.rbtDichVu.Location = new System.Drawing.Point(434, 108);
            this.rbtDichVu.Name = "rbtDichVu";
            this.rbtDichVu.Size = new System.Drawing.Size(79, 20);
            this.rbtDichVu.TabIndex = 5;
            this.rbtDichVu.TabStop = true;
            this.rbtDichVu.Text = "DỊch vụ";
            this.rbtDichVu.UseVisualStyleBackColor = true;
            this.rbtDichVu.CheckedChanged += new System.EventHandler(this.rbtTatCa_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(497, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Từ ngày";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(760, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tới ngày";
            // 
            // rbtPhong
            // 
            this.rbtPhong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtPhong.AutoSize = true;
            this.rbtPhong.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtPhong.ForeColor = System.Drawing.Color.White;
            this.rbtPhong.Location = new System.Drawing.Point(529, 108);
            this.rbtPhong.Name = "rbtPhong";
            this.rbtPhong.Size = new System.Drawing.Size(72, 20);
            this.rbtPhong.TabIndex = 5;
            this.rbtPhong.TabStop = true;
            this.rbtPhong.Text = "Phòng";
            this.rbtPhong.UseVisualStyleBackColor = true;
            this.rbtPhong.CheckedChanged += new System.EventHandler(this.rbtTatCa_CheckedChanged);
            // 
            // cbbItems
            // 
            this.cbbItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbbItems.FormattingEnabled = true;
            this.cbbItems.Location = new System.Drawing.Point(637, 104);
            this.cbbItems.Name = "cbbItems";
            this.cbbItems.Size = new System.Drawing.Size(245, 24);
            this.cbbItems.TabIndex = 7;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.IndianRed;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(907, 99);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(111, 31);
            this.btnThongKe.TabIndex = 8;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // frmDoanhThu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1033, 632);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.cbbItems);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rbtPhong);
            this.Controls.Add(this.rbtDichVu);
            this.Controls.Add(this.rbtMatHang);
            this.Controls.Add(this.rbtTatCa);
            this.Controls.Add(this.mtbToiNgay);
            this.Controls.Add(this.mtbTuNgay);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDoanhThu);
            this.Name = "frmDoanhThu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmDoanhThu";
            this.Load += new System.EventHandler(this.frmDoanhThu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDoanhThu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDoanhThu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mtbTuNgay;
        private System.Windows.Forms.MaskedTextBox mtbToiNgay;
        private System.Windows.Forms.RadioButton rbtTatCa;
        private System.Windows.Forms.RadioButton rbtMatHang;
        private System.Windows.Forms.RadioButton rbtDichVu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rbtPhong;
        private System.Windows.Forms.ComboBox cbbItems;
        private System.Windows.Forms.Button btnThongKe;
    }
}