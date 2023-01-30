namespace QL_NET
{
    partial class frmTonKho
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
            this.dgvTonKho = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.rbtTatCaMatHang = new System.Windows.Forms.RadioButton();
            this.rbtGanHet = new System.Windows.Forms.RadioButton();
            this.rbtDaHet = new System.Windows.Forms.RadioButton();
            this.btnThongKe = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTonKho
            // 
            this.dgvTonKho.AllowUserToAddRows = false;
            this.dgvTonKho.AllowUserToDeleteRows = false;
            this.dgvTonKho.AllowUserToOrderColumns = true;
            this.dgvTonKho.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTonKho.BackgroundColor = System.Drawing.Color.White;
            this.dgvTonKho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTonKho.Location = new System.Drawing.Point(12, 138);
            this.dgvTonKho.Name = "dgvTonKho";
            this.dgvTonKho.ReadOnly = true;
            this.dgvTonKho.RowHeadersWidth = 51;
            this.dgvTonKho.RowTemplate.Height = 24;
            this.dgvTonKho.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTonKho.Size = new System.Drawing.Size(1231, 468);
            this.dgvTonKho.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1011, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "THỐNG KÊ TỒN KHO";
            // 
            // rbtTatCaMatHang
            // 
            this.rbtTatCaMatHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtTatCaMatHang.AutoSize = true;
            this.rbtTatCaMatHang.Checked = true;
            this.rbtTatCaMatHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtTatCaMatHang.ForeColor = System.Drawing.Color.White;
            this.rbtTatCaMatHang.Location = new System.Drawing.Point(695, 91);
            this.rbtTatCaMatHang.Name = "rbtTatCaMatHang";
            this.rbtTatCaMatHang.Size = new System.Drawing.Size(166, 24);
            this.rbtTatCaMatHang.TabIndex = 2;
            this.rbtTatCaMatHang.TabStop = true;
            this.rbtTatCaMatHang.Text = "Tất cả mặt hàng";
            this.rbtTatCaMatHang.UseVisualStyleBackColor = true;
            // 
            // rbtGanHet
            // 
            this.rbtGanHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtGanHet.AutoSize = true;
            this.rbtGanHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtGanHet.ForeColor = System.Drawing.Color.White;
            this.rbtGanHet.Location = new System.Drawing.Point(895, 91);
            this.rbtGanHet.Name = "rbtGanHet";
            this.rbtGanHet.Size = new System.Drawing.Size(96, 24);
            this.rbtGanHet.TabIndex = 3;
            this.rbtGanHet.Text = "Gần hết";
            this.rbtGanHet.UseVisualStyleBackColor = true;
            // 
            // rbtDaHet
            // 
            this.rbtDaHet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rbtDaHet.AutoSize = true;
            this.rbtDaHet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.rbtDaHet.ForeColor = System.Drawing.Color.White;
            this.rbtDaHet.Location = new System.Drawing.Point(1025, 91);
            this.rbtDaHet.Name = "rbtDaHet";
            this.rbtDaHet.Size = new System.Drawing.Size(85, 24);
            this.rbtDaHet.TabIndex = 4;
            this.rbtDaHet.Text = "Đã hết";
            this.rbtDaHet.UseVisualStyleBackColor = true;
            // 
            // btnThongKe
            // 
            this.btnThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThongKe.BackColor = System.Drawing.Color.IndianRed;
            this.btnThongKe.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.btnThongKe.ForeColor = System.Drawing.Color.White;
            this.btnThongKe.Location = new System.Drawing.Point(1116, 89);
            this.btnThongKe.Name = "btnThongKe";
            this.btnThongKe.Size = new System.Drawing.Size(127, 29);
            this.btnThongKe.TabIndex = 5;
            this.btnThongKe.Text = "Thống kê";
            this.btnThongKe.UseVisualStyleBackColor = false;
            this.btnThongKe.Click += new System.EventHandler(this.btnThongKe_Click);
            // 
            // frmTonKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.IndianRed;
            this.ClientSize = new System.Drawing.Size(1255, 618);
            this.Controls.Add(this.btnThongKe);
            this.Controls.Add(this.rbtDaHet);
            this.Controls.Add(this.rbtGanHet);
            this.Controls.Add(this.rbtTatCaMatHang);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvTonKho);
            this.Name = "frmTonKho";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmTonKho";
            this.Load += new System.EventHandler(this.frmTonKho_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTonKho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTonKho;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbtTatCaMatHang;
        private System.Windows.Forms.RadioButton rbtGanHet;
        private System.Windows.Forms.RadioButton rbtDaHet;
        private System.Windows.Forms.Button btnThongKe;
    }
}