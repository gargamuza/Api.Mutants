using Api.Mutants.Configuration;
using Api.Mutants.Helpers;
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
       
        public bool IsMutant(string[] adn)
        {
            var adnMatrix = ArraysHelper.ConvertToMultiArray(adn);
           
            return DnaHorizontalSearch(adnMatrix) || DnaVerticalSearch(adnMatrix) || DnaDiagonalSearch(adnMatrix);           
        }

        #region Dna Search

        public bool DnaDiagonalSearch(string[,] adnMatrix)
        {                    
            //Busqueda Diagonal 
            for (int iDiagonal = 0; iDiagonal < 2; iDiagonal++)
            {
                Console.WriteLine($"Busqueda Diagonal {iDiagonal}");

                if (iDiagonal == 1)
                    adnMatrix = ArraysHelper.TransposeRowsAndColumns(adnMatrix);

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
      
        public bool DnaVerticalSearch(string[,] adnMatrix)
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

        public bool DnaHorizontalSearch(string[,] adnMatrix)
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

        #endregion
    }
}
