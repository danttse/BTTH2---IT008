using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bai01
{
    class Tinhtoan
    {
        public static void Xuatlich(DateTime ngaydau)
        {
            Console.WriteLine("Sun   Mon   Tue   Wed   Thu   Fri   Sat");
            int i = 1;
            int n = DateTime.DaysInMonth(ngaydau.Year, ngaydau.Month);
            bool t = false;
            while (true)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j == (int)ngaydau.DayOfWeek) t = true;
                    if (t)
                    {
                        if (i < 10)
                            Console.Write($"{i,3}   ");
                        else
                            Console.Write($"{i,3}   ");
                        ++i;
                        if (i > n) return;
                    }
                    else
                        Console.Write($"{"",6}");
                }
                Console.WriteLine();
            }
        }
    }
    class Program
    {
        public static void Main()
        {

            Console.Write("Month: ");
            string[] tam = Console.ReadLine().Split('/');
            int thang = int.Parse(tam[0]);
            int nam = int.Parse(tam[1]);
            if (thang <= 12 && thang > 0 && nam > 0)
            {
                DateTime ngaydau = new DateTime(nam, thang, 1);
                Tinhtoan.Xuatlich(ngaydau);
            }
            else
            {
                Console.WriteLine("Thang hoac nam khong hop le!");
            }
        }
    }
}