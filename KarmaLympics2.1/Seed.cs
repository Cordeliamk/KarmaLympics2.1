using KarmaLympics2._1.Models;
using KarmaLympics2._1.Data;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1
{
    public class Seed
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<Seed> _logger;

        public Seed(DataContext dataContext, ILogger<Seed>logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }
        public void SeedDataContext()
        {
            try
            {
                _dataContext.Database.Migrate();
                _logger.LogInformation("Database migration succeeded.");
                _logger.LogInformation("Removing existing data...");
                _dataContext.RemoveRange(_dataContext.Occasions);
                _dataContext.SaveChanges();
                _logger.LogInformation("Existing data removed.");

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
                    Points = 24
                };

            TeamChallenge teamChallenge = new TeamChallenge
            {
                Team = redTeam,
                Challenge = challenge,
                PointsEarned = 24,
                ApprovalStatus = true
            };

                karmakarma.Teams = new List<Team> { redTeam };
                karmakarma.Challenges = new List<Challenge> { challenge };
                

               _dataContext.Occasions.AddRange(karmakarma);
                _dataContext.TeamsChallenges.AddRange(teamChallenge);
               _dataContext.SaveChanges();

                _logger.LogInformation("Seeding completed successfully.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred during seeding.");
                throw; // Rethrow the exception to stop the application startup
            }
        }
    }
}


