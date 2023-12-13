using FluentAssertions;
using FluentAssertions.Execution;
using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;
using Moq;
using Match = FootballWorldCupScoreBoard.Application.Matches.Match;

namespace FootballWorldCupScoreBoard.Application.UnitTests.Scoring;

public class ScoreBoardTests
{
    private const string HomeTeamName = "Spain";
    private const string AwayTeamName = "Italy";
    private readonly Mock<IMatchProvider> _matchProviderMock = new();
    private readonly Mock<ISummaryRecorder> _summaryRecorderMock = new();
    private readonly Mock<ISummaryProvider> _summaryProviderMock = new();
    private readonly ScoreBoard _sut;

    public ScoreBoardTests()
    {
        _sut = new ScoreBoard(
            _matchProviderMock.Object,
            _summaryRecorderMock.Object,
            _summaryProviderMock.Object
        );
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

    [Fact]
    public void Finish_WhenNoStartedGame_ShouldThrowInvalidOperation()
    {
        // Act
        var action = () => _sut.Finish();

        // Assert
        action
            .Should()
            .ThrowExactly<InvalidOperationException>("Cannot finish match when it is not started");
    }

    [Fact]
    public void Finish_WhenGameWasStarted_ShouldSendMatchAsEventAndAllowToStartNew()
    {
        // Arrange
        var expected = new Mock<IMatch>().Object;
        _matchProviderMock.Setup(x => x.Create(HomeTeamName, AwayTeamName)).Returns(expected);
        _sut.StartNew(HomeTeamName, AwayTeamName);

        // Act
        _sut.Finish();
        var action = () => _sut.StartNew("SomeOtherHomeTeam", "AndAnotherAwayTeam");

        // Assert
        using (new AssertionScope())
        {
            _summaryRecorderMock.Verify(x => x.SaveMatch(expected));
            action.Should().NotThrow();
        }
    }

    [Fact]
    public void ShowRecent_Always_ReturnsAllGames()
    {
        // Arrange
        var first = MatchScoreStub.From("Spain", 1, "Italy", 2);
        var second = MatchScoreStub.From("Poland", 1, "England", 1);
        _summaryProviderMock.Setup(x => x.GetAllGames()).Returns(new[] { first, second });

        // Act
        var actual = _sut.ShowRecent();

        // Assert
        actual.Should().ContainInOrder(second, first);
    }

    private record MatchScoreStub(
        Team HomeTeam,
        byte HomeTeamScore,
        Team AwayTeam,
        byte AwayTeamScore
    ) : IMatchScore
    {
        public static MatchScoreStub From(
            string homeTeam,
            byte homeTeamScore,
            string awayTeam,
            byte awayTeamScore
        )
        {
            return new MatchScoreStub(
                Team.Create(homeTeam),
                homeTeamScore,
                Team.Create(awayTeam),
                awayTeamScore
            );
        }
    }
}
