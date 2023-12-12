﻿using FluentAssertions;

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

    [Fact]
    public void Increment_WhenInvokedOneTime_ShouldSetScoreToOne()
    {
        // Arrange
        var sut = TeamScore.CreateFor(AnyTeam);

        // Act
        sut.Increase();

        // Assert
        sut.Score.Should().Be(1);
    }

    [Theory]
    [InlineData(2)]
    [InlineData(5)]
    [InlineData(255)]
    public void Increment_WhenInvokedMoreThanOnce_ShouldSetScoreToAmountOfInvocationTimes(
        byte times
    )
    {
        // Arrange
        var sut = TeamScore.CreateFor(AnyTeam);

        // Act
        for (var _ = 0; _ < times; _++)
        {
            sut.Increase();
        }

        // Assert
        sut.Score.Should().Be(times);
    }
}
