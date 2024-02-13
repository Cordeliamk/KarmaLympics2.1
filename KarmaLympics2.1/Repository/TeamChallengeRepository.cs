using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace KarmaLympics2._1.Repository
{
    public class TeamChallengeRepository(DataContext context) : ITeamChallengeRepository
    {
        private readonly DataContext _context = context;

        public IEnumerable<string> GetTeamAnswer(int teamId)
        {
            var allAnswers = _context.TeamsChallenges
               .Where(tc => tc.TeamId == teamId)
               .SelectMany(tc => new[] { tc.Answer, tc.PicturePath, tc.VideoPath })
               .Where(answer => !string.IsNullOrEmpty(answer));
           
            
                return allAnswers;
            
        }

        public TeamChallenge GetChallengeByTeam(int teamId, int challengeId)
        {
            var teamChallenge = _context.TeamsChallenges
            .FirstOrDefault(t => t.TeamId == teamId && t.ChallengeId == challengeId);

            return teamChallenge ?? throw new Exception($"TeamChallenge with TeamId {teamId} and ChallengeId {challengeId} not found.");
        }

        public ICollection<TeamChallenge> GetTeamChallenges(int teamId)
        {
           return _context.TeamsChallenges.OrderBy(tc => tc.TeamId).ToList();
        }

        public int GetTeamPointsEarned(int teamId)
        {
            int pointsEarned = _context.TeamsChallenges
                .Where(tc => tc.TeamId == teamId)
                .Select(tc => tc.PointsEarned)
                .FirstOrDefault();
            return pointsEarned;
        }
    }
}

 

      