namespace FootballWorldCupScoreBoard.Application;

public class MatchProvider : IMatchProvider
{
    public IMatch Create(Team homeTeam, Team awayTeam) => Match.Create(homeTeam, awayTeam);
}
