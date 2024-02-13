using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface ITeamChallengeRepository
    {
        Task<ICollection<TeamChallenge>> GetTeamChallenges(int teamId);
        Task<TeamChallenge> GetTeamChallenge(int teamId, int challengeId);
        Task<IEnumerable<string>> GetTeamAnswer(int teamId);
        Task<int> GetTeamPointsEarned(int teamId, int challengeId);
    }
}
