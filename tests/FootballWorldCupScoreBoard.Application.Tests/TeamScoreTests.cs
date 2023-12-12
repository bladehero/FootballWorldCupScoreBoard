using FluentAssertions;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class TeamScoreTests
{
    private const string AnyName = "Italy";
    private static readonly Team AnyTeam = Team.Create(AnyName);

    [Fact]
    public void CreateFor_Always_ShouldReturnTeamScore()
    {
        // Act
        var actual = TeamScore.CreateFor(AnyTeam);

        // Assert
        actual
            .Should()
            .NotBeNull()
            .And
            .BeOfType<TeamScore>()
            .And
            .BeEquivalentTo(new { Team = new { Name = AnyName }, Score = 0 });
    }
}
