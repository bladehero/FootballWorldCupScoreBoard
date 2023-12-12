using FluentAssertions;
using FootballWorldCupScoreBoard.Application.Matches;

namespace FootballWorldCupScoreBoard.Application.UnitTests.Matches;

public class MatchProviderTests
{
    private const string HomeTeamName = "Spain";
    private const string AwayTeamName = "Italy";
    private static readonly Team HomeTeam = Team.Create(HomeTeamName);
    private static readonly Team AwayTeam = Team.Create(AwayTeamName);

    private readonly MatchProvider _sut;

    public MatchProviderTests()
    {
        _sut = new MatchProvider();
    }

    [Fact]
    public void Create_Always_ShouldReturnMatchWithTwoProvidedTeams()
    {
        // Act
        var actual = _sut.Create(HomeTeam, AwayTeam);

        // Assert
        actual
            .Should()
            .NotBeNull()
            .And
            .BeOfType<Match>()
            .And
            .BeEquivalentTo(new { HomeTeam, AwayTeam });
    }
}
