using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QL_NET
{
    public class DoanhThuPhong
    {
        public int Gio { get; set; }
        public int Phut { get; set; }
        public DoanhThuPhong()
        {

        }
        public DoanhThuPhong(double thoiGian)
        {
            var tg = LayGio(thoiGian);
            Gio = (int)tg;//vd: 8.5123 --> 8h
            Phut = (int)((tg - Math.Truncate(tg))*60);
        }
        public double LayGio(double thoigian)
        {
            //vd: 8.432525233 --> 8.4h
            return Math.Round(thoigian, 1);
        }

        public override string ToString()
        {
            return string.Format("{0}:{1}",Gio, Phut);
        }
        public double ThanhTien(double thoiGian,int donGia)
        {
            return LayGio(thoiGian) * donGia;
        }
    }
}
