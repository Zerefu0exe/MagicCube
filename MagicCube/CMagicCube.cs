using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicCube
{
    public class CMagicCube
    {
        private int size;
        private int[,] result;
        private int[,] catalyst;

        public int[,] GetMagicCube => result;

        public CMagicCube(int size)
        {
            result = new int[size, size];
            catalyst = new int[2 * size - 1, 2 * size - 1];
            this.size = size;

            Fill_numbers();
            Rotation45();
            Outskirts_replacement();
            Center_replacement();
        }

        private void Outskirts_replacement()
        {
            int u = 2 * size - 1;
            int v = (size - 1) / 2;
            int g = 3 * (size - 1) / 2;

            for (int i = 0; i < 2 * size - 1; i++)
            {
                for (int j = 0; j < 2 * size - 1; j++)
                {
                    if (catalyst[i, j] != 0 && 0 <= i && i < v)
                    {
                        catalyst[i + size, j] = catalyst[i, j];
                    }
                    else if (catalyst[i, j] != 0 && g < i && i <= u - 1)
                    {
                        catalyst[i - size, j] = catalyst[i, j];
                    }
                    else if (catalyst[i, j] != 0 && 0 <= j && j < v)
                    {
                        catalyst[i, j + size] = catalyst[i, j];
                    }
                    else if (catalyst[i, j] != 0 && g < j && j <= u - 1)
                    {
                        catalyst[i, j - size] = catalyst[i, j];
                    }
                }
            }
        }

        private void Center_replacement()
        {
            int u = (size - 1) / 2;
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = catalyst[u + i, u + j];
                }
            }
        }

        private void Rotation45()
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    catalyst[size - 1 + i - j, i + j] = result[i, j];
                }
            }
        }

        private void Fill_numbers()
        {
            int count = 1;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    result[i, j] = count++;
                }
            }
        }
    }
}
