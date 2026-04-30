using Marketplace.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace Marketplace.API.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}
