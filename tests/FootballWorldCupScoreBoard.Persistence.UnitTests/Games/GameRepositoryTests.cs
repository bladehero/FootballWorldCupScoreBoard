using FluentAssertions;
using FluentAssertions.Execution;
using FootballWorldCupScoreBoard.Application;
using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Persistence.Games;
using Moq;

namespace FootballWorldCupScoreBoard.Persistence.UnitTests.Games;

public class GameRepositoryTests
{
    private static readonly Guid SomeRandomGuid = Guid.Parse(
        "dce522fb-8977-4a36-a296-4aa65751b308"
    );
    private readonly DatabaseContext _context = new();
    private readonly Mock<IGuidProvider> _guidProviderMock = new();
    private readonly GameRepository _sut;

    public GameRepositoryTests()
    {
        _sut = new GameRepository(_context, _guidProviderMock.Object);
    }

    [Fact]
    public void SaveMatch_Always_ShouldAddToGameCollection()
    {
        // Arrange
        var match = new MatchStub("England", 3, "Germany", 2);
        _guidProviderMock.Setup(x => x.NewGuid()).Returns(SomeRandomGuid);

        // Act
        _sut.SaveMatch(match);

        // Assert
        using (new AssertionScope())
        {
            _context.Games.Should().HaveCount(1);
            _context
                .Games
                .First()
                .Should()
                .BeEquivalentTo(
                    new
                    {
                        Guid = SomeRandomGuid,
                        HomeTeamName = "England",
                        HomeTeamScore = 3,
                        AwayTeamName = "Germany",
                        AwayTeamScore = 2
                    }
                );
        }
    }

    [Fact]
    public void GetAllGames_WhenNoGamesAdded_ShouldReturnEmptyCollection()
    {
        // Act
        var actual = _sut.GetAllGames();

        // Assert
        actual.Should().BeEmpty().And.Subject.Should().AllBeOfType<IMatchScore>();
    }

    private class MatchStub : IMatch
    {
        public MatchStub(
            string homeTeamName,
            byte homeTeamScore,
            string awayTeamName,
            byte awayTeamScore
        )
        {
            HomeTeam = Team.Create(homeTeamName);
            HomeTeamScore = homeTeamScore;
            AwayTeam = Team.Create(awayTeamName);
            AwayTeamScore = awayTeamScore;
        }

        public Team HomeTeam { get; }
        public byte HomeTeamScore { get; }
        public Team AwayTeam { get; }
        public byte AwayTeamScore { get; }

        public void HomeTeamScoresGoal() => throw new NotImplementedException();

        public void AwayTeamScoresGoal() => throw new NotImplementedException();
    }
}
