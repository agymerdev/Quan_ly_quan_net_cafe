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
using System.Windows.Forms.VisualStyles;
using System.Drawing.Drawing2D;
using System.Net.NetworkInformation;

namespace QL_NET
{
    public partial class frmBanHang : Form
    {
        public frmBanHang(string nv)
        {
            this.nhanvien = nv;
            InitializeComponent();
        }

        ListView lv;
        private ImageList imgl;
        private string nhanvien;
        private QLNET_DatabaseDataContext db;
        private void frmBanHang_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();
            var dsLoaiPhong = db.LoaiPhongs;//lấy danh sách loại phòng
            foreach (var l in dsLoaiPhong)//duyệt danh sách loại phòng
            {
                TabPage tp = new TabPage(l.TenLoaiPhong);
                tp.Name = l.ID.ToString();
                tbcContent.Controls.Add(tp);
            }
            idLoaiPhong = db.LoaiPhongs.Min(x => x.ID);
            //mặc định sẽ load tabpage đầu tiên có tabindex là 0
            LoadPhong(idLoaiPhong, tabIndex);
            #region ds_mat_hang 
            ShowMatHang();

            dgvDanhSachMatHang.Columns["mahang"].Visible = false;
            dgvDanhSachMatHang.Columns["isDichVu"].Visible = false;

            dgvDanhSachMatHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvDanhSachMatHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvDanhSachMatHang.Columns["dg"].HeaderText = "Giá";
            dgvDanhSachMatHang.Columns["tonkho"].HeaderText = "Tồn";

            dgvDanhSachMatHang.Columns["dvt"].Width = 50;
            dgvDanhSachMatHang.Columns["mahang"].Width = 50;
            dgvDanhSachMatHang.Columns["dg"].Width = 60;
            dgvDanhSachMatHang.Columns["tonkho"].Width = 50;
            dgvDanhSachMatHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvDanhSachMatHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvDanhSachMatHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvDanhSachMatHang.Columns["tonkho"].DefaultCellStyle.Format = "N0";
            #endregion

            ShowLSGD();//gọi hàm lsgd khi form đc load lên
            dgvLSGD.Columns["idHoaDon"].Visible = false;

            dgvLSGD.Columns["phong"].HeaderText = "Phòng";
            dgvLSGD.Columns["tgBatDau"].HeaderText = "Bắt đầu";
            dgvLSGD.Columns["tgKetThuc"].HeaderText = "Kết thúc";
            dgvLSGD.Columns["sotien"].HeaderText = "Số tiền";

            dgvLSGD.Columns["tgBatDau"].Width = 150;
            dgvLSGD.Columns["tgKetThuc"].Width = 150;



