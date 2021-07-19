using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Configuration
{
    public class DnaOptions
    {
        public int MutantOcurrences { get; set; }
        public string MutantPattern { get; set; }
        public static string Section = "Application:DnaConfiguration";

    }
}