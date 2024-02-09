using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;

namespace KarmaLympics2._1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options): base(options) 
        {
            
        }

        public DbSet<Challenge> Challenges {  get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Occasion> Occasions { get; set;  }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamChallenge> TeamsChallenges { get; set;}
        public DbSet<Video> Videos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .HasMany(e => e.Challenges)
                .WithMany(e => e.Teams)
                .UsingEntity<TeamChallenge>( e =>
            {
                e.HasOne(tc => tc.Team)
                    .WithMany()
                    .OnDelete(DeleteBehavior.Cascade); // Cascade delete when Team is deleted
            });

        }






    }
}
