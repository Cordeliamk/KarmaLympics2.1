using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Repository
{
    public class ChallengeRepository(DataContext context) : IChallengeRepository
    {
        private readonly DataContext _context = context;

        public async Task<Challenge> GetChallenge(int id)
        {
            return await _context.Challenges.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> GetChallengePoint(int id)
        {
            int challengePoints = await _context.Challenges
                .Where(c => c.Id == id)
                .Select(c => c.Points)
                .FirstOrDefaultAsync();
            return challengePoints;
        }

        public async Task<ICollection<Challenge>> GetChallenges()
        {
            return await _context.Challenges.OrderBy(c => c.Id).ToListAsync();  
        }

        public async Task<bool> ChallengeExists(int challengeId)
        {
            return await _context.Challenges.AnyAsync(c => c.Id == challengeId);
        }
    }
}
