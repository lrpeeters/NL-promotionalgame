using Microsoft.Extensions.DependencyInjection;
using PromotionalGame.Storage.Builders;

namespace PromotionalGame.Storage.Configuration;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterStorage(this IServiceCollection services)
    {
        services
            //.AddTransient<IGameNameBuilder, GameNameBuilder>()
            .AddTransient<IScratchboardBuilder, ScratchboardBuilder>();
        return services;
    }
}
