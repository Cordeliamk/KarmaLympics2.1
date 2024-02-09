namespace KarmaLympics2._1.Models
{
    public class TeamChallenge
    {
        public int TeamId { get; set; }
        public int ChallengeId { get; set; }
        public Team Team { get; set; }
        public Challenge Challenge { get; set; }
    }
}
