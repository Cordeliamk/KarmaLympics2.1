using KarmaLympics2._1.Data;
using KarmaLympics2._1.Interfaces;
using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace KarmaLympics2._1.Repository
{
    public class OccasionRepository(DataContext context) : IOccasionRepository
    {
        private readonly DataContext _context = context;

        public async Task<Occasion> GetOccasion(int id)
        {
            return await _context.Occasions.Where(o => o.Id == id).FirstAsync();
        }

        public async Task<Occasion> GetOccasionByUrl(string occasionUrl)
        {
            return await _context.Occasions.Where(o => o.OccasionUrl == occasionUrl).FirstAsync();
        }

        public async Task<string> GetOccasionHostMail(int occasionId)
        {
            string hostMail = await _context.Occasions
                .Where(o => o.Id == occasionId).Select(o => o.HostMail).FirstAsync();
            return hostMail;
        }



        public async Task<ICollection<Occasion>> GetOccasions()
        {
            return await _context.Occasions.OrderBy(o => o.Id).ToListAsync();
        }

        public async Task<string> GetOccasionUrl(int occasionId)
        {
           string? occasionUrl = await _context.Occasions
          .Where(o => o.Id == occasionId).Select(o => o.OccasionUrl).FirstAsync();
            if (string.IsNullOrEmpty(occasionUrl))
            {
                Console.WriteLine("No Url found");
            }
            return occasionUrl;
        }

        public async Task<bool> OccasionExists(int occasionId)
        {
            return await _context.Occasions.AnyAsync(o => o.Id == occasionId);
        }

        public Task<int> ExtractOccasionIdFromUrl(string occasionUrl)
        {
            int index = occasionUrl.IndexOf("/pow/");
            if (index != -1)
            {
                // Get the substring after "/occasion/" (which should contain the occasion ID)
                string substring = occasionUrl.Substring(index + "/pow/".Length);
                //Split the substring by'-' to seperate the occasion ID from other characters
                string[] parts = substring.Split('-');

                if (int.TryParse(parts[0], out int occasionID))
                {

                    return Task.FromResult (occasionID);
                }
            }
         
            throw new ArgumentException("Invalid Occasion URL");
        }

        public async Task<string> GenerateUniqueUrl(int occasionId, string occasionName)
        {
           
            string randomCharacters = await GenerateRandomCharacters();
            return $"\"https://localhost:5113\"/{occasionName}/pow/{occasionId}-{randomCharacters}";
        }
        public  Task<string> GenerateRandomCharacters()
        {
            const int length = 8;
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            Random random = new();
            char[] randomChars = new char[length];

            for (int i = 0; i < length; i++)
            {
                randomChars[i] = chars[random.Next(chars.Length)];
            }
            return Task.FromResult(new string(randomChars));
        }

        public async Task<bool> CreateOccasion(Occasion occasion)
        {
            
            await _context.Occasions.AddAsync(occasion);
            
            return await Save();


        }


        public async Task<bool> UpdateOccasion(Occasion occasion)
        {
          
               _context.Occasions.Update(occasion);

               return await Save();
        }

        public async Task<bool> Save()
        {
            return await _context.SaveChangesAsync() > 0;
        }


    }
}
