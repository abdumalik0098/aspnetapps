using Microsoft.EntityFrameworkCore;

namespace HabbitApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Habbit> Habbits { get; set; } = null;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
            Database.EnsureCreated();
        }
    }
}
