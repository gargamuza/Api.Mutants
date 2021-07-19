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

                    if (iOcurrencias == _dnaOptions.MutantOcurrences-1)
                    {
                        Console.WriteLine("Mutante");
                        return true;
                    }
                }
            }

            //Busqueda Vertical
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

            Console.WriteLine("Busqueda Diagonal 1");
            //for (int jx = 0; jx < adnMatrix.GetLength(1) - _dnaOptions.MutantOcurrences; jx++)
            {
                //Busqueda Diagonal 1
                
                for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
                {
                    int iOcurrencias = 0;
                    var tempI = i;

                    for (int j = 0; j < adnMatrix.GetLength(1) - 1  - i; j++)
                    {

                        if (adnMatrix[tempI, j] == adnMatrix[++tempI, j + 1])
                            iOcurrencias++;
                        else
                            iOcurrencias = 0;

                        Console.WriteLine($"Comparando coordenada {tempI - 1 },{j } con {tempI},{j+1} ");

                        if (iOcurrencias == _dnaOptions.MutantOcurrences - 1)
                        {
                            Console.WriteLine("Mutante");
                            return true;
                        }
                    }
                }
            }

            ////Busqueda Diagonal 2
            //Console.WriteLine("Busqueda Diagonal 2");
            //for (int i = adnMatrix.GetLength(0) - 1; i > 0; i--)
            //{
            //    int iOcurrencias = 0;

            //    for (int j = 0; j < adnMatrix.GetLength(1) - 1; j++)
            //    {
            //        if (adnMatrix[i, j] == adnMatrix[--i, j + 1])
            //            iOcurrencias++;
            //        else
            //            iOcurrencias = 0;

            //        Console.WriteLine($"Comparando coordenada {i + 1},{j} con {i},{j + 1} ");

            //        if (iOcurrencias == _dnaOptions.MutantOcurrences - 1)
            //        {
            //            Console.WriteLine("Mutante");
            //            return true;
            //        }
            //    }
            //}

            Console.WriteLine("No Mutante");
            return false;
        }      
    }
}
