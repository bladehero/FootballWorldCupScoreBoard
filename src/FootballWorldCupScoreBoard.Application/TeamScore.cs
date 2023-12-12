namespace FootballWorldCupScoreBoard.Application;

public record TeamScore
{
    public Team Team { get; init; } = null!;
    public byte Score { get; init; }

    private TeamScore() { }

    public static TeamScore CreateFor(Team team) => new() { Team = team, Score = 0 };
}
