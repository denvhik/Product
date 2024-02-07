using Microsoft.Extensions.Configuration;

public class CustomProvider : ConfigurationProvider
{
    private readonly IConfiguration _configuration;

    public CustomProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public override void Load()
    {
        var url = _configuration.GetSection("Api-Url").Value;
        if (url == null) 
        {
            throw new InvalidOperationException();
        }
        Data["path"] = url;
        
    }
}
