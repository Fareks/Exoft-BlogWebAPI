using Exoft_BlogWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exoft_BlogWebAPI.ModelConfiguration
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
        }
    }
}
