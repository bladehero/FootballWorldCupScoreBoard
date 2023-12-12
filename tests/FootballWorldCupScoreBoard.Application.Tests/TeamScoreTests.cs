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

    [Fact]
    public void Increase_WhenInvokedOneTime_ShouldSetScoreToOne()
    {
        // Act
        _sut.Increase();

        // Assert
        _sut.Score.Should().Be(1);
    }

    [Theory]
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

    private static void RepeatIncreaseFor(TeamScore teamScore, int times)
    {
        for (var _ = 0; _ < times; _++)
        {
            teamScore.Increase();
        }
    }
}
