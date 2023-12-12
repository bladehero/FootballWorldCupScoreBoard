namespace FootballWorldCupScoreBoard.Persistence.Games;

public interface IGameRepository
{
    IEnumerable<GameModel> GetAllGames();
}
