﻿namespace FootballWorldCupScoreBoard.Application.Matches;

public interface IMatch
{
    Team HomeTeam { get; }
    byte HomeTeamScore { get; }
    Team AwayTeam { get; }
    byte AwayTeamScore { get; }
    void HomeTeamScoresGoal();
    void AwayTeamScoresGoal();
}
