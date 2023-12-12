using FluentAssertions;
using FluentAssertions.Execution;
using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;
using Moq;

namespace FootballWorldCupScoreBoard.Application.UnitTests.Scoring;

public class ScoreBoardTests
{
    private const string HomeTeamName = "Spain";
    private const string AwayTeamName = "Italy";
    private readonly Mock<IMatchProvider> _matchProviderMock = new();
    private readonly ScoreBoard _sut;

    public ScoreBoardTests()
    {
        _sut = new ScoreBoard(_matchProviderMock.Object);
    }

    [Fact]
    public void Start_Always_ProduceNewMatch()
    {
        // Arrange
        var expected = new Mock<IMatch>().Object;
        _matchProviderMock.Setup(x => x.Create(HomeTeamName, AwayTeamName)).Returns(expected);

        // Act
        var actual = _sut.StartNew(HomeTeamName, AwayTeamName);

        // Assert
        using (new AssertionScope())
        {
            actual.Should().Be(expected);
            _matchProviderMock.VerifyAll();
        }
    }
}
