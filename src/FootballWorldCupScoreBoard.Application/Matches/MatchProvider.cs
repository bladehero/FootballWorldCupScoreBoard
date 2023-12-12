namespace FootballWorldCupScoreBoard.Application.Matches;

public class MatchProvider : IMatchProvider
{
    public IMatch Create(string homeTeamName, string awayTeamName)
    {
        var homeTeam = Team.Create(homeTeamName);
        var awayTeam = Team.Create(awayTeamName);
        return Match.Create(homeTeam, awayTeam);
    }
}
