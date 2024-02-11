using KarmaLympics2._1.Data;
using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Repository
{
    public class TeamRepository
    {
        private readonly DataContext _context;
        public TeamRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Team> GetTeams()
        {
            return _context.Teams.OrderBy( t => t.Id).ToList(); 
        }

    }
}
