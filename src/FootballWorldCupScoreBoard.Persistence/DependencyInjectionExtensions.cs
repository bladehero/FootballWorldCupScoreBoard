using Microsoft.Extensions.DependencyInjection;

namespace FootballWorldCupScoreBoard.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services) =>
        services.AddSingleton<DatabaseContext>();
}
