using Api.Mutants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Services
{
    public interface IStatsService
    {
        public void SaveStat(Stat stat);
        public Task<StatCalculation> GetStats();
    }
}
