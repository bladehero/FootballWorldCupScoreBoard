using System.Diagnostics.CodeAnalysis;

namespace FootballWorldCupScoreBoard.Persistence.Games;

[ExcludeFromCodeCoverage]
public class GameModel
{
    public Guid Guid { get; set; }
    public string HomeTeamName { get; set; } = null!;
    public byte HomeTeamScore { get; set; }
    public string AwayTeamName { get; set; } = null!;
    public byte AwayTeamScore { get; set; }
}
