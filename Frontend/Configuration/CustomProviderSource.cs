using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Xml;

public class CustomProviderSource : IConfigurationSource
{
    private readonly IConfiguration _configuration;

    public CustomProviderSource(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public IConfigurationProvider Build(IConfigurationBuilder builder)
    {
        return new CustomProvider(_configuration);
    }
}
