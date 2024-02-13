using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Repository
{
    public class OccasionRepository(DataContext context) : IOccasionRepository
    {
        private readonly DataContext _context = context;

        public async Task<Occasion> GetOccasion(int id)
        {
            return await _context.Occasions.Where(o => o.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Occasion> GetOccasionByUrl(string occasionUrl)
        {
            return await _context.Occasions.Where(o => o.OccasionUrl == occasionUrl).FirstOrDefaultAsync();
        }

        public async Task<string> GetOccasionHostMail(int occasionId)
        {
            string hostMail = await _context.Occasions
                .Where(o => o.Id == occasionId).Select(o => o.HostMail).FirstOrDefaultAsync();
            return hostMail;
        }

        public async Task<ICollection<Occasion>> GetOccasions()
        {
            return await _context.Occasions.OrderBy(o => o.Id).ToListAsync();
        }

        public async Task<string> GetOccasionUrl(int occasionId)
        {
            string occasionUrl = await _context.Occasions
          .Where(o => o.Id == occasionId).Select(o => o.OccasionUrl).FirstOrDefaultAsync();
            return occasionUrl;
        }

        public async Task<bool> OccasionExists(int occasionId)
        {
            return await _context.Occasions.AnyAsync(o => o.Id == occasionId);
        }
    }
}
