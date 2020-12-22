using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laborate
{
    class MyFrac
    {
        private long nom, denom;

        public MyFrac(long _nom, long _denom)
        {
            if(_denom == 0)
            {
                throw new DivideByZeroException();
            }
            long gcd = GCD(_nom, _denom);
            nom = _nom / gcd;
            denom = _denom / gcd;
        }
        private long GCD(long a, long b)
        {
            a = Math.Abs(a); b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            return a;
        }
        public override string ToString()
        {
            return nom + "/" + denom;
        }
        public string ToStringWithIntegerPart()
        {
            if (nom > denom)
            {
                if (nom % denom == 0)
                {
                    return (nom / denom).ToString();
                }
                else
                {
                    return nom / denom + " + " + (nom - denom * (nom / denom)) + "/" + denom;
                }
            }
            else return ToString();
        }
        public double DoubleValue()
        {
            return (double)nom / (double)denom;
        }
        public static MyFrac operator +(MyFrac f1, MyFrac f2)
        {
            if (f1.denom == f2.denom)
            {
                return new MyFrac(f1.nom + f2.nom, f1.denom);
            }
            else
            {
                return new MyFrac(f1.nom * f2.denom + f2.nom * f1.denom, f1.denom * f2.denom);
            }
        }
        public static MyFrac operator -(MyFrac f1, MyFrac f2)
        {
            if (f1.denom == f2.denom)
            {
                return new MyFrac(f1.nom - f2.nom, f1.denom);
            }
            else
            {
                return new MyFrac(f1.nom * f2.denom - f2.nom * f1.denom, f1.denom * f2.denom);
            }
        }
        public static MyFrac operator *(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.nom, f1.denom * f2.denom);
        }
        public static MyFrac operator /(MyFrac f1, MyFrac f2)
        {
            return new MyFrac(f1.nom * f2.denom, f1.denom * f2.nom);
        }
        static public MyFrac GetRGR113LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 3);
            for (int i = 2; i <= n; i++)
            {
                res += new MyFrac(1, (2 * i - 1) * (2 * i + 1));
            }
            return res;
        }
        static public MyFrac GetRGR115LeftSum(int n)
        {
            MyFrac res = new MyFrac(1, 1);
            for (int i = 2; i <= n; i++)
            {
                res *= new MyFrac(1, 1) - new MyFrac(1, i * i);
            }
            return res;
        }
    }
}
