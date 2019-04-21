using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        public enum State
        {
            DiagonalUp,// avalaible for begining movement up of diagonal
            DiagonalDown,// avalaible for begining movement down of diagonal
        };

        static void Main(string[] args)
        {
            Random rand = new Random();
            int row = rand.Next(2, 9);
            int column = rand.Next(2, 9);
            
            int[,] matr1 = new int[row,column];
            
            State st = State.DiagonalUp;

            int i= 0;
            int j = 0;
            while((i < row) & (j <column))
            {
                PrintMatrix(matr1);
                matr1[i, j] = rand.Next(10, 99);

               if (st == State.DiagonalUp)
                {
                    UpDiagonal(column, ref i, ref j, ref st);
                   continue;
                }

                if (st == State.DiagonalDown)
                {
                    DownDiagonal(row, ref i, ref j, ref st);
                    continue;
                }
                
            }

            for (int numColumn = 0; numColumn < matr1.GetLength(1); numColumn++)
            {
                QuikSort(ref matr1, 0, matr1.GetLength(0), numColumn);
            }

            PrintMatrix(matr1);
            Console.ReadKey();
        }

        public static void PrintMatrix(int [,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.Write('\n');
            }

            Console.Write('\n');
            Console.ReadKey();
        }
    
        public static void QuikSort(ref int[,] matz, int min, int max, int numColumn)
        {        
            double sr = 0;
            int i;
            int j;
            if (min >= max) return;

            for  (i = min; i <max; i++)
            {
                sr += matz[i, numColumn];
            }

            sr = sr / (max - min + 1);

            for (i = min, j = max-1; i <= j;)
            {
                if (matz[i, numColumn] < sr)
                {
                    i++;
                    continue;
                }

                if (matz[j, numColumn] >= sr)
                {
                    j--;
                    continue;
                }

                int c = matz[i, numColumn];
                matz[i, numColumn] = matz[j, numColumn];
                matz[j, numColumn] = c;
                i++;
                j--;
            }

            if ((j != max)&(i != min))
                {
                    QuikSort(ref matz, min, j, numColumn);

                    QuikSort(ref matz, i, max, numColumn);
                }
    }

        public static void Right(ref int i, ref int j)
        {
            j += 1;
        }

        public static void Down(ref int i, ref int j)
        {
            i += 1;
        }

        public static void UpDiagonal(int column, ref int i, ref int j, ref State st)
        {
            if (j == column - 1)
            {
                Down(ref i, ref j);
                st = State.DiagonalDown;
            }

            else if (i == 0)
            {
                Right(ref i, ref j);
                st = State.DiagonalDown;
            }

            else
            {
                j += 1;
                i -= 1;
            }
        }

        public static void DownDiagonal(int row, ref int i, ref int j, ref State st)
        {
            if (i == row-1)
            {
                Right(ref i, ref j);
                st = State.DiagonalUp;
            }

            else if (j == 0)
            {
                Down(ref i, ref j);
                st = State.DiagonalUp;
            }

            else
            {
                j -= 1;
                i += 1;
            }
        }

    } 
}