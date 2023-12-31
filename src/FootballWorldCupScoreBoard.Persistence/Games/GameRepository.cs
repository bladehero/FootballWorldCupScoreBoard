﻿using FootballWorldCupScoreBoard.Application;
using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;

namespace FootballWorldCupScoreBoard.Persistence.Games;

public class GameRepository : ISummaryRecorder, ISummaryProvider
{
    private readonly DatabaseContext _context;
    private readonly IGuidProvider _guidProvider;

    public GameRepository(DatabaseContext context, IGuidProvider guidProvider)
    {
        _context = context;
        _guidProvider = guidProvider;
    }

    public IEnumerable<IMatchScore> GetAllGames()
    {
        return _context.Games.Select(AsMatchScore);

        IMatchScore AsMatchScore(GameModel model)
        {
            var homeTeam = Team.Create(model.HomeTeamName);
            var awayTeam = Team.Create(model.AwayTeamName);
            return new MatchScore(homeTeam, model.HomeTeamScore, awayTeam, model.AwayTeamScore);
        }
    }

    public void SaveMatch(IMatch match) =>
        _context
            .Games
            .Add(
                new GameModel
                {
                    Guid = _guidProvider.NewGuid(),
                    HomeTeamName = match.HomeTeam.Name,
                    HomeTeamScore = match.HomeTeamScore,
                    AwayTeamName = match.AwayTeam.Name,
                    AwayTeamScore = match.AwayTeamScore,
                }
            );

    private record MatchScore(Team HomeTeam, byte HomeTeamScore, Team AwayTeam, byte AwayTeamScore)
        : IMatchScore;
}
