using System.Diagnostics.CodeAnalysis;

namespace FootballWorldCupScoreBoard.Persistence;

[ExcludeFromCodeCoverage(Justification = "Wrapping static functionality")]
public class GuidProvider : IGuidProvider
{
    public Guid NewGuid() => Guid.NewGuid();
}
