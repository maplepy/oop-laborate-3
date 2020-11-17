using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laborate
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("1: MyMatrix test  2: MyFrac test. Input: ");
            string choise = Console.ReadLine();
            switch(choise)
            {
                case "1":
                    MyMatrixTest();
                    return;
                case "2":
                    MyFracTest();
                    return;
            }         
        }
        static void MyMatrixTest()
        {
            int size = rnd.Next(5, 10);
            MyMatrix m1 = new MyMatrix(RandomDoubleArr(size));
            MyMatrix m2 = new MyMatrix(RandomStr(size));

            Console.WriteLine("m1: width: {0}, height: {1}\n{2}\n\nm2: width: {3}, height: {4}\n{5}", m1.Width, m1.Height, m1, m2.Width, m2.Height, m2);
            Console.WriteLine("\nm1 + m2:\n{0}\n\nm1 * m2:\n{1}\n\nm1 transp:\n{2}", m1 + m2, m1 * m2, m1.GetTransponedCopy());
        }
        static double[,] RandomDoubleArr(int size)
        {
            double[,] d1 = new double[size, size];

            for (int i = 0; i < d1.GetLength(0); i++)
            {
                for(int j = 0; j < d1.GetLength(1); j++)
                {
                    d1[i, j] = Math.Round(rnd.NextDouble() * 100, 3);
                }
            }
            return d1;
        }
        static string[] RandomStrArr(int size)
        {
            double[,] d = RandomDoubleArr(size);
            string[] strArr = new string[d.GetLength(0)];
            for (int i = 0; i < d.GetLength(0); i++)
            {
                string s = "";
                for (int j = 0; j < d.GetLength(1); j++)
                {
                    s += d[i, j].ToString() + "\t";
                }
                strArr[i] = s.Trim('\t');
            }
            return strArr;
        }
        static string RandomStr(int size)
        {
            double[,] d = RandomDoubleArr(size);
            string str = "";
            for (int i = 0; i < d.GetLength(0); i++)
            {
                string s = "";
                for (int j = 0; j < d.GetLength(1); j++)
                {
                    s += d[i, j].ToString() + "\t";
                }
                str += s.Trim('\t') + "\n";
            }
            return str.Trim('\n');
        }
        static void MyFracTest()
        {
            MyFrac f1 = new MyFrac(rnd.Next(1, 100), rnd.Next(1, 100));
            MyFrac f2 = new MyFrac(rnd.Next(1, 100), rnd.Next(1, 100));

            Console.WriteLine("f1: {0}, f2: {1}\n", f1.ToStringWithIntegerPart(), f2.ToStringWithIntegerPart());
            Console.WriteLine("f1 + f2: {0}\nf1 - f2: {1}\nf1 * f2: {2}\nf1 / f2: {3}\n", f1 + f2, f1 - f2, f1 * f2, f1 / f2);
            int n = rnd.Next(10, 20);
            Console.WriteLine("RGR113LeftSum: {0}, n/(2n+1): {1}\nRGR115LeftSum: {2}, (n+1)/(2n): {3}", MyFrac.GetRGR113LeftSum(n).DoubleValue(), (double)n/(2*n+1), MyFrac.GetRGR115LeftSum(n).DoubleValue(), ((double)n+1)/(2*(double)n));
        }
    }
    class TestException: Exception
    {
        public TestException(string msg): base(msg)
        {
        }
    }
}
