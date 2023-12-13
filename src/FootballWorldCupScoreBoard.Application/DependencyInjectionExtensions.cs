using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;
using Microsoft.Extensions.DependencyInjection;

namespace FootballWorldCupScoreBoard.Application;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) =>
        services.AddTransient<IMatchProvider, MatchProvider>().AddScoped<IScoreBoard, ScoreBoard>();
}
