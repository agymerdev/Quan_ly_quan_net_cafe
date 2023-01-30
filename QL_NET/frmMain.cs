using QL_NET.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QL_NET
{
    public partial class frmMain : Form
    {

        public frmMain()
        {

            InitializeComponent();
        }
        


        private QLNET_DatabaseDataContext db;
        NhanVien nv;
        #region Giao_Dien
        public const int VM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImportAttribute("user32.dll")]

        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]

        public static extern bool ReleaseCapture();
        private Boolean isMaximize = false;
        private void ptbExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ptbMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ptbMaximize_Click(object sender, EventArgs e)
        {
            if (!isMaximize)
            {
                this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
                this.WindowState = FormWindowState.Maximized;
                ptbMaximize.Image = Properties.Resources.res;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                ptbMaximize.Image = Properties.Resources.maxi;
            }
            isMaximize = !isMaximize;
        }

        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, VM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        private void frmMain_Load(object sender, EventArgs e)
        {
            var f = new frmDangNhap();
            f.ShowDialog();
            nv = f.nv;



            if (nv != null)
            {

                if (nv.ID == 2)
                {
                    thốngKêBáoCáoToolStripMenuItem.Visible = false;
                    nhanVienToolStripMenuItem.Visible = false;
                }
                MessageBox.Show("Người truy cập: " + nv.HoVaTen);
                lblNhanVien.Text = String.Format("Người truy cập: {0}", nv.HoVaTen);

                db = new QLNET_DatabaseDataContext();
                var ten = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "tencuahang").giatri;
                var diachi = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "diachi").giatri;
                var phone = db.CauHinhs.SingleOrDefault(x => x.tukhoa == "phone").giatri;

                lblTitle.Text = String.Format($"{ten} - {diachi} - {phone} ");
            }
            else
            {
                Application.Exit();
            }



        }
        #region menu
        private void addForm(Form f)
        {
            f.FormBorderStyle = FormBorderStyle.None;//bỏ viền form
            f.Dock = DockStyle.Fill;//tự động co giãn
            f.TopLevel = false;
            f.TopMost = true;
            grbContent.Controls.Clear();//xóa các item đang có trên groupbox
            grbContent.Controls.Add(f);
            f.Show();
        }
        private void loaiPhongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmLoaiPhong(nv.Username); //khai báo form
            addForm(f);

        }

        private void phongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmPhong(nv.Username);
            addForm(f);
        }

        private void matHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmMatHang(nv.Username);
            addForm(f);
        }

        private void donvitinhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDonViTinh(nv.Username);
            addForm(f);
        }

        private void nhaCungCapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhaCC(nv.Username);
            addForm(f);
        }

        private void nhanVienToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhanVien(nv.Username);
            addForm(f);
        }

        private void nhapHangToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmNhapHang(nv.Username);
            addForm(f);
        }

        private void bánHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmBanHang(nv.Username);
            addForm(f);
        }
        private void tồnKhoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmTonKho();
            addForm(f);
        }

        private void doanhThuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var f = new frmDoanhThu();
            addForm(f);
        }

        #endregion

        private void thoatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new frmDoiMatKhau(nv).ShowDialog();
        }
    }
}