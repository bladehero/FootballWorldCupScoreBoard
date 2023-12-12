using FootballWorldCupScoreBoard.Application.Matches;

namespace FootballWorldCupScoreBoard.Application.Scoring;

public interface ISummaryRecorder
{
    void SaveMatch(IMatch match);
}
