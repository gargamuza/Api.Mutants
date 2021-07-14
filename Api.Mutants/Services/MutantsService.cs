﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Services
{
    public class MutantsService : IMutantsService
    {
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
            for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
            {
                int iOcurrencias = 0;

                for (int j = 0; j < adnMatrix.GetLength(1) - 1; j++)
                {
                    if (adnMatrix[i, j] == adnMatrix[i, j + 1])
                        iOcurrencias++;
                    else
                        iOcurrencias = 0;

                    if (iOcurrencias == 3)
                    {
                        Console.WriteLine("Mutante");
                        return true;
                    }

                }
            }

            //Busqueda Vertical
            for (int j = 0; j < adnMatrix.GetLength(1) - 1; j++)
            {
                int iOcurrencias = 0;

                for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
                {
                    if (adnMatrix[i, j] == adnMatrix[i + 1, j])
                        iOcurrencias++;
                    else
                        iOcurrencias = 0;

                    if (iOcurrencias == 3)
                    {
                        Console.WriteLine("Mutante");
                        return true;
                    }
                }
            }

            //Busqueda Diagonal
            for (int i = 0; i < adn.GetLength(0) - 1; i++)
            {
                int iOcurrencias = 0;

                for (int j = 0; j < adn.GetLength(1) - 1; j++)
                {
                    if (adnMatrix[i, j] == adnMatrix[++i, j + 1])
                        iOcurrencias++;
                    else
                        iOcurrencias = 0;

                    if (iOcurrencias == 3)
                    {
                        Console.WriteLine("Mutante");
                        return true;
                    }
                }
            }

            Console.WriteLine("No Mutante");
            return false;
        }

        public bool IsValidAdn(string[] adn)
        {
            throw new NotImplementedException();
        }
    }
}