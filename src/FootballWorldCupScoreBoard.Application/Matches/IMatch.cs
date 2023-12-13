namespace FootballWorldCupScoreBoard.Application.Matches;

public interface IMatch : IMatchScore
{
    void HomeTeamScoresGoal();
    void AwayTeamScoresGoal();
}
