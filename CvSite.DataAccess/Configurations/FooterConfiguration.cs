using CvSite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CvSite.DataAccess.Configurations;

public class FooterConfiguration : IEntityTypeConfiguration<Footer>
{
    public void Configure(EntityTypeBuilder<Footer> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Instagram)
            .IsRequired(false);

        builder.Property(x => x.Linkedin)
            .IsRequired(false);
    }
}