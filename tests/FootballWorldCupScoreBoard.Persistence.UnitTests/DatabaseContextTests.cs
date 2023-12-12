using FluentAssertions;

namespace FootballWorldCupScoreBoard.Persistence.UnitTests;

public class DatabaseContextTests
{
    [Fact]
    public void Constructor_Always_ReturnsContextWithEmptyGames()
    {
        // Act
        var sut = new DatabaseContext();

        // Assert
        sut.Games.Should().BeEmpty();
    }
}
