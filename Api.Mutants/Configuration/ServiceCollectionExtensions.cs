
using Api.Mutants.Converters;
using Api.Mutants.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Api.Mutants.Configuration
{
    public static class ServiceCollectionExtensions
    {

        public static void AddDnaConfiguration(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
            }

            var dnaOptions = new DnaOptions();
            configuration.GetSection(DnaOptions.Section).Bind(dnaOptions);
            services.AddSingleton(typeof(DnaOptions), dnaOptions);
        }

        public static void AddBdContext(this IServiceCollection services)
        {
            IConfiguration configuration;

            using (
                var serviceScope = services.BuildServiceProvider().CreateScope())
            {
                configuration = serviceScope.ServiceProvider.GetService<IConfiguration>();
            }

            var applicationOptions = new ApplicationOptions();
            configuration.GetSection(ApplicationOptions.Section).Bind(applicationOptions);

            services.AddDbContext<MutantsContext>(options =>
                    options.UseSqlServer(applicationOptions.ConnectionString));
        }
    }
}