using FluentAssertions;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class MatchTests
{
    private static readonly Team HomeTeam = Team.Create("Spain");
    private static readonly Team AwayTeam = Team.Create("Italy");

    private readonly Match _sut;

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
}
