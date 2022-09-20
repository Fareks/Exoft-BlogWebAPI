using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfiguration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {

        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(x => x.CommentContent).IsRequired().HasMaxLength(150);
            builder.HasOne(x => x.User)
                .WithMany(u=> u.Comments)
                .HasForeignKey(x => x.UserId);
            builder.HasOne(x => x.Post)
                .WithMany(u => u.Comments)
                .HasForeignKey(x => x.PostId);
        }
    }
}
