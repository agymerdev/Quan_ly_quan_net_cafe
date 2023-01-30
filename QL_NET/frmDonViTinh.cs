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
    public partial class frmDonViTinh : Form
    {
        public frmDonViTinh(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }
        private QLNET_DatabaseDataContext db;
        private string nhanvien;
        private void frmDonViTinh_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();//khởi tạo đối tượng datacontext
            ShowData();

            dgvDVT.Columns["ID"].HeaderText = "Mã ĐVT";//đổi tên hiển thị khi xuất ra datagriview 
            dgvDVT.Columns["ID"].Width = 100;//bề rộng cột
            dgvDVT.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//căn giữa cột            

            dgvDVT.Columns["TenDVT"].HeaderText = "Tên ĐVT";//đổi tên hiển thị khi xuất ra datagriview 
            dgvDVT.Columns["TenDVT"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//bề rộng tự động co giãn
        }

        // tạo phương thức lấy dữ liêu từ database vào dgv
        private void ShowData()
        {
            //dgvDVT.DataSource = db.DonViTinhs.ToList(); //truyền hết dữ liệu trong db vào dgv
            var rs = (from d in db.DonViTinhs
                          select new
                          {
                              d.ID,
                              d.TenDVT

                          }).ToList();// Tolist: toán tử trong Linq chuyển đổi tập hợp thành danh sách
            dgvDVT.DataSource = rs;//lấy ds đơn vị tính lên datagridview có tên dgvDVT
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtDVT.Text))//nếu textbox txtDVT không là gt null
            {
                DonViTinh dvt = new DonViTinh();
                dvt.TenDVT = txtDVT.Text;//gán tên
                dvt.NguoiTao = nhanvien;//gán nhân viên tạo
                dvt.NgayTao = DateTime.Now;//gán ngày giờ tạo
                db.DonViTinhs.InsertOnSubmit(dvt);// thêm dvt vào csdl
                db.SubmitChanges();//lưu vào csdl
                MessageBox.Show("thêm mới đơn vị tính thành công", "Successfully!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();// gọi hàm ShowData để cập nhập lại danh sách hiển thị
                txtDVT.Text = null;//sau khi thêm thành công thì reset lại giá trị của textbox thành null.
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đơn vị tính", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private DataGridViewRow r;

        private void dgvDVT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show(e.RowIndex.ToString());//e.RowIndex là chỉ số hàng
            //chỉ số hàng được tính như sau: hàng đầu là 0 hàng 2 là 1(như trong mảng)
            //từ sự kiện click vào hàng để lấy giá trị của hàng và tiến hành cập nhập
            r = dgvDVT.Rows[e.RowIndex];//hàng được chọn dựa vào sự kiện click chuột
            //MessageBox.Show(r.Cells["TenDVT"].Value.ToString());//hiển thị 1 msbox tên của đơn vị tính khi clik vào
            txtDVT.Text = r.Cells["TenDVT"].Value.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu không có hàng nào của datagriview được chọn
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần cập nhật", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//thì dừng lại mà không thực thi các câu lệnh phía dưới
            }
            if (!string.IsNullOrEmpty(txtDVT.Text))
            {
                //mỗi đối tượng r là 1 hàng thuộc datagriview dgvDVT
                //mỗi hàng gồm có 2 cột ID và TenDVT
                //muốn cập nhập đơn vị tính thì cần dựa vào id của dvt và khóa chính đã thiết kế trước đó
                //vì vậy, đầu tiên cần tìm ra đvt nào cần được cập nhập
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));//vì r.cells["TenDVT"].Value.Tostring() là string, mà id trong csdl lại là int => ép kiểu qua int
                //SingleOrDefault: nhận được phần tử phù hợp duy nhất hoặc giá trị mặc định(trả về 0) nếu không tìm thấy phần tử nào
                dvt.TenDVT = txtDVT.Text;// cập nhập lại tên của đơn vị tính dựa và giá trị của textbox txtDVT
                dvt.NgayCapNhap = DateTime.Now;
                dvt.NguoiCapNhap = nhanvien;
                db.SubmitChanges();//lưu vào csdl

                MessageBox.Show("Cập nhập đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();// gọi lạ hàm ShowData sau khi cập nhập xong
                r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                txtDVT.Text = null;
            }
            else
            {

                MessageBox.Show("Vui lòng chọn đơn vị tính cần cập nhật", "Chú ý!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//thì dừng lại mà không thực thi các câu lệnh phía dưới
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)//nếu chưa có hàng nào được chọn trên datagriview dgvDVT
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng chương trình và không thực hiện các câu lệnh phí dưới
            }

            if (MessageBox.Show("Bạn có thật sự muốn xóa đơn vị tính" + r.Cells["TenDVT"].Value.ToString() + " ?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes
                )
            {
                var dvt = db.DonViTinhs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));//vì r.cells["ID"].Value.Tostring() là string, mà id trong csdl lại là int => ép kiểu qua int
                //SingleOrDefault: nhận được phần tử phù hợp duy nhất hoặc giá trị mặc định(trả về 0) nếu không tìm thấy phần tử nào:
                //bình thường nếu dùng sigle mà k tìm đc phần tử phù hợp chương trình sẽ báo lỗi
                //còn singleordefault k tìm thấy nó tự trả về giá trị mặc định là 0
                db.DonViTinhs.DeleteOnSubmit(dvt);
                db.SubmitChanges();
                MessageBox.Show("Xóa đơn vị tính thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();// gọi lại hàm ShowData sau khi cập nhập xong
                r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                txtDVT.Text = null;
            }
        }
    }
}
