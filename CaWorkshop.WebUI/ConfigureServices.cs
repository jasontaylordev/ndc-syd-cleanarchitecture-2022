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
        
        return services;
    }
}
