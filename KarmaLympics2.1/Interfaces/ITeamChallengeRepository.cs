using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface ITeamChallengeRepository
    {
        ICollection<TeamChallenge> GetTeamChallenges();
        TeamChallenge GetTeamChallenge(int id);
        TeamChallenge GetTeamAnwser();
        TeamChallenge GetTeamPointsEarned(int id);
    }
}
