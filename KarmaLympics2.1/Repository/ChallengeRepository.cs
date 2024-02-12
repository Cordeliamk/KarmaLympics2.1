using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Repository
{
    public class ChallengeRepository : IChallangeRepository
    {
        private readonly DataContext _context;

        public ChallengeRepository(DataContext context)
        {
            _context = context;
        }

        public Challenge GetChallenge(int id)
        {
            return _context.Challenges.Where(c => c.Id == id).FirstOrDefault();
        }

        public int GetChallengePoint(int id)
        {
            int challengePoints = _context.Challenges
                .Where(c => c.Id == id)
                .Select(c => c.Points)
                .FirstOrDefault();
            return challengePoints;
        }

        public ICollection<Challenge> GetChallenges()
        {
            return _context.Challenges.OrderBy(c => c.Id).ToList();  
        }
    }
}
