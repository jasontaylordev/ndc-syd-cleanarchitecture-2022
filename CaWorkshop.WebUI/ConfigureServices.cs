using Ardalis.ListStartupServices;
using CaWorkshop.Application.Common.Interfaces;
using CaWorkshop.WebUI.Services;
using NSwag.Generation.Processors.Security;
using NSwag;

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
            configure.AddSecurity("JWT", Enumerable.Empty<string>(),
                new OpenApiSecurityScheme
                {
                    Type = OpenApiSecuritySchemeType.ApiKey,
                    Name = "Authorization",
                    In = OpenApiSecurityApiKeyLocation.Header,
                    Description = "Type into the textbox: Bearer {your JWT token}."
                });

            configure.OperationProcessors.Add(
                new AspNetCoreOperationSecurityScopeProcessor("JWT"));
        });

        services.AddHttpContextAccessor();

        services.AddScoped<ICurrentUser, CurrentUser>();

#if DEBUG
        services.Configure<ServiceConfig>(config =>
        {
            config.Services = new List<ServiceDescriptor>(services);
            config.Path = "/allservices";
        });

        services.AddLogging(configure
            => configure.AddSeq());
#endif

        return services;
    }
}
