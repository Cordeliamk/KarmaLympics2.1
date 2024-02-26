

namespace KarmaLympics2._1.Models
{
    public class Occasion
    {
        public int Id { get; set; }
        public string OccasionName { get; set; } = string.Empty;
        public string? OccasionDescription { get; set; }
        public string HostName { get; set; } = string.Empty;
        public string HostMail { get; set; } = string.Empty;
        public string? OccasionUrl { get; set; }

        //Refrence keys
        public List<Team> Teams { get; set; } = new List<Team>();
        public List<Challenge> Challenges { get; set; } = new List<Challenge>();
    }
}
