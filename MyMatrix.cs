using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Laborate
{
    class MyMatrix
    {
        private double[,] matrix;

        public MyMatrix(MyMatrix a)
        {
            matrix = (double[,])a.matrix.Clone();
        }
        public MyMatrix(double[,] _matrix)
        {
            if (_matrix.Length == 0)
            {
                throw new TestException("Масив не повинен бути пустим.");
            }
            matrix = _matrix;
        }
        public MyMatrix(double[][] _matrix)
        {
            if (_matrix.Length == 0)
            {
                throw new TestException("Масив не повинен бути пустим.");
            }
            matrix = ConvertJaggedArrTo2DArr(_matrix);
        }
        public MyMatrix(string[] _matrix)
        {
            if (_matrix.Length == 0)
            {
                throw new TestException("Масив не повинен бути пустим.");
            }
            matrix = ConvertStringArrTo2DArr(_matrix);
        }
        public MyMatrix(string _matrix)
        {
            if (_matrix.Length == 0)
            {
                throw new TestException("Рядок не повинен бути пустим.");
            }
            matrix = ConvertStrTo2dArr(_matrix);
        }
        private bool JaggedArrayRectangular(double[][] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Length != array[0].Length)
                {
                    return false;
                }
            }
            return true;
        }
        private bool StringArrayRectangular(string[] array)
        {
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i].Split(' ', '\t').Length != array[0].Split(' ', '\t').Length)
                {
                    return false;
                }
            }
            return true;
        }
        private double[,] ConvertJaggedArrTo2DArr(double[][] jagArr)
        {
            if (JaggedArrayRectangular(jagArr))
            {
                double[,] returnArr = new double[jagArr.Length, jagArr[0].Length];
                for (int i = 0; i < jagArr.Length; i++)
                {
                    for (int j = 0; j < jagArr[0].Length; j++)
                    {
                        returnArr[i, j] = jagArr[i][j];
                    }
                }
                return returnArr;
            }
            else throw new TestException("Зубчастий масив повинен бути прямокутним.");
        }
        private double[,] ConvertStringArrTo2DArr(string[] strArr)
        {
            if (StringArrayRectangular(strArr))
            {
                double[,] returnArr = new double[strArr.Length, strArr[0].Split(' ', '\t').Length];
                for (int i = 0; i < strArr.Length; i++)
                {
                    double[] tempArr = Array.ConvertAll(strArr[i].Trim().Split(' ', '\t'), double.Parse);
                    for (int j = 0; j < tempArr.Length; j++)
                    {
                        returnArr[i, j] = tempArr[j];
                    }
                }
                return returnArr;
            }
            else throw new TestException("Кількість елементів в кожному рядку повинна бути однаковою.");
        }
        private double[,] ConvertStrTo2dArr(string str)
        {
            string[] strArr = str.Split('\n');
            return ConvertStringArrTo2DArr(strArr);
        }
        public int Width
        {
            get
            {
                return matrix.GetLength(0);
            }
        }
        public int GetWidth()
        {
            return Width;
        }
        public int Height
        {
            get
            {
                return matrix.GetLength(1);
            }
        }
        public int GetHeight()
        {
            return Height;
        }
        public double GetElem(int row, int column)
        {
            return matrix[row, column];
        }
        public void SetElem(int row, int column, double elem)
        {
            matrix[row, column] = elem;
        }
        public double this[int row, int column]
        {
            get
            {
                return matrix[row, column];
            }
            set
            {
                matrix[row, column] = value;
            }
        }
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Width == b.Width && a.Height == b.Height)
            {
                double[,] res = new double[a.Width, a.Height];
                for (int i = 0; i < a.Width; i++)
                {
                    for (int j = 0; j < a.Height; j++)
                    {
                        res[i, j] = a.matrix[i, j] + b.matrix[i, j];
                    }
                }
                return new MyMatrix(res);
            }
            else throw new TestException("Матриці повинні бути одинаковими по розміру.");
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Width)
            {
                throw new TestException("Кількість стовпців першої матриці повинна бути рівна кількості рядків другої матриці.");
            }

            double[,] c = new double[a.Width, b.Height];

            for (var i = 0; i < a.Width; i++)
            {
                for (var j = 0; j < b.Height; j++)
                {
                    c[i, j] = 0;
                    for (var k = 0; k < a.Height; k++)
                    {
                        c[i, j] += a.matrix[i, k] * b.matrix[k, j];
                    }
                }
            }
            return new MyMatrix(c);
        }
        override public String ToString()
        {
            string returnStr = "";
            for(int i = 0; i < Width; i++)
            {
                string tempStr = "";
                for (int j = 0; j < Height; j++)
                {
                    tempStr += matrix[i, j] + "\t";
                }
                returnStr += tempStr.Trim('\t') + "\n";
            }
            return returnStr.Trim('\n');
        }
        private double[,] GetTransponedArray()
        {
            double[,] transArr = new double[Height, Width];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    transArr[i, j] = matrix[j, i];
                }
            }
            return transArr;
        }
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }
        public void TransponedMe()
        {
            matrix = GetTransponedArray();
        }
    }
}
