using Microsoft.EntityFrameworkCore;
using SuperMarket.Models;

namespace SuperMarket.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Post> Posts { get; set; }

        public DbSet<Category> Categories { get; set; }
    }
}
