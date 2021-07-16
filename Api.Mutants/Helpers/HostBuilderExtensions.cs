using Microsoft.Extensions.Configuration;

namespace Api.Mutants.Helpers
{
    public class HostBuilderExtensions
    {
        private static IConfigurationRoot _builtConfiguration;
        public static IConfigurationRoot GetConfiguration(string enviromentName, string contentRootPath = null)
        {
            if (_builtConfiguration != null)
                return _builtConfiguration;

            var configurationbuilder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: false)
                .AddJsonFile($"appsettings.{enviromentName}.json", optional: true, reloadOnChange: false)
                .AddEnvironmentVariables();
                

            if (contentRootPath != null)
            {
                configurationbuilder.SetBasePath(contentRootPath);              
            }

            _builtConfiguration = configurationbuilder.Build();

            return _builtConfiguration;
        }
    }
}