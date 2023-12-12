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
        if (_current is not null)
        {
            throw new InvalidOperationException("Another match has been already started");
        }

        _current = _matchProvider.Create(homeTeamName, awayTeamName);
        return _current;
    }
}
