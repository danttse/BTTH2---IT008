using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH2
{
    abstract class Batdongsan
    {
        protected string diadiem;
        protected long giatien;
        protected float dientich;
        public string getDiadiem
        { get { return diadiem; } }
        public long getGiatien
        { get { return giatien; } }
        public float getDientich
        { get { return dientich; } }
        public abstract void Nhap();
        public abstract void Xuat();
        protected void Nhapthongtinchung()
        {
            Console.Write("Dia diem: ");
            diadiem = Console.ReadLine();
            Console.Write("Gia tien: ");
            giatien = long.Parse(Console.ReadLine());
            Console.Write("Dien tich: ");
            dientich = float.Parse(Console.ReadLine());
        }
        protected void Xuatthongtinchung()
        {
            Console.WriteLine($"    Dia diem: {diadiem}");
            Console.WriteLine($"    Gia tien: {giatien}");
            Console.WriteLine($"    Dien tich: {dientich}");
        }
    }
    class Khudat:Batdongsan
    {
        public override void Nhap()
        {
            Console.WriteLine("Nhap thong tin cua khu dat!");
            Nhapthongtinchung();
        }
        public override void Xuat()
        {
            Console.WriteLine("Khu dat");
            Xuatthongtinchung();
        }
    }
    class Nhapho : Batdongsan
    {
        long namxd;
        long sotang;
        public long getNamxd
        { get { return namxd; }}
        public long getSotang
        { get { return sotang; }}
        public override void Nhap()
        {
            Console.WriteLine("Nhap thong tin cua nha pho!");
            Nhapthongtinchung();
            Console.Write("Nam xay dung: ");
            namxd=long.Parse(Console.ReadLine());
            Console.Write("So tang: ");
            sotang=long.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine("Nha pho");
            Xuatthongtinchung();
            Console.WriteLine($"    Nam xay dung: {namxd}");
            Console.WriteLine($"    So tang: {sotang}");
        }
    }
    class Chungcu : Batdongsan
    {
        long sotang;
        public long getSotang
        { get { return sotang; } }
        public override void Nhap()
        {
            Console.WriteLine("Nhap thong tin cua chung cu!");
            Nhapthongtinchung();
            Console.Write("So tang: ");
            sotang = long.Parse(Console.ReadLine());
        }
        public override void Xuat()
        {
            Console.WriteLine("Chung cu");
            Xuatthongtinchung();
            Console.WriteLine($"    So tang: {sotang}");
        }
    }
    class Quanly
    {
        List<Batdongsan> Danhsach;
        public Quanly() {
            Danhsach = new List<Batdongsan>();
        }
        public void Nhapdanhsach()
        {
            Console.Write("Nhap so BDS: ");
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.Write("Chon loai bat dong san (1-Khu dat,2-Nha pho,3-Chung cu): ");
                int tam = int.Parse(Console.ReadLine());
                Batdongsan BDS;
                if (tam == 1)
                {
                    BDS = new Khudat();
                    BDS.Nhap();
                    Danhsach.Add(BDS);
                }
                else
                if (tam == 2)
                {
                    BDS = new Nhapho();
                    BDS.Nhap();
                    Danhsach.Add(BDS);
                }
                else
                {
                    BDS = new Chungcu();
                    BDS.Nhap();
                    Danhsach.Add(BDS);
                }
            }
        }
        public void Xuatdanhsach()
        {
            for (int i = 0; i < Danhsach.Count; i++)
            {
                Danhsach[i].Xuat();
            }
        }
        public void Xuattonggia()
        {
            long Sumkhudat = 0, Sumnhapho = 0, Sumchungcu = 0;
            for (int i = 0; i < Danhsach.Count; i++)
            {
                if (Danhsach[i] is Khudat)
                {
                    Sumkhudat += Danhsach[i].getGiatien;
                }
                else
                if (Danhsach[i] is Nhapho)
                {
                    Sumnhapho += Danhsach[i].getGiatien;
                }
                else
                {
                    Sumchungcu += Danhsach[i].getGiatien;
                }
            }
            Console.WriteLine("\nTong gia ban khu dat: " + Sumkhudat);
            Console.WriteLine("Tong gia ban nha pho: " + Sumnhapho);
            Console.WriteLine("Tong gia ban chung cu: " + Sumchungcu);
        }
        public void Locdientich()
        {
            Console.WriteLine("\nCac bat dong san dat chuan dien tich: ");
            bool t = false;
            for (int i = 0; i < Danhsach.Count; i++)
            {
                if (Danhsach[i] is Khudat)
                {
                    if (Danhsach[i].getDientich >= 100)
                    {
                        Danhsach[i].Xuat();
                        t = true;
                    }
                } else
                if (Danhsach[i] is Nhapho tam)
                {
                    if (tam.getDientich > 60 && tam.getNamxd >= 2019)
                    {
                        tam.Xuat();
                        t = true;
                    }
                }
            }
            if (!t) Console.WriteLine("   Khong co");
        }
        public void Timkiem()
        {
            Console.Write("\nTu khoa dia diem tim kiem: ");
            string keyword = Console.ReadLine();
            Console.Write("Gia tim kiem: ");
            long keygia = long.Parse(Console.ReadLine());
            Console.Write("Dien tich tim kiem: ");
            int keydientich = int.Parse(Console.ReadLine());
            Console.WriteLine("Ket qua tim kiem: ");
            keyword = keyword.ToLower();
            bool t = false;
            for (int i = 0; i < Danhsach.Count; i++)
            {
                if (Danhsach[i].getDiadiem.ToLower().Contains(keyword) &&
                    Danhsach[i].getGiatien <= keygia &&
                    Danhsach[i].getDientich >= keydientich)
                {
                    Danhsach[i].Xuat();
                    t = true;
                }
            }
            if (!t) Console.WriteLine("     Khong tim thay");
        }
        
    }
    class Program
    {
        public static void Main()
        {
            Quanly tam=new Quanly();
            tam.Nhapdanhsach();
            tam.Xuatdanhsach();
            tam.Xuattonggia();
            tam.Locdientich();
            tam.Timkiem();
        }
    }
}
