namespace FootballWorldCupScoreBoard.Application;

public record Team
{
    public string Name { get; init; } = null!;

    private Team() { }

    public static Team Create(string name)
    {
        ArgumentException.ThrowIfNullOrEmpty(name);
        return new Team { Name = name };
    }
}
