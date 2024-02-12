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
                var karmakarma = new Occasion
                {
                    OccasionName = "Olala",
                    OccasionDescription = " Velkommen alle sammen",
                    HostName = "Cordelia",
                    HostMail = "Cordelia@test.no"

                };

                var redTeam = new Team
                {
                    TeamName = "RedTeam",
                    TeamUrl = "testurltest"
                };

                var challenge = new Challenge
                {
                    ChallengeDescription = "Take a picture with a cow",
                    MaxPoints = 24
                };

                karmakarma.Teams = new List<Team> { redTeam };
                karmakarma.Challenges = new List<Challenge> { challenge };

                dataContext.Occasions.Add(karmakarma);
                dataContext.SaveChanges();
        }
    }
}


