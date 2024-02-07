using Microsoft.Extensions.Configuration;

public static class ConfigurationExtension
{
    public static IConfigurationBuilder AddUrlConfiguration(this IConfigurationBuilder builder, IConfiguration configuration)
    {
        builder.Add(new CustomProviderSource(configuration));
        return builder;
    }
}
