using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Repository
{
    public class TeamRepository(DataContext context) : ITeamRepository
    {
        private readonly DataContext _context = context;

        public async Task<Team> GetTeam(int id)
        {
            return await _context.Teams.Where(t => t.Id == id).FirstAsync();
        }
         
        public async Task<Team> GetTeam(string teamName)
        {
            return await _context.Teams.Where(t => t.TeamName == teamName).FirstAsync();
        }
        public async Task<Team> GetTeamByUrl(string teamUrl)
        {
            return await _context.Teams.Where(t => t.TeamUrl == teamUrl).FirstAsync();
        }
        public async Task<ICollection<Team>> GetTeams()
        {
            return await _context.Teams.OrderBy( t => t.Id).ToListAsync(); 
        }

        //public object GetTeamScore(int teamId)
        //{
        //  Team team = _context.Teams
        //        .Include(t => t.TeamChallenges).FirstOrDefault(t => t.Id == teamId);

        //    if (team == null)
        //    {
        //        return " Team not found";
        //    }

        //    int teamScore = team.TeamChallenges.Sum(tc => tc.PointsEarned);
        //    return teamScore;
        //}

        public async Task<bool> TeamExists(int teamId)
        {
          return await _context.Teams.AnyAsync(t => t.Id ==  teamId);
        }

        public async Task<int> GetTeamScore(int teamId)
        {
               int teamScore = await _context.Teams
                .Where(t => t.Id == teamId)
                .Select(t => t.TeamScore)
                .FirstOrDefaultAsync();
            return teamScore;
        }

        public async Task<string> GetTeamUrl(int teamId)
        {
            string teamUrl = await _context.Teams
          .Where(t => t.Id == teamId).Select(t => t.TeamUrl).FirstOrDefaultAsync();
            return teamUrl;
        }

        public async Task<bool> CreateTeam(Team team)
        {
                await _context.Teams.AddAsync(team);
                return await Save();
        }

        public async Task<bool> Save()
        {
                return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<Team>> GetTeamsByOccasionId(int occasionId)
        {
            return await _context.Teams
                .Where(t => t.OccasionId == occasionId)
                .ToListAsync();
        }
    }
}
