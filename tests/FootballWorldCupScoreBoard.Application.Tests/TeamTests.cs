using FluentAssertions;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class TeamTests
{
    [Fact]
    public void Create_Always_ShouldReturnTeam()
    {
        // Act
        var actual = Team.Create();

        // Assert
        actual.Should().NotBeNull().And.BeOfType<Team>();
    }
}
