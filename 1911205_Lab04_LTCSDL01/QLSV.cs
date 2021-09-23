using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1911205_Lab04_LTCSDL01
{

    public class QLSV
    {

        public List<SinhVien> DanhSach;
        public QLSV()
        {
            DanhSach = new List<SinhVien>();

        }
        public void Them(SinhVien sv)
        {
            this.DanhSach.Add(sv);
        }
        public SinhVien this[int index]
        {
            get { return DanhSach[index]; }

            set { DanhSach[index] = value; }
        }

        public void Xoa(object obj, SoSanh ss)
        {
            int i = DanhSach.Count - 1;
            for (; i >= 0; i--)
                if (ss(obj, this[i]) == 0)
                    DanhSach.RemoveAt(i);
        }
        public SinhVien Tim(object obj, SoSanh ss)
        {
            SinhVien svresult = null;
            foreach (SinhVien sv in DanhSach)
                if (ss(obj, sv) == 0)
                {
                    svresult = sv;
                    break;
                }
            return svresult;
        }
        public bool Sua(SinhVien svsua, object obj, SoSanh ss)
        {
            int i, count;
            bool kq = false;
            count = this.DanhSach.Count - 1;
            for (i = 0; i < count; i++)
                if (ss(obj, DanhSach[i]) == 0)
                {
                    this[i] = svsua;
                    kq = true;
                    break;
                }
            return kq;
        }
        public void LuuFile(string filename)
        {
            string t;
            using (var sr = new FileStream(filename, FileMode.Create, FileAccess.Write))
            using (var writer = new StreamWriter(sr))
                foreach (var sv in DanhSach)
                {

                    t = sv.MaSo;
                    t += "*" + sv.HoTen;
                    t += "*"+sv.NgaySinh.ToString("dd/MM/yyyy") ;
                    t += "*" + sv.DiaChi;
                    t += "*" + sv.Lop;
                    t += "*" + sv.Hinh;
                    t += "*" + (sv.GioiTinh ? "1" : "0");
                    t += "*" + sv.Email;
                    t += "*" + sv.SDT;
                    writer.WriteLine(t);
                }

        }
        public void DocTuFile(string filename)
        {
            string t;
            string[] s;
            SinhVien sv;
            StreamReader sr = new StreamReader(
            new FileStream(filename, FileMode.Open));
            while ((t = sr.ReadLine()) != null)
            {
                s = t.Split('*');
                sv = new SinhVien();
                sv.MaSo = s[0];
                sv.HoTen = s[1];
                sv.NgaySinh = DateTime.ParseExact(s[2], "dd/MM/yyyy", null);
                sv.DiaChi = s[3];
                sv.Lop = s[4];
                sv.Hinh = s[5];
                sv.GioiTinh = false;
                if (s[6] == "1")
                    sv.GioiTinh = true;
                sv.Email = s[7];
                sv.SDT = s[8];
                this.Them(sv);
            }
        }

    }
}


