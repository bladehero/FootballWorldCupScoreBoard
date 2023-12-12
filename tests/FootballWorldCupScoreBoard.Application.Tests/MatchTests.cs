using FluentAssertions;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class MatchTests
{
    private const string HomeTeamName = "Spain";
    private const string AwayTeamName = "Italy";
    private static readonly Team HomeTeam = Team.Create(HomeTeamName);
    private static readonly Team AwayTeam = Team.Create(AwayTeamName);

    private readonly IMatch _sut;

    public MatchTests()
    {
        _sut = Match.Create(HomeTeam, AwayTeam);
    }

    [Fact]
    public void Create_Always_ShouldReturnMatchWithTwoProvidedTeams()
    {
        // Act
        var actual = Match.Create(HomeTeam, AwayTeam);

        // Assert
        actual
            .Should()
            .NotBeNull()
            .And
            .BeOfType<Match>()
            .And
            .BeEquivalentTo(new { HomeTeam, AwayTeam });
    }

    [Fact]
    public void HomeTeamScoresGoal_Always_ShouldIncreaseHomeTeamScore()
    {
        // Act
        _sut.HomeTeamScoresGoal();

        // Assert
        _sut.HomeTeamScore.Should().Be(1);
    }

    [Fact]
    public void AwayTeamScoresGoal_Always_ShouldIncreaseAwayTeamScore()
    {
        // Act
        _sut.AwayTeamScoresGoal();

        // Assert
        _sut.AwayTeamScore.Should().Be(1);
    }

    [Fact]
    public void ToString_Always_ReturnFormattedScoreForMatch()
    {
        // Arrange
        _sut.HomeTeamScoresGoal();
        _sut.AwayTeamScoresGoal();
        _sut.HomeTeamScoresGoal();

        // Act
        var actual = _sut.ToString();

        // Assert
        actual.Should().Be($"{HomeTeamName} 2 - {AwayTeamName} 1");
    }
}
