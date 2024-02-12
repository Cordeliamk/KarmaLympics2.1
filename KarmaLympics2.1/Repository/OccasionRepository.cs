using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;

namespace KarmaLympics2._1.Repository
{
    public class OccasionRepository : IOccasionRepository
    {
        private readonly DataContext _context;
        public OccasionRepository(DataContext context) {
            _context = context;
        }
        public Occasion GetOccasion(int id)
        {
            return _context.Occasions.Where(o => o.Id == id).FirstOrDefault();
        }

        public Occasion GetOccasionByUrl(string occasionUrl)
        {
            return _context.Occasions.Where(o => o.OccasionUrl == occasionUrl).FirstOrDefault();
        }

        public string GetOccasionHostMail(int occasionId)
        {
            string hostMail = _context.Occasions
                .Where(o => o.Id == occasionId).Select(o => o.HostMail).FirstOrDefault();
            return hostMail;
        }

        public ICollection<Occasion> GetOccasions()
        {
            return _context.Occasions.OrderBy(o => o.Id).ToList();
        }

        public string GetOccasionUrl(int occasionId)
        {
            string occasionUrl = _context.Occasions
          .Where(o => o.Id == occasionId).Select(o => o.OccasionUrl).FirstOrDefault();
            return occasionUrl;
        }

        public bool OccasionExists(int occasionId)
        {
            return _context.Occasions.Any(o => o.Id == occasionId);
        }
    }
}
