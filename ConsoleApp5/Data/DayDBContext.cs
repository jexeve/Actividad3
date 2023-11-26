using Microsoft.EntityFrameworkCore;

namespace ConsoleApp5.Data
{
    public class DayDBContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=weather;User Id=root;",
                new MySqlServerVersion(new Version(8, 0, 25)),
                options => options.EnableRetryOnFailure());
        }

        public DbSet<Day> Days { get; set; }
    }
}