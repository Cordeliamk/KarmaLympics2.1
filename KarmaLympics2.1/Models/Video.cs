namespace KarmaLympics2._1.Models
{
    public class Video
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }
        public Challenge Challenge { get; set; }
    }
}
