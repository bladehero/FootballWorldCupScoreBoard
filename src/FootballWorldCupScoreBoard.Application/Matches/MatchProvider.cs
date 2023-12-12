namespace FootballWorldCupScoreBoard.Application.Matches;

public class MatchProvider : IMatchProvider
{
    public IMatch Create(Team homeTeam, Team awayTeam) => Match.Create(homeTeam, awayTeam);
}
