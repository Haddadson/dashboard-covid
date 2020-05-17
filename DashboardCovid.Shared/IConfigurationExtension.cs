using Microsoft.Extensions.Configuration;

namespace DashboardCovid.Shared
{
    //Configurações para facilitar o uso de acesso de registros do appsettings
    public static class IConfigurationExtension
    {
        public static IConfiguration ObterConfiguracao(this IConfiguration configuration)
        {
            return configuration.GetSection("AppConfiguration");
        }

        public static IConfiguration ObterConfiguracao(this IConfiguration configuration, string chave)
        {
            return configuration.GetSection($"AppConfiguration:{chave}");
        }

        public static string ObterSecao(this IConfiguration configuration, string chave)
        {
            return configuration.GetSection("AppConfiguration").GetSection(chave).Value;
        }

    }
}
