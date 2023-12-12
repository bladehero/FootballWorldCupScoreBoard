using FootballWorldCupScoreBoard.Application.Matches;

namespace FootballWorldCupScoreBoard.Application.Scoring;

public class ScoreBoard
{
    private readonly IMatchProvider _matchProvider;
    private IMatch? _current;

    public ScoreBoard(IMatchProvider matchProvider)
    {
        _matchProvider = matchProvider;
    }

    public IMatch StartNew(string homeTeamName, string awayTeamName)
    {
        _current = _matchProvider.Create(homeTeamName, awayTeamName);
        return _current;
    }
}
