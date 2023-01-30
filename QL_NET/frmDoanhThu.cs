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
    public partial class frmDoanhThu : Form
    {
        public frmDoanhThu()
        {
            InitializeComponent();
        }
        private QLNET_DatabaseDataContext db;

        //4 radiobutton dùng chung sk checkedchanged
        private void rbtTatCa_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtTatCa.Checked)
            {
                cbbItems.Enabled = false;
               

            }else
            {
                cbbItems.Enabled = true;
                if (rbtMatHang.Checked)
                {
                    //chỉ lấy mặt hàng không phải là dịch vụ
                    var rs = from h in db.MatHangs.Where(x => x.isDichVu == 0)
                             join d in db.DonViTinhs on h.IDDVT equals d.ID
                             select new
                             {
                                 TenMatHang = h.TenMatHang+" - ["+d.TenDVT+"]",
                                 ID = h.ID
                             };
                    cbbItems.DataSource = rs;
                    cbbItems.DisplayMember = "TenMatHang";
                    cbbItems.ValueMember = "ID";
                }
                else if(rbtDichVu.Checked) 
                {
                    cbbItems.DataSource = db.MatHangs.Where(x => x.isDichVu == 1);
                    cbbItems.DisplayMember = "TenMatHang";
                    cbbItems.ValueMember = "ID";
                }
                else
                {
                    //rbt phòng
                    cbbItems.DataSource = db.Phongs;
                    cbbItems.DisplayMember = "TenPhong";
                    cbbItems.ValueMember = "ID";
                }    
            }
            cbbItems.SelectedIndex = -1;//không chọn gì cả
        }

        private void frmDoanhThu_Load(object sender, EventArgs e)
        {
             db = new QLNET_DatabaseDataContext();

            btnThongKe.PerformClick();
            //set giá trị mặc định cho 2 maskedtextbox
            mtbTuNgay.Text = DateTime.Now.ToString("dd/MM/yyyy 00:01");//đầu ngày hiện tại
            mtbToiNgay.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//Thời điểm hiện tại


            //tự động co giãn 
            dgvDoanhThu.Columns["MatHang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (rbtPhong.Checked)
            {
                ThongKePhong();
                return;

            }
            if (rbtDichVu.Checked)
            {
                ThongKeDV();
                return;
            }
            if (rbtMatHang.Checked)
            {
                ThongkeHang();
                return;
            }

            if (rbtTatCa.Checked)
            {

                ThongKeTatCa();
                return;
            }
        }

        private void ThongKePhong()
        {
            var rs = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGIanKThuc != null)//lấy các hóa đơn đã kết thúc
                     join p in db.Phongs on hd.IDPhong equals p.ID
                     select new
                     {
                         NgayGD = hd.ThoiGianBDau,
                         MatHang = p.TenPhong,
                         DVT ="Giờ",
                         DG = hd.DonGiaPhong,
                         SL = new DoanhThuPhong(((DateTime)hd.ThoiGIanKThuc - (DateTime)hd.ThoiGianBDau).TotalHours),
                         ThanhTien = new DoanhThuPhong().ThanhTien(((DateTime)hd.ThoiGIanKThuc - (DateTime)hd.ThoiGianBDau).TotalHours,(int)hd.DonGiaPhong)
                     };
            dgvDoanhThu.DataSource = rs;
        }

        private void ThongKeDV()
        {
            var rs = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGIanKThuc != null)
                     join ct in db.ChiTietHoaDonBans on hd.IDHoaDon equals ct.IDHoaDon
                     join h in db.MatHangs.Where(x => x.isDichVu == 1) on ct.IDMatHang equals h.ID
                     join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                     select new
                     {
                         NgayGD = hd.ThoiGianBDau,
                         MatHang = h.TenMatHang,
                         DVT = dv.TenDVT,
                         SL = ct.SL,
                         DG = ct.DonGia,
                         ThanhTien = ct.SL * ct.DonGia
                     };

            dgvDoanhThu.DataSource = rs;
        }

        private void ThongkeHang()
        {
            var rs = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGIanKThuc != null)
                     join ct in db.ChiTietHoaDonBans on hd.IDHoaDon equals ct.IDHoaDon
                     join h in db.MatHangs.Where(x=>x.isDichVu ==0) on ct.IDMatHang equals h.ID
                     join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                     select new
                     {
                         NgayGD = hd.ThoiGianBDau,
                         MatHang = h.TenMatHang,
                         DVT = dv.TenDVT,
                         SL = ct.SL,
                         DG = ct.DonGia,
                         ThanhTien = ct.SL * ct.DonGia
                     };

            dgvDoanhThu.DataSource = rs;
        }

        private void ThongKeTatCa()
        {
            var rs = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGIanKThuc != null)
                     join ct in db.ChiTietHoaDonBans on hd.IDHoaDon equals ct.IDHoaDon
                     join h in db.MatHangs on ct.IDMatHang equals h.ID
                     join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                     
                     select new
                     {
                         NgayGD = hd.ThoiGianBDau,
                         MatHang = h.TenMatHang,
                         DVT = dv.TenDVT,
                         SL = ct.SL,
                         DG = ct.DonGia,
                         ThanhTien = ct.SL * ct.DonGia
                     };

            dgvDoanhThu.DataSource = rs;
        }

    }
}
