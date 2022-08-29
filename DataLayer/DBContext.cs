using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using DataLayer.ModelConfiguration;

namespace DataLayer
{
    public class DBContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            base.OnModelCreating(builder);
        }
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        { 
            
        }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<PostLike> PostLike { get; set; }

    }
}
