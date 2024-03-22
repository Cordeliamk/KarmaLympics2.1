using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface IChallengeRepository
    {
        Task<ICollection<Challenge>> GetChallenges();
        Task<Challenge> GetChallenge(int id);
        Task<int> GetChallengePoint(int id);

        Task<bool> ChallengeExists(int challengeId);

        Task<bool> CreateChallenge(Challenge challenge);

        Task<bool> UpdateChallenge(Challenge challenge);

        Task<bool> Save();
    }
}
