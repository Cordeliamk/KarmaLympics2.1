using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface ITeamRepository
    {
        ICollection<Team> GetTeams();

        Team GetTeam (int id);
        Team GetTeam (string teamName);
        Team GetTeamByUrl(string teamUrl);
        int GetTeamScore(int teamId);
        bool TeamExists(int teamId);



       






    }
}
