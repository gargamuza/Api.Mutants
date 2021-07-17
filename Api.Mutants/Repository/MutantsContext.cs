using Api.Mutants.Configuration;
using Api.Mutants.Helpers;
using Api.Mutants.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Reflection;

namespace Api.Mutants.Repository
{
    public class MutantsContext:DbContext
    {
        private MigrationOptions _migrationOptions;
        private ApplicationOptions _appOptions;

        public MutantsContext(DbContextOptions<MutantsContext> options) : base(options)
        {
            LoadMigrationOptionsForLocalDevelopment();
            LoadApplicationOptionsForLocalDevelopment();
        }
        public MutantsContext()
        {
            LoadMigrationOptionsForLocalDevelopment();
            LoadApplicationOptionsForLocalDevelopment();
        }

        private void LoadApplicationOptionsForLocalDevelopment()
        {
            _appOptions = new ApplicationOptions();
            var configuration =
              HostBuilderExtensions.GetConfiguration(
                  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

            var appOptions = new ApplicationOptions();
            configuration.GetSection(ApplicationOptions.Section).Bind(appOptions);
            _appOptions = appOptions;
        }

        private void LoadMigrationOptionsForLocalDevelopment()
        {
            _migrationOptions = new MigrationOptions();
            var configuration =
              HostBuilderExtensions.GetConfiguration(
                  Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT"));

            var migrationOptions = new MigrationOptions();
            configuration.GetSection(MigrationOptions.Section).Bind(migrationOptions);
            _migrationOptions = migrationOptions;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            var runningAssembly = Assembly.GetEntryAssembly();
            modelBuilder.ApplyConfigurationsFromAssembly(runningAssembly);

            //para las migraciones.
            //no se ejecuta como un host, entonces GetEntryAssembly no es api.mutants
            if (!string.IsNullOrWhiteSpace(_migrationOptions.EntitiesAssemblyName))
            {
                if (runningAssembly.GetName().Name != _migrationOptions.EntitiesAssemblyName)
                    modelBuilder.ApplyConfigurationsFromAssembly(Assembly.Load(_migrationOptions.EntitiesAssemblyName));
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var sqlServerExtension = optionsBuilder.Options.FindExtension<Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal.SqlServerOptionsExtension>();

            //este if sirve para saber si se esta ejecutando normal o con el Package manager console
            //Si se ejecuta con Package manager console aun no se le configuró el provider 
            if (sqlServerExtension == null)
                optionsBuilder.UseSqlServer(_appOptions.ConnectionString);
        }
    }
}