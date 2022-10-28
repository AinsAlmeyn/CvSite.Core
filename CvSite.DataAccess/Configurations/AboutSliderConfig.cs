using CvSite.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CvSite.DataAccess.Configurations;

public class AboutSliderConfig : IEntityTypeConfiguration<AboutSlider>
{
    public void Configure(EntityTypeBuilder<AboutSlider> builder)
    {
        builder.HasKey(x => x.SliderId);

        builder.Property(x => x.SliderIcon)
            .IsRequired();

        builder.Property(x => x.SliderTitle)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(x => x.SliderShortDescription)
            .IsRequired()
            .HasMaxLength(120);
    }
}