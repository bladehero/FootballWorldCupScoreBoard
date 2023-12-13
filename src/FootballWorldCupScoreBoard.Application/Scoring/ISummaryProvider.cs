using FootballWorldCupScoreBoard.Application.Matches;

namespace FootballWorldCupScoreBoard.Application.Scoring;

public interface ISummaryProvider
{
    IEnumerable<IMatchScore> GetAllGames();
}