using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Models
{
    public class StatCalculation
    {
        public int CountMutantDna { get; set; }
        public int CountPersonDna { get; set; }
        public double Ratio { get; set; }
    }
}
