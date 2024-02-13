using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface ITeamRepository
    {
       Task<ICollection<Team>> GetTeams();

        Task<Team> GetTeam (int id);
        Task<Team> GetTeam (string teamName);
        Task<Team> GetTeamByUrl(string teamUrl);
        Task<int> GetTeamScore(int teamId);
        Task<bool> TeamExists(int teamId);



       






    }
}
