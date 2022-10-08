using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfiguration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.Comments)
                   .WithOne(c => c.User)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasMany(u => u.Post)
                   .WithOne(p => p.User)
                   .HasForeignKey(p => p.UserId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(u => u.UserImage)
                   .WithOne(i => i.User);
            builder.HasIndex(U => U.Email).IsUnique();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Email).HasMaxLength(40);
        }
    }
}
