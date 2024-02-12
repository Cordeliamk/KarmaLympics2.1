using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface IChallangeRepository
    {
        ICollection<Challenge> GetChallenges();
        Challenge GetChallenge(int id);
        int GetChallengePoint(int id);
    }
}
