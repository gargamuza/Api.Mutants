using Api.Mutants.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Services
{
    public interface IMutantsService
    {
        public bool IsMutant(string[] adn);
        public bool DnaDiagonalSearch(string[,] adn);
        public bool DnaVerticalSearch(string[,] adn);
        public bool DnaHorizontalSearch(string[,] adn);

    }
}
