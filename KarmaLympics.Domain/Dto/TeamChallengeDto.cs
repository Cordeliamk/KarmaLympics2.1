namespace KarmaLympics2._1.Dto
{
    public class TeamChallengeDto
    {
        public int TeamId { get; set; }
        public int ChallengeId { get; set; }
        public bool ApprovalStatus { get; set; }
        public string? Answer { get; set; }
        public string? PicturePath { get; set; }
        public string? VideoPath { get; set; }
        public int? PointsEarned { get; set; }
    }
}
