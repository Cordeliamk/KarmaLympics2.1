using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface ITeamChallengeRepository
    {
        ICollection<TeamChallenge> GetTeamChallenges(int teamId);
        TeamChallenge GetChallengeByTeam(int teamId, int challengeId);
        IEnumerable<string> GetTeamAnswer(int teamId);
        int GetTeamPointsEarned(int teamId);
    }
}
