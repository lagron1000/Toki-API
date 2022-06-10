using Microsoft.EntityFrameworkCore;
using Toki_API.Models;

namespace Toki_API
{
    public class UserContext : DbContext
    {
        private const string connectionString = "server=localhost;post=3306;database=User;user=root;password=123";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(connectionString, MariaDbServerVersion.AutoDetect(connectionString));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(e => e.Id);
        }

        public DbSet<User>? Users { get; set; }
    }
}
