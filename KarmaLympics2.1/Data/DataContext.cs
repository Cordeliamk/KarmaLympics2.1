using KarmaLympics2._1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;

namespace KarmaLympics2._1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Challenge> Challenges { get; set; }

        public DbSet<Occasion> Occasions { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamChallenge> TeamsChallenges { get; set; }
        public DbSet<TeamChallengeResult> TeamChallengeResults { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
            @"Server = (localdb)\MSSQLLocalDB; " +
            "Database = EFKarmalympics; " +
            "Trusted_Connection = True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamChallenge>()
                .HasKey(tc => new { tc.TeamId, tc.ChallengeId });
            modelBuilder.Entity<TeamChallenge>()
                .HasOne(t => t.Team)
                .WithMany(tc => tc.TeamChallenges)
                .HasForeignKey(t => t.TeamId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<TeamChallenge>()
                .HasOne(t => t.Challenge)
                .WithMany(tc => tc.TeamChallenges)
                .HasForeignKey(c => c.ChallengeId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Challenge>()
                .HasOne(c => c.Occasion)
                .WithMany(o => o.Challenges)
                .HasForeignKey(c => c.OccasionId)
                .IsRequired();

            modelBuilder.Entity<Occasion>()
                .HasMany(e => e.Teams)
                .WithOne(e => e.Occasion)
                .HasForeignKey(e => e.OccasionId)
                .IsRequired();
        }
    }
}

