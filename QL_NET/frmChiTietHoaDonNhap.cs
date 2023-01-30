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
    public partial class frmChiTietHoaDonNhap : Form
    {
        public frmChiTietHoaDonNhap(long idHoaDon, byte danhapkho)//tham số này được truyền qua để lấy mã hóa đơn
        {
            this.idHoaDon = idHoaDon;
            this.danhapkho = danhapkho;
            InitializeComponent();
        }
        private long idHoaDon;//tạo biến để lấy mã hóa đơn truyền qua
        private byte danhapkho;

        private QLNET_DatabaseDataContext db;

        private DataGridViewRow r;
        private void frmChiTietHoaDonNhap_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();

            //khi form này được load lên => kiểm tra xem trạng thái của đơn hàng đã nhập kho hay chưa
            //nếu chưa nhập kho thì cho thêm,xóa mặt hàng 
            //còn nếu đã nhập kho rồi thì sẽ không cho chỉnh sửa đơn hàng nữa(vô hiệu hóa 2 button thêm và xóa)
            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            if (hd.DaNhap == 1)
            {
                btnThem.Enabled = btnXoa.Enabled = false;
            }

            //truyền dữ liệu cho combobox
            //để phân biệt các mặt hàng cùng tên nhưng khác đơn vị tính
            //==>kết hợp tên mặt hàng với đơn vị tính
            var rs = from h in db.MatHangs.Where(x=>x.isDichVu == 0 || x.isDichVu == null)
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         tenmathang = h.TenMatHang + " - " + d.TenDVT,
                         mahang = h.ID
                     };

            cbbMatHang.DataSource = rs;
            cbbMatHang.DisplayMember = "tenmathang";
            cbbMatHang.ValueMember = "mahang";
            cbbMatHang.SelectedIndex = -1;//mặc định sẽ không chọn mặt hàng nào cả

            ShowData();

            //tùy chỉnh lại hiển thị datagriview
            dgvMatHang.Columns["idmathang"].Visible = false;
            dgvMatHang.Columns["idcha"].Visible = false;

            dgvMatHang.Columns["mathang"].HeaderText = "Tên mặt hàng";
            dgvMatHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvMatHang.Columns["sl"].HeaderText = "SL";
            dgvMatHang.Columns["dg"].HeaderText = "Đơn giá";
            dgvMatHang.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvMatHang.Columns["dvt"].Width = 100;
            dgvMatHang.Columns["sl"].Width = 100;
            dgvMatHang.Columns["thanhtien"].Width = 100;
            dgvMatHang.Columns["dg"].Width = 100;
            dgvMatHang.Columns["mathang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            //định dạng phần nghìn
            dgvMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvMatHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";





        }

        private void ShowData()
        {
            //join 2 bảng chi tiết hóa đơn nhập với mặt hàng để lưu tên mặt hàng vì csdl chi tiet hóa đơn nhặp chỉ lưu mặt hàng mà không lưu tên mặt hàng.
            var rs = (from c in db.ChiTietHoaDonNhaps.Where(x => x.IDHoaDon == idHoaDon)
                      join h in db.MatHangs
                      on c.IDMatHang equals h.ID
                      join d in db.DonViTinhs on h.IDDVT equals d.ID
                      select new
                      {
                          idmathang = h.ID,
                          idcha = h.IdCha,
                          mathang = h.TenMatHang,
                          dvt = d.TenDVT,
                          sl = c.SoLuong,
                          dg = c.DonGiaNhap,
                          thanhtien = c.SoLuong * c.DonGiaNhap,
                      }).Where(x => x.idcha <= 0  || x.idcha == null || x.idcha >= 0);

            dgvMatHang.DataSource = rs;
            lblTongTien.Text = string.Format("Tổng tiền: {0:N0} VNĐ", rs.Sum(x => x.thanhtien));
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (cbbMatHang.SelectedIndex < 0)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần cập nhập", "Rằng buộc dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var ct = new ChiTietHoaDonNhap();
            ct.IDHoaDon = idHoaDon;//idhoadon được truyền qua khi form được gọi

            //trước khi thêm sẽ kiểm tra ứng với hoadon có id là idhoadon và mặt hàng đang được chọn đã tồn tại trong csdl chưa
            var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(cbbMatHang.SelectedValue.ToString()));
            //nếu chưa thì item sẽ là null
            //ngược lại item sẽ khác null
            if (item == null)//nếu chưa có trong đơn nhập hàng
            {
                ct.IDMatHang = int.Parse(cbbMatHang.SelectedValue.ToString());
                ct.DonGiaNhap = int.Parse(txtDonGiaNhap.Text);
                ct.SoLuong = int.Parse(txtSL.Text);
                db.ChiTietHoaDonNhaps.InsertOnSubmit(ct);
                db.SubmitChanges();
            }
            else//nếu đã có, thì cập nhật lại số lượng <->update
            {
                item.SoLuong += int.Parse(txtSL.Text);
                db.SubmitChanges();
            }

            ShowData();
        }

        private void dgvMatHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                r = dgvMatHang.Rows[e.RowIndex];
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (r == null)
            {
                MessageBox.Show("Vui lòng chọn mặt hàng cần xóa khỏi phiếu nhập", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (

                MessageBox.Show("Bạn có chắc muốn xóa mặt hàng: " + r.Cells["mathang"].Value.ToString() + " ?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                == DialogResult.Yes
                )
            {

                var item = db.ChiTietHoaDonNhaps.FirstOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["idmathang"].Value.ToString()));
                db.ChiTietHoaDonNhaps.DeleteOnSubmit(item);
                db.SubmitChanges();
                MessageBox.Show("Xóa mặt hàng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowData();
            }





        }

        private void rbtNhapKho_Click(object sender, EventArgs e)
        {
            if (rbtYeuCau.Checked)//nếu ở chế độ yêu cầu
            {
                txtTienThanhToan.Enabled = false;//thì chưa thanh toán; enableb = false là không cho nhập tiền
                txtTienThanhToan.Text = "0"; //mặc định tiền là 0
            }
            else
            {
                txtTienThanhToan.Enabled = true;//ngược lại khi thực nhập, tức là mua hàng thực tế thì cần nhập số tiền đã thanh toán cho nhà cung cấp
            }
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            //nếu chưa có mặt hàng nào thì sẽ không cho xác nhận. nếu đơn hàng đang trống
            if (dgvMatHang.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng nhập mặt hàng vào hóa đơn nhập trước khi tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            //khi click btnXacNhan sẽ cần làm 2 thao tác
            //1: update số tiền thanh toán
            //2: update trạng thái của phiếu là đang yêu cầu hay là đã nhập thực tế

            //:xác định hóa đơn đang thao tác là hóa đơn nào dựa vào idhoadon được truyền qua form
            var hd = db.HoaDonNhaps.SingleOrDefault(x => x.ID == idHoaDon);
            hd.TienThanhToan = int.Parse(txtTienThanhToan.Text);
            hd.DaNhap = rbtYeuCau.Checked ? (byte)0 : (byte)1;
            db.SubmitChanges();
            this.Dispose();//đóng form
        }
    }
}
