using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PromotionalGame.Configuration.Models;

namespace PromotionalGame.Configuration.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection RegisterConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var gameSettings = configuration
            .GetSection(GameSettingsConfiguration.SectionName)
            .Get<GameSettingsConfiguration>();

        if (gameSettings is not null)
        {
            services.AddSingleton(gameSettings);
        }

        return services;
    }
}
