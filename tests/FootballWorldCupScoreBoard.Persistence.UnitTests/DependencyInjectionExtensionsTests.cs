using FluentAssertions;
using FluentAssertions.Execution;
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
        using (new AssertionScope())
        {
            sut.Should()
                .Contain(
                    x =>
                        x.Lifetime == ServiceLifetime.Transient
                        && x.ServiceType == typeof(IGuidProvider)
                        && x.ImplementationType == typeof(GuidProvider)
                );
            sut.Should()
                .Contain(
                    x =>
                        x.Lifetime == ServiceLifetime.Singleton
                        && x.ServiceType == typeof(DatabaseContext)
                        && x.ImplementationType == typeof(DatabaseContext)
                );
        }
    }
}
