﻿namespace FootballWorldCupScoreBoard.Application;

public record Team
{
    public string Name { get; init; }

    private Team() { }

    public static Team Create(string name) => new() { Name = name };
}
