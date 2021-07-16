using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Configuration
{
    public class DnaOptions
    {
        public int Ocurrences { get; set; }
        public static string Section = "Application:DnaConfiguration";

    }
}