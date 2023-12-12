using FluentAssertions;

namespace FootballWorldCupScoreBoard.Application.Tests;

public class TeamScoreTests
{
    private const int MoreThanByteCanStore = byte.MaxValue + 1;
    private const string AnyName = "Italy";
    private static readonly Team AnyTeam = Team.Create(AnyName);

    private readonly TeamScore _sut;

    public TeamScoreTests() => _sut = TeamScore.CreateFor(AnyTeam);

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

    [Theory]
    [InlineData(1)]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(255)]
    public void Increase_WhenInvokedMoreThanOnce_ShouldSetScoreToAmountOfInvocationTimes(byte times)
    {
        // Act
        RepeatIncreaseFor(_sut, times);

        // Assert
        _sut.Score.Should().Be(times);
    }

    [Fact]
    public void Increase_WhenScoreMoreThan255_ShouldThrowOverflowException()
    {
        // Act
        var action = () => RepeatIncreaseFor(_sut, MoreThanByteCanStore);

        // Assert
        action.Should().ThrowExactly<OverflowException>();
    }

    [Theory]
    [InlineData(1)]
    [InlineData(3)]
    public void ToString_Always_ShouldReturnTeamNameAndScore(int times)
    {
        // Arrange
        RepeatIncreaseFor(_sut, times);

        // Act & Assert
        _sut.ToString().Should().Be($"{AnyName} {times}");
    }

    private static void RepeatIncreaseFor(TeamScore teamScore, int times)
    {
        for (var _ = 0; _ < times; _++)
        {
            teamScore.Increase();
        }
    }
}
