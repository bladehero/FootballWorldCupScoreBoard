using System.Diagnostics.CodeAnalysis;

namespace FootballWorldCupScoreBoard.Persistence.Games;

[ExcludeFromCodeCoverage]
public class GameModel
{
    public Guid Guid { get; set; }
    public string HomeTeamName { get; set; } = null!;
    public string HomeTeamScore { get; set; } = null!;
    public string AwayTeamName { get; set; } = null!;
    public string AwayTeamScore { get; set; } = null!;
}
