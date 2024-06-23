using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PromotionalGame.Storage.Json.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterJsonStorage(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterStorageConfiguration(configuration)
            .AddTransient<IScratchboardDatasourceLoader, ScratchboardDatasourceLoader>()
            .AddTransient<IScratchboardInitializer, ScratchboardJsonInitializer>()
            .AddTransient<IScratchboardReader, ScratchboardJsonReader>()
            .AddTransient<IScratchboardWriter, ScratchboardJsonWriter>();
        return services;
    }

    private static IServiceCollection RegisterStorageConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var jsonConfig = configuration
            .GetSection(ScratchboardJsonStorageConfiguration.SectionName)
            .Get<ScratchboardJsonStorageConfiguration>();

        if (jsonConfig is not null)
        {
            services.AddSingleton(jsonConfig);
        }

        return services;
    }
}
