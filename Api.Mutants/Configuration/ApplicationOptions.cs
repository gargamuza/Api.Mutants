using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Configuration
{
    public class ApplicationOptions
    {
        public static string Section = "Application";
        public string ConnectionString { get; set; }
    }
}