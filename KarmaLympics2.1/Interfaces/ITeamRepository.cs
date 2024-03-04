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

        Task<bool> CreateTeam(Team team);
        Task<bool> Save();
        Task<bool> UpdateTeam(Team team);
        Task<string> GenerateRandomCharacters();
        Task<string> GenerateUniqueTeamUrl(int occasionId, int teamId, string teamName);






    }
}
