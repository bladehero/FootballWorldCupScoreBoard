using FluentAssertions;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class MatchTests
{
    private static readonly Team HomeTeam = Team.Create("Spain");
    private static readonly Team AwayTeam = Team.Create("Italy");

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
}
