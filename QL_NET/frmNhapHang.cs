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
using System.Globalization;

namespace QL_NET
{
    public partial class frmNhapHang : Form
    {
        public frmNhapHang(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }

        private QLNET_DatabaseDataContext db;

        private string nhanvien ;

        private DataGridViewRow r;
        private void ShowData()
        {
            var rs = from o in db.HoaDonNhaps
                     join n in db.NhaCungCaps on o.IDNhaCC equals n.ID
                     join c in db.NhanViens on o.NhanVienNhap equals c.Username

                     select new
                     {
                         id = o.ID,
                         NgayNhap = o.NgayNhap,
                         TenNCC = n.TenNCC,
                         danhap = o.DaNhap,
                         trangthai = o.DaNhap == 1 ? "Đã nhập" : "Yêu cầu",
                         tongtien = db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == o.ID).Sum(y => y.SoLuong * y.DonGiaNhap),//tổng tiền được tính dựa vào tổng các mặt hàng: sl*dg tương ứng với hóa đơn, 
                         //không bao gồm thành tiền của các mặt hàng quy đổi
                         dathanhtoan = o.TienThanhToan
                     };

            dgvHoaDonNhap.DataSource = rs;
        }
        private void frmNhapHang_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();
            mtbNgayNhap.Text = DateTime.Now.ToString("dd//MM//yyyy");

            cbbNhanVienNhap.DataSource = db.NhanViens;
            cbbNhanVienNhap.DisplayMember = "HoVaTen";
            cbbNhanVienNhap.ValueMember = "Username";
            cbbNhanVienNhap.SelectedIndex = -1;

            cbbNhaCungCap.DataSource = db.NhaCungCaps;
            cbbNhaCungCap.DisplayMember = "TenNCC";
            cbbNhaCungCap.ValueMember = "ID";
            cbbNhaCungCap.SelectedIndex = -1;

            ShowData();
            dgvHoaDonNhap.Columns["danhap"].Visible = false;

            dgvHoaDonNhap.Columns["ID"].HeaderText = "ID phiếu";
            dgvHoaDonNhap.Columns["NgayNhap"].HeaderText = "Ngày nhập";
            dgvHoaDonNhap.Columns["TenNCC"].HeaderText = "Nhà cung cấp";
            dgvHoaDonNhap.Columns["trangthai"].HeaderText = "Trạng thái";
            dgvHoaDonNhap.Columns["tongtien"].HeaderText = "Tổng tiền";
            dgvHoaDonNhap.Columns["dathanhtoan"].HeaderText = "Đã thanh toán";

