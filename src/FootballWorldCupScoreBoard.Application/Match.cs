﻿namespace FootballWorldCupScoreBoard.Application;

public class Match
{
    private TeamScore _homeTeamScore = null!;
    private TeamScore _awayTeamScore = null!;

    public Team HomeTeam => _homeTeamScore.Team;
    public byte HomeTeamScore => _homeTeamScore.Score;

    public Team AwayTeam => _awayTeamScore.Team;
    public byte AwayTeamScore => _awayTeamScore.Score;

    private Match() { }

    public void HomeTeamScoresGoal() => _homeTeamScore.Increase();

    public void AwayTeamScoresGoal() => _awayTeamScore.Increase();

    public override string ToString() => $"{_homeTeamScore} - {_awayTeamScore}";

    public static Match Create(Team homeTeam, Team awayTeam) =>
        new()
        {
            _homeTeamScore = TeamScore.CreateFor(homeTeam),
            _awayTeamScore = TeamScore.CreateFor(awayTeam)
        };
}