using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface ITeamRepository
    {
        ICollection<Team> GetTeams();

    }
}
