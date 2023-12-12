using FluentAssertions;
using FluentAssertions.Execution;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class TeamTests
{
    private const string AnyName = "Italy";

    [Fact]
    public void Create_Always_ShouldReturnTeam()
    {
        // Act
        var actual = Team.Create(AnyName);

        // Assert
        using (new AssertionScope())
        {
            actual.Should().NotBeNull().And.BeOfType<Team>();
            actual.Name.Should().Be(AnyName);
        }
    }
}
