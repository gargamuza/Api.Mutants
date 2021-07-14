using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

            var emailOptions = new DnaOptions();
            configuration.GetSection(DnaOptions.Section).Bind(emailOptions);
            services.AddSingleton(typeof(DnaOptions), emailOptions);
        }
    }
}
