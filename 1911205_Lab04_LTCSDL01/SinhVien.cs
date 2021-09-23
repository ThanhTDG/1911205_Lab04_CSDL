using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1911205_Lab04_LTCSDL01
{
    public class SinhVien
    {
        public string MaSo { get; set; }
        public string HoTen { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgaySinh { get; set; }
        public string Lop { get; set; }
        public string Hinh { get; set; }
        public string SDT { get; set; }
        public bool GioiTinh { get; set; }

        public SinhVien() { }
        public SinhVien(string ms, string ht, string email, DateTime ngay,
        string dc, string lop,string sdt, string hinh, bool gt)
        {
            MaSo = ms;
            HoTen = ht;
            Email = email;
            SDT = sdt;
            NgaySinh = ngay;
            DiaChi = dc;
            Lop = lop;
            Hinh = hinh;
            GioiTinh = gt;
        }
    }
}

