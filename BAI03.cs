using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BAI03
{
    class Tinhtoan
    {
        public static void Xuat(int[,] a)
        {
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    Console.Write($"{a[i, j],-4}");
                Console.WriteLine();
            }
        }
        public static void Timkiem(int[,] a, int key)
        {
            int posx = -1, posy = -1;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if (a[i, j] == key)
                    {
                        posx = i;
                        posy = j;
                        Console.WriteLine($"Tim thay {key} tai dong {posx} cot {posy}");
                        return;
                    }
            }
            Console.WriteLine($"Khong tim thay {key}");
        }
        static bool checkngto(int n)
        {
            if (n < 2) return false;
            for (int i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }
        public static void Phantunguyento(int[,] a)
        {
            Console.Write("Danh sach cac so nguyen to trong ma tran: ");
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                    if (checkngto(a[i, j])) Console.Write(a[i, j] + " ");
            }
            Console.WriteLine();
        }
        public static void Dongnhieunguyento(int[,] a)
        {
            int jmax = 0;
            int posx = -1;
            for (int i = 0; i < a.GetLength(0); i++)
            {
                int dem = 0;
                for (int j = 0; j < a.GetLength(1); j++)
                    if (checkngto(a[i, j])) ++dem;
                if (dem > jmax)
                {
                    jmax = dem;
                    posx = i;
                }
            }
            if (posx >= 0)
            {
                Console.WriteLine($"Dong co nhieu so nguyen to nhat la dong {posx} voi {jmax} so");
            }
            else Console.WriteLine("Khong co so nguyen to");
        }
    }
    class Program
    {
        public static void Main()
        {
            Console.Write("So dong: ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("So cot: ");
            int m = int.Parse(Console.ReadLine());
            int[,] a = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] tam = Console.ReadLine().Split();
                for (int j = 0; j < m; j++)
                {
                    a[i, j] = int.Parse(tam[j]);
                }
            }
            Tinhtoan.Xuat(a);
            Console.Write("Nhap phan tu can tim: ");
            int key = int.Parse(Console.ReadLine());
            Tinhtoan.Timkiem(a, key);
            Tinhtoan.Phantunguyento(a);
            Tinhtoan.Dongnhieunguyento(a);
        }
    }
}
