using FluentAssertions;
using FluentAssertions.Execution;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class TeamTests
{
    private const string AnyName = "Italy";

    [Fact]
    public void Create_WhenValidName_ShouldReturnTeam()
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

    [Fact]
    public void Create_WhenNameIsNullOrEmpty_ShouldThrowArgumentException()
    {
        // Act
        var action = () => Team.Create(null!);

        // Assert
        action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("name");
    }
}
