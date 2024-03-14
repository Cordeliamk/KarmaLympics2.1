using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Repository
{
    public class TeamChallengeRepository(DataContext context) : ITeamChallengeRepository
    {
        private readonly DataContext _context = context;

        public async Task<IEnumerable<string>> GetTeamAnswer(int teamId)
        {
            List<string?> allAnswers = await _context.TeamsChallenges
               .Where(tc => tc.TeamId == teamId)
               .SelectMany(tc => new[] { tc.Answer, tc.PicturePath, tc.VideoPath })
               .Where(answer => !string.IsNullOrEmpty(answer))
               .ToListAsync();

                return allAnswers.AsEnumerable();
        }

        public async Task<TeamChallenge> GetTeamChallenge(int teamId, int challengeId)
        {
            var teamChallenge = await _context.TeamsChallenges
            .FirstOrDefaultAsync(t => t.TeamId == teamId && t.ChallengeId == challengeId);

            return teamChallenge ?? throw new Exception($"TeamChallenge with TeamId {teamId} and ChallengeId {challengeId} not found.");
        }

    

        public async Task<ICollection<TeamChallenge>> GetTeamChallenges(int teamId)
        {
           return await _context.TeamsChallenges.OrderBy(tc => tc.TeamId).ToListAsync();
        }

        public async Task<int> GetTeamPointsEarned(int teamId, int challengeId)
        {
            int pointsEarned = await _context.TeamsChallenges
                .Where(tc => tc.TeamId == teamId && tc.ChallengeId == challengeId)
                .Select(tc => tc.PointsEarned)
                .FirstOrDefaultAsync();
            return pointsEarned;
        }



        public async Task<bool> AddAnswer(TeamChallenge teamChallenge)
        {

            await _context.TeamsChallenges.AddAsync(teamChallenge);
            return await Save();
        }

        public async Task<ICollection<TeamChallenge>> GetTeamChallengesByOccasionId(int occasionId)
        {
            return await _context.TeamsChallenges
                .Include(tc => tc.Team)
                .ThenInclude( t => t.Occasion)
                .Where(tc => tc.Team.OccasionId == occasionId)
                .OrderBy(tc => tc.TeamId)
                .ToListAsync();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}

 

      