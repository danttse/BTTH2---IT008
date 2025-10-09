using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace BAI04
{
    class Tinhtoan
    {
        public static int Uocchung(int a, int b)
        {
            if (a < b)
            {
                int tam = a;
                a = b;
                b = tam;
            }
            while (b != 0)
            {
                int tam = a;
                a = b;
                b = tam % b;
            }
            return a < 0 ? -a : a;
        }
    }
    class Phanso
    {
        int tuso;
        int mauso;
        public Phanso(int tuso, int mauso)
        {
            int ucln = Tinhtoan.Uocchung(tuso, mauso);
            if (mauso < 0)
            {
                tuso = -tuso;
                mauso = -mauso;
            }
            this.tuso = tuso / ucln;
            this.mauso = mauso / ucln;
        }
        public static Phanso operator +(Phanso A, Phanso B)
        {
            int newtu = A.tuso * B.mauso + B.tuso * A.mauso;
            int newmau = A.mauso * B.mauso;
            Phanso kq = new Phanso(newtu, newmau);
            return kq;
        }
        public static Phanso operator -(Phanso A, Phanso B)
        {
            int newtu = A.tuso * B.mauso - B.tuso * A.mauso;
            int newmau = A.mauso * B.mauso;
            Phanso kq = new Phanso(newtu, newmau);
            return kq;
        }
        public static Phanso operator *(Phanso A, Phanso B)
        {
            int newtu = A.tuso * B.tuso;
            int newmau = A.mauso * B.mauso;
            Phanso kq = new Phanso(newtu, newmau);
            return kq;
        }
        public static Phanso operator /(Phanso A, Phanso B)
        {
            int newtu = A.tuso * B.mauso;
            int newmau = A.mauso * B.tuso;
            Phanso kq = new Phanso(newtu, newmau);
            return kq;
        }
        public void Xuat()
        {
            if (mauso == 1)
            {
                Console.Write(tuso + " ");
            }
            else
                Console.Write($"{tuso}/{mauso} ");
        }
        public float Giatri()
        {
            return (float)tuso / mauso;
        }
    }
    class Program
    {
        public static void Main()
        {
            //NHAP VAO 2 PHAN SO VA TINH TONG, HIEU, TICH, THUONG
            string[] tam;
            Phanso A;
            Phanso B;
            while (true)
            {
                Console.Write("Nhap phan so thu nhat (tuso/mauso): ");
                tam = Console.ReadLine().Split('/');
                if (int.Parse(tam[1]) == 0)
                {
                    Console.WriteLine("Mau khong thoa man!");
                    continue;
                }
                A = new Phanso(int.Parse(tam[0]), int.Parse(tam[1]));
                break;
            }
            while (true)
            {
                Console.Write("Nhap phan so thu nhat (tuso/mauso): ");
                tam = Console.ReadLine().Split('/');
                if (int.Parse(tam[1]) == 0)
                {
                    Console.WriteLine("Mau khong thoa man!");
                    continue;
                }
                B = new Phanso(int.Parse(tam[0]), int.Parse(tam[1]));
                break;
            }
            Phanso tong = A + B;
            Phanso hieu = A - B;
            Phanso tich = A * B;
            Phanso thuong = A / B;
            Console.WriteLine("Tong, hieu, tich, thuong lan luot la: ");
            tong.Xuat();
            hieu.Xuat();
            tich.Xuat();
            thuong.Xuat();
            //NHAP VAO DAY PHAN SO
            Console.Write("\nNhap vao so n: ");
            int n = int.Parse(Console.ReadLine());
            List<Phanso> ds = new List<Phanso>();
            for (int i = 0; i < n; i++)
            {
                Console.Write($"Phan so thu {i + 1} : ");
                tam = Console.ReadLine().Split('/');
                ds.Add(new Phanso(int.Parse(tam[0]), int.Parse(tam[1])));
            }
            Phanso jmax = ds[0];
            for (int i = 1; i < ds.Count; i++)
                if (jmax.Giatri() < ds[i].Giatri()) jmax = ds[i];
            Console.Write("Phan so lon nhat la: ");
            jmax.Xuat();
            Console.WriteLine("\nDay phan so sau sap xep: ");
            ds.Sort((a, b) =>
            {
                return a.Giatri().CompareTo(b.Giatri());
            }
            );
            for (int i = 0; i < ds.Count; i++)
            {
                ds[i].Xuat();
            }
        }
    }
}
