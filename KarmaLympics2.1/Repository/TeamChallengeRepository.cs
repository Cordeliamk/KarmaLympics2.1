using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Repository
{
    public class TeamChallengeRepository : ITeamChallengeRepository
    {
        private readonly DataContext _context;
        public TeamChallengeRepository(DataContext context)
        {
            _context = context;
        }
        public TeamChallenge GetTeamAnwser()
        {
            var allAnwsers = _context.TeamsChallenges
         .SelectMany(tc => new[] { tc.Answer, tc.PicturePath, tc.VideoPath })
         .Where(answer => !string.IsNullOrEmpty(answer));
            return (TeamChallenge) allAnwsers;
        }

        public TeamChallenge GetTeamChallenge(int id)
        {
            throw new NotImplementedException();
        }

        public ICollection<TeamChallenge> GetTeamChallenges()
        {
            throw new NotImplementedException();
        }

        public TeamChallenge GetTeamPointsEarned(int id)
        {
            throw new NotImplementedException();
        }
    }
}
