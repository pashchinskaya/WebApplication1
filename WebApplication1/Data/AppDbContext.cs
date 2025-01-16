using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace WebApplication1.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Organizers> Organizers { get; set; }
        public DbSet<LocationEvent> LocationEvents { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Events> Events { get; set; }
        
    }
}
