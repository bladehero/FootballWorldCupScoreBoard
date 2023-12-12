namespace FootballWorldCupScoreBoard.Application;

public interface IMatchProvider
{
    IMatch Create(Team homeTeam, Team awayTeam);
}
