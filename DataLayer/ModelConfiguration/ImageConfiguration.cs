using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfiguration
{
    public class ImageConfiguration : IEntityTypeConfiguration<UserImage>
    {

        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder.HasOne(i => i.User)
                  .WithOne(u => u.UserImage);
        }
    }
}
