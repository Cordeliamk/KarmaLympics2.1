

namespace KarmaLympics2._1.Models
{
    public class Occasion
    {
        public int Id { get; set; }
        public string OccasionName { get; set; }
        public string? OccasionDescription { get; set; }
        public string HostName { get; set; }
        public string HostMail { get; set; }

        //Refrence keys
        public List<Team> Teams { get; set; }
        public List<Challenge> Challenges { get; set; }
    }
}
