using Frontend.Service.CustomHttpClients;
using Frontend.Service;
using System.Net.Http.Headers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Frontend.Filters;



namespace Frontend.DomainService
{
    public static class DomainService
    {
        public static void AddDomainService(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddControllersWithViews();
            serviceCollection.AddScoped<IGroupService, GroupService>();
            serviceCollection.AddScoped<ICategoryService, CategoryService>();
            //filters 
            serviceCollection.AddControllersWithViews(opts =>
             {
                 opts.Filters.Add(new CheckModelStateFilter());

             }).AddControllersAsServices();

            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddUrlConfiguration(configuration);


            var loadedConfiguration = configurationBuilder.Build();
            var apiUrl = loadedConfiguration["path"];

            serviceCollection.AddHttpClient("CustomHttpClient", config =>
            {
                config.BaseAddress = new Uri(apiUrl);
                config.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            });
            serviceCollection.AddHttpClient<CustomHttpClient>();
        }
    }
}
