using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromotionalGame.Service.Validations;
using PromotionalGame.Storage.Configuration;
using PromotionalGame.Storage.Json.Configuration;

namespace PromotionalGame.Service.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddTransient<IScratchFieldValidator, ScratchFieldValidator>()
            .AddTransient<IScratchAdminService, ScratchAdminService>()
            .AddTransient<IScratchService, ScratchService>();

        services
            .RegisterStorage()
            .RegisterJsonStorage(configuration);

        return services;
    }
}
