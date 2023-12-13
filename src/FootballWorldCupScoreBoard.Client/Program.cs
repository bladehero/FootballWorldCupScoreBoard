using FootballWorldCupScoreBoard.Application;
using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;
using FootballWorldCupScoreBoard.Persistence;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddApplication().AddPersistence();
using var host = builder.Build();

var scoreBoard = host.Services.GetRequiredService<IScoreBoard>();

// Spain 2 - Italy 1
IMatchScore matchSpainItaly = scoreBoard.StartNew("Spain", "Italy");
Console.WriteLine("Started match: {0}", matchSpainItaly);

scoreBoard.IncreaseAwayTeamScore();
Console.WriteLine(matchSpainItaly);

scoreBoard.IncreaseHomeTeamScore();
Console.WriteLine(matchSpainItaly);

scoreBoard.IncreaseHomeTeamScore();
Console.WriteLine(matchSpainItaly);

scoreBoard.Finish();
Console.WriteLine("Finished match: {0}", matchSpainItaly);
Console.WriteLine();

// Germany 0 - England 0
IMatchScore matchGermanyEngland = scoreBoard.StartNew("Germany", "England");
Console.WriteLine("Started match: {0}", matchGermanyEngland);

scoreBoard.Finish();
Console.WriteLine("Finished match: {0}", matchGermanyEngland);
Console.WriteLine();

// Summary Board
foreach (var (game, index) in scoreBoard.ShowRecent().Select((game, index) => (game, index)))
{
    Console.WriteLine(
        "{0}. {1} {2} - {3} {4}",
        index,
        game.HomeTeam,
        game.HomeTeamScore,
        game.AwayTeam,
        game.AwayTeamScore
    );
}

Console.ReadKey();
