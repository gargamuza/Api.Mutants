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
    public class StatsService : IStatsService
    {
        private readonly MutantsContext _mutantsContext;
        private readonly IServiceScopeFactory _serviceFactory;
        public StatsService(MutantsContext mutantsContext, IServiceScopeFactory serviceFactory)
        {
            _mutantsContext = mutantsContext;
            _serviceFactory = serviceFactory;
        }
        public void SaveStat(Stat stat)
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