            dgvHoaDonNhap.Columns["ID"].Width = 100;
            dgvHoaDonNhap.Columns["NgayNhap"].Width = 100;
            dgvHoaDonNhap.Columns["trangthai"].Width = 100;
            dgvHoaDonNhap.Columns["tongtien"].Width = 100;
            dgvHoaDonNhap.Columns["dathanhtoan"].Width = 100;
            dgvHoaDonNhap.Columns["TenNCC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvHoaDonNhap.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonNhap.Columns["trangthai"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvHoaDonNhap.Columns["tongtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvHoaDonNhap.Columns["dathanhtoan"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dgvHoaDonNhap.Columns["tongtien"].DefaultCellStyle.Format = "N0";
            dgvHoaDonNhap.Columns["dathanhtoan"].DefaultCellStyle.Format = "N0";



        }

        #region
        //ý tưởng:khi double click vào 1 dòng trên datagriview sẽ:
        //1: xem được thông tin chi tiết của phiếu nhập hàng
        //2: sửa,xóa các mặt hàng có trong phiếu nhập hàng nếu trạng thái của phiếu nhập chưa xác thực vào kho
        //=> cần có 2 thông tin: 1 id phiếu, 2 trạng thái của phiếu
        //ta sẽ dùng form frmChiTietHoaDonNhap để vừa thêm mới mặt hàng vào đơn nhập
        //vừa dùng để chỉnh sửa hóa đơn nhập khi trạng thái danhap = false hoặc null
        #endregion
        private void btnThem_Click(object sender, EventArgs e)
        {
            DateTime ngaynhap;
            try
            {
                ngaynhap = DateTime.ParseExact(mtbNgayNhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //CultureInfo trong thư viện System.Globalization
                //Giá trị mặc định là CultureInfo.InstalledUICulturevì vậy CultureInfo mặc định phụ thuộc vào cài đặt của hệ điều hành đang thực thi
                //giúp đổi thông tin về ngày / giá trị thập phân / tiền tệ phụ thuộc vào nền văn hóa của hệ điều hành đang thực thi
            }
            catch (Exception)
            {

                MessageBox.Show("Ngày nhập không hợp lệ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            //nhân viên nhập hàng sẽ là người phụ trách kiểm tra hàng hóa khi nhập kho
            if (cbbNhanVienNhap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên nhập hàng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var od = new HoaDonNhap();
                od.NhanVienNhap = cbbNhanVienNhap.SelectedValue.ToString();
                od.IDNhaCC = int.Parse(cbbNhaCungCap.SelectedValue.ToString());
                od.NgayNhap = ngaynhap;

                od.Ngaytao = DateTime.Now;
                od.NguoiTao = nhanvien;

                db.HoaDonNhaps.InsertOnSubmit(od);
                db.SubmitChanges();
                MessageBox.Show("Tạo mới hóa đơn nhập hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var idHDNhap = db.HoaDonNhaps.Max(x => x.ID);
                //với hóa đơn nhập mới, trạng thái nhập kho sẽ là false = đang yêu cầu nhập hàng
                new frmChiTietHoaDonNhap(idHDNhap, 0).ShowDialog();//truyền mã hóa đơn
                ShowData();

                //thiết lập lại các compponent
                cbbNhanVienNhap.SelectedIndex = -1;
                cbbNhaCungCap.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Tạo hóa đơn nhập hàng thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {

            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            DateTime ngaynhap;
            try
            {
                ngaynhap = DateTime.ParseExact(mtbNgayNhap.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //CultureInfo trong thư viện System.Globalization
                //Giá trị mặc định là CultureInfo.InstalledUICulturevì vậy CultureInfo mặc định phụ thuộc vào cài đặt của hệ điều hành đang thực thi
                //giúp đổi thông tin về ngày / giá trị thập phân / tiền tệ phụ thuộc vào nền văn hóa của hệ điều hành đang thực thi
            }
            catch (Exception)
            {

                MessageBox.Show("Ngày nhập không hợp lệ", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }



            //nhân viên nhập hàng sẽ là người phụ trách kiểm tra hàng hóa khi nhập kho
            if (cbbNhanVienNhap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhân viên nhập hàng", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbNhaCungCap.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
               
                var od = db.HoaDonNhaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
                od.NhanVienNhap = cbbNhanVienNhap.SelectedValue.ToString();
                od.IDNhaCC = int.Parse(cbbNhaCungCap.SelectedValue.ToString());
                od.NgayNhap = ngaynhap;

                od.Ngaytao = DateTime.Now;
                od.NguoiTao = nhanvien;

               
                db.SubmitChanges();
                MessageBox.Show("cập nhật hóa đơn nhập hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                
                
                
                ShowData();

                //thiết lập lại các compponent
                cbbNhanVienNhap.SelectedIndex = -1;
                cbbNhaCungCap.SelectedIndex = -1;

            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "cập nhật đơn nhập hàng thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // if (r == null)
            //{
            //    MessageBox.Show("Vui lòng chọn phiếu nhập cần xóa", "chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //    return;
            //}
            //if (MessageBox.Show("Bạn có thật sự muốn xóa phiếu nhập " + r.Cells["ID"].Value.ToString() + " ?",
            //   "Xác nhận xóa",
            //   MessageBoxButtons.YesNo,
            //   MessageBoxIcon.Question) == DialogResult.Yes
            //   )
            //{
            //    try
            //    {
            //        var od = db.HoaDonNhaps.SingleOrDefault(x => x.ID == int.Parse(r.Cells["ID"].Value.ToString()));
            //        db.HoaDonNhaps.DeleteOnSubmit(od);
            //        db.SubmitChanges();
            //        MessageBox.Show("Xóa phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //        ShowData();// gọi lại hàm ShowData sau khi cập nhập xong
            //        r = null;//sau khi cập nhập xong thì set r = null ==> không hàng nào còn được chọn trên datagriview

            //        //reset lại giá trị mặc định cho các component
            //        cbbNhanVienNhap.SelectedIndex = -1;
            //        cbbNhaCungCap.SelectedIndex = -1;

            //    }
            //    catch (Exception)
            //    {

            //        MessageBox.Show("Xóa phiếu nhập thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
        }

       

        private void dgvHoaDonNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvHoaDonNhap.Rows[e.RowIndex];//xác định được 1 hàng vừa click

                //set các giá trị cho component: khi click vào dòng nào thì giá trị sẽ hiển thị lên các textbox và cbb
                
               
                cbbNhaCungCap.Text = r.Cells["TenNCC"].Value.ToString();

            }
        }

        private void dgvHoaDonNhap_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvHoaDonNhap.Rows[e.RowIndex];

                //khi double click vào hàng của datagriview => lấy được hóa đơn nhập tương ứng
                //từ đó truyền qua 2 giá trị: mã đơn nhập và trạng thái đơn nhập
                byte danhapkho = r.Cells["danhap"].Value == null ? (byte)0 : byte.Parse(r.Cells["danhap"].Value.ToString());
                new frmChiTietHoaDonNhap(long.Parse(r.Cells["ID"].Value.ToString()), danhapkho).ShowDialog();
                ShowData();
            }
        }
    }
}
