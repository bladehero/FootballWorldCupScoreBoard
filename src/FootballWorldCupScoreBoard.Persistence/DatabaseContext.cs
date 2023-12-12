using FootballWorldCupScoreBoard.Persistence.Games;

namespace FootballWorldCupScoreBoard.Persistence;

public class DatabaseContext
{
    public GameCollection Games { get; set; }

    public DatabaseContext()
    {
        Games = new GameCollection();
    }
}
