using FluentAssertions;
using FluentAssertions.Execution;
using FootballWorldCupScoreBoard.Application.Matches;
using FootballWorldCupScoreBoard.Application.Scoring;
using Microsoft.Extensions.DependencyInjection;

namespace FootballWorldCupScoreBoard.Application.UnitTests;

public class DependencyInjectionExtensionsTests
{
    [Fact]
    public void AddApplication_Always_AddSingletonOfDatabaseContext()
    {
        // Arrange
        var sut = new ServiceCollection();

        // Act
        sut.AddApplication();

        // Assert
        using (new AssertionScope())
        {
            VerifyServiceInjection<IMatchProvider, MatchProvider>(sut, ServiceLifetime.Transient);
            VerifyServiceInjection<IScoreBoard, ScoreBoard>(sut, ServiceLifetime.Scoped);
        }
    }

    private static void VerifyServiceInjection<TService, TImplementation>(
        ServiceCollection sut,
        ServiceLifetime lifetime
    )
    {
        sut.Should()
            .Contain(
                x =>
                    x.Lifetime == lifetime
                    && x.ServiceType == typeof(TService)
                    && x.ImplementationType == typeof(TImplementation)
            );
    }
}
