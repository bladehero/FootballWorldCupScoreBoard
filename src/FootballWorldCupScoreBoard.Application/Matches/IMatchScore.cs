namespace FootballWorldCupScoreBoard.Application.Matches;

public interface IMatchScore
{
    Team HomeTeam { get; }
    byte HomeTeamScore { get; }
    Team AwayTeam { get; }
    byte AwayTeamScore { get; }
}
