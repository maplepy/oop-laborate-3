using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laborate
{
    class Program
    {
        static void Main(string[] args)
        {
            TTriangle ABC = new TTriangle(3, 4, 5);
            Console.WriteLine("Сторони: {0} {1} {2}", ABC.getA, ABC.getB, ABC.getC);
            Console.WriteLine("Периметр: {0}, площа: {1}", ABC.perimeter, ABC.area);
            ABC.setA = 6;
            Console.WriteLine("Сторони після зміни A: {0} {1} {2}", ABC.getA, ABC.getB, ABC.getC);
            ABC.setA = 106;
        }
    }
    class TTriangle
    {
        protected int A;
        protected int B;
        protected int C;

        public TTriangle(int A_, int B_, int C_)
        {
            if (TriangleExist(A_, B_, C_))
            {
                A = A_;
                B = B_;
                C = C_;
            }
            else throw new Exception("Трикутника з введеними сторонами не існує.");
        }
        private bool TriangleExist(int A, int B, int C)
        {
            if (A < B + C && B < A + C && C < B + A)
            {
                return true;
            }
            else return false;
        }
        public int getA
        {
            get
            {
                return A;
            }
        }
        public int getB
        {
            get
            {
                return B;
            }
        }
        public int getC
        {
            get
            {
                return C;
            }
        }
        public int setA
        {   
            set
            {
                if (TriangleExist(value, B, C))
                {
                    A = value;
                }
                else throw new Exception("Трикутника зі зміненою стороною не існує.");
            }           
        }
        public int setB
        {
            set
            {
                if (TriangleExist(A, value, C))
                {
                    B = value;
                }
                else throw new Exception("Трикутника зі зміненою стороною не існує.");
            }
        }
        public int setC
        {
            set
            {
                if (TriangleExist(A, B, value))
                {
                    C = value;
                }
                else throw new Exception("Трикутника зі зміненою стороною не існує.");
            }
        }
        public int perimeter
        {
            get
            {
                return A + B + C;
            }
        }
        public double area
        {
            get
            {
                int p = (A + B + C) / 2;
                return Math.Sqrt(p*(p-A)*(p-B)*(p-C));
            }
        }
    }
}
