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
    public partial class frmDangNhap : Form
    {
        public frmDangNhap()
        {


            InitializeComponent();
        }
        private QLNET_DatabaseDataContext db;
        public NhanVien nv;


        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void frmDangNhap_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();
            //truyền dữ liệu cho cbb
            cbbLoaiTK.DataSource = db.LoaiTKs;
            cbbLoaiTK.DisplayMember = "TenLoaiTK";//thuộc tính hiển thị
            cbbLoaiTK.ValueMember = "ID";//thuộc tính giá trị: ID-Mã loại phòng
            cbbLoaiTK.SelectedIndex = -1;//mặc định không chọn loại phòng nào
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTaiKhoan.Text) || string.IsNullOrEmpty(txtMatKhau.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTaiKhoan.Select();
                return;
            }

            QLNET_DatabaseDataContext db = new QLNET_DatabaseDataContext();

            var tk = db.NhanViens.SingleOrDefault(x => x.Username == txtTaiKhoan.Text && x.Password == txtMatKhau.Text && x.ID != 0);
            if (tk != null)
            {
                if ((cbbLoaiTK.SelectedIndex == 0) && tk.ID == 1)
                {

                    nv = tk;

                    this.Dispose();

                }
                else if ((cbbLoaiTK.SelectedIndex == 1) && tk.ID == 2)
                {

                    nv = tk;

                    this.Dispose();

                }
                else
                {
                    MessageBox.Show("Vui lòng kiểm tra lại tài khoản và mật khẩu", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTaiKhoan.Select();
                    return;
                }
                return;
            }



        }
    }
}
