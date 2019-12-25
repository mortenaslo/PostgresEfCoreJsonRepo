using EfCoreJsonRepo.Models;

using Microsoft.EntityFrameworkCore;

namespace EfCoreJsonRepo.Data
{
    public class NiceDbContext : DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=NiceDatabase;Username=postgres;Password=password");
        }

    }
}
