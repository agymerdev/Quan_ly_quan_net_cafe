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
    public partial class frmPhong : Form
    {
        public frmPhong(string nhanvien)
        {
            this.nhanvien = nhanvien;
            InitializeComponent();
        }

        private QLNET_DatabaseDataContext db;

        private string nhanvien ;
        private DataGridViewRow r;
        private void frmPhong_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();
            ShowData();

            //truyền dữ liệu cho cbbLoaiPhong
            cbbLoaiPhong.DataSource = db.LoaiPhongs;
            cbbLoaiPhong.DisplayMember = "TenLoaiPhong";//thuộc tính hiển thị
            cbbLoaiPhong.ValueMember = "ID";//thuộc tính giá trị: ID-Mã loại phòng
            cbbLoaiPhong.SelectedIndex = -1;//mặc định không chọn loại phòng nào

            //chỉnh lại cột của datagridview cho đẹp
            dgvPhong.Columns["ID"].Width = 80;//set bề rộng cố định 
            dgvPhong.Columns["TenLoaiPhong"].Width = 105;//set bề rộng cố định
            dgvPhong.Columns["DonGia"].Width = 100;//set bề rộng cố định 
            dgvPhong.Columns["TenPhong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//tự động co giãn theo độ rộng của form
            dgvPhong.Columns["SucChua"].Width = 80;//set bề rộng cố định 


            //căn chỉnh vị trí
            dgvPhong.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvPhong.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvPhong.Columns["DonGia"].DefaultCellStyle.Format = "N0";
            dgvPhong.Columns["SucChua"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //đặt lại tên cột
            dgvPhong.Columns["ID"].HeaderText = "Mã Phòng";
            dgvPhong.Columns["TenLoaiPhong"].HeaderText = "Tên loại phòng";
            dgvPhong.Columns["TenPhong"].HeaderText = "Tên Phòng";
            dgvPhong.Columns["DonGia"].HeaderText = "Đơn Giá";
            dgvPhong.Columns["SucChua"].HeaderText = "Sức chứa";


        }

        private void ShowData()
        {
            //2 bảng Phong và LoaiPhong quan hệ với nhau 1-n
            //Dựa vào khóa ngoại [IDLoaiphong]
            //để lấy 2 bảng => sử dụng join trong linq
            var showData = from p in db.Phongs
                           join l in db.LoaiPhongs on p.IDLoaiPhong equals l.ID
                           select new
                           {
                               p.ID,
                               l.TenLoaiPhong,
                               p.TenPhong,
                               l.DonGia,
                               p.SucChua

                           };
            dgvPhong.DataSource = showData;//lấy dữ liệu truyền vào datagridview
                           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            if (cbbLoaiPhong.SelectedIndex <0)
            {
                MessageBox.Show("Vui lòng chọn loại phòng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text)<=0)
            {
                MessageBox.Show("Vui lòng nhập sức chứa(lớn hơn 0)", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucChua.Select();
                return;
            }

            var p = new Phong();

            p.TenPhong = txtTenPhong.Text;
            p.IDLoaiPhong = int.Parse(cbbLoaiPhong.SelectedValue.ToString());
            p.SucChua = int.Parse(txtSucChua.Text);

            p.NgayTao = DateTime.Now;
            p.NguoiTao = nhanvien;

            db.Phongs.InsertOnSubmit(p);
            db.SubmitChanges();

            MessageBox.Show("Thêm mới phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //thiết lập lại giá trị mặc định các component
            txtSucChua.Text = txtTenPhong.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;

               


        }

        private void txtSucChua_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaban
            {
                e.Handled = true;
            }
        }

        private void dgvPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvPhong.Rows[e.RowIndex];//xác định được 1 hàng vừa click

                //set các giá trị cho component: khi click vào dòng nào thì giá trị sẽ hiển thị lên các textbox và cbb
                txtTenPhong.Text = r.Cells["TenPhong"].Value.ToString();
                txtSucChua.Text = r.Cells["SucChua"].Value.ToString();
                cbbLoaiPhong.Text = r.Cells["TenLoaiPhong"].Value.ToString();

            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
            {
                MessageBox.Show("Vui lòng chọn phòng cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên phòng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenPhong.Select();
                return;
            }

            if (cbbLoaiPhong.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn phòng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtSucChua.Text) || int.Parse(txtSucChua.Text) <= 0)
            {
                MessageBox.Show("Vui lòng nhập sức chứa(lớn hơn 0)", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSucChua.Select();
                if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
                {
                    MessageBox.Show("Vui lòng chọn phòng cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }

            var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));

            p.TenPhong = txtTenPhong.Text;
            p.SucChua = int.Parse(txtSucChua.Text);
            p.NgayTao = DateTime.Now;
            p.NguoiTao = nhanvien;

            db.SubmitChanges();
            MessageBox.Show("Cập nhật phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //thiết lập lại giá trị mặc định các component
            txtSucChua.Text = txtTenPhong.Text = null;
            cbbLoaiPhong.SelectedIndex = -1;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn phòng cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa phòng " + r.Cells["TenPhong"].Value.ToString() + " ?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes
               )
            {
                try
                {
                    var p = db.Phongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    db.Phongs.DeleteOnSubmit(p);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();// gọi lại hàm ShowData sau khi cập nhập xong
                    r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                    //reset lại giá trị mặc định cho các component
                    txtSucChua.Text = txtTenPhong.Text = null;
                    cbbLoaiPhong.SelectedIndex = -1;

                }
                catch (Exception)
                {

                    MessageBox.Show("Xóa phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
