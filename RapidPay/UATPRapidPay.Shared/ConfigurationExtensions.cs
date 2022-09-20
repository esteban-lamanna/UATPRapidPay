using Microsoft.Extensions.Configuration;

namespace UATPRapidPay.Shared
{
    public static class ConfigurationExtensions
    {
        public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string sectionName)
            where TOptions : new()
        {
            var options = new TOptions();
            configuration.GetSection(sectionName).Bind(sectionName, options);
            return options;
        }
    }
}