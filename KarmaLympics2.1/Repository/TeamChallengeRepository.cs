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

        public IEnumerable<string> GetTeamAnswer(int teamId)
        {
            var allAnswers = _context.TeamsChallenges
               .Where(tc => tc.TeamId == teamId)
               .SelectMany(tc => new[] { tc.Answer, tc.PicturePath, tc.VideoPath })
               .Where(answer => !string.IsNullOrEmpty(answer));

            return allAnswers;
        }

        public TeamChallenge GetTeamChallenge(int teamId, int challengeId)
        {
            return _context.TeamsChallenges
                .Where(t =>t.TeamId == teamId && t.ChallengeId == challengeId)
                .FirstOrDefault();
        }

        public ICollection<TeamChallenge> GetTeamChallenges(int teamId)
        {
            throw new NotImplementedException();
        }

        public int GetTeamPointsEarned(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}

 

      