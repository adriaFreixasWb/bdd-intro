using Microsoft.Extensions.Configuration;

namespace IntroToBDD.Helpers.Settings
{
    public static class ConfigurationLoader
    {
        private static IConfiguration Configuration { get; } = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .AddJsonFile("myappsettings.secrets.json", optional: true, reloadOnChange: true)
            .Build();
        public static ContractApiSettings LoadContractApiSettings()
        {
            var cmfSettings = new ContractApiSettings();
            Configuration.GetSection(nameof(ContractApiSettings)).Bind(cmfSettings);
            return cmfSettings;
        }
    }
}
