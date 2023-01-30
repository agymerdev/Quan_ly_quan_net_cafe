using QL_NET.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NET
{
    public partial class frmDoiMatKhau : Form
    {
        public frmDoiMatKhau(NhanVien nv)
        {
            this.nv = nv;
            InitializeComponent();
        }
        private NhanVien nv;
        private QLNET_DatabaseDataContext db;
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
             db = new QLNET_DatabaseDataContext();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMatKhauHienTai.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu hiện tại", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauHienTai.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtMatKhauMoi.Text) || string.IsNullOrEmpty(txtXacNhanMatKhauMoi.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Select();
                return;
            }
            if (string.IsNullOrEmpty(txtXacNhanMatKhauMoi.Text))
            {
                MessageBox.Show("Nhập mật khẩu không khớp", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauMoi.Select();
                return;
            }



            var tk = db.NhanViens.SingleOrDefault(x => x.Username == nv.Username && x.Password == txtMatKhauHienTai.Text);
            if (tk == null)
            {
                MessageBox.Show("Mật khẩu hiện tại không đúng", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhauHienTai.Select();
                return;
            }
            
            tk.Password = txtXacNhanMatKhauMoi.Text;
            tk.NguoiCapNhap = nv.Username;
            tk.NgayCapNhap = DateTime.Now;
            db.SubmitChanges();
            MessageBox.Show("Đổi mật khẩu thành công", "Nice", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Dispose();
        }


    }
}
