using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Mutants.Configuration
{
    public class MigrationOptions
    {
        public string EntitiesAssemblyName { get; set; }

        public static string Section = "Application:DatabaseMigrations";
    }
}
