using MagicCube;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestLib
{
    class TestLibrary
    {
        static void Main(string[] args)
        {
            int size = 5;

            CMagicCube gen = new CMagicCube(size);

            gen.GetMagicCube.Print();
            Console.WriteLine("Это {0}магический квадрат.", gen.GetMagicCube.TestOnMagicCube(size) ? "" : "не ");

            Console.ReadKey();
        }
    }

    static class AddFuncion
    {
        public static bool TestOnMagicCube(this int[,] array2d, int size)
        {
            int control_num = size * (size * size + 1) / 2;

            int[] inline = new int[size];
            int[] incolu = new int[size];
            int[] indiag = new int[2];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        indiag[0] += array2d[i, j];
                    }
                    if (i + j == size - 1)
                    {
                        indiag[1] += array2d[i, j];
                    }
                    inline[i] += array2d[i, j];
                    incolu[j] += array2d[i, j];
                }
            }

            return inline.All(u => u == control_num) && incolu.All(u => u == control_num) && indiag.All(u => u == control_num);
        }

        public static void Print(this int[,] array2d)
        {
            int i = 0;

            foreach (var item in array2d)
            {
                Console.Write("{0,2} ", item);

                if (i++ == array2d.GetLength(0) - 1)
                {
                    Console.WriteLine();
                    i = 0;
                }
            }
        }
    }
}
