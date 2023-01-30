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
    public partial class frmMatHang : Form
    {
        public frmMatHang(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }
        private QLNET_DatabaseDataContext db;

        private string nhanvien ;
        private DataGridViewRow r;

        private void frmMatHang_Load(object sender, EventArgs e)
        {
            
            db = new QLNET_DatabaseDataContext();

            cbbMatHangGoc.DataSource = db.MatHangs.Where(x => x.IdCha == null || x.IdCha == -1);//id cha bằng null hoặc -1=> không có mặt hàng nào là cha
            //vd: thùng sting sẽ có id là null vì đơn vị thùng là lớn nhất
            cbbMatHangGoc.DisplayMember = "TenMatHang";
            cbbMatHangGoc.ValueMember = "ID";
            cbbMatHangGoc.SelectedIndex = -1;

            ShowData();

            dgvMatHang.Columns["idcha"].Visible = false;
            dgvMatHang.Columns["tile"].Visible = false;


            //truyền dữ liệu cho combobox dvt(cbbDVT)
            cbbDVT.DataSource = db.DonViTinhs;
            cbbDVT.DisplayMember = "TenDVT";//thuộc tính hiển thị
            cbbDVT.ValueMember = "id";//thuộc tính giá trị ngầm(mã của đơn vị tính)

            cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết


            //chỉnh lại cột của datagridview cho đẹp
            dgvMatHang.Columns["ID"].Width = 100;//set bề rộng cố định 
            dgvMatHang.Columns["TenDVT"].Width = 100;//set bề rộng cố định
            dgvMatHang.Columns["DonGiaBan"].Width = 100;//set bề rộng cố định 
            dgvMatHang.Columns["TenMatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//tự động co giãn theo độ rộng của form

            //căn chỉnh vị trí
            dgvMatHang.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//căn giữa cho mã hàng
            dgvMatHang.Columns["TenDVT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;//căn giữa cho đơn vị tính
            dgvMatHang.Columns["DonGiaBan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;//căn phải cho đơn giá bán
            dgvMatHang.Columns["DonGiaBan"].DefaultCellStyle.Format = "N0";//phân cách phần nghìn

            //đặt lại tên cột
            dgvMatHang.Columns["ID"].HeaderText = "Mã hàng";
            dgvMatHang.Columns["TenDVT"].HeaderText = "ĐVT";
            dgvMatHang.Columns["DonGiaBan"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["TenMatHang"].HeaderText = "Tên mặt hàng";

        }

        private void ShowData()
        {
            var rs = from h in db.MatHangs
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         h.ID,
                         h.IdCha,
                         h.tile,
                         h.TenMatHang,
                         d.TenDVT,
                         h.DonGiaBan

                     };
            dgvMatHang.DataSource = rs;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenMatHang.Text))//kiểm tra tính hợp lệ của tên mặt hàng(không được để trống)
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMatHang.Select();//set focus con trỏ chuột tại textbox này
                return;//dừng ngang đây và không thực hiện những câu lệnh dưới
            }
            if (cbbDVT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text))//kiểm tra tính hợp lệ của tên mặt hàng(không được để trống)
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Select();//set focus tại textbox này
                return;
            }


            int idCha = -1;
            int tile = 0;
            if (cbbMatHangGoc.SelectedIndex >= 0)// nếu chọn 1 mặt hàng làm cha thì có nghĩa phải tồn tại tỉ lệ quy đổi
            {
                idCha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                try
                {
                    tile = int.Parse(txtTiLe.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLe.Select();
                        return;

                    }
                }
                catch
                {

                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLe.Select();
                    return;
                }
            }


            var mh = new MatHang();
            mh.TenMatHang = txtTenMatHang.Text;
            mh.IDDVT = int.Parse(cbbDVT.SelectedValue.ToString()); //vì giá trị nhận được từ combobox là string
            //trong khi iddvt trong csdl là kiểu int ==> ép kiểu string qua int
            mh.DonGiaBan = int.Parse(txtDonGiaBan.Text);//giá trị từ txtDonGiaBan nhận đc là string ==> ép kiểu qua int
            mh.IdCha = idCha;
            mh.tile = tile;
            mh.NgayTao = DateTime.Now;
            mh.NguoiTao = nhanvien;
            mh.isDichVu = rbtDichVu.Checked ? (byte)1 : (byte)0;

            db.MatHangs.InsertOnSubmit(mh);//thêm mặt hàng mới vào csdl
            db.SubmitChanges();//lưu

            ShowData();//sau khi thêm mới xong thì cập nhật lại danh sách mặt hàng
            MessageBox.Show("Thêm mới mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //reset lại giá trị cho các component(thành phần)
            txtTenMatHang.Text = null;
            txtDonGiaBan.Text = "0";
            cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết
        }

        private void txtDonGiaBan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaban
            {
                e.Handled = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //dùng sự kiện click trên datagriview để lấy ra mặt hàng nào đc click và xác định được mặt hàng cần cập nhật
            //dựa vào sự kiện click để lấy đc các thông tin mặt hàng như mã, tên , đvt, đơn giá bán

            //tìm ra mặt hàng trong csdl cần được cập nhập dựa vào khóa chính là id của mặt hàng
            var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
            //vì mặt hàng chỉ tồn tại duy nhất 1 mã - khóa chính nên dùng singleordefault 

            if (r == null)//nếu chưa có hàng nào được chọn trên datagriview dgvDVT
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng chương trình và không thực hiện các câu lệnh phí dưới
            }
            //rằng buộc dữ liệu
            if (string.IsNullOrEmpty(txtTenMatHang.Text))//kiểm tra tính hợp lệ của tên mặt hàng(không được để trống)
            {
                MessageBox.Show("Vui lòng nhập tên mặt hàng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTenMatHang.Select();//set focus con trỏ chuột tại textbox này
                return;
            }
            if (cbbDVT.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn đơn vị tính", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(txtDonGiaBan.Text))//kiểm tra tính hợp lệ của tên mặt hàng(không được để trống)
            {
                MessageBox.Show("Vui lòng nhập đơn giá", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDonGiaBan.Select();//set focus tại textbox này
                if (r == null)//nếu chưa có hàng nào được chọn trên datagriview 
                {
                    MessageBox.Show("Vui lòng chọn mặt hàng cần cập nhật", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                return;
            }

            int idCha = -1;
            int tile = 0;
            if (cbbMatHangGoc.SelectedIndex >= 0)//nếu chọn 1 mặt hàng làm cha thì có nghĩa phải tồn tại tỉ lệ quy đổi
            {
                idCha = int.Parse(cbbMatHangGoc.SelectedValue.ToString());
                //
                try
                {
                    tile = int.Parse(txtTiLe.Text);
                    if (tile <= 0)
                    {
                        MessageBox.Show("Tỉ lệ quy đổi phải lớn hơn 0", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTiLe.Select();
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("Tỉ lệ quy đổi không hợp lệ", "Ràng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtTiLe.Select();
                    return;
                }
            }


            //cập nhập lại các giá trị cho mặt hàng vừa được tìm thấy ở trên
            mh.TenMatHang = txtTenMatHang.Text;
            mh.IDDVT = int.Parse(cbbDVT.SelectedValue.ToString());
            mh.DonGiaBan = int.Parse(txtDonGiaBan.Text);

            mh.NgayCapNhap = DateTime.Now;
            mh.NguoiTao = nhanvien;
            mh.NguoiCapNhap = nhanvien;
            mh.isDichVu = rbtDichVu.Checked ? (byte)1 : (byte)0;

            db.SubmitChanges();
            ShowData();//sau khi thêm mới xong thì cập nhật lại danh sách mặt hàng
            MessageBox.Show("Cập nhật mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //reset lại giá trị cho các component(thành phần)
            txtTenMatHang.Text = null;
            txtDonGiaBan.Text = "0";
            cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];//xác định được 1 hàng vừa click

                //set các giá trị cho component: khi click vào dòng nào thì giá trị sẽ hiển thị lên các textbox và cbb
                txtTenMatHang.Text = r.Cells["TenMatHang"].Value.ToString();
                cbbDVT.Text = r.Cells["TenDVT"].Value.ToString();
                txtDonGiaBan.Text = r.Cells["DonGiaBan"].Value.ToString();
                txtTiLe.Text = r.Cells["tile"].Value == null ? "0" : r.Cells["tile"].Value.ToString();

                if (r.Cells["idcha"].Value == null || r.Cells["idcha"].Value.ToString() == "-1")
                {
                    cbbMatHangGoc.SelectedIndex = -1;
                }
                else
                {
                    var item = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["idcha"].Value.ToString()));
                    cbbMatHangGoc.Text = item.TenMatHang;
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;//dừng chương trình và không thực hiện các câu lệnh phí dưới
            }
            if (MessageBox.Show("Bạn có thật sự muốn xóa mặt hàng " + r.Cells["TenMatHang"].Value.ToString() + " ?",
               "Xác nhận xóa",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes
               )
            {
                try
                {
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                    db.MatHangs.DeleteOnSubmit(mh);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowData();// gọi lại hàm ShowData sau khi cập nhập xong
                    r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

                    //reset lại giá trị cho các component(thành phần)
                    txtTenMatHang.Text = null;
                    txtDonGiaBan.Text = "0";
                    cbbDVT.SelectedIndex = -1;//không chọn đơn vị tính nào hết
                }
                catch (Exception)
                {

                    MessageBox.Show("Xóa mặt hàng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            var showData = (from h in db.MatHangs
                            join d in db.DonViTinhs on h.IDDVT equals d.ID
                            select new
                            {
                                h.ID,
                                h.TenMatHang,
                                d.TenDVT,
                                h.DonGiaBan
                            }).Where
                            (
                x => x.TenMatHang.ToLower().Contains(txtTuKhoa.Text.ToLower()) ||
                x.TenDVT.ToLower().Contains(txtTuKhoa.Text.ToLower())
                );

            dgvMatHang.DataSource = showData;


        }

        private void rbtDichVu_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtMatHang.Checked)
            {
                cbbMatHangGoc.Enabled = true;
                txtTiLe.Enabled = true;
            }
            else
            {
                cbbMatHangGoc.Enabled = false;
                cbbMatHangGoc.SelectedIndex = -1;//không chọn item nào cả
                txtTiLe.Text = "0";//mặc định bằng 0
                txtTiLe.Enabled = false;
            }
        }
    }
}
