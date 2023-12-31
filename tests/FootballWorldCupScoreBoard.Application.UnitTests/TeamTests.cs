﻿using FluentAssertions;
using FluentAssertions.Execution;

namespace FootballWorldCupScoreBoard.Application.UnitTests;

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

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void Create_WhenNameIsNullOrEmpty_ShouldThrowArgumentException(string? name)
    {
        // Act
        var action = () => Team.Create(name!);

        // Assert
        action.Should().Throw<ArgumentException>().Which.ParamName.Should().Be("name");
    }

    [Fact]
    public void ToString_Always_ShouldReturnTeamName()
    {
        // Arrange
        var sut = Team.Create(AnyName);

        // Act
        var actual = sut.ToString();

        // Assert
        actual.Should().Be(AnyName);
    }
}
