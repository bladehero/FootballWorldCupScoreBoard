namespace FootballWorldCupScoreBoard.Application.Matches;

public interface IMatchProvider
{
    IMatch Create(string homeTeamName, string awayTeamName);
}
