using Api.Mutants.Configuration;
using Api.Mutants.Models;
using Api.Mutants.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Services
{
    public class MutantsService : IMutantsService
    {
        DnaOptions _dnaOptions;
        public MutantsService(DnaOptions dnaOptions)
        {
            _dnaOptions = dnaOptions;
        }

        public string[,] ConvertToMultiArray(string[] adn)
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

        public bool IsMutant(string[] adn)
        {
            var adnMatrix = ConvertToMultiArray(adn);
           
            return AdnHorizontalSearch(adnMatrix) || AdnVerticalSearch(adnMatrix) || AdnDiagonalSearch(adnMatrix);           
        }

        public bool AdnDiagonalSearch(string[,] adnMatrix)
        {                    
            //Busqueda Diagonal 
            for (int iDiagonal = 0; iDiagonal < 2; iDiagonal++)
            {
                Console.WriteLine($"Busqueda Diagonal {iDiagonal}");

                if (iDiagonal == 1)
                    adnMatrix = TransposeRowsAndColumns(adnMatrix);

                int rowLength = adnMatrix.GetLength(0);
                int colLength = adnMatrix.GetLength(1);

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        Console.Write(string.Format("{0} ", adnMatrix[i, j]));
                    }
                    Console.Write(Environment.NewLine + Environment.NewLine);
                }

                for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
                {
                    int iOcurrencias = 0;
                    var tempI = i;

                    for (int j = 0; j < adnMatrix.GetLength(1) - 1 - i; j++)
                    {

                        if (adnMatrix[tempI, j] == adnMatrix[++tempI, j + 1])
                            iOcurrencias++;
                        else
                            iOcurrencias = 0;

                        Console.WriteLine($"Comparando coordenada {tempI - 1 },{j } con {tempI},{j + 1} ");

                        if (iOcurrencias == _dnaOptions.MutantOcurrences - 1)
                        {
                            Console.WriteLine("Mutante");
                            return true;
                        }
                    }
                }
            }         
            return false;
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

        public void Reverse2DimArray(ref string[,] theArray)
        {
            
            

            for (int rowIndex = 0;
                 rowIndex <= (theArray.GetUpperBound(0)); rowIndex++)
            {
                for (int colIndex = 0;
                     colIndex <= (theArray.GetUpperBound(1) / 2); colIndex++)
                {
                    string tempHolder = theArray[rowIndex, colIndex];
                    theArray[rowIndex, colIndex] =
                      theArray[rowIndex, theArray.GetUpperBound(1) - colIndex];
                    theArray[rowIndex, theArray.GetUpperBound(1) - colIndex] =
                      tempHolder;
                }
            }
        }

        private string[,] InvertMatrix(ref string[,] adnMatrix)
        {
            for (int i = 0; i < adnMatrix.GetLength(0); i++)
            {             
                for (int j = 0; j < adnMatrix.GetLength(1); j++)
                {
                    if (i == j)
                        continue;
                    var aux = adnMatrix[i, j];
                    adnMatrix[i, j] = adnMatrix[j, i];
                    adnMatrix[j, i] = aux;                   
                }
            }
            return adnMatrix;
        }

        public bool AdnVerticalSearch(string[,] adnMatrix)
        {
            Console.WriteLine("Busqueda Vertical");
            for (int j = 0; j < adnMatrix.GetLength(1) - 1; j++)
            {
                int iOcurrencias = 0;

                for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
                {
                    if (adnMatrix[i, j] == adnMatrix[i + 1, j])
                        iOcurrencias++;
                    else
                        iOcurrencias = 0;

                    Console.WriteLine($"Comparando coordenada {i},{j} con {i + 1},{j} ");

                    if (iOcurrencias == _dnaOptions.MutantOcurrences - 1)
                    {
                        Console.WriteLine("Mutante");
                        return true;
                    }
                }
            }
            return false;
        }

        public bool AdnHorizontalSearch(string[,] adnMatrix)
        {
            //Busqueda Horizontal
            Console.WriteLine("Busqueda Horizontal");
            for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
            {
                int iOcurrencias = 0;

                for (int j = 0; j < adnMatrix.GetLength(1) - 1; j++)
                {
                    if (adnMatrix[i, j] == adnMatrix[i, j + 1])
                        iOcurrencias++;
                    else
                        iOcurrencias = 0;

                    Console.WriteLine($"Comparando coordenada {i},{j} con {i},{j + 1} ");

                    if (iOcurrencias == _dnaOptions.MutantOcurrences - 1)
                    {
                        Console.WriteLine("Mutante");
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
