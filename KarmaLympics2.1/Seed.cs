using KarmaLympics2._1.Models;
using KarmaLympics2._1.Data;

namespace KarmaLympics2._1
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void SeedDataContext()
        {
            if (!dataContext.TeamsChallenges.Any())
            {
                var teamChallenges = new List<TeamChallenge>()
                {

                    new TeamChallenge()
                    {
                        Team = new Team()
                        {
                            TeamName = "ReadTeam",
                            TeamUrl = "testurltest",
                            TeamChallenges = new List<TeamChallenge>()

                            {
                                new TeamChallenge { Challenge = new Challenge() { ChallengeDescription = " Take a picture with a cow" } }

                            },
                        }

                    }


                };

                dataContext.TeamsChallenges.AddRange(teamChallenges);
                dataContext.SaveChanges();
            }
        }
    }
}


