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
        private readonly MutantsContext _mutantsContext;
        private readonly IServiceScopeFactory _serviceFactory;
        public MutantsService(MutantsContext mutantsContext, IServiceScopeFactory serviceFactory)
        {
            _mutantsContext = mutantsContext;
            _serviceFactory = serviceFactory;
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
            for (int i = 0; i < adnMatrix.GetLength(0) - 1; i++)
            {
                int iOcurrencias = 0;

                for (int j = 0; j < adnMatrix.GetLength(1) - 1; j++)
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

        public  void SaveStat(Stat stat)
        {
            Task.Run(() =>
            {
                using (var scope = _serviceFactory.CreateScope())
                {                   
                    var mutantsContext = scope.ServiceProvider.GetService<MutantsContext>();
                    mutantsContext.Attach(stat);
                    mutantsContext.SaveChanges();
                }
            });
        }

        public async Task<StatCalculation> GetStats()
        {
            var statCalculation = new StatCalculation();

            var stats = _mutantsContext.Set<Stat>().AsNoTracking();

            statCalculation.CountMutantDna = await stats.Where(x => x.IsMutant).CountAsync();
            statCalculation.CountPersonDna = await stats.Where(x => !x.IsMutant).CountAsync();
            var total = statCalculation.CountMutantDna + statCalculation.CountPersonDna;
            statCalculation.Ratio = total != 0 ? (double)statCalculation.CountMutantDna / (double)total : 0;

            return statCalculation;               
        }
    }
}
