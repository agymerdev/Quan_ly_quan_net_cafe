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
    public partial class frmLoaiPhong : Form
    {
        public frmLoaiPhong(string nhanvien)
        {
            this.nv = nhanvien;
            InitializeComponent();
        }

        

        private string nv;
        private QLNET_DatabaseDataContext db;

        private string nhanvien;
        private void frmLoaiPhong_Load(object sender, EventArgs e)
        {
            db= new QLNET_DatabaseDataContext();
            ShowData();

            //chỉnh lại datagriview cho đẹp
            dgvLoaiPhong.Columns["ID"].HeaderText = "Mã loại";
            dgvLoaiPhong.Columns["TenLoaiPhong"].HeaderText = "Tên loại phòng";
            dgvLoaiPhong.Columns["DonGia"].HeaderText = "Đơn giá";

            //căn chỉnh
            dgvLoaiPhong.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;//căn giữa
            dgvLoaiPhong.Columns["DonGia"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//căn phải

            //Bề rộng cột
            dgvLoaiPhong.Columns["ID"].Width = 100;
            dgvLoaiPhong.Columns["DonGia"].Width = 150;
            dgvLoaiPhong.Columns["TenLoaiPhong"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; //tự động co giãn

            //định dạng phần nghìn cho cột đơn giá
            dgvLoaiPhong.Columns["DonGia"].DefaultCellStyle.Format = "N0";




        }

        private void ShowData()
        {
            var rs = from l in db.LoaiPhongs
                           select new
                           {
                               l.ID,
                               l.TenLoaiPhong,
                               l.DonGia
                           };
            dgvLoaiPhong.DataSource = rs;
                           
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenLoaiPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiPhong.Select();
                return;
            }

            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Select();
                return;
            }

            LoaiPhong l = new LoaiPhong();//tạo đối tượng
            l.TenLoaiPhong = txtTenLoaiPhong.Text;
            l.DonGia = int.Parse(txtDonGia.Text);
            l.NgayTao = DateTime.Now;
            l.NguoiTao = nhanvien;

            db.LoaiPhongs.InsertOnSubmit(l);
            db.SubmitChanges();
            MessageBox.Show("thêm mới loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset lại giá trị mặc định cho các component
            txtDonGia.Text = "0";
            txtTenLoaiPhong.Text = null;
            

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaban
            {
                e.Handled = true;
            }
        }

        private DataGridViewRow r;
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(txtTenLoaiPhong.Text))
            {
                MessageBox.Show("Vui lòng nhập tên loại phòng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenLoaiPhong.Select();//set focus con trỏ chuột tại textbox này
                return;
            }
            
            if (string.IsNullOrEmpty(txtDonGia.Text))
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGia.Select();
                if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
                {
                    MessageBox.Show("Vui lòng chọn loại phòng cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }

            var l = db.LoaiPhongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));


            l.TenLoaiPhong = txtTenLoaiPhong.Text;
            l.DonGia = int.Parse(txtDonGia.Text);
            l.NgayCapNhap = DateTime.Now;
            l.NguoiCapNhap = nhanvien;

            
            db.SubmitChanges();
            MessageBox.Show("Cập nhật loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ShowData();

            //reset lại giá trị mặc định cho các component
            txtDonGia.Text = "0";
            txtTenLoaiPhong.Text = null;

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn loại phòng cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa loại phòng " + r.Cells["TenLoaiPhong"].Value.ToString() + " ?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes
               )
            {
                try
                {
                    var l = db.LoaiPhongs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    db.LoaiPhongs.DeleteOnSubmit(l);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa loại phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();// gọi lại hàm ShowData sau khi cập nhập xong
                    r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                    //reset lại giá trị mặc định cho các component
                    txtDonGia.Text = "0";
                    txtTenLoaiPhong.Text = null;
                }
                catch (Exception)
                {

                    MessageBox.Show("Xóa loại phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvLoaiPhong_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                r = dgvLoaiPhong.Rows[e.RowIndex];//xác định được 1 hàng vừa click

                //set các giá trị cho component: khi click vào dòng nào thì giá trị sẽ hiển thị lên các textbox và cbb
                txtTenLoaiPhong.Text = r.Cells["TenLoaiPhong"].Value.ToString();
                
                txtDonGia.Text = r.Cells["DonGia"].Value.ToString();

            }
        }

        private void txtTenLoaiPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
