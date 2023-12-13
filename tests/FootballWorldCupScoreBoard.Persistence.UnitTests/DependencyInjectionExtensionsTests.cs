using FluentAssertions;
using FluentAssertions.Execution;
using FootballWorldCupScoreBoard.Application.Scoring;
using FootballWorldCupScoreBoard.Persistence.Games;
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
            VerifyServiceInjection<DatabaseContext>(sut, ServiceLifetime.Singleton);
            VerifyServiceInjection<IGuidProvider, GuidProvider>(sut, ServiceLifetime.Transient);
            VerifyServiceInjection<ISummaryRecorder, GameRepository>(sut, ServiceLifetime.Scoped);
            VerifyServiceInjection<ISummaryProvider, GameRepository>(sut, ServiceLifetime.Scoped);
        }
    }

    private static void VerifyServiceInjection<T>(
        ServiceCollection sut,
        ServiceLifetime lifetime
    ) => VerifyServiceInjection<T, T>(sut, lifetime);

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
