using Ardalis.ListStartupServices;

namespace Microsoft.Extensions.DependencyInjection;

public static class ConfigureServices
{
    public static IServiceCollection AddWebUI(this IServiceCollection services)
    {
        services.AddDatabaseDeveloperPageExceptionFilter();
        services.AddControllersWithViews();
        services.AddRazorPages();

        services.AddOpenApiDocument(configure =>
        {
            configure.Title = "CaWorkshop API";
        });

#if DEBUG
        services.Configure<ServiceConfig>(config =>
        {
            config.Services = new List<ServiceDescriptor>(services);
            config.Path = "/allservices";
        });
#endif

        return services;
    }
}
