namespace FootballWorldCupScoreBoard.Application;

public record TeamScore
{
    public Team Team { get; init; } = null!;
    public byte Score { get; private set; }

    private TeamScore() { }

    public void Increase()
    {
        checked
        {
            Score++;
        }
    }

    public override string ToString() => $"{Team} {Score}";

    public static TeamScore CreateFor(Team team) => new() { Team = team, Score = 0 };
}
