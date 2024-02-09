

namespace KarmaLympics2._1.Models
{
    public class Challenge
    {
        public int Id { get; set; }
        public string? ChallengeDescription { get; set; }
        public int MaxPoints { get; set; }
        public int OccasionId { get; set; }
        public Occasion Occasion { get; set; }
        public List<Team> Teams { get; set; }
        public List<TeamChallenge> TeamChallenges { get; set; }
    }
}
