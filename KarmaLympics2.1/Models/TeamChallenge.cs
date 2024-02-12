namespace KarmaLympics2._1.Models
{
    public class TeamChallenge
    {
        public int TeamId { get; set; }
        public int ChallengeId { get; set; }
        public Team Team { get; set; }
        public Challenge Challenge { get; set; }
        public string? Answer { get; set; }
        public string? PicturePath { get; set; } 
        public string? VideoPath { get; set; }
        public bool ApprovalStatus { get; set; }
        public int? PointsEarned { get; set; }
    }
}
