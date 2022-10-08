using Microsoft.EntityFrameworkCore;
using DataLayer.Models;
using DataLayer.ModelConfiguration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DataLayer
{
    public class AppDbContext : IdentityDbContext<User, AppRole, Guid>
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            base.OnModelCreating(builder);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
            
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<PostLike> PostLike { get; set; }
        public DbSet<CommentLike> CommentLike { get; set; }
        public DbSet<UserImage> UserImages { get; set; }
        public DbSet<PostImage> PostImages { get; set; }
    }
}
