using QL_NET.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NET
{
    public partial class frmOrder : Form
    {
        public frmOrder(long idHoaDon, string tenphong, DataGridViewRow r)
        {
            this.idHoaDon = idHoaDon;
            this.r = r;
            this.tenphong = tenphong;
            InitializeComponent();


        }
        private long idHoaDon;
        private DataGridViewRow r;
        private string tenphong;
        private QLNET_DatabaseDataContext db;
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }



        private void frmOrder_Load(object sender, EventArgs e)
        {
            this.lblTenMatHang.Text = "Mặt hàng yêu cầu: " + r.Cells["tenhang"].Value.ToString() + " - [" + r.Cells["dvt"].Value.ToString() + "]";
            this.lblPhong.Text = String.Format("Phòng phục vụ: {0}", tenphong);

            db = new QLNET_DatabaseDataContext();


        }

        private void txtSL_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))//chỉ cho phép nhập số tự nhiên vào textbox txtDonGiaban
            {
                e.Handled = true;
            }

            if(e.KeyChar == (char)13)
            {
                btnSubmit.PerformClick();//gọi tới sự kiện click của btn khi bấm enter
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int sl = 0;
                try
                {
                    sl = int.Parse(txtSL.Text);
                    if (sl == 0)
                    {
                        MessageBox.Show("Số lượng không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtSL.Select();
                        return;
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Số lượng không hợp lệ", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtSL.Select();
                    return;
                }
                //trước khi thêm, cần kiểm tra đã tồn tại chưa, mặt hàng này trong hóa đơn được chọn hay chưa
                var item = db.ChiTietHoaDonBans.SingleOrDefault(x => x.IDHoaDon == idHoaDon && x.IDMatHang == int.Parse(r.Cells["mahang"].Value.ToString()));
                if (item != null)
                {
                    //nếu đã tồn tại, chỉ việc cập nhập lại sl yêu cầu
                    item.SL += sl;//cộng dồn
                    db.SubmitChanges();


                }
                else
                {
                    var ct = new ChiTietHoaDonBan();
                    ct.IDHoaDon = idHoaDon;//mã hòa đơn được truyền từ form frmBanHang qua
                    ct.IDMatHang = int.Parse(r.Cells["mahang"].Value.ToString());//r là dòng dữ liệu được chộn từ datagriview dgvDanhSachMatHang trong form frmBanHang truyền qua
                    ct.SL = sl;

                    //trong csdl,còn có cột dongia
                    //đơn giá được lấy từ cột giaban trong bảng mathang
                    //muốn lấy được => cần tìm ra mặt hàng có mã id =int.Parse(r.Cells["mahang"].Value.ToString()); chính là mã hàng được truyền qua từ form frmBanHang
                    var mh = db.MatHangs.SingleOrDefault(x => x.ID == int.Parse(r.Cells["mahang"].Value.ToString()));

                    ct.DonGia = mh.DonGiaBan;

                    db.ChiTietHoaDonBans.InsertOnSubmit(ct);
                    db.SubmitChanges();

                }
                MessageBox.Show("Mặt hàng khách hàng yêu cầu được thêm thành công vào " + tenphong, "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);

                this.Dispose();
            }
            catch (Exception ex)
            {

                MessageBox.Show("lỗi " + ex.Message, "yêu cầu phục vụ thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
