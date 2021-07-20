using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Helpers
{
    public class ArraysHelper
    {
        public static string[,] ConvertToMultiArray(string[] adn)
        {
            string[,] adnMatrix = new string[adn.Length, adn.Max(s => s.Length)];

            for (int i = 0; i < adnMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < adnMatrix.GetLength(1); j++)
                {
                    adnMatrix[i, j] = adn[i].Substring(j, 1);
                }
            }

            return adnMatrix;
        }

        public static T[,] TransposeRowsAndColumns<T>(T[,] arr)
        {
            int rowCount = arr.GetLength(0);
            int columnCount = arr.GetLength(1);
            T[,] transposed = new T[columnCount, rowCount];
            if (rowCount == columnCount)
            {
                transposed = (T[,])arr.Clone();
                for (int i = 1; i < rowCount; i++)
                {
                    for (int j = 0; j < i; j++)
                    {
                        T temp = transposed[i, j];
                        transposed[i, j] = transposed[j, i];
                        transposed[j, i] = temp;
                    }
                }
            }
            else
            {
                for (int column = 0; column < columnCount; column++)
                {
                    for (int row = 0; row < rowCount; row++)
                    {
                        transposed[column, row] = arr[row, column];
                    }
                }
            }
            return transposed;
        }
    }
}
