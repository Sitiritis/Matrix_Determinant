using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixDet
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 5;
            int[,] temp_chek_Matrix = new int[n, n];

            Random rnd = new Random();

            Console.WriteLine("A = ");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    temp_chek_Matrix[i, j] = rnd.Next(26);
                    Console.Write(temp_chek_Matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.WriteLine("Det(A) = " + MatrixDeterm(temp_chek_Matrix));

            Console.ReadKey();
        }

        public static int MatrixDeterm(int[,] Matrix) // Функция возвращает определитель указанной матрици
        {
            int n = (int)Math.Sqrt(Matrix.Length);
            if (n == 1)
            {                
                return Matrix[0, 0];
            }

            int result = 0;
            for (int i = 0; i < n; i++)
            {

                if ( (i % 2) == 0)
                {
                    result += Matrix[0, i] * MatrixDeterm(AdMinora(Matrix, i, 0));
                }
                else
                {
                    result -= Matrix[0, i] * MatrixDeterm(AdMinora(Matrix, i, 0));
                }
            }

            return result;
        }
                       
        public static int[,] AdMinora(int[,] Matrix, int x, int y) // Функция возвращает дополнительный минор xy-ового элемента матрицы Matrix (в виде матрици)
        {
            int n = (int)Math.Sqrt(Matrix.Length);

            int[,] Minora = new int[n - 1, n - 1];

            for (int i = 0, ln = 0; i < n; i++)
            {
                for (int j = 0, cm = 0; j < n; j++)
                {
                    if ((i == y) || (j == x))
                    {
                        continue;
                    }
                    else
                    {
                        Minora[ln, cm] = Matrix[i, j];
                        cm++;
                        if (cm == n - 1)
                        {
                            ln++;
                        }
                    }
                }
            }

            return Minora;
        }

    }
}
