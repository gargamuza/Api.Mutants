using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Services
{
    public interface IMutantsService
    {
        public bool IsMutant(string[] adn);
        public bool IsValidAdn(string[] adn);
        public string[,] ConvertToMultiArray(string[] adn);
    }
}
