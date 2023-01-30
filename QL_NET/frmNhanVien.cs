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
    public partial class frmNhanVien : Form
    {
        public frmNhanVien(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private QLNET_DatabaseDataContext db;

        private string nhanvien;

        private DataGridViewRow r;


        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();
            ShowData();


            //chỉnh lại datagriview cho đẹp
            dgvNhanVien.Columns["Password"].Visible = false;// ẩn cột mật khẩu

            dgvNhanVien.Columns["Username"].HeaderText = "Tài khoản";
            dgvNhanVien.Columns["Password"].HeaderText = "Mật khẩu";
            dgvNhanVien.Columns["HoVaTen"].HeaderText = "Họ và tên";
            dgvNhanVien.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";

            dgvNhanVien.Columns["DienThoai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//căn phải

            dgvNhanVien.Columns["Username"].Width = 130;
            dgvNhanVien.Columns["Password"].Width = 100;
            dgvNhanVien.Columns["HoVaTen"].Width = 150;
            dgvNhanVien.Columns["DienThoai"].Width = 130;

            dgvNhanVien.Columns["DiaChi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //tự động co giãn
        }

        private void ShowData()
        {
            var showData = from nv in db.NhanViens
                           select new
                           {
                               nv.Username,
                               nv.Password,
                               nv.HoVaTen,
                               nv.DienThoai,
                               nv.DiaChi
                           };
            dgvNhanVien.DataSource = showData;
        }

        private void txtDienThoai_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaban
            {
                e.Handled = true;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Select();
                return;
            }



            //kiểm tra sự tồn tại của tài khoản trong csdl
            var c = db.NhanViens.Where(x => x.Username.Trim().ToLower() == txtUsername.Text.Trim().ToLower()).Count();
            if (c > 0)
            {
                MessageBox.Show("Tài khoản này đã tồn tại", "rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Select();
                return;
            }

            NhanVien nv = new NhanVien();
            nv.Username = txtUsername.Text.Trim().ToLower();
            nv.Password = txtPassword.Text;
            nv.HoVaTen = txtHoVaTen.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.NguoiTao = nhanvien;
            db.NhanViens.InsertOnSubmit(nv);
            db.SubmitChanges();
            MessageBox.Show("Thêm mới nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset lại giá trị mặc định cho các component
            txtUsername.Text = null;
            txtPassword.Text = null;
            txtHoVaTen.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;



        }



        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvNhanVien.Rows[e.RowIndex];//xác định được 1 hàng vừa click

                //set các giá trị cho component: khi click vào dòng nào thì giá trị sẽ hiển thị lên các textbox và cbb
                txtUsername.Text = r.Cells["Username"].Value.ToString();
                txtPassword.Text = r.Cells["Password"].Value.ToString();
                txtHoVaTen.Text = r.Cells["HoVaTen"].Value.ToString();
                txtDienThoai.Text = r.Cells["DienThoai"].Value.ToString();
                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Select();
                return;
            }
            

            var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["Username"].Value.ToString());
            nv.Username = txtUsername.Text.Trim().ToLower();
            nv.Password = txtPassword.Text;
            nv.HoVaTen = txtHoVaTen.Text;
            nv.DiaChi = txtDiaChi.Text;
            nv.DienThoai = txtDienThoai.Text;
            nv.NguoiCapNhap = nhanvien;
            nv.NgayCapNhap = DateTime.Now;
            
            db.SubmitChanges();
            MessageBox.Show("cập nhật nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset lại giá trị mặc định cho các component
            txtUsername.Text = null;
            txtPassword.Text = null;
            txtHoVaTen.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa tài khoản " + r.Cells["Username"].Value.ToString() + " ?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes
               )
            {
                try
                {
                    var nv = db.NhanViens.SingleOrDefault(x => x.Username == r.Cells["Username"].Value.ToString());
                    db.NhanViens.DeleteOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhân viên thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();// gọi lại hàm ShowData sau khi cập nhập xong
                    r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                    //reset lại giá trị mặc định cho các component
                    
                }
                catch (Exception)
                {

                    MessageBox.Show("Xóa nhân viên thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
