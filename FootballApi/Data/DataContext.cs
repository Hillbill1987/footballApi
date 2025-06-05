using FootballApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FootballApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FootballTeam>().HasData(
            new FootballTeam
            {
                Id = 1,
                Name = "Fc Cola",
                YearFounded = 1987,
                Country = "England",
                Manager = "Mr T"
            },
            new FootballTeam
            {
                Id = 2,
                Name = "RunTime Warriors",
                YearFounded = 1912,
                Country = "Nigeria",
                Manager = "Mr No"
            },
            new FootballTeam
            {
                Id = 3,
                Name = "Shavers head",
                YearFounded = 1956,
                Country = "Scotland",
                Manager = "Mr Yu"
            });

            modelBuilder.Entity<FootballPlayer>().HasData(
            new FootballPlayer
            {
                Id = 1,
                FirstName = "Dave",
                LastName = "test",
                Age = 25,
                Team = "Underwood"
            },
            new FootballPlayer
            {
                Id = 2,
                FirstName = "Roger",
                LastName = "Owens",
                Age = 35,
                Team = "Cola"
            },
            new FootballPlayer
            {
                Id = 3,
                FirstName = "Kello",
                LastName = "Dance",
                Age = 30,
                Team = "Water"
            });
        }

        public DbSet<FootballPlayer> players { get; set; }
        public DbSet<FootballTeam> teams { get; set; }
    }
}
