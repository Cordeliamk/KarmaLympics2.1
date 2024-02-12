using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Interfaces
{
    public interface IOccasionRepository
    {
        ICollection<Occasion> GetOccasions();

        Occasion GetOccasion(int Id);
        Occasion GetOccasionByUrl(string OccasionUrl);
        string GetOccasionUrl(int Id);
        string GetOccasionHostMail(int occasionId);
        bool OccasionExists(int occasionId);

    }
}
