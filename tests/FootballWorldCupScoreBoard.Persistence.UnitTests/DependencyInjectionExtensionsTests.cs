using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace FootballWorldCupScoreBoard.Persistence.UnitTests;

public class DependencyInjectionExtensionsTests
{
    [Fact]
    public void AddPersistence_Always_AddSingletonOfDatabaseContext()
    {
        // Arrange
        var sut = new ServiceCollection();

        // Act
        sut.AddPersistence();

        // Assert
        sut.Should()
            .ContainSingle(
                x =>
                    x.Lifetime == ServiceLifetime.Singleton
                    && x.ImplementationType == typeof(DatabaseContext)
            );
    }
}
