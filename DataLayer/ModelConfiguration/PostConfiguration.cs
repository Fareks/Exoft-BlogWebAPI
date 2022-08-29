using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfiguration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {

        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.HasMany(p => p.PostLikes)
                   .WithOne(pl => pl.Post)
                   .HasForeignKey(pl => pl.Post.Id)
                   .OnDelete(DeleteBehavior.Restrict);
            builder.HasMany(p => p.Comments)
                   .WithOne(c => c.Post)
                   .HasForeignKey(pl => pl.Post.Id)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
