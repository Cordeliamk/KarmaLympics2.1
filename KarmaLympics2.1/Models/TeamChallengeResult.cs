namespace KarmaLympics2._1.Models
{
    public class TeamChallengeResult
    {
            public int Id { get; set; }

            // Foreign key properties
            public int TeamChallengeId { get; set; }

            // Navigation properties
            public TeamChallenge TeamChallenge { get; set; }

            // Additional properties
            public int PointsEarned { get; set; }
       
    }
}
