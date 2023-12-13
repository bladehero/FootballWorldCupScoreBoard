using FootballWorldCupScoreBoard.Application.Matches;

namespace FootballWorldCupScoreBoard.Application.Scoring;

public interface IScoreBoard
{
    IMatch StartNew(string homeTeamName, string awayTeamName);
    void IncreaseHomeTeamScore();
    void IncreaseAwayTeamScore();
    void Finish();
    IEnumerable<IMatchScore> ShowRecent();
}
