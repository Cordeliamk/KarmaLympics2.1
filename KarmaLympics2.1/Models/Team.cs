
namespace KarmaLympics2._1.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string TeamUrl { get; set; }
        public int OccasionId { get; set; }

        //Reference Keys
        public Occasion Occasion { get; set; }
        public List<TeamChallenge> TeamChallenges { get; set; }
    }
}