            dgvLSGD.Columns["sotien"].DefaultCellStyle.Format = "N0";
            dgvLSGD.Columns["sotien"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvLSGD.Columns["sotien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;





        }


        private void LoadPhong(int loaiphong, int tabIndex)
        {

            tbcContent.TabPages[tabIndex].Controls.Clear();
            lv = new ListView();
            lv.Dock = DockStyle.Fill; //set dockstyle là fill để listview lấp đầy tabpage            
            lv.SelectedIndexChanged += lv_SelectedIndexChanged;
            imgl = new ImageList();//khai báo 1 imagelist
            imgl.ImageSize = new Size(256, 128);//set size cho image


            //add 2 ảnh đại diện cho 2 trạng thái phòng trống và phòng đang có khách
            imgl.Images.Add(Properties.Resources.off);//index 0
            imgl.Images.Add(Properties.Resources.on);//index 1

            //set imagelist cho listview được khai báo ở trên
            lv.LargeImageList = imgl;

            //lấy danh sách phòng theo loại phòng dựa vào idloaiphong

            var dsPhong = db.Phongs.Where(x => x.IDLoaiPhong == loaiphong);
            //duyệt danh sách phòng tìm được
            foreach (var p in dsPhong)
            {
                //add item lên listview
                if (p.TrangThai == 1)//đang được sử dụng
                {
                    lv.Items.Add(new ListViewItem { ImageIndex = 1, Text = p.TenPhong, Name = p.ID.ToString(), Tag = true });//tag = true dùng để đánh dấu phòng đang có khách
                }
                else
                {
                    lv.Items.Add(new ListViewItem { ImageIndex = 0, Text = p.TenPhong, Name = p.ID.ToString(), Tag = false });//tag = false để đánh dấu phòng đang trống
                }
            }
            //add listview lên tabpage
            tbcContent.TabPages[tabIndex].Controls.Add(lv);
        }


        private int idLoaiPhong = 0;
        private string tenphong;
        private long idHoaDon = 0;
        private int idPhong = 0;
        private int tabIndex = 0;
        private void lv_SelectedIndexChanged(object sender, EventArgs e)
        {
            var idx = lv.SelectedIndices;
            if (idx.Count > 0)
            {
                idPhong = int.Parse(lv.SelectedItems[0].Name);
                tenphong = lv.SelectedItems[0].Text.ToUpper();//toupper => chữ hoa


                lblPhongDangChon.Text = tenphong;


                if ((bool)lv.SelectedItems[0].Tag)//nếu phòng đang có khách
                {
                    btnBatDau.Enabled = false;
                    btnKetThuc.Enabled = true;
                    //khi click vào item trên listview <-> click vào phòng đang có khách
                    //lấy thông tin hóa đơn bán hàng dựa vào id phòng
                    //lấy  hóa đơn có id lớn nhất có mã phòng đang được chọn
                    var hd = db.HoaDonBanHangs.FirstOrDefault(x => x.IDHoaDon == db.HoaDonBanHangs.Where(y => y.IDPhong == idPhong).Max(z => z.IDHoaDon));
                    idHoaDon = hd.IDHoaDon;
                    //khi phòng đang có khách -> thời gian bắt đầu được tính trong hóa đơn
                    mtbKetThuc.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//giờ kết thúc bằng giờ hiện tại
                    mtbBatDau.Text = ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm");

                    ShowChiTietHoaDon();
                }
                else
                {
                    //nếu phòng chưa có khách thì cho timer chạy để lấy giờ hiện tại làm giờ bắt đầu sử dụng phòng

                    dgvChiTietBanHang.DataSource = null;
                    mtbBatDau.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");//giờ bắt đầu bằng giờ hiện tại
                    btnBatDau.Enabled = true;
                    btnKetThuc.Enabled = false;
                }

            }
        }



        private void ShowMatHang()
        {


            #region tồn kho cha
            //I.Tính tồn kho mặt hàng cha nhập vào
            //chỉ lấy hàng để bán khi danhap =1
            var details = from ct in db.ChiTietHoaDonNhaps
                          join hd in db.HoaDonNhaps.Where(x => x.DaNhap == 1)
                          on ct.IDHoaDon equals hd.ID
                          select new
                          {
                              mahang = ct.IDMatHang,
                              sl = ct.SoLuong
                          };
            //bắt đầu tính tồn kho của cha: chỉ lấy tổng số lượng của các mặt hàng không là con của mặt hàng khác(idcha=null)
            //tính tổng số lượng theo từng mặt hàng =>  cần group by theo mã hàng
            var nhapCha = from ct in details.GroupBy(x => x.mahang)
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0) on ct.First().mahang equals h.ID
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          select new
                          {
                              mahang = ct.First().mahang,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.Sum(x => x.sl)//lấy tổng số lượng
                          };

            //II: tính số mặt hàng cha bán ra: bán ra nguyên thùng + số lon(mặt hàng con) quy ra số lượng
            //1.tính số lượng mặt hàng cha bán ra nguyên đơn vị => nhập vào thùng,bán ra cũng là thùng
            var xuatCha = from p in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.IdCha == null || x.IdCha <= 0)//chỉ lấy tổng số lượng của các mặt hàng không là con của mặt hàng khác(idcha=null)
                          on p.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = p.Sum(x => x.SL)
                          };



