namespace FootballWorldCupScoreBoard.Application;

public record TeamScore
{
    public Team Team { get; init; } = null!;
    public byte Score { get; private set; }

    private TeamScore() { }

    public static TeamScore CreateFor(Team team) => new() { Team = team, Score = 0 };

    public void Increase()
    {
        Score = 1;
    }
}
