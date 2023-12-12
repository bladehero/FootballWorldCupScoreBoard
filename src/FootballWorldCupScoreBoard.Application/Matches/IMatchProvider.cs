namespace FootballWorldCupScoreBoard.Application.Matches;

public interface IMatchProvider
{
    IMatch Create(Team homeTeam, Team awayTeam);
}
