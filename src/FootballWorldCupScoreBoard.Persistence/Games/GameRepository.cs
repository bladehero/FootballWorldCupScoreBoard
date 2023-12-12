using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;

namespace FootballWorldCupScoreBoard.Persistence.Games;

public class GameRepository : ISummaryRecorder
{
    private readonly DatabaseContext _context;
    private readonly IGuidProvider _guidProvider;

    public GameRepository(DatabaseContext context, IGuidProvider guidProvider)
    {
        _context = context;
        _guidProvider = guidProvider;
    }

    public void SaveMatch(IMatch match) =>
        _context
            .Games
            .Add(
                new GameModel
                {
                    HomeTeamName = match.HomeTeam.Name,
                    HomeTeamScore = match.HomeTeamScore,
                    AwayTeamName = match.AwayTeam.Name,
                    AwayTeamScore = match.AwayTeamScore,
                }
            );
}
