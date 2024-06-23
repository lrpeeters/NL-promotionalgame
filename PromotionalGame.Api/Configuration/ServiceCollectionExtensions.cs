using PromotionalGame.Configuration.Extensions;
using PromotionalGame.Service.Configuration;

namespace PromotionalGame.Api.Configuration;

internal static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterGameComponents(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .RegisterConfiguration(configuration)
            .RegisterServices(configuration);
        return services;
    }
}
