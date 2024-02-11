using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface IKarmalympicsRepository
    {
        ICollection<Team> GetTeams();
    }
}
