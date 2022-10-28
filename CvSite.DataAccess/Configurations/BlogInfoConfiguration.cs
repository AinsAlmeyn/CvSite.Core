using CvSite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CvSite.DataAccess.Configurations;

public class BlogInfoConfiguration : IEntityTypeConfiguration<BlogInfo>
{
    public void Configure(EntityTypeBuilder<BlogInfo> builder)
    {
        builder.HasKey(x => x.BlogInfoId);

        builder.Property(x => x.Image)
            .IsRequired();

        builder.Property(x => x.Title)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(x => x.Description)
            .IsRequired()
            .HasMaxLength(100);
    }
}