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
    public partial class frmNhaCC : Form
    {
        public frmNhaCC(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private QLNET_DatabaseDataContext db;

        private string nhanvien;

        private DataGridViewRow r;

        private void frmNhaCC_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();
            ShowData();

            dgvNhaCC.Columns["ID"].Visible = false;//ẩn cột ID
            dgvNhaCC.Columns["TenNCC"].HeaderText = "Tên nhà cung cấp";
            dgvNhaCC.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvNhaCC.Columns["DienThoai"].HeaderText = "Điện thoại";
            dgvNhaCC.Columns["Email"].HeaderText = "Email";

            dgvNhaCC.Columns["DiaChi"].Width = 200;
            dgvNhaCC.Columns["DienThoai"].Width = 100;
            dgvNhaCC.Columns["Email"].Width = 200;
            dgvNhaCC.Columns["TenNCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;



        }

        private void ShowData()
        {
            var showData = from n in db.NhaCungCaps
                           select new
                           {
                               n.ID,
                               n.TenNCC,
                               n.DiaChi,
                               n.DienThoai,
                               n.Email
                           };
            dgvNhaCC.DataSource = showData;
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
            if (string.IsNullOrEmpty(txtTenNhaCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhaCC.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Select();
                return;
            }

           

            NhaCungCap ncc = new NhaCungCap();
            ncc.TenNCC = txtTenNhaCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.DienThoai = txtDienThoai.Text;
            ncc.Email = txtEmail.Text;
            ncc.NgayTao = DateTime.Now;
            ncc.NguoiTao = nhanvien;

            db.NhaCungCaps.InsertOnSubmit(ncc);
            db.SubmitChanges();

            MessageBox.Show("Thêm mới nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset lại các component
            txtTenNhaCC.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Text = null;

        }

        private void dgvNhaCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >=0)
            {
                r = dgvNhaCC.Rows[e.RowIndex];//xác định được 1 hàng vừa click

                //set các giá trị cho component: khi click vào dòng nào thì giá trị sẽ hiển thị lên các textbox và cbb
                txtTenNhaCC.Text = r.Cells["TenNCC"].Value.ToString();

                txtDiaChi.Text = r.Cells["DiaChi"].Value.ToString();

                txtDienThoai.Text = r.Cells["DienThoai"].Value.ToString();

                txtEmail.Text = r.Cells["Email"].Value.ToString();


            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenNhaCC.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenNhaCC.Select();//set focus con trỏ chuột tại textbox này
                return;
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập địa chỉ nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDiaChi.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDienThoai.Select();
                if (r == null)
                {
                    MessageBox.Show("Vui lòng chọn nhà cung cấp cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }

            var ncc = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));

            ncc.TenNCC = txtTenNhaCC.Text;
            ncc.DiaChi = txtDiaChi.Text;
            ncc.DienThoai = txtDienThoai.Text;
            ncc.Email = txtEmail.Text;
            ncc.NgayCapNhap = DateTime.Now;
            ncc.NguoiCapNhap = nhanvien;
            

            
            db.SubmitChanges();

            MessageBox.Show("Thêm mới nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset lại các component
            txtTenNhaCC.Text = null;
            txtDiaChi.Text = null;
            txtDienThoai.Text = null;
            txtEmail.Text = null;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa nhà cung cấp " + r.Cells["TenNCC"].Value.ToString() + " ?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes
               )
            {
                try
                {
                    var l = db.NhaCungCaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    db.NhaCungCaps.DeleteOnSubmit(l);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa nhà cung cấp thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();
                    r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                    //reset lại các component
                    txtTenNhaCC.Text = null;
                    txtDiaChi.Text = null;
                    txtDienThoai.Text = null;
                    txtEmail.Text = null;
                }
                catch (Exception)
                {

                    MessageBox.Show("Xóa nhà cung cấp thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
