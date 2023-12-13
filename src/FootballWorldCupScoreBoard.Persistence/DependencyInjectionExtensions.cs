using FootballWorldCupScoreBoard.Application.Scoring;
using FootballWorldCupScoreBoard.Persistence.Games;
using Microsoft.Extensions.DependencyInjection;

namespace FootballWorldCupScoreBoard.Persistence;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services) =>
        services
            .AddSingleton<DatabaseContext>()
            .AddTransient<IGuidProvider, GuidProvider>()
            .AddScoped<ISummaryRecorder, GameRepository>()
            .AddScoped<ISummaryProvider, GameRepository>();
}
