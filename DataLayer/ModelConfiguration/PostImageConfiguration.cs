using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataLayer.ModelConfiguration
{
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {

        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.HasOne(i => i.Post)
                  .WithOne(u => u.PostImage);
        }
    }
}
