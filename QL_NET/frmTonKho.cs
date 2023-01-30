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
    public partial class frmTonKho : Form
    {
        public frmTonKho()
        {
            InitializeComponent();
        }

        private QLNET_DatabaseDataContext db;
        private void frmTonKho_Load(object sender, EventArgs e)
        {
            db = new QLNET_DatabaseDataContext();

            btnThongKe.PerformClick(); // gọi sự kiện click của btnThongKe khi form được load

            //ẩn cột
            dgvTonKho.Columns["isDichVu"].Visible = false;

            //đặt lại tên cột
            dgvTonKho.Columns["mahang"].HeaderText = "Mã hàng";

            dgvTonKho.Columns["tenhang"].HeaderText = "Tên hàng";
            dgvTonKho.Columns["dvt"].HeaderText = "ĐVT";
            dgvTonKho.Columns["tonkho"].HeaderText = "Tồn kho";
            dgvTonKho.Columns["dg"].HeaderText = "Đơn giá";


            //căn chỉnh
            dgvTonKho.Columns["tenhang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvTonKho.Columns["mahang"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTonKho.Columns["dvt"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTonKho.Columns["tonkho"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;



            //định dạng phần nghìn
            dgvTonKho.Columns["tonkho"].DefaultCellStyle.Format = "N0";
            dgvTonKho.Columns["dg"].DefaultCellStyle.Format = "N0";




        }
        private int LoaiThongKe = -1;
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (rbtDaHet.Checked)
            {
                ThongKe(0);
                return;
            }
            if (rbtGanHet.Checked)
            {
                ThongKe(-1);
                return;

            }
            if (rbtTatCaMatHang.Checked)
            {
                ThongKe(1); //thêm 1 tham số để phân biệt các trường hợp
                return;
            }
            
        }

        private void ThongKe(int dieukien)
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

            if(dieukien == 0)//lấy các mặt hàng khi số lượng đã hết
            {
                var rs = tonkhohang.Where(x => x.tonkho == 0);
                dgvTonKho.DataSource = rs;
                return;
            }
            if (dieukien == 1)
            {
               
                dgvTonKho.DataSource = tonkhohang;
                return;
            }
            if (dieukien == -1)//lấy các mặt hàng gần hết
            {
                var ganhet = int.Parse(db.CauHinhs.SingleOrDefault(x => x.tukhoa == "ganhet").giatri);
                var rs = tonkhohang.Where(x => x.tonkho <= ganhet);
                dgvTonKho.DataSource = rs;
                return;
            }

            //sắp xếp tăng theo thứ tự mặt hàng trước, dịch vụ sau. rồi sắp xếp tăng dần theo tên mặt hàng và dịch vụ
            dgvTonKho.DataSource = tonkhohang;
        }



    }
}