            //2.tính số lượng mặt hàng cha bán ra được qquy ra từ số lượng mặt hàng con bán
            //vd: bán 24 chai sting -> quy ra được một thùng
            var xuatQuyRaCha = from ct in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                               join h in db.MatHangs.Where(x => x.IdCha > 0)//chỉ lấy các mặt hàng
                               on ct.First().IDMatHang equals h.ID
                               select new
                               {
                                   mahang = (int)h.IdCha,
                                   soluong = ct.Sum(x => x.SL) % h.tile == 0 ? ct.Sum(x => x.SL) / h.tile : ct.Sum(x => x.SL) / h.tile + 1
                                   //ct.Sum(x => x.SL) = (tổng số lượng bán ra)

                                   //soluong = ct.Sum(x => x.SL) % h.tile == 0 (tổng số lượng bán ra có chia hết cho tỉ lệ quy đổi không)
                                   //vd:24 %24 = 0 tức là chia hết => số thùng bán ra là 24/24 = 1
                                   //ngược lại không chia hết cho tỉ lệ tức là còn dư
                                   //vd: bán ra 25 chai => 25%24 =1 khác 0 => không chia hết => số thùng bán ra (x => x.SL)/ h.tile + 1

                               };

            //3 tính tổng toàn bộ mặt hàng cha đã bán ra dựa vào kết quả thu được từ (1) và (2)
            var tongXuatCha = from xc in xuatCha.Union(xuatQuyRaCha).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = xc.First().mahang,
                                  soluong = xc.Sum(x => x.soluong)
                              };

            //III. tính tồn kho của mặt hàng cha từ I và II
            //tồn = nhập - xuất 
            //nhập vào nhưng chưa bán ra
            //tức là dữ liệu không tồn tại đồng thời cả 2 bảng
            //=>dùng left join(gộp dữ liệu)
            var tonKhoCha = from p in nhapCha
                            join q in tongXuatCha on p.mahang equals q.mahang into tmp
                            from t in tmp.DefaultIfEmpty()
                                //Phương thức mở rộng DefaultIfEmpty trả về một danh sách mới với giá trị mặc định nếu danh sách đã cho rỗng.
                            select new
                            {
                                mahang = p.mahang,
                                tenhang = p.tenhang,
                                isDichVu = 0,
                                dvt = p.dvt,
                                dg = p.dg,
                                tonkho = (int)(p.soluong - (t == null ? 0 : t.soluong))//nhập - xuất
                            };
            #endregion

            #region tồn kho con
            //=>>>IV. Tính tồn kho của mặt hàng con
            //IV.1. tính tổng số lượng nhập vào của mặt hàng con
            //tổng nhập của mặt hàng con => số lượng mặt hàng cha nhập vào x tỉ lệ quy đổi ra
            //danh sách mặt hàng cha nhập đã tính được ở I
            var nhapCon = from ct in nhapCha
                          join h in db.MatHangs on ct.mahang equals h.IdCha//=> inner join -> chỉ lấy các mặt hàng có id cha = mahang trong ds nhapCha
                          join d in db.DonViTinhs on h.IDDVT equals d.ID
                          select new
                          {
                              mahang = h.ID,
                              tenhang = h.TenMatHang,
                              dvt = d.TenDVT,
                              dg = h.DonGiaBan,
                              soluong = ct.soluong * h.tile
                              //số mặt hàng con nhập vào được tính theo số lượng mặt hàng cha nhập vào 1 cách tự động (auto)
                          };

            //IV.2 Tính tổng số mặt hàng con bán ra
            //tổng mặt hàng con bán ra = tổng mặt hàng cha bán ra X tỉ lệ quy đổi + số mặt hàng hàng con bán ra
            //vd: sting bán ra 3 thùng chẵn và 15 chai lẻ
            // tổng số lon bán ra = 3x24 +15 = 72+15 = 87 chai

            //IV.2.a tính tổng con bán ra được quy ra từ cha bằng cách lấy xuatCha đã tính ở II X vơi tỷ lệ quy đổi

            var xuatConQuyTuCha = from xc in xuatCha
                                  join h in db.MatHangs.Where(x => x.IdCha > 0)//chỉ lấy các mặt hàng là con của mặt hàng khác
                                  on xc.mahang equals h.IdCha//(lưu ý điều kiện join)
                                  select new
                                  {
                                      mahang = h.ID,
                                      soluong = xc.soluong * h.tile
                                  };

            //IV.2.b tính tổng mặt hàng con bán ra, tức là bán ra theo chai

            var xuatCon = from ct in db.ChiTietHoaDonBans.GroupBy(x => x.IDMatHang)
                          join h in db.MatHangs.Where(x => x.IdCha > 0 && x.isDichVu == 0)//chỉ lấy các mặt hàng là con của mặt hàng khác
                          on ct.First().IDMatHang equals h.ID
                          select new
                          {
                              mahang = h.ID,
                              soluong = ct.Sum(x => x.SL)
                          };

            //IV.3 tổng mặt hàng con bán ra bằng tổng kết qua từ IV.2.a và IV.2.b
            var tongConXuat = from ct in xuatConQuyTuCha.Union(xuatCon).GroupBy(x => x.mahang)
                              select new
                              {
                                  mahang = ct.First().mahang,
                                  slXuat = ct.Sum(x => x.soluong)
                              };
            //IV.3 tính tồn kho mặt hàng con = tổng con nhập vào - tổng con bán ra

            //tương tụ trên dùng left join
            var tonKhoCon = from nc in nhapCon
                            join xc in tongConXuat on nc.mahang equals xc.mahang into tmp
                            from x in tmp.DefaultIfEmpty()
                            select new
                            {
                                mahang = nc.mahang,
                                tenhang = nc.tenhang,
                                isDichVu = 0,
                                dvt = nc.dvt,
                                dg = nc.dg,
                                tonkho = (int)(nc.soluong - (x == null ? 0 : x.slXuat))
                            };

            #endregion

            //V.danh sách tồn kho của mặt hàng cha và mặt hàng con
            var tonkhohang = tonKhoCha.Concat(tonKhoCon).OrderBy(x => x.tenhang);//sắp xếp tăng dần theo tên mặt hàng
            var dichvu = from h in db.MatHangs.Where(x => x.isDichVu == 1) //lấy các mặt hàng là dịch vụ
                         join d in db.DonViTinhs on h.IDDVT equals d.ID

                         select new
                         {
                             mahang = h.ID,
                             tenhang = h.TenMatHang,
                             isDichVu = 1,
                             dvt = d.TenDVT,
                             dg = h.DonGiaBan,
                             tonkho = 0 // kinh doanh dịch vụ nên không cần tồn kho
                         };

            //sắp xếp tăng theo thứ tự mặt hàng trước, dịch vụ sau. rồi sắp xếp tăng dần theo tên mặt hàng và dịch vụ
            dgvDanhSachMatHang.DataSource = tonkhohang.Concat(dichvu).OrderBy(x => x.tenhang).OrderBy(x => x.isDichVu);
        }


        private void dgvDanhSachMatHang_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (idPhong == 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để tiếp tục", "Chú ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (e.RowIndex < 0)
            {
                return;
            }

            //chỉ hiển thị form frmOder khi phòng đang ở trạng thái có khách
            var phong = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
            if (phong.TrangThai == 1)
            {
                var r = dgvDanhSachMatHang.Rows[e.RowIndex];
                new frmOrder(idHoaDon, tenphong, r).ShowDialog();
                ShowMatHang();
                ShowChiTietHoaDon();
            }





        }


        //hiện thị phòng trên các tapcontrol khác nhau
        private void tbcContent_SelectedIndexChanged(object sender, EventArgs e)
        {
            idLoaiPhong = int.Parse(tbcContent.SelectedTab.Name);//lấy id loại phòng đã được gán ở trên
            tabIndex = tbcContent.SelectedIndex;
            LoadPhong((idLoaiPhong), tabIndex);
        }

        private void ShowChiTietHoaDon()
        {
            //lấy chi tiết hóa đơn bán hàng liên quan tới hóa đơn được lấy ở trên
            //vì trong bảng chitiethoadonban chỉ lưu mã hàng
            //trong khi cần lấy thông tin tường minh là tên mặt hàng
            //=> cần join 2 bảng chitiethoadoban và mathang dựa vào idmathang
            var rs = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == idHoaDon)
                     join h in db.MatHangs on ct.IDMatHang equals h.ID
                     join d in db.DonViTinhs on h.IDDVT equals d.ID
                     select new
                     {
                         mahang = h.ID,
                         tenhang = h.TenMatHang,
                         dvt = d.TenDVT,
                         sl = ct.SL,
                         dg = ct.DonGia,
                         thanhtien = ct.SL * ct.DonGia
                     };
            dgvChiTietBanHang.DataSource = rs;
            dgvChiTietBanHang.Columns["mahang"].Visible = false;
            dgvChiTietBanHang.Columns["tenhang"].HeaderText = "Mặt hàng";
            dgvChiTietBanHang.Columns["dvt"].HeaderText = "ĐVT";
            dgvChiTietBanHang.Columns["sl"].HeaderText = "SL";
            dgvChiTietBanHang.Columns["dg"].HeaderText = "Đơn giá";
            dgvChiTietBanHang.Columns["thanhtien"].HeaderText = "Thành tiền";

            dgvChiTietBanHang.Columns["sl"].Width = 30;
            dgvChiTietBanHang.Columns["dvt"].Width = 70;
            dgvChiTietBanHang.Columns["dg"].Width = 70;
            dgvChiTietBanHang.Columns["thanhtien"].Width = 100;
            dgvChiTietBanHang.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dgvChiTietBanHang.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietBanHang.Columns["sl"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvChiTietBanHang.Columns["dg"].DefaultCellStyle.Format = "N0";
            dgvChiTietBanHang.Columns["thanhtien"].DefaultCellStyle.Format = "N0";
        }

        private void btnBatDau_Click(object sender, EventArgs e)
        {
            try
            {

                //tạo đơn hàng xong cần cập nhập lại trạng thái phòng
                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);

                //lấy ra loại phòng tương ứng với phòng được chọn
                var lp = db.LoaiPhongs.SingleOrDefault(x => x.ID == idLoaiPhong);

                var od = new HoaDonBanHang();
                od.IDPhong = idPhong;
                od.NguoiBan = nhanvien;
                od.ThoiGianBDau = DateTime.ParseExact(mtbBatDau.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                od.NgayTao = DateTime.Now;
                od.NguoiTao = nhanvien;
                od.DonGiaPhong = lp.DonGia;

                db.HoaDonBanHangs.InsertOnSubmit(od);
                db.SubmitChanges();



                p.TrangThai = 1;
                db.SubmitChanges();
                LoadPhong(idLoaiPhong, tabIndex);
                btnBatDau.Enabled = false;
                btnKetThuc.Enabled = true;
                MessageBox.Show("Gọi phòng thành công", "Succressfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Gọi phòng thất bại", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            try
            {


                //cập nhập trạng thái thời gian kết thúc cho hóa đơn bán hàng
                var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);
                hd.ThoiGIanKThuc = DateTime.ParseExact(mtbKetThuc.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                db.SubmitChanges();

                //cập nhập trạng thái cho phòng từ có khách => không có khách
                var p = db.Phongs.SingleOrDefault(x => x.ID == idPhong);
                p.TrangThai = 0;
                db.SubmitChanges();


                //load lại danh sách phòng
                LoadPhong(idLoaiPhong, tabIndex);

                //reset
                mtbBatDau.Text = DateTime.Now.ToString("dd//MM//yyyy HH:mm");
                btnBatDau.Enabled = true;
                btnKetThuc.Enabled = false;
                MessageBox.Show("Thanh toán phòng thành công", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShowLSGD();


                idHoaDon = hd.IDHoaDon;
                InHoaDon();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Lỗi: " + ex.Message, "Thanh toán phòng thất bại", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }


        }
     
        private void ShowLSGD()
        {
            var rs = from hd in db.HoaDonBanHangs.Where(x => x.ThoiGIanKThuc != null)
                     join p in db.Phongs on hd.IDPhong equals p.ID
                     join ct in db.ChiTietHoaDonBans.GroupBy(t => t.IDHoaDon)
                     on hd.IDHoaDon equals ct.First().IDHoaDon
                     select new
                     {
                         idHoaDon = hd.IDHoaDon,
                         phong = p.TenPhong,
                         tgBatDau = hd.ThoiGianBDau,
                         tgKetThuc = hd.ThoiGIanKThuc,
                         // số tiền = đơn giá phòng + tiền hàng bán đc
                         soTien = (((DateTime)hd.ThoiGIanKThuc - (DateTime)hd.ThoiGianBDau)).TotalHours * hd.DonGiaPhong  //tổng tiền phòng
                         + ct.Sum(x => x.SL * x.DonGia)//tổng tiền hàng
                         //TotalHours: tính giờ, thời gian giữa 2 đối tượng 
                     };

            dgvLSGD.DataSource = rs;
        }



        private void dgvLSGD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        //hàm xử lý in hóa đơn
        private void InHoaDon()
        {
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            //lấy thông tin từ bảng cấu hình
            var ten = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "tencuahang").giatri;
            var diachi = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "diachi").giatri;
            var phone = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "phone").giatri;

            //lấy hóa đơn dựa vào idHoaDon
            var hd = db.HoaDonBanHangs.SingleOrDefault(x => x.IDHoaDon == idHoaDon);

            //lấy bề rộng của giấy in
            var rong = printDocument1.DefaultPageSettings.PaperSize.Width;


            #region header
            //vẽ header của bill
            //1.tên cửa hàng
            e.Graphics.DrawString(
                ten.ToUpper(),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black, new Point(100, 20)
                );

            //mã hóa đơn
            e.Graphics.DrawString(
                String.Format($"HD{hd.IDHoaDon}"),
                new Font("Courier New", 12, FontStyle.Bold),
                Brushes.Black,
                new Point(rong / 2 + 200, 20)
                );
            //2. địa chỉ và số điện thoại
            e.Graphics.DrawString(
                String.Format($"{diachi} - {phone}"),
                new Font("Courier New", 8, FontStyle.Bold),
                Brushes.Black,
                new Point(100, 45)
                );

            //ngày giờ xuất hóa đơn
            e.Graphics.DrawString(
               String.Format("{0}", DateTime.Now.ToString("dd/MM/yyyy HH:mm")),
               new Font("Courier New", 12, FontStyle.Bold),
               Brushes.Black,
               new Point(rong / 2 + 200, 45)
               );




            //định dạng bút vẽ
            Pen blackpen = new Pen(Color.Black, 1);

            //tọa độ theo chiều dọc
            var y = 70;

            //định nghĩa 2 điểm để vẽ đường thẳng
            //cách lề trái 10,lề phải 10
            Point p1 = new Point(10, y);
            Point p2 = new Point(rong - 10, y);
            //kẻ đường thẳng thứ nhất
            e.Graphics.DrawLine(blackpen, p1, p2);

            y += 10;
            e.Graphics.DrawString(
              String.Format("Giờ bắt đầu: {0}", ((DateTime)hd.ThoiGianBDau).ToString("dd/MM/yyyy HH:mm")),
              new Font("Courier New", 10, FontStyle.Bold),
              Brushes.Black,
              new Point(10, y)
              );

            e.Graphics.DrawString(
              String.Format("Giờ kết thúc: {0}", ((DateTime)hd.ThoiGIanKThuc).ToString("dd/MM/yyyy HH:mm")),
              new Font("Courier New", 10, FontStyle.Bold),
              Brushes.Black,
              new Point(rong / 2, y)
              );


            y += 20;
            //tổng tiền --- tổng tiền = tiền phòng + tiền hàng/dịch vụ
            int sum = 0;
            //tính thời gian sử dụng phòng 
            var tgsd = ((DateTime)hd.ThoiGIanKThuc - (DateTime)hd.ThoiGianBDau).TotalMinutes;

            var gio = (int)(tgsd / 60);
            var phut = tgsd % 60;

            //tiền sử dụng phòng
            var tienphong = (int)Math.Round((double)(tgsd / 60 * hd.DonGiaPhong) / 1000, 3) * 1000;
            sum += tienphong;


            e.Graphics.DrawString(
             String.Format($"Thời gian sử dụng: {gio}:{phut}"),
             new Font("Courier New", 10, FontStyle.Bold),
             Brushes.Black,
             new Point(10, y)
             );

            e.Graphics.DrawString(
             String.Format($"Tiền phòng: {tienphong:N0} VNĐ"),
             new Font("Courier New", 10, FontStyle.Bold),
             Brushes.Black,
             new Point(rong / 2, y)
             );

            //set lại tọa độ cho 2 điểm để vẽ đường thẳng thứ 2
            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(rong - 10, y);

            e.Graphics.DrawLine(blackpen, p1, p2);
            #endregion

            #region body
            e.Graphics.DrawString("STT", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(10, y));
            e.Graphics.DrawString("Mặt hàng/dịch vụ", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(50, y));
            e.Graphics.DrawString("SL", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(rong / 2, y));
            e.Graphics.DrawString("Đơn giá", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(rong / 2 + 100, y));
            e.Graphics.DrawString("Thành tiền", new Font("Courier New", 10, FontStyle.Bold), Brushes.Black, new Point(rong - 200, y));

            ////lấy dữ liệu hóa đơn dựa vào idhoadon
            var result = from ct in db.ChiTietHoaDonBans.Where(x => x.IDHoaDon == idHoaDon)
                         join h in db.MatHangs on ct.IDMatHang equals h.ID
                         join dv in db.DonViTinhs on h.IDDVT equals dv.ID
                         select new
                         {
                             TenMatHang = h.TenMatHang,                                   
                             DVT = dv.TenDVT,
                             SL = (int)ct.SL,
                             DG = (int)ct.DonGia,
                             ThanhTien = ct.SL * ct.DonGia
                         };

            ////lặp các phần tử của mảng
            ////mỗi phần tử tương ứng 1 hàng trên bill

            int i = 1;
            y += 20;

            foreach (var l in result)
            {
                sum += l.SL * l.DG;
                e.Graphics.DrawString(string.Format("{0}", i++), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(10, y));
                e.Graphics.DrawString(l.TenMatHang, new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(50, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.SL), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(rong / 2, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.DG), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(rong / 2 + 100, y));
                e.Graphics.DrawString(string.Format("{0:N0}", l.ThanhTien), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(rong - 200, y));
                y += 20;
            }


            #endregion

            #region footer
            y += 40;
            //set lại tọa độ cho 2 điểm để vẽ đường thẳng thứ 3
            y += 20;
            p1 = new Point(10, y);
            p2 = new Point(rong - 10, y);
            e.Graphics.DrawLine(blackpen, p1, p2);

            //tổng tiền thanh toán
            y += 20;
            e.Graphics.DrawString(string.Format("Tổng tiền: {0:N0} VNĐ", sum), new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(rong - 200, y));

            //đọc số thành chữ
            y += 30;
            e.Graphics.DrawString(string.Format("Thành chữ: {0}", new SoThanhChu().ChuyenSoSangChuoi(sum)), new Font("Courier New", 8, FontStyle.Italic), Brushes.Black, new Point(10, y));

            y += 40;
            e.Graphics.DrawString("Xin chân thành cảm ơn sự ủng hộ của quý khách!", new Font("Courier New", 8, FontStyle.Bold), Brushes.Black, new Point(rong / 2, y));
            #endregion
        }

        private void dgvLSGD_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idHoaDon = long.Parse(dgvLSGD.Rows[e.RowIndex].Cells["IDHoaDon"].Value.ToString());
                InHoaDon();
            }
        }
    }
}
