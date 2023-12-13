using FootballWorldCupScoreBoard.Application.Matches;

namespace FootballWorldCupScoreBoard.Persistence.Games;

public interface IGameRepository
{
    IEnumerable<IMatchScore> GetAllGames();
}
