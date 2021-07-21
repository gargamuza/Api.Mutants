
using Api.Mutants.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.OpenApi.Models;

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

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Mutants {groupName}",
                    Version = groupName,
                    Description = "Magneto API",
                    Contact = new OpenApiContact
                    {
                        Name = "Magneto Mutants Company",
                        Email = string.Empty,
                        Url = new Uri("https://magnetomutantscompany.com/"),
                    }
                });
            });
        }
    }
}