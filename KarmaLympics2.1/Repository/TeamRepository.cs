using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Repository
{
    public class TeamRepository :ITeamRepository
    {
        private readonly DataContext _context;
        public TeamRepository(DataContext context)
        {
            _context = context;
        }
        public Team GetTeam(int id)
        {
            return _context.Teams.Where(t => t.Id == id).FirstOrDefault();
        }

        public Team GetTeam(string teamName)
        {
            return _context.Teams.Where(t => t.TeamName == teamName).FirstOrDefault();
        }
        public Team GetTeamByUrl(string teamUrl)
        {
            return _context.Teams.Where(t => t.TeamUrl == teamUrl).FirstOrDefault();
        }
        public ICollection<Team> GetTeams()
        {
            return _context.Teams.OrderBy( t => t.Id).ToList(); 
        }
        public object GetTeamScore(int teamId)
        {
          Team team = _context.Teams
                .Include(t => t.TeamChallenges).FirstOrDefault(t => t.Id == teamId);

            if (team == null)
            {
                return " Team not found";
            }

            int teamScore = team.TeamChallenges.Sum(tc => tc.PointsEarned);
            return teamScore;
        }
        public bool teamExists(int teamId)
        {
          return _context.Teams.Any(t => t.Id ==  teamId);
        }

        int ITeamRepository.GetTeamScore(int teamId)
        {
            throw new NotImplementedException();
        }
    }
}
