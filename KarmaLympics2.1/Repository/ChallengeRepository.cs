﻿using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Repository
{
    public class ChallengeRepository(DataContext context) : IChallengeRepository
    {
        private readonly DataContext _context = context;

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

        public bool ChallengeExists(int challengeId)
        {
            return _context.Challenges.Any(c => c.Id == challengeId);
        }
    }
}
