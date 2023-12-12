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
    public void StartNew_WhenNotAlreadyStartedOne_ProduceNewMatch()
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

    [Fact]
    public void StartNew_WhenAlreadyStarted_ShouldThrowInvalidOperation()
    {
        // Arrange
        var expected = new Mock<IMatch>().Object;
        _matchProviderMock.Setup(x => x.Create(HomeTeamName, AwayTeamName)).Returns(expected);
        _sut.StartNew(HomeTeamName, AwayTeamName);

        // Act
        var action = () => _sut.StartNew("AnyOtherHomeTeam", "AnyOtherAwayTeam");

        // Assert
        action
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .And
            .Message
            .Should()
            .Be("Another match has been already started");
    }

    [Fact]
    public void IncreaseHomeTeamScore_Always_ShouldIncreaseScoreOfHomeTeam()
    {
        // Arrange
        var matchMock = new Mock<IMatch>();
        _matchProviderMock
            .Setup(x => x.Create(HomeTeamName, AwayTeamName))
            .Returns(matchMock.Object);
        _sut.StartNew(HomeTeamName, AwayTeamName);

        // Act
        _sut.IncreaseHomeTeamScore();

        // Assert
        matchMock.Verify(x => x.HomeTeamScoresGoal(), Times.Once);
    }

    [Fact]
    public void IncreaseHomeTeamScore_WhenNoStartedMatch_ShouldThrowInvalidOperationException()
    {
        // Act
        var action = () => _sut.IncreaseHomeTeamScore();

        // Assert
        action.Should().ThrowExactly<InvalidOperationException>();
    }

    [Fact]
    public void IncreaseAwayTeamScore_Always_ShouldIncreaseScoreOfHomeTeam()
    {
        // Arrange
        var matchMock = new Mock<IMatch>();
        _matchProviderMock
            .Setup(x => x.Create(HomeTeamName, AwayTeamName))
            .Returns(matchMock.Object);
        _sut.StartNew(HomeTeamName, AwayTeamName);

        // Act
        _sut.IncreaseAwayTeamScore();

        // Assert
        matchMock.Verify(x => x.AwayTeamScoresGoal(), Times.Once);
    }

    [Fact]
    public void IncreaseAwayTeamScore_WhenNoStartedMatch_ShouldThrowInvalidOperationException()
    {
        // Act
        var action = () => _sut.IncreaseAwayTeamScore();

        // Assert
        action.Should().ThrowExactly<InvalidOperationException>();
    }
}
