using ERoadPolice.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ERoadPolice.Infrastructure.DataAccess
{
    public class PoliceRoadDbContext : DbContext
    {

        public PoliceRoadDbContext()
        {

        }

        public PoliceRoadDbContext(DbContextOptions<PoliceRoadDbContext> options)
            : base(options)
        {

        }

        public DbSet<Role>Roles { get; set; }   
        public DbSet<Officer> Officers { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Incident> Incidents { get; set; }
    }
}
