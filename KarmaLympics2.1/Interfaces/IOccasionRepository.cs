using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Interfaces
{
    public interface IOccasionRepository
    {
        Task<ICollection<Occasion>> GetOccasions();
        Task<Occasion> GetOccasion(int Id);
        Task<Occasion> GetOccasionByUrl(string OccasionUrl);
        Task<string> GetOccasionUrl(int Id);
        Task<string> GetOccasionHostMail(int occasionId);
        Task<bool> OccasionExists(int occasionId);
        Task<int> ExtractOccasionIdFromUrl(string occasionUrl);
        Task<string> GenerateRandomCharacters();
        Task<string> GenerateUniqueUrl(int occasionId, string occasionName);
        Task<bool> CreateOccasion(Occasion occasion);
        Task<bool> Save();
    }
}
